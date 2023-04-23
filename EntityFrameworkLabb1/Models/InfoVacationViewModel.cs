using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLabb1.Models
{
    public class InfoVacationViewModel
    {
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        public string LastName { get; set; }


        [Display(Name = "Arbetsroll")]
        public string Role { get; set; }

        [Display(Name = "Ledighetstyp")]
        public string VacationType { get; set; }

        [Display(Name = "Startdatum")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Slutdatum")]
        public DateTime EndDate { get; set; }
    }
}
