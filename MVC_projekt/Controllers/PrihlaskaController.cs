using Microsoft.AspNetCore.Mvc;
using MVC_projekt.Models;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Mvc.Rendering;
using ORMLibrary;

namespace MVC_projekt.Controllers
{
    public class PrihlaskaController : Controller
    {

        private SqliteConnection connection;

        public PrihlaskaController()
        {
            this.connection=new SqliteConnection("Data source=../database.db");
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(PrihlaskaForm form)
        {
            if (ModelState.IsValid)
            {
                connection.Open();
                Student t = new Student { jmeno = form.jmeno, prijmeni = form.prijmeni, datum_narozeni = form.datum_narozeni.ToString(), email = form.email, mesto = form.mesto, misto_narozeni = form.misto_narozeni, psc = form.psc, rodne_cislo = form.rodne_cislo, stat = form.stat, statni_obcanstvi = form.statni_obcanstvi, ulice = form.ulice };
                if (form.telefonni_cislo != null)
                {
                    t.telefon = form.telefonni_cislo;
                }
                long id = connection.Count<Student>() + 1;
                t.id_studenta = id;
                connection.Insert(t);
                Prihlaska p = new Prihlaska { id_skola_program = form.id_skola_program1[0]-48, id_studenta = id };
                if(form.id_skola_program2 != null)
                {
                    p.id_skola_program1 = form.id_skola_program2[0] - 48;
                }
                if (form.id_skola_program3 != null)
                {
                    p.id_skola_program2 = form.id_skola_program3[0] - 48;
                }
                p.id_prihlasky = connection.Count<Prihlaska>() + 1;

                connection.Insert(p);


                return RedirectToAction("odeslano");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult odeslano()
        {
            return View();
        }

        public async Task<IActionResult> vyhledejSkoly(string hledanaSkola)
        {
            List<string> q = new List<string>();
            try
            {
                await connection.OpenAsync();

                foreach (skola_program sp in await connection.Select<skola_program>())
                {
                    studijni_program p = connection.Get<studijni_program>(sp.id_programu);
                    stredni_skola stredni_Skola = connection.Get<stredni_skola>(sp.id_skoly);

                    q.Add(sp.id_skola_program + ": " + stredni_Skola.nazev + "(" + stredni_Skola.typ + ") -> " + p.nazev);
                }
            }
            finally
            {
                connection.Close();
            }
            if (hledanaSkola == null) return Json("");
            var schools=q.Where(sp => sp.ToLower().Contains(hledanaSkola.ToLower())).Select(sp => new { text=sp }).ToList();
           

            return Json(schools);
        }

    }
}
        