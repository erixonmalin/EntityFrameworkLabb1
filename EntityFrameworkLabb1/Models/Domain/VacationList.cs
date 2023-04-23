using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EntityFrameworkLabb1.Models.Domain
{
    public class VacationList
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]

        public int VacationListId { get; set; } = 0;

        [Required]
        [Display(Name = "Startdatum")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Slutdatum")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Ansökningsdatum")]
        public DateTime AskDate { get; set; } = DateTime.Now;

        [Display(Name = "Anställd")]
        [ForeignKey(name: "Employees")]
        public int FK_Id { get; set; }
        public virtual Employee? Employees { get; set; }

        [Display(Name = "Ledighetstyp")]
        [ForeignKey(name: "Vacations")]
        public int FK_VacationId { get; set; }
        public virtual Vacation? Vacations { get; set; } 
    }
}
