using Microsoft.AspNetCore.Mvc;
using Mvc01.Models;

namespace Mvc01.Controllers
{
    public class ProductsController : Controller
    {
        private ProductInMemoryRepository _productRepository;
        public ProductsController()
        {

            _productRepository = new ProductInMemoryRepository();
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
        public IActionResult Create(ProductModel model)
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
        public IActionResult Edit(ProductModel model)
        {
            _productRepository.UpdateProduct(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetProductDetails(id);
            return View(product);
        }

        public IActionResult DeleteProduct(ProductModel model)
        {
            _productRepository.DeleteProduct(model.Id);
            return RedirectToAction("Index");
        }
    }

}
