using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_CommerceShop.Core.Contracts;
using E_CommerceShop.Core.Models;
using E_CommerceShop.Core.ViewModels;
using E_CommerceShop.DataAccess.InMemory;

namespace E_CommerceShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        IRepository<Products> context;
        IRepository<ProductCategory> productCategories;

       public ProductManagerController(IRepository<Products> productContext, IRepository<ProductCategory> productCategoryContext )
        {
            context = productContext;
            productCategories =productCategoryContext;
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Products> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ProductManagerViewModels viewModel = new ProductManagerViewModels();

            viewModel .Product = new Products();
            viewModel.ProductCategories = productCategories.Collection();
            
            return View(viewModel);
                
        }
        [HttpPost]
        public ActionResult Create(Products product,HttpPostedFileBase file)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                if(file != null)
                {
                    product.Image = product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + product.Image);
                }

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
                ProductManagerViewModels viewModels = new ProductManagerViewModels();
                viewModels.Product = product;

                viewModels.ProductCategories = productCategories.Collection();
                
                return View(viewModels);
            }
        }

        [HttpPost]
        public ActionResult Edit(Products product, string Id, HttpPostedFileBase file)
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
               
                if(file!=null)
                {
                    productToEdit.Image = product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + productToEdit.Image);
                }
                    productToEdit.Category = product.Category;
                    productToEdit.Descripition = product.Descripition;
                    productToEdit.Name = product.Name;
                    productToEdit.Price = product.Price;
                  

                    context.Commit();
                    return RedirectToAction("Index");
               
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