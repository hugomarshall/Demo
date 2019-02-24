using DemoCore.Application.Interfaces;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.WebUI.Controllers
{
    public class CandidateController : BaseController
    {
        private readonly IPeopleService peopleService;
        private readonly IBestWorkTimeService bwtService;
        private readonly IWorkAvailabilityService waService;
        private readonly IOccupationService occupationService;
        private readonly IDesignerService designerService;
        private readonly IDeveloperService developerService;
        private readonly IKnowledgeService knowledgeService;

        public CandidateController(INotificationHandler<DomainNotification> notifications,
                IPeopleService peopleService, IBestWorkTimeService bwtService,
                IOccupationService occupationService, IWorkAvailabilityService waService,
                IDesignerService designerService, IDeveloperService developerService,
                IKnowledgeService knowledgeService) : base(notifications)
        {
            this.peopleService = peopleService;
            this.bwtService = bwtService;
            this.waService = waService;
            this.occupationService = occupationService;
            this.designerService = designerService;
            this.developerService = developerService;
            this.knowledgeService = knowledgeService;
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCandidateData")]
        [Route("candidate/register-new")]
        public async Task<IActionResult> IndexAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }

            var people = await peopleService.GetByEmailAsync(User.Identity.Name);

            if (people == null) return View();

            if (people.Occupation == null)
            {
                return RedirectToActionPermanent("Occupation", "Candidate");
            }

            if(people.Knowledge == null)
            {
                return RedirectToActionPermanent("Knowledge", "Candidate");
            }

            return View("Progress", people);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCandidateData")]
        [Route("candidate/candidate-progress/")]
        public async Task<IActionResult> ProgressAsync()
        {
            var people = await peopleService.GetByEmailAsync(User.Identity.Name);
            return View("Progress", people);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCandidateData")]
        [Route("candidate/register-occupation/")]
        public async Task<IActionResult> OccupationAsync()
        {
            var people = await peopleService.GetByEmailAsync(User.Identity.Name);
            if (people.Occupation == null)
            {
                people.Occupation = new OccupationVM()
                {
                    Id = 0,
                    People = people,
                    PeopleId = people.Id,
                    EntityState = EntityStateOptions.Active

                };
            }

            //if(people.Knowledge == null)
            //{
            //    people.Knowledge = new KnowledgeVM()
            //    {
            //        Id = 0,
            //        People = people,
            //        PeopleId = people.Id,
            //        EntityState = EntityStateOptions.Active
            //    };
            //}

            PopulateAssignedWAData(people.Occupation);
            PopulateAssignedBTData(people.Occupation);

            return View("Occupation", people.Occupation);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCandidateData")]
        [Route("candidate/register-occupation/")]
        public async Task<IActionResult> OccupationAsync([Bind("People, PeopleId, WorkAvailabilities, BestWorkTimes, Id")]OccupationVM request, string[] selectWA, string[] selectBT)
        {
            occupationService.UpdateOccupationBestWorkTime(selectBT, request);
            occupationService.UpdateOccupationWorkAvailability(selectWA, request);

            var people = await peopleService.GetByEmailAsync(User.Identity.Name);
            people.Occupation = request;
            peopleService.Update(people);

            PopulateAssignedWAData(people.Occupation);
            PopulateAssignedBTData(people.Occupation);

            return RedirectToAction("OccupationAsync", people.Id);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCandidateData")]
        [Route("candidate/register-knowledge/")]
        public async Task<IActionResult> KnowledgeAsync()
        {
            var people = await peopleService.GetByEmailAsync(User.Identity.Name);

            if (people.Knowledge == null)
            {
                people.Knowledge = new KnowledgeVM()
                {
                    Id = 0,
                    People = people,
                    PeopleId = people.Id,
                    EntityState = EntityStateOptions.Active,
                    KnowledgeDesigner = new List<KnowledgeDesignerVM>(),
                    KnowledgeDeveloper = new List<KnowledgeDeveloperVM>()
                };
            }

            PopulateAssignedDeveloperData(people.Knowledge);
            PopulateAssignedDesignerData(people.Knowledge);

            return View("Knowledge", people.Knowledge);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCandidateData")]
        [Route("candidate/register-knowledge/")]
        public async Task<IActionResult> KnowledgeAsync([Bind("People, PeopleId, KnowledgeDesigner, KnowledgeDeveloper, Id")]KnowledgeVM request, string[] selectDeveloper, string[] selectDesigner)
        {
            knowledgeService.UpdateKnowledgeDesigner(selectDesigner, request);
            knowledgeService.UpdateKnowledgeDeveloper(selectDeveloper, request);

            var people = await peopleService.GetByEmailAsync(User.Identity.Name);

            people.Knowledge = request;
            knowledgeService.Register(request);

            PopulateAssignedDeveloperData(people.Knowledge);
            PopulateAssignedDesignerData(people.Knowledge);

            return RedirectToAction("KnowledgeAsync", people.Id);
        }

        private void PopulateAssignedDeveloperData(KnowledgeVM knowledge)
        {
            var all = developerService.GetAll();
            var knowledgeDev = new HashSet<int>(knowledge.KnowledgeDeveloper.Select(c => c.DeveloperId));
            var viewModel = new List<SelectedItemWithValue>();
            foreach (var item in all)
            {
                viewModel.Add(new SelectedItemWithValue("selectDeveloper")
                {
                    Id = item.Id,
                    DescriptionEN = item.DescriptionEN,
                    DescriptionPT = item.DescriptionPT,
                    Value = "1"
                });
            }

            ViewData["Developer"] = viewModel;
        }

        private void PopulateAssignedDesignerData(KnowledgeVM knowledge)
        {
            var all = designerService.GetAll();
            var knowledgeDes = new HashSet<int>(knowledge.KnowledgeDesigner.Select(c => c.DesignerId));
            var viewModel = new List<SelectedItemWithValue>();
            foreach (var item in all)
            {
                viewModel.Add(new SelectedItemWithValue("selectDesigner")
                {
                    Id = item.Id,
                    DescriptionEN = item.DescriptionEN,
                    DescriptionPT = item.DescriptionPT,
                    Value = "1"
                });
            }

            ViewData["Designer"] = viewModel;
        }


        private void PopulateAssignedWAData(OccupationVM occupation)
        {
            var all = waService.GetAll();
            var occupationWA = new HashSet<int>(occupation.WorkAvailabilities.Select(c => c.WorkAvailabilityId));
            var viewModel = new List<SelectedItems>();
            foreach (var item in all)
            {
                viewModel.Add(new SelectedItems
                {
                    Id = item.Id,
                    DescriptionEN = item.DescriptionEN,
                    DescriptionPT = item.DescriptionPT,
                    Assigned = occupationWA.Contains(item.Id)
                });
            }

            ViewData["WorkAvailabilities"] = viewModel;
        }

        private void PopulateAssignedBTData(OccupationVM occupation)
        {
            var all = bwtService.GetAll();
            var occupationWA = new HashSet<int>(occupation.BestWorkTimes.Select(c => c.BestWorkTimeId));
            var viewModel = new List<SelectedItems>();
            foreach (var item in all)
            {
                viewModel.Add(new SelectedItems
                {
                    Id = item.Id,
                    DescriptionEN = item.DescriptionEN,
                    DescriptionPT = item.DescriptionPT,
                    Assigned = occupationWA.Contains(item.Id)
                });
            }

            ViewData["BestWorkTimes"] = viewModel;
        }

        private void PopulateAssignedKnowledgeDeveloperData(KnowledgeVM knowledge)
        {
            var all = developerService.GetAll();
            var knowledgeDev = new HashSet<int>(knowledge.KnowledgeDeveloper.Select(c => c.DeveloperId));
            var viewModel = new List<SelectedItems>();
            foreach (var item in all)
            {
                viewModel.Add(new SelectedItems
                {
                    Id = item.Id,
                    DescriptionEN = item.DescriptionEN,
                    DescriptionPT = item.DescriptionPT,
                    Assigned = knowledgeDev.Contains(item.Id)
                });
            }

            ViewData["Developers"] = viewModel;
        }

        private void PopulateAssignedKnowledgeDesignerData(KnowledgeVM knowledge)
        {
            var all = designerService.GetAll();
            var knowledgeDes = new HashSet<int>(knowledge.KnowledgeDesigner.Select(c => c.DesignerId));
            var viewModel = new List<SelectedItems>();
            foreach (var item in all)
            {
                viewModel.Add(new SelectedItems
                {
                    Id = item.Id,
                    DescriptionEN = item.DescriptionEN,
                    DescriptionPT = item.DescriptionPT,
                    Assigned = knowledgeDes.Contains(item.Id)
                });
            }

            ViewData["Designers"] = viewModel;
        }

    }
}