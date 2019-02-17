using DemoCore.Application.Interfaces;
using DemoCore.Application.ViewModels;
using DemoCore.Domain.Core.Bus;
using DemoCore.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoCore.WebAPI.Controllers
{
    //[Authorize]
    public class DeveloperController : ApiController
    {
        private readonly IDeveloperService _developerService;
        public DeveloperController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, IDeveloperService developerService) : base(notifications, mediator)
        {
            _developerService = developerService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("developer-management")]
        public IActionResult Get()
        {
            return Response(_developerService.GetAll());
        }

        [HttpGet]
        [Authorize(Policy = "CanReadDeveloperData")]
        [Route("developer-management/{id:int}")]
        public IActionResult Get(int id)
        {
            var customerViewModel = _developerService.GetById(id);

            return Response(customerViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteDeveloperData")]
        [Route("developer-management")]
        public IActionResult Post([FromBody]DeveloperVM request)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(request);
            }

            _developerService.Register(request);

            return Response(request);
        }

        [HttpPut]
        [Authorize(Policy = "CanWriteDeveloperData")]
        [Route("developer-management")]
        public IActionResult Put([FromBody]DeveloperVM request)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(request);
            }

            _developerService.Update(request);

            return Response(request);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveDeveloperData")]
        [Route("developer-management")]
        public IActionResult Delete(int id)
        {
            _developerService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("developer-management/history/{id:int}")]
        public IActionResult History(int id)
        {
            //TODO: Implement History
            var customerHistoryData = _developerService.GetById(id);
            return Response(customerHistoryData);
        }
    }
}