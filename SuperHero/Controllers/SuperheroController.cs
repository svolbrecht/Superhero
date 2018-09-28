using SuperHero.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHero.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Superhero
        public ActionResult Index()
        {
            return View(db.Superheros);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Alterego, PrimaryAbility, SecondaryAbility, Catchphrase")]Superheroes superheroes)
        {
            if(ModelState.IsValid)
            {
                db.Superheros.Add(superheroes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Name = new SelectList(db.Superheros, "ID", "Name", superheroes.Name);
            return View(superheroes);
        }

        public ActionResult Edit(int Id)
        {            
            var superhero = db.Superheros.Where(s => s.ID == Id).FirstOrDefault();

            return View(superhero);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,Name,Alterego,PrimaryAbility,SecondaryAbility,Catchphrase")]Superheroes superheroes)
        {
            if(ModelState.IsValid)
            {
                db.Entry(superheroes).State = EntityState.Modified;
                db.SaveChanges();
                return (RedirectToAction("Index"));
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var heros = db.Superheros.Where(h => h.ID == id).FirstOrDefault();

            return View(heros);
        }

        public ActionResult Delete(int id)
        {
            var hero = db.Superheros.Where(h => h.ID == id).FirstOrDefault();
            return View(hero);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var heros = db.Superheros.Where(h => h.ID == id).FirstOrDefault();
            db.Superheros.Remove(heros);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}