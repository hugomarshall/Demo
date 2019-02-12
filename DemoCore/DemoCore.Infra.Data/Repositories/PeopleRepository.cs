using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoCore.Infra.Data.Repositories
{
    public class PeopleRepository: Repository<People>, IPeopleRepository
    {
        public PeopleRepository(DemoCoreContext context): base(context)
        {
            
        }

        public People GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(x => x.Email == email);
        }

    }
}
