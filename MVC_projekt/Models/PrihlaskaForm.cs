using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_projekt.Models
{
    public class PrihlaskaForm
    {

        [Required]
        [MaxLength(85)]
        [Display(Name ="Jméno")]
        public string jmeno { get; set; }

        [Required]
        [MaxLength(95)]
        [Display(Name = "příjmení")]
        public string prijmeni { get; set; }

        [Required]
        [MaxLength(65)]
        [Display(Name = "místo narození")]
        public string misto_narozeni { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Datum narození")]
        public DateOnly datum_narozeni { get; set; }

        [Required]
        [MaxLength(65)]
        [Display(Name = "Státní občanství")]
        public string statni_obcanstvi { get; set; }


        [Required]
        [MaxLength(15)]
        [Display(Name = "Rodné číslo")]
        public string rodne_cislo { get; set; }

        [Required]
        [MaxLength(55)]
        [Display(Name = "Město")]
        public string mesto { get; set; }

        [Required]
        [MaxLength(95)]
        [Display(Name = "Ulice")]
        public string ulice { get; set; }

        [Required]
        [MaxLength(7)]
        [Display(Name = "PSČ")]
        public string psc { get; set; }

        [Required]
        [MaxLength(65)]
        [Display(Name = "Stát")]
        public string stat{ get; set; }

        [Required]
        [MaxLength(75)]
        [Display(Name = "Email")]
        public string email{ get; set; }

        [MaxLength(17)]
        [Display(Name = "Telefonní číslo")]
        public string telefonni_cislo{ get; set; }


        [Required]
        [Display(Name="studijní program")]
        public string id_skola_program1 { get; set; }

        [Display(Name = "studijní program")]
        public string? id_skola_program2 { get; set; }

        [Display(Name = "studijní program")]
        public string? id_skola_program3 { get; set; }

    }
}
