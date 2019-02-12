using System.ComponentModel.DataAnnotations;

namespace DemoCore.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
