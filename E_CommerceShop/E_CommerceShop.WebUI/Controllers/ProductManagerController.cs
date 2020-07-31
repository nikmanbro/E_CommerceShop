using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_CommerceShop.Core.Models;
using E_CommerceShop.DataAccess.InMemory;

namespace E_CommerceShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository context;

       public ProductManagerController()
        {
            context = new ProductRepository();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Products> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            Products product = new Products();
            return View(product);
                
        }
        [HttpPost]
        public ActionResult Create(Products product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Products product = context.Find(Id);
            if(product==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Edit(Products product, string Id)
        {
            Products productToEdit = context.Find(Id);

               if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                else
                {
                    productToEdit.Category = product.Category;
                    productToEdit.Descripition = product.Descripition;
                    productToEdit.Name = product.Name;
                    productToEdit.Price = product.Price;
                    productToEdit.Image = product.Image;

                    context.Commit();
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult  Delete(string Id)
        {
            Products productToDelete = context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Products productToDelete = context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        }
}