using DemoCore.Application.Interfaces;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoCore.WebUI.Controllers
{
    public class CandidateController : BaseController
    {
        private readonly IPeopleService peopleService;

        public CandidateController(INotificationHandler<DomainNotification> notifications,
                IPeopleService peopleService) : base(notifications)
        {
            this.peopleService = peopleService;
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCandidateData")]
        [Route("candidate-management/register-new")]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }

            var people = peopleService.GetByEmail(User.Identity.Name);

            if (people == null) return View();

            if (people.Occupation == null) return RedirectToAction("Occupation");

            return View("Progress", people);
            //return RedirectToAction("Create", "People", null);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCandidateData")]
        [Route("candidate-management/candidate-progress")]
        public IActionResult Progress(PeopleVM people)
        {
            return View(people);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCandidateData")]
        [Route("candidate-management/register-occupation/{id:int}")]
        public IActionResult Occupation(PeopleVM people)
        {
            return View(people);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCandidateData")]
        [Route("candidate-management/register-occupation/{id:int}")]
        public IActionResult RegisterOccupation(PeopleVM people)
        {
            return View();
        }

    }
}