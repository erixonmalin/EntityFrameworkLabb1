using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkLabb1.Models.Domain
{
    public class Vacation
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]

        public int VacationId { get; set; } = 0;

        [Required]
        [Display(Name = "Ledighetstyp")]
        public string VacationType { get; set; }

        public virtual ICollection<VacationList>? VacationLists { get; set; }
    }
}
