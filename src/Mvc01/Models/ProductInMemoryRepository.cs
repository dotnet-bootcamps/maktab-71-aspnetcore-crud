namespace Mvc01.Models;

public class ProductInMemoryRepository
{
    private static List<ProductModel> _products = new List<ProductModel>();

    public ProductInMemoryRepository()
    {
        //_products.Add(new ProductModel()
        //{
        //    Id = 1,
        //    Price = 500,
        //    ProductCount = 10,
        //    ProductName = "لیوان"
        //});

        //_products.Add(new ProductModel()
        //{
        //    Id = 2,
        //    Price = 300,
        //    ProductCount = 11,
        //    ProductName = "چای"
        //});

        //_products.Add(new ProductModel()
        //{
        //    Id = 3,
        //    Price = 200,
        //    ProductCount = 15,
        //    ProductName = "قهوه"
        //});
    }

    public List<ProductModel> GetAllProducts()
    {
        return _products;
    }

    public ProductModel GetProductDetails(int productId)
    {
        return _products.Where(w => w.Id == productId).FirstOrDefault();
    }

    public int AddProduct(ProductModel model)
    {
        model.Id = 1;

        var lastRecord= _products.OrderByDescending(o=>o.Id).FirstOrDefault();

        if (lastRecord != null)
            model.Id = lastRecord.Id + 1;

        _products.Add(model);
        return model.Id;
    }

    public void UpdateProduct(ProductModel model)
    {
        var product = GetProductDetails(model.Id);
        product.Price = model.Price;
        product.ProductCount = model.ProductCount;
        product.ProductName = model.ProductName;
    }

    public ProductModel DeleteProduct(int productId)
    {
        var product = GetProductDetails(productId);
        _products.Remove(product);
        return product;
    }


}