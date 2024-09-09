using KTSF.Dto.Product_;

namespace KTSF.Dto.Receipt_;

public class BuyProductDTO
{
    public int Id { get; set; }

    public ProductDTO Product { get; set; } = null!; 
    
    public double Price { get; set; }
    
    public int Count { get; set; }
    
    public double TotalSumProduct { get; set; }
    
    public double? Discount { get; set; }
}