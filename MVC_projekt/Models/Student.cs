namespace MVC_projekt.Models
{
    public class Student
    {
        public long id_studenta { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public string mesto { get; set; }
        public string ulice { get; set; }
        public string psc{ get; set; }
        public string misto_narozeni{ get; set; }
        public string datum_narozeni { get; set; }
        public string statni_obcanstvi{ get; set; }
        public string rodne_cislo { get; set; }
        public string stat { get; set; }
        public string email { get; set; }
        public string? telefon { get; set; }
    }
}
