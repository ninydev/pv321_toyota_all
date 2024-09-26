using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationGeo.Models.Shop;

public class VendorModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
    
}