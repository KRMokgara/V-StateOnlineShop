using System;

using V_StateOnline.Core;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V_StateOnline.Core.Models;
using V_StateOnline.DataAccess.Inmemory;
using V_StateOnline.Core.ViewModels;
using V_StateOnline.Core.Contracts;

namespace V_StateOnline.UI.Controllers
{
    public class ProductController : Controller
    {
       IRepository <Product> context;
        IRepository <productCategory> productCategories;

        public ProductController(IRepository<Product> productcontext, IRepository<ProductCategory> categorycontext)
        {
            context = productcontext();
            productCategories = categorycontext();
        }
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create()
        {
            ProductVM viewModel = new ProductVM();
            viewModel.Product = new Product();
            viewModel.ProductCategories = productCategories.Collection();
            
            return View(viewModel);
        }
        [HttpPost]

        public ActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("index");
            }
        }
        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if(product == null)
            {
                return HttpNotFound();

            }
            else
            {
                ProductVM viewModel = new ProductVM();
                viewModel.Product = product;
                viewModel.ProductCategories = productCategories.Collection();
                
                return View(viewModel);
            }
        }
        [HttpPost]

        public ActionResult Edit(Product product, string Id)
        {
            Product prod = context.Find(Id);
            
            if (prod== null)
            {
                return HttpNotFound();

            }
            else
            {
                if(ModelState.IsValid)
                {
                    return View(product);
                }
                prod.Category = product.Category;
                prod.Description = product.Description;
                prod.Image = product.Image;
                prod.Name = product.Name;
                prod.Price = product.Price;
                context.Commit();
                return RedirectToAction("Index");
            } 
        }

        public ActionResult Delete(string Id)
        {
            Product productToDelete = context.Find(Id);
            if(productToDelete == null)
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

            Product productToDelete = context.Find(Id);
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