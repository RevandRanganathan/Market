using Market.Models;
using Market.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Market.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllProducts()
        {

            ProductRepository ProRepo = new ProductRepository();
            ModelState.Clear();
            return View(ProRepo.GetAllProducts());
        }
        //public ActionResult ViewProduct(int id)
        //{

        //    ProductRepository ProRepo = new ProductRepository();
        //    ModelState.Clear();
        //    return View(ProRepo.ViewProduct().Find(Emp => Emp.id == id));
        //}
        // GET: Product/AddProduct   

        public ActionResult AddProduct()
        {
            return View();
        }

        // POST: Product/AddProduct   
        [HttpPost]
        public ActionResult AddProduct(Product Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductRepository ProRepo = new ProductRepository();

                    if (ProRepo.AddProduct(Emp))
                    {
                        ViewBag.Message = "Product added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ViewPro(int? id)
        {
            ProductRepository ProRepo = new ProductRepository();
            ModelState.Clear();
            return View(ProRepo.GetData(id));
        }

        // GET: Product/EditProduct   
        public ActionResult EditProduct(int id)
        {
            ProductRepository ProRepo = new ProductRepository();



            return View(ProRepo.GetAllProducts().Find(Emp => Emp.ProductId == id));

        }

        // POST: Product/EditProduct   
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult EditProduct(int id, Product obj)
        {
            try
            {
                ProductRepository EmpRepo = new ProductRepository();

                EmpRepo.UpdateProduct(obj);
                return RedirectToAction("GetAllProducts");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/DeleteProduct   
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                ProductRepository ProRepo = new ProductRepository();
                if (ProRepo.DeleteProduct(id))
                {
                    ViewBag.AlertMsg = "Product details deleted successfully";

                }
                return RedirectToAction("GetAllProducts");

            }
            catch
            {
                return View();
            }
        }
    }
}