using System;
using DemoCore.Application.Interfaces;
using DemoCore.Domain.Interfaces;
using DemoCore.Infra.CrossCutting.Identity.Data;
using DemoCore.Infra.Data.UoW;
using Microsoft.Extensions.Configuration;

namespace DemoCore.Tests.XUnitTestProject
{
    public class BaseTest : Startup
    {
        protected IDeveloperService developerService;
        protected IDesignerService designerService;
        protected IWorkAvailabilityService workAvailabilityService;
        protected IBestWorkTimeService bestWorkTimeService;
        protected IPeopleService peopleService;

        protected IDeveloperRepository developerRepository;
        protected IDesignerRepository designerRepository;
        protected IBestWorkTimeRepository bestWorkTimeRepository;
        protected IWorkAvailabilityRepository workAvailabilityRepository;
        protected IPeopleRepository peopleRepository;
        public BaseTest() : base()
        {
            Setup();
        }

        private void Setup()
        {

        }
    }
}
