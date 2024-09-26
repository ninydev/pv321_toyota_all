using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationGeo.Models.Shop;

public class ActionModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string EndDate { get; set; }
    
    public int DiscountCount { get; set; } // - к  цене
    public int DiscountPercentage { get; set; } // - % к цене (после скидки)
    
    public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
}