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
    public class DesignerController : BaseController
    {
        private readonly IDesignerService designerService;

        public DesignerController(INotificationHandler<DomainNotification> notifications, IDesignerService designerService) : base(notifications)
        {
            this.designerService = designerService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("designer-management/list-all")]
        public IActionResult Index()
        {
            return View(designerService.GetAll());
        }

        [HttpGet]
        [Authorize(Policy = "CanReadDesignerData")]
        [Route("designer-management/designer-details/{id:int}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bwtVM = designerService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteDesignerData")]
        [Route("designer-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteDesignerData")]
        [Route("designer-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DesignerVM request)
        {
            if (!ModelState.IsValid) return View(request);
            designerService.Register(request);

            if (IsValidOperation())
                ViewBag.Sucesso = "Best Work Time Registered!";

            return View(request);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteDesignerData")]
        [Route("designer-management/edit-designer/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bwtVM = designerService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteDesignerData")]
        [Route("designer-management/edit-designer/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DesignerVM request)
        {
            if (!ModelState.IsValid) return View(request);

            designerService.Update(request);

            if (IsValidOperation())
                ViewBag.Sucesso = "Best Work Time Updated!";

            return View(request);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveDesignerData")]
        [Route("designer-management/remove-designer/{id:int}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bwtVM = designerService.GetById(id.Value);

            if (bwtVM == null)
            {
                return NotFound();
            }

            return View(bwtVM);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveDesignerData")]
        [Route("designer-management/remove-designer/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            designerService.Remove(id);

            if (!IsValidOperation()) return View(designerService.GetById(id));

            ViewBag.Sucesso = "Best Work Time Removed!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("designer-management/designer-history/{id:guid}")]
        public JsonResult History(Guid id)
        {
            //var customerHistoryData = designerService.GetAllHistory(id);
            //return Json(customerHistoryData);
            return Json(null);
        }
    }
}