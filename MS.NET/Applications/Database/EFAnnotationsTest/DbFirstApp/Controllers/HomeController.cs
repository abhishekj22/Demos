using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbFirstApp.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        ShopEntities model = new ShopEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View(model.Products.ToList());
        }

        public ActionResult Details(int id)
        {
            Product product = model.Products.Find(id);
            ViewBag.SelectedProduct = product;
            model.Entry(product).Collection(c => c.Orders).Load(); //explicit loading of child entities
            return View(product.Orders);
        }

        public ActionResult Edit(int id)
        {
            Product product = model.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product input)
        {
            model.Entry(input).State = System.Data.Entity.EntityState.Modified;
            model.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}