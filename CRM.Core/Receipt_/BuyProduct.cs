using System.ComponentModel.DataAnnotations.Schema;
using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.Core.Product_;

namespace KTSF.Core.Receipt_;

public partial class BuyProduct : ObservableObject
{
    public int Id { get; set; }
    
    [ForeignKey(nameof(Product))]
    public int ProductId { get; }
    public Product Product; // Товар 
    
    public double Price; // Цена данного товара в чеке
    
    public int Count; // Количество данного товара в чеке
    
    public double TotalSumProduct; // Общая стомость данного продукта в чеке
    
    public double? Discount; // Процент скидки
}