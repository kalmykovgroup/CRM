using System.ComponentModel.DataAnnotations.Schema;
using CommunityToolkit.Mvvm.ComponentModel;
// ReSharper disable UnassignedGetOnlyAutoProperty

namespace KTSF.Core.Receipt_;

[Table("payment_infos")]
public partial class PaymentInfo : ObservableObject
{
    public int Id { get; set; }
    public double TotalSum { get; set; } // Общая стоимость всех продуктов в чеке
    public double CashAmount { get; set; } // Внесенная сумма "деньгами"
    public double CardAmount { get; set; } // Внесенная сумма "картой"
    public double AmountPaid { get; set; } // Общая внесенная сумма


    public int PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = null!; // Тип оплаты чека
}
