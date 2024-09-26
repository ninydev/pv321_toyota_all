using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationGeo.Models.Shop;

public class ProductModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int VendorId { get; set; }
    [ForeignKey("VendorId")]
    public VendorModel Vendor { get; set; }
    
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public CategoryModel Category { get; set; }
    
    
    public ICollection<ActionModel> Actions { get; set; } = new List<ActionModel>();
}