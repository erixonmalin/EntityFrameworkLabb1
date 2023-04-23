using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkLabb1.Models.Domain
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; } = 0;

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 1)]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; } = default!;

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; } = default!;

        [Display(Name = "Arbetsroll")]
        public string? Role { get; set; }

        public virtual ICollection<VacationList>? VacationLists { get; set; }
    }
}
