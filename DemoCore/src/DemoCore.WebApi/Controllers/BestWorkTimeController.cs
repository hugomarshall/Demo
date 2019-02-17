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
    public class BestWorkTimeController : ApiController
    {
        private readonly IBestWorkTimeService bestWorkService;

        public BestWorkTimeController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator
            ,IBestWorkTimeService bestWorkService) : base(notifications, mediator)
        {
            this.bestWorkService = bestWorkService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("bestworktime-management")]
        public IActionResult Get()
        {
            return Response(bestWorkService.GetAll());
        }

        [HttpGet]
        [Authorize(Policy = "CanReadBestWorkTimeData")]
        [Route("bestworktime-management/{id:int}")]
        public IActionResult Get(int id)
        {
            var customerViewModel = bestWorkService.GetById(id);

            return Response(customerViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteBestWorkTimeData")]
        [Route("bestworktime-management")]
        public IActionResult Post([FromBody]BestWorkTimeVM request)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(request);
            }

            bestWorkService.Register(request);

            return Response(request);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteBestWorkTimeData")]
        [Route("bestworktime-management")]
        public IActionResult Put([FromBody]BestWorkTimeVM request)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(request);
            }

            bestWorkService.Update(request);

            return Response(request);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveBestWorkTimeData")]
        [Route("bestworktime-management")]
        public IActionResult Delete(int id)
        {
            bestWorkService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("bestworktime-management/history/{id:int}")]
        public IActionResult History(int id)
        {
            //TODO: Implement History
            var customerHistoryData = bestWorkService.GetById(id);
            return Response(customerHistoryData);
        }
    }
}