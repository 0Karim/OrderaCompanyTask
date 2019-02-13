using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderaTaskVersion2.DAL;
using OrderaTaskVersion2.Models;
using OrderaTaskVersion2.DAL.RepositoryInterfaces;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;

namespace OrderaTaskVersion2.Controllers
{


    [Authorize]
    //[AllowAnonymous]
    public class ProductsController : Controller
    {
        //private ProductRepository db = new ProductRepository(new ProductContext());
        //private IProductRepository db = new ProductRepository(new ProductContext());
        //private UnitOfWork unitOfWork = new UnitOfWork();

        IProductRepository db;

        public ProductsController(IProductRepository db)
        {
            this.db = db;
        }

        // GET: Products
        public ActionResult Index()
        {
            //return View(unitOfWork._ProductRepository.GetAll());
            return View(db.GetAll());
        }
        
        // GET: Products/Create
        public ActionResult Create()
        {
            //ViewBag.CategoryID = new SelectList(unitOfWork.CategoreyRepository.GetAll(), "ID", "Name");
            ViewBag.CategoryID = new SelectList(db.GetAllCategories(), "ID", "Name");
            return View();  
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductName,NumberInStock,ProductDescription,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                //unitOfWork._ProductRepository.Add(product);
                db.Add(product);
                return RedirectToAction("Index");
            }

            //ViewBag.CategoryID = new SelectList(unitOfWork.CategoreyRepository.GetAll(), "ID", "Name", product.CategoryID);
            ViewBag.CategoryID = new SelectList(db.GetAllCategories(), "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var product = unitOfWork._ProductRepository.Get((int)id);
            var product = db.Get((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.GetAllCategories(), "ID", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductName,NumberInStock,ProductDescription,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                //unitOfWork._ProductRepository.Update(product);
                db.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.GetAllCategories(), "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);
            //var product = unitOfWork._ProductRepository.Get((int)id);
            var product = db.Get((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //var product = unitOfWork._ProductRepository.Get((int)id);
            //unitOfWork._ProductRepository.Remove(product);
            var product = db.Get((int)id);
            db.Remove(product);
            return RedirectToAction("Index");
        }

    }
}
