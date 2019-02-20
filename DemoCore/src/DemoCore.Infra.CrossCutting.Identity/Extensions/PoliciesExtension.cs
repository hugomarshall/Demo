using DemoCore.Infra.CrossCutting.Identity.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoCore.Infra.CrossCutting.Identity.Extensions
{
    public static class PoliciesExtension
    {
        public static void AddPoliciesSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanReadPeopleData", policy => policy.Requirements.Add(new ClaimRequirement("People", "Read")));
                options.AddPolicy("CanWritePeopleData", policy => policy.Requirements.Add(new ClaimRequirement("People", "Write")));
                options.AddPolicy("CanRemovePeopleData", policy => policy.Requirements.Add(new ClaimRequirement("People", "Delete")));

                options.AddPolicy("CanReadBestWorkTimeData", policy => policy.Requirements.Add(new ClaimRequirement("BestWorkTime", "Read")));
                options.AddPolicy("CanWriteBestWorkTimeData", policy => policy.Requirements.Add(new ClaimRequirement("BestWorkTime", "Write")));
                options.AddPolicy("CanRemoveBestWorkTimeData", policy => policy.Requirements.Add(new ClaimRequirement("BestWorkTime", "Delete")));

                options.AddPolicy("CanReadDesignerData", policy => policy.Requirements.Add(new ClaimRequirement("Designer", "Read")));
                options.AddPolicy("CanWriteDesignerData", policy => policy.Requirements.Add(new ClaimRequirement("Designer", "Write")));
                options.AddPolicy("CanRemoveDesignerData", policy => policy.Requirements.Add(new ClaimRequirement("Designer", "Delete")));

                options.AddPolicy("CanReadDeveloperData", policy => policy.Requirements.Add(new ClaimRequirement("Developer", "Read")));
                options.AddPolicy("CanWriteDeveloperData", policy => policy.Requirements.Add(new ClaimRequirement("Developer", "Write")));
                options.AddPolicy("CanRemoveDeveloperData", policy => policy.Requirements.Add(new ClaimRequirement("Developer", "Delete")));

                options.AddPolicy("CanReadWorkAvailabilityData", policy => policy.Requirements.Add(new ClaimRequirement("WorkAvailability", "Read")));
                options.AddPolicy("CanWriteWorkAvailabilityData", policy => policy.Requirements.Add(new ClaimRequirement("WorkAvailability", "Write")));
                options.AddPolicy("CanRemoveWorkAvailabilityData", policy => policy.Requirements.Add(new ClaimRequirement("WorkAvailability", "Delete")));

                options.AddPolicy("CanWriteCandidateData", policy => policy.Requirements.Add(new ClaimRequirement("People", "Write")));
                options.AddPolicy("CanWriteCandidateData", policy => policy.Requirements.Add(new ClaimRequirement("People", "Read")));
            });
        }
        
    }
}
