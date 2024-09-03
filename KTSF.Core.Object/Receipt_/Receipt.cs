using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using CommunityToolkit.Mvvm.ComponentModel;

namespace KTSF.Core.Object.Receipt_;

[Table("receipts")]
public class Receipt : ObservableObject
{

    public int Id { get; set; }

    public double? Discount { get; set; } // Процент скидки

    public DateTime CreatedDate { get; set; }


    public int PaymentInfoId { get; set; }
    public PaymentInfo ReceiptPaymentInfo { get; set; } = null!; // Класс отвечающий за информацию об оплате

    public List<BuyProduct> BuyProducts { get; set; } = []; // Список купленных продуктов
}