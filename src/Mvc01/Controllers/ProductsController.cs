using Microsoft.AspNetCore.Mvc;
using Mvc01.Models;

namespace Mvc01.Controllers
{
    public class ProductsController : Controller
    {
        private ProductEfCoreRepository _productRepository;
        public ProductsController()
        {

            _productRepository = new ProductEfCoreRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts();
            return View("Index", products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            _productRepository.AddProduct(model);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductDetails(id);
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetProductDetails(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            _productRepository.UpdateProduct(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetProductDetails(id);
            return View(product);
        }

        public IActionResult DeleteProduct(Product model)
        {
            _productRepository.DeleteProduct(model.Id);
            return RedirectToAction("Index");
        }
    }

}
