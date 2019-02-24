using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Infra.Data.Migrations
{
    public class DemoCoreDbInitializer
    {
        private readonly DemoCoreContext context;

        public DemoCoreDbInitializer(DemoCoreContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            if (!context.BestWorkTime.Any())
            {
                context.AddRange(_sampleBestWork);
                await context.SaveChangesAsync();
            }

            if(!context.WorkAvailability.Any())
            {
                context.AddRange(_sampleWorkAvailability);
                await context.SaveChangesAsync();
            }

            if(!context.Designer.Any())
            {
                context.AddRange(_sampleDesigner);
                await context.SaveChangesAsync();
            }

            if (!context.Developer.Any())
            {
                context.AddRange(_sampleDeveloper);
                await context.SaveChangesAsync();
            }

            if(!context.People.Any())
            {
                context.AddRange(_samplePeople);
                await context.SaveChangesAsync();
            }
        }

        private List<Designer> _sampleDesigner = new List<Designer>
        {
            new Designer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Photoshop",
                DescriptionEN = "Photoshop"
            },
            new Designer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Illustration",
                DescriptionEN = "Illustration"
            },
            new Designer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "IOS",
                DescriptionEN = "IOS"
            },
            new Designer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "InDesign",
                DescriptionEN = "InDesign"
            },
            new Designer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Criação de marcas",
                DescriptionEN = "Brand Creation"
            },
            new Designer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Mockups",
                DescriptionEN = "Mockups"
            },
            new Designer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Marketing Social",
                DescriptionEN = "Social Marketing"
            },
            new Designer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Web Design",
                DescriptionEN = "Web Design"
            }
        };

        private List<Developer> _sampleDeveloper = new List<Developer>
        {
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Ionic",
                DescriptionEN = "Ionic"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "ReactJS",
                DescriptionEN = "ReactJS"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "React Native",
                DescriptionEN = "React Native"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Android",
                DescriptionEN = "Android"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "IOS",
                DescriptionEN = "IOS"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "HTML",
                DescriptionEN = "HTML"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "CSS",
                DescriptionEN = "CSS"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Bootstrap",
                DescriptionEN = "Bootstrap"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "JQuery",
                DescriptionEN = "JQuery"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "AngularJs",
                DescriptionEN = "AngularJs"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Angular",
                DescriptionEN = "Angular"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "JAVA",
                DescriptionEN = "JAVA"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Asp.Net MVC",
                DescriptionEN = "Asp.Net MVC"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Asp.Net WebForm",
                DescriptionEN = "Asp.Net WebForm"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "C",
                DescriptionEN = "C"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "C#",
                DescriptionEN = "C#"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "NodeJS",
                DescriptionEN = "NodeJS"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Cake",
                DescriptionEN = "Cake"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Django",
                DescriptionEN = "Django"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Majento",
                DescriptionEN = "Majento"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "PHP",
                DescriptionEN = "PHP"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Vue",
                DescriptionEN = "Vue"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Wordpress",
                DescriptionEN = "Wordpress"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Phyton",
                DescriptionEN = "Phyton"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Ruby",
                DescriptionEN = "Ruby"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "My SQL Server",
                DescriptionEN = "My SQL Server"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "My SQL",
                DescriptionEN = "My SQL"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Salesforce",
                DescriptionEN = "Salesforce"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Photoshop",
                DescriptionEN = "Photoshop"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Illustrator",
                DescriptionEN = "Illustrator"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "SEO",
                DescriptionEN = "SEO"
            },
            new Developer()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Laravel",
                DescriptionEN = "Laravel"
            },
        };

        private List<WorkAvailability> _sampleWorkAvailability = new List<WorkAvailability>
        {
            new WorkAvailability()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Manhã (de 08:00 ás 12:00)",
                DescriptionEN = "Morning (from 08:00 to 12:00)"
            },
            new WorkAvailability()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Tarde (de 13:00 ás 18:00)",
                DescriptionEN = "Afternoon (from 1:00 p.m. to 6:00 p.m.)"
            },
            new WorkAvailability()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Noite (de 19:00 as 22:00)",
                DescriptionEN = "Night (7:00 p.m. to 10:00 p.m.)"
            },
            new WorkAvailability()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Madrugada (de 22:00 em diante)",
                DescriptionEN = "Dawn (from 10 p.m. onwards)"
            },
            new WorkAvailability()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Comercial (de 08:00 as 18:00)",
                DescriptionEN = "Business (from 08:00 a.m. to 06:00 p.m.)"
            }
        }; 

        private List<BestWorkTime> _sampleBestWork = new List<BestWorkTime>
        {
            new BestWorkTime()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Até 4 horas por dia",
                DescriptionEN = "Up to 4 hours per day"
            },
            new BestWorkTime()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "De 4 á 6 horas por dia",
                DescriptionEN = "4 to 6 hours per day"
            },
            new BestWorkTime()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "De 6 á 8 horas por dia",
                DescriptionEN = "6 to 8 hours per day"
            },
            new BestWorkTime()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Acima de 8 horas por dia (tem certeza?)",
                DescriptionEN = "Up to 8 hours a day (are you sure?)"
            },
            new BestWorkTime()
            {
                EntityState = EntityStateOptions.Active,
                DescriptionPT = "Apenas finais de semana",
                DescriptionEN = "Only weekends"
            }
        };

        private List<People> _samplePeople = new List<People>
        {
            new People()
            {
                Name = "Test Sample",
                Email = "test@test.com.br",
                Phone = "35-98875-7779",
                LinkedIn = "linkedin.com/a/test",
                Skype = "echo test",
                IsDesigner = true,
                IsDeveloper = true,
                Portfolio = "",
                City = "Test",
                State = "Minas Gerais",
                EntityState = EntityStateOptions.Active,
            }
        };
    }
}
