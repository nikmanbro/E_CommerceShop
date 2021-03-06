﻿using E_CommerceShop.Core.Contracts;
using E_CommerceShop.Core.Models;
using E_CommerceShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerceShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Products> context;
        IRepository<ProductCategory> productCategories;

        public HomeController(IRepository<Products> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
        }
        public ActionResult Index(string Category=null)
        {
            List<Products> products;
            List<ProductCategory> categories=productCategories.Collection().ToList();
            if(Category==null)
            {
               products= context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == Category).ToList(); 
            }
            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductCategories =categories;

            return View(model);
        }

        public ActionResult Details( string Id)
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}