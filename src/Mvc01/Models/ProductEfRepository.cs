namespace Mvc01.Models;

public class ProductEfRepository
{

    private readonly ShopDbContext _shopDbContext;
    public ProductEfRepository()
    {
        _shopDbContext = new ShopDbContext();
    }

    public List<ProductModel> GetAllProducts()
    {
        return _shopDbContext.Products.ToList();
    }

    public ProductModel GetProductDetails(int productId)
    {
        return _shopDbContext.Products.Where(w => w.Id == productId).FirstOrDefault();
    }

    public int AddProduct(ProductModel model)
    {
        //model.Id = 1;

        //var lastRecord = _shopDbContext.Products.OrderByDescending(o => o.Id).FirstOrDefault();

        //if (lastRecord != null)
        //    model.Id = lastRecord.Id + 1;

        _shopDbContext.Products.Add(model);
        _shopDbContext.SaveChanges();
        return model.Id;
    }

    public void UpdateProduct(ProductModel model)
    {
        var product = GetProductDetails(model.Id);
        product.Price = model.Price;
        product.ProductCount = model.ProductCount;
        product.ProductName = model.ProductName;
        _shopDbContext.SaveChanges();
    }

    public ProductModel DeleteProduct(int productId)
    {
        var product = GetProductDetails(productId);
        _shopDbContext.Products.Remove(product);
        _shopDbContext.SaveChanges();
        return product;
    }
}