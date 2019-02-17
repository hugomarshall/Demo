using System;
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
    public class PeopleController : ApiController
    {
        private readonly IPeopleService _peopleService;
        public PeopleController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, IPeopleService peopleService) : base(notifications, mediator)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("people-management")]
        public IActionResult Get()
        {
            return Response(_peopleService.GetAll());
        }

        [HttpGet]
        [Authorize(Policy = "CanReadPeopleData")]
        [Route("people-management/{id:int}")]
        public IActionResult Get(int id)
        {
            var customerViewModel = _peopleService.GetById(id);

            return Response(customerViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWritePeopleData")]
        [Route("people-management")]
        public IActionResult Post([FromBody]PeopleVM peopleVM)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(peopleVM);
            }

            _peopleService.Register(peopleVM);

            return Response(peopleVM);
        }

        [HttpPut]
        [Authorize(Policy = "CanWritePeopleData")]
        [Route("people-management")]
        public IActionResult Put([FromBody]PeopleVM peopleVM)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(peopleVM);
            }

            _peopleService.Update(peopleVM);

            return Response(peopleVM);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemovePeopleData")]
        [Route("people-management")]
        public IActionResult Delete(int id)
        {
            _peopleService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("people-management/history/{id:int}")]
        public IActionResult History(int id)
        {
            //TODO: Implement History
            var customerHistoryData = _peopleService.GetById(id);
            return Response(customerHistoryData);
        }
    }
}