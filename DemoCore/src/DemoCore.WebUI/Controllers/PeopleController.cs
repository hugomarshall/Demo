using DemoCore.Application.Interfaces;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoCore.WebUI.Controllers
{
    [Authorize]
    public class PeopleController : BaseController
    {
        private readonly IPeopleService peopleService;

        public PeopleController(INotificationHandler<DomainNotification> notifications, IPeopleService peopleService) : base(notifications)
        {
            this.peopleService = peopleService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("people-management/list-all")]
        public IActionResult Index()
        {
            return View(peopleService.GetAll());
        }

        [HttpGet]
        [Authorize(Policy = "CanReadPeopleData")]
        [Route("people-management/people-details/{id:int}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bwtVM = peopleService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpGet]
        [Authorize(Policy = "CanWritePeopleData")]
        [Route("people-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWritePeopleData")]
        [Route("people-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PeopleVM request)
        {
            if (!ModelState.IsValid) return View(request);
            peopleService.Register(request);

            if (IsValidOperation())
                ViewBag.Sucesso = "People Registered!";

            return View(request);
        }

        [HttpGet]
        [Authorize(Policy = "CanWritePeopleData")]
        [Route("people-management/edit-people/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bwtVM = peopleService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpPost]
        [Authorize(Policy = "CanWritePeopleData")]
        [Route("people-management/edit-people/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PeopleVM request)
        {
            if (!ModelState.IsValid) return View(request);

            peopleService.Update(request);

            if (IsValidOperation())
                ViewBag.Sucesso = "People Updated!";

            return View(request);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemovePeopleData")]
        [Route("people-management/remove-people/{id:int}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bwtVM = peopleService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemovePeopleData")]
        [Route("people-management/remove-people/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            peopleService.Remove(id);

            if (!IsValidOperation()) return View(peopleService.GetById(id));

            ViewBag.Sucesso = "People Removed!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("people-management/people-history/{id:int}")]
        public JsonResult History(int id)
        {
            //var customerHistoryData = peopleService.GetAllHistory(id);
            //return Json(customerHistoryData);
            return Json(null);
        }
    }
}