using Activity2.Models;
using Activity2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Activity2.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ProductsDAO products = new ProductsDAO();
            return View(products.GetAllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {
            ProductsDAO products = new ProductsDAO();
            List<ProductModel> productsList = products.SearchProducts(searchTerm);
            return View("Index", productsList);
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult Message()
        {
            return View();
        }

        public IActionResult Welcome(string name, int secretNumber = 13)
        {
            ViewBag.Name = name;
            ViewBag.SecretNumber = secretNumber;
            return View();
        }
    }
}
