using System.ComponentModel.DataAnnotations;

namespace Mvc01.Models;

public class ProductModel
{
    public int Id { get; set; }

    [Display(Name="نام محصول")]
    public string ProductName { get; set; }
    
    public int Price { get; set; }

    public int ProductCount { get; set; }

}