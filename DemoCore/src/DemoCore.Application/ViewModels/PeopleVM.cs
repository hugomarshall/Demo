using System;
using System.ComponentModel.DataAnnotations;
using static DemoCore.Domain.Core.Enums.EntityStateEnum;

namespace DemoCore.Application.ViewModels
{
    public class PeopleVM
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3)]
        [MaxLength(200)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MinLength(3)]
        [MaxLength(200)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Skype is required")]
        [MinLength(3)]
        [MaxLength(200)]
        [Display(Name = "Skype")]
        public string Skype { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [MinLength(3)]
        [MaxLength(30)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "LinkedIn is required")]
        [MinLength(3)]
        [MaxLength(400)]
        [Display(Name = "LinkedIn Account")]
        public string LinkedIn { get; set; }
        [Required(ErrorMessage = "City is required")]
        [MinLength(3)]
        [MaxLength(200)]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        [MinLength(3)]
        [MaxLength(200)]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Portfolio is required")]
        [MinLength(3)]
        [MaxLength(200)]
        [Display(Name = "Link do Portfolio")]
        public string Portfolio { get; set; }
        [Display(Name = "Developer")]
        public bool IsDeveloper { get; set; }
        [Display(Name = "Designer")]
        public bool IsDesigner { get; set; }
        public OccupationVM Occupation { get; set; }
        public KnowledgeVM Knowledge { get; set; }
        [Display(Name = "Entity State")]
        public EntityStateOptions EntityState { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Date of Last Update")]
        public DateTime? DateLastUpdate { get; set; }
    }
}
