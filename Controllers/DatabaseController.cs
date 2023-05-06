using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Лабораторная_работа___5.Models;

namespace Лабораторная_работа___5.Controllers
{
    public class DatabaseController : Controller
    {
        private DatabaseContext _db = new DatabaseContext();

        private bool InternalHelperMethod()
        {
            bool result = false;

            var databaseList = _db.Databases.ToList();

            foreach (var database in databaseList)
            {
                if (database.RecordsCount > 1000)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public static class ExternalHelperClass
        {
            public static bool ExternalHelperMethod()
            {
                bool result = false;

                var random = new Random();
                int randomNumber = random.Next(1, 100);

                if (randomNumber >= 50)
                {
                    result = true;
                }

                return result;
            }
        }

        // GET: Database
        public ActionResult Index()
        {
            bool useInternalMethod = true; // здесь задается логическое значение

            if (useInternalMethod)
            {
                ViewData["HelperMethod"] = InternalHelperMethod();
            }
            else
            {
                ViewData["HelperMethod"] = ExternalHelperClass.ExternalHelperMethod();
            }

            var databaseList = _db.Databases.ToList();
            return View(databaseList);
        }

        // GET: Database/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Database/Create
        [HttpPost]
        public ActionResult Create(DatabaseModel database)
        {
            try
            {
                database.CreationDate = DateTime.Now;
                _db.Databases.Add(database);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Database/Edit/5
        public ActionResult Edit(int id)
        {
            var database = _db.Databases.FirstOrDefault(d => d.Id == id);
            return View(database);
        }

        // POST: Database/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DatabaseModel database)
        {
            try
            {
                var originalDatabase = _db.Databases.FirstOrDefault(d => d.Id == id);
                if (originalDatabase != null)
                {
                    originalDatabase.Name = database.Name;
                    originalDatabase.Description = database.Description;
                    originalDatabase.RecordsCount = database.RecordsCount;
                    originalDatabase.SizeInBytes = database.SizeInBytes;
                    originalDatabase.Author = database.Author;
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Database/Delete/5
        public ActionResult Delete(int id)
        {
            var database = _db.Databases.FirstOrDefault(d => d.Id == id);
            return View(database);
        }

        // POST: Database/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var database = _db.Databases.FirstOrDefault(d => d.Id == id);
                if (database != null)
                {
                    _db.Databases.Remove(database);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class DatabaseContext : DbContext
    {
        public DbSet<DatabaseModel> Databases { get; set; }
    }
}