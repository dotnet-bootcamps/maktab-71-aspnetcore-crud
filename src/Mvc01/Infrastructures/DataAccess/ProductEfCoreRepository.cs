using Mvc01.Infrastructures.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mvc01.Models.QueryModel;

namespace Mvc01.Models;

public class ProductEfCoreRepository
{
    private readonly ShopDbContext _dbContext;
    public ProductEfCoreRepository()
    {
        _dbContext = new ShopDbContext();
    }

    public List<ProductWithCategory> GetAllProductsWithCategory()
    {
        var result =
        (
            from p in _dbContext.Products
            join c in _dbContext.Categories on p.CategoryId equals c.Id
            select new ProductWithCategory
            {
                ProductId = p.Id,
                HasanTitle = p.ProductName,
                CategoryTitle = c.Title
            }).ToList();

        return result;

        //var anounymouseType =
        //(
        //    from p in _dbContext.Products
        //    join c in _dbContext.Categories on p.CategoryId equals c.Id
        //    select new
        //    {
        //        p.Id,
        //        p.CategoryId,
        //        p.ProductName
        //    }
        //).FirstOrDefault();

        //foreach (var item in anonymouseType)
        //{
        //    Console.WriteLine(item.Id);
        //}
    }

    public List<ProductWithCategory> GetAllProductsWithCategory2()
    {

        var result11 = _dbContext.Products.ToList();
        var result1 = _dbContext.Products.Include(i => i.Category).ToList();


        var sdfgsdfsdf = _dbContext.Categories.ToList();
        var sdfsdf = _dbContext.Categories.Include(i => i.Products).ToList();


        var result2 = _dbContext.Products.Include(i => i.Category)
            .Select(s => new
            {
                //s.CategoryId,
                s.ProductName,
                s.Category.Title,
                s.Category.MadeIn
            })
            .ToList();

        var result3 = _dbContext.Products.Include(i => i.Category)
            .Select(s => new ProductWithCategory
            {
               ProductId= s.Id,
               CategoryTitle = s.Category.Title,
               HasanTitle = s.ProductName
            })
            .ToList();

        return result3;
    }

    public List<Product> GetAllProducts()
    {
        return _dbContext.Products.ToList();
    }

    public Product GetProductDetails(int productId)
    {
        return _dbContext.Products.Where(w => w.Id == productId).FirstOrDefault();
    }

    public int AddProduct(Product model)
    {
        _dbContext.Products.Add(model);
        _dbContext.SaveChanges();
        return model.Id;
    }

    public void UpdateProduct(Product model)
    {
        var product = GetProductDetails(model.Id);
        product.Price = model.Price;
        product.ProductCount = model.ProductCount;
        product.ProductName = model.ProductName;
        _dbContext.SaveChanges();
    }

    public Product DeleteProduct(int productId)
    {
        var product = GetProductDetails(productId);
        _dbContext.Products.Remove(product);
        _dbContext.SaveChanges();
        return product;
    }
}