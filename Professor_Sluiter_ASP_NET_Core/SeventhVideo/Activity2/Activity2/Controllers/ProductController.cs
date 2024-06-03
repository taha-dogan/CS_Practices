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

        public IActionResult ShowDetails(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View(foundProduct);
        }

        public IActionResult Edit(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View("ShowEdit",foundProduct);
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Update(product);
            return View("Index", products.GetAllProducts());
        }

        public IActionResult Delete(int id) 
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(id);
            products.Delete(product);
            return View("Index", products.GetAllProducts());
        }

        public IActionResult InputForm()
        {
            return View();
        }

        public IActionResult ProcessCreate(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Insert(product);
            return View("ShowDetails", products.GetProductById(product.Id));
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
