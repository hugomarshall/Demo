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
    public class WorkAvailabilityController : BaseController
    {
        private readonly IWorkAvailabilityService waService;

        public WorkAvailabilityController(IWorkAvailabilityService waService,  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.waService = waService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("workavailability-management/list-all")]
        public IActionResult Index()
        {
            return View(waService.GetAll());
        }

        [HttpGet]
        [Authorize(Policy = "CanReadWorkAvailabilityData")]
        [Route("workavailability-management/workavailability-details/{id:int}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bwtVM = waService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteWorkAvailabilityData")]
        [Route("workavailability-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteWorkAvailabilityData")]
        [Route("workavailability-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WorkAvailabilityVM request)
        {
            if (!ModelState.IsValid) return View(request);
            waService.Register(request);

            if (IsValidOperation())
                ViewBag.Sucesso = "Best Work Time Registered!";

            return View(request);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteWorkAvailabilityData")]
        [Route("workavailability-management/edit-workavailability/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bwtVM = waService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteWorkAvailabilityData")]
        [Route("workavailability-management/edit-workavailability/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WorkAvailabilityVM request)
        {
            if (!ModelState.IsValid) return View(request);

            waService.Update(request);

            if (IsValidOperation())
                ViewBag.Sucesso = "Best Work Time Updated!";

            return View(request);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveWorkAvailabilityData")]
        [Route("workavailability-management/remove-workavailability/{id:int}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bwtVM = waService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveWorkAvailabilityData")]
        [Route("workavailability-management/remove-workavailability/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            waService.Remove(id);

            if (!IsValidOperation()) return View(waService.GetById(id));

            ViewBag.Sucesso = "Best Work Time Removed!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("workavailability-management/workavailability-history/{id:guid}")]
        public JsonResult History(Guid id)
        {
            //var workavailabilityHistoryData = waService.GetAllHistory(id);
            //return Json(workavailabilityHistoryData);
            return Json(null);
        }
    }
}