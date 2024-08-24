using CommunityToolkit.Mvvm.ComponentModel;
// ReSharper disable UnassignedGetOnlyAutoProperty

namespace KTSF.Core.Receipt_;

public partial class PaymentInfo : ObservableObject
{
    public int Id { get; set; }
    public double TotalSum { get; } // Общая стомость всех продуктов в чеке
    public double CashAmount { get; } // Внесенная сумма "деньгами"
    public double CardAmount { get; } // Внесенная сумма "картой"
    public double AmountPaid { get; } // Общая внесенная сумма
    public PaymentMethod PaymentMethod { get; } // Тип оплаты яека
}

public enum PaymentMethod {
    None,
    Cash,
    Card,
    Mixed
}
