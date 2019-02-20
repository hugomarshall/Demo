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
    public class BestWorkTimeController : BaseController
    {
        private readonly IBestWorkTimeService bwtService;

        public BestWorkTimeController(INotificationHandler<DomainNotification> notifications,
            IBestWorkTimeService bwtService) : base(notifications)
        {
            this.bwtService = bwtService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("bestworktime-management/list-all")]
        public IActionResult Index()
        {
            return View(bwtService.GetAll());
        }

        [HttpGet]
        [Authorize(Policy = "CanReadBestWorkTimeData")]
        [Route("bestworktime-management/bestworktime-details/{id:int}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var bwtVM = bwtService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteBestWorkTimeData")]
        [Route("bestworktime-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteBestWorkTimeData")]
        [Route("bestworktime-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BestWorkTimeVM request)
        {
            if (!ModelState.IsValid) return View(request);
            bwtService.Register(request);

            if (IsValidOperation())
                ViewBag.Sucesso = "Best Work Time Registered!";

            return View(request);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteBestWorkTimeData")]
        [Route("bestworktime-management/edit-bestworktime/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bwtVM = bwtService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteBestWorkTimeData")]
        [Route("bestworktime-management/edit-bestworktime/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BestWorkTimeVM request)
        {
            if (!ModelState.IsValid) return View(request);

            bwtService.Update(request);

            if (IsValidOperation())
                ViewBag.Sucesso = "Best Work Time Updated!";

            return View(request);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveBestWorkTimeData")]
        [Route("bestworktime-management/remove-bestworktime/{id:int}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bwtVM = bwtService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveBestWorkTimeData")]
        [Route("bestworktime-management/remove-bestworktime/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bwtService.Remove(id);

            if (!IsValidOperation()) return View(bwtService.GetById(id));

            ViewBag.Sucesso = "Best Work Time Removed!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("bestworktime-management/bestworktime-history/{id:int}")]
        public JsonResult History(Guid id)
        {
            //var customerHistoryData = bwtService.GetAllHistory(id);
            //return Json(customerHistoryData);
            return Json(null);
        }
    }
}