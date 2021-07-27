using Market.Models;
using Market.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Market.Controllers
{
    public class SellerController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllSellers()
        {

            SellerRepository ProRepo = new SellerRepository();
            ModelState.Clear();
            return View(ProRepo.GetAllSellers());
        }  

        public ActionResult AddSeller()
        {
            return View();
        }

        // POST: Product/AddProduct   
        [HttpPost]
        public ActionResult AddSeller(Seller Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SellerRepository ProRepo = new SellerRepository();

                    if (ProRepo.AddSeller(Emp))
                    {
                        ViewBag.Message = "Seller added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        //[HttpGet]
        //public ActionResult ViewSell(int? id)
        //{
        //    SellerRepository ProRepo = new SellerRepository();
        //    ModelState.Clear();
        //    return View(ProRepo.GetData(id));
        //}

        public ActionResult Details(int id)
        {
            SellerProductRepository ProRepo = new SellerProductRepository();
            ModelState.Clear();
            Session["SellerId"] = id;
            return View(ProRepo.SellersProduct(id));
        }


        public ActionResult AddSellersproduct()
        {
            SellerRepository sr = new SellerRepository();
            ProductRepository pr = new ProductRepository();
            ViewBag.SList = sr.GetAllSellers().Select(i => new { i.SellerId, i.Name });
            var PList = pr.GetAllProducts();
            List<SelectListItem> FProduct = new List<SelectListItem>();

            foreach (var item in PList)
            {
                FProduct.Add
                    (new SelectListItem
                    {
                    Text=item.Name,
                    Value=item.ProductId.ToString()
                    });
            }
            ViewBag.ProList = FProduct;
            return View();
        }

        // POST: Product/AddProduct   
        [HttpPost]
        public ActionResult AddSellersproduct(SellerProduct Emp)
        {
            try
            {
                Emp.SellerId = Convert.ToInt32(Session["SellerId"]);
                if (ModelState.IsValid)
                {
                    SellerProductRepository ProRepo = new SellerProductRepository();

                    if (ProRepo.AddSellersproduct(Emp))
                    {
                        ViewBag.Message = "Sellers Product added successfully";
                    }
                }

                return RedirectToAction("Details", new { id = Emp.SellerId });
            }
            catch
            {
                return View();
            }
        }


        //public ActionResult DeleteSellerProduct(int id, int SellerId)
        //{
        //    try
        //    {
        //        SellerProductRepository ProRepo = new SellerProductRepository();
        //        if (ProRepo.DeleteSellerProduct(id))
        //        {
        //            ViewBag.AlertMsg = "Seller details deleted successfully";

        //        }
        //        return RedirectToAction("Details", new { id = SellerId });

        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        // GET: Product/EditProduct   
        public ActionResult EditSeller(int id)
        {
            SellerRepository ProRepo = new SellerRepository();



            return View(ProRepo.GetAllSellers().Find(Emp => Emp.SellerId == id));

        }

        // POST: Product/EditProduct   
        [HttpPost]

        public ActionResult EditSeller(int id, Seller obj)
        {
            try
            {
                SellerRepository EmpRepo = new SellerRepository();

                EmpRepo.UpdateSeller(obj);
                return RedirectToAction("GetAllSellers");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/DeleteProduct   
        public ActionResult DeleteSeller(int id)
        {
            try
            {
                SellerRepository ProRepo = new SellerRepository();
                if (ProRepo.DeleteSeller(id))
                {
                    ViewBag.AlertMsg = "Seller details deleted successfully";

                }
                return RedirectToAction("GetAllSellers");

            }
            catch
            {
                return View();
            }
        }
    }
}