using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.Infra.Data.Repositories
{
    public class DeveloperRepository : Repository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(DemoCoreContext context) : base(context)
        {
        }
    }
}
