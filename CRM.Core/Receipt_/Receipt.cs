using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using CommunityToolkit.Mvvm.ComponentModel;

namespace KTSF.Core.Receipt_;

public partial class Receipt : ObservableObject {
    public int Id { get; set; }
    
    public double? Discount; // Процент скидки

    [ForeignKey(nameof(ReceiptPaymentInfo))]
    public int PaymentInfoId;
    public PaymentInfo ReceiptPaymentInfo { get; set; } // Класс отвечающий за информацию об оплате
    
    public List<BuyProduct> BuyProducts { get; set; } = []; // Список купленных продуктов
}