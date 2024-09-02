using System.ComponentModel.DataAnnotations.Schema;
using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.Core.Object.Product_;

namespace KTSF.Core.Object.Receipt_;

[Table("buy_product")]
public class BuyProduct : ObservableObject
{
    public int Id { get; set; }

    public double Price { get; set; } // Цена данного товара в чеке

    public int Count { get; set; } // Количество данного товара в чеке

    public double TotalSumProduct { get; set; } // Общая стомость данного продукта в чеке

    public double? Discount { get; set; } // Процент скидки


    public int ProductId { get; set; }
    public Product Product { get; set; } = null!; // Товар 

    public int ReceiptId { get; set; }
    public Receipt Receipt { get; set; } = null!; // Чек
}