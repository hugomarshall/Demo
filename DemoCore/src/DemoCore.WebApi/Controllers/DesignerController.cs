using DemoCore.Application.Interfaces;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Core.Bus;
using DemoCore.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoCore.WebAPI.Controllers
{
    [Authorize]
    public class DesignerController : ApiController
    {
        private readonly IDesignerService designerService;

        public DesignerController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator
                    ,IDesignerService designerService) : base(notifications, mediator)
        {
            this.designerService = designerService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("designer-management")]
        public IActionResult Get()
        {
            return Response(designerService.GetAll());
        }

        [HttpGet]
        [Authorize(Policy = "CanReadDesignerData")]
        [Route("designer-management/{id:int}")]
        public IActionResult Get(int id)
        {
            var customerViewModel = designerService.GetById(id);

            return Response(customerViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteDesignerData")]
        [Route("designer-management")]
        public IActionResult Post([FromBody]DesignerVM request)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(request);
            }

            designerService.Register(request);

            return Response(request);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteDesignerData")]
        [Route("designer-management")]
        public IActionResult Put([FromBody]DesignerVM request)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(request);
            }

            designerService.Update(request);

            return Response(request);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveDesignerData")]
        [Route("designer-management")]
        public IActionResult Delete(int id)
        {
            designerService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("designer-management/history/{id:int}")]
        public IActionResult History(int id)
        {
            //TODO: Implement History
            var customerHistoryData = designerService.GetById(id);
            return Response(customerHistoryData);
        }
    }
}