using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCore.Infra.CrossCutting.Identity.Models
{
    [Table("ApplicationUser", Schema = "Identity")]
    public class ApplicationUser : IdentityUser
    {
    }
}
