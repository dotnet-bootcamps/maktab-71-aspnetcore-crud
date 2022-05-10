using System.ComponentModel.DataAnnotations;

namespace Mvc01.Models;

public class Product
{
    public int Id { get; set; }

    [Display(Name = "نام محصول")]
    public string ProductName { get; set; }

    public int Price { get; set; }

    public int ProductCount { get; set; }


    public int CategoryId { get; set; }
    public Category Category { get; set; }

}