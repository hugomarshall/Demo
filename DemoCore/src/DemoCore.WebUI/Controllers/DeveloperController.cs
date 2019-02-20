using System;
using DemoCore.Application.Interfaces;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoCore.WebUI.Controllers
{
    [Authorize]
    public class DeveloperController : BaseController
    {
        private readonly IDeveloperService developerService;

        public DeveloperController(INotificationHandler<DomainNotification> notifications, IDeveloperService developerService) : base(notifications)
        {
            this.developerService = developerService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("developer-management/list-all")]
        public IActionResult Index()
        {
            return View(developerService.GetAll());
        }

        [HttpGet]
        [Authorize(Policy = "CanReadDeveloperData")]
        [Route("developer-management/developer-details/{id:int}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bwtVM = developerService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteDeveloperData")]
        [Route("developer-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteDeveloperData")]
        [Route("developer-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DeveloperVM request)
        {
            if (!ModelState.IsValid) return View(request);
            developerService.Register(request);

            if (IsValidOperation())
                ViewBag.Sucesso = "Developer Registered!";

            return View(request);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteDeveloperData")]
        [Route("developer-management/edit-developer/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bwtVM = developerService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteDeveloperData")]
        [Route("developer-management/edit-developer/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DeveloperVM request)
        {
            if (!ModelState.IsValid) return View(request);

            developerService.Update(request);

            if (IsValidOperation())
                ViewBag.Sucesso = "Developer Updated!";

            return View(request);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveDeveloperData")]
        [Route("developer-management/remove-developer/{id:int}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bwtVM = developerService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveDeveloperData")]
        [Route("developer-management/remove-developer/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            developerService.Remove(id);

            if (!IsValidOperation()) return View(developerService.GetById(id));

            ViewBag.Sucesso = "Developer Removed!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("developer-management/developer-history/{id:guid}")]
        public JsonResult History(Guid id)
        {
            //var customerHistoryData = developerService.GetAllHistory(id);
            //return Json(customerHistoryData);
            return Json(null);
        }
    }
}