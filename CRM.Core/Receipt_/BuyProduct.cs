using System.ComponentModel.DataAnnotations.Schema;
using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.Core.Product_;

namespace KTSF.Core.Receipt_;

public partial class BuyProduct : ObservableObject
{
    public int Id { get; set; }
    
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!; // Товар 
    
    public double Price { get; set; } // Цена данного товара в чеке
    
    public int Count { get; set; } // Количество данного товара в чеке
    
    public double TotalSumProduct { get; set; } // Общая стомость данного продукта в чеке
    
    public double? Discount { get; set; } // Процент скидки
}