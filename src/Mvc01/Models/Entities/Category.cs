using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc01.Models;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; }
    public CountryEnum MadeIn { get; set; }

    public ICollection<Product> Products { get; set; }
}