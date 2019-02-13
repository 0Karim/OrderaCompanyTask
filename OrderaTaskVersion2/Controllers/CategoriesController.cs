using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderaTaskVersion2.DAL.RepositoryInterfaces;
using OrderaTaskVersion2.DAL;
using OrderaTaskVersion2.Models;
using System.Net;
using Microsoft.Owin;

namespace OrderaTaskVersion2.Controllers
{

    [Authorize]
    //[AllowAnonymous]
    public class CategoriesController : Controller
    {
        //private ICategoryRepository db = new CategoryRepository(new ProductContext());
        private ICategoryRepository db;

        public CategoriesController(ICategoryRepository db)
        {
            this.db = db;
        }

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.GetAll());
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="ID , Name , Description")]ProductCategories category)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                db.Add(category);
                return RedirectToAction("Index");
            }
            return View(category); //in case of Validation Error
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = db.Get((int)id);
            if(category == null)
            {
                return HttpNotFound();
            }

            // return if found
            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID , Name, Description")] ProductCategories category)
        {
            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                db.Update(category);
                return RedirectToAction("Index");
            }
            //in case validation error
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = db.Get((int)id);
            if (category == null)
                return HttpNotFound();

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost , ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete logic here
            var category = db.Get(id);
            db.Remove(category);
            return RedirectToAction("Index");
        }
    }
}
