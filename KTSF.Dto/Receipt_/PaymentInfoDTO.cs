namespace KTSF.Dto.Receipt_;

public class PaymentInfoDTO
{
    public int Id { get; set; }
    public double TotalSum { get; set; } 
    public double CashAmount { get; set; }
    public double CardAmount { get; set; }
    public double AmountPaid { get; set; }
    public PaymentMethodDTO PaymentMethod { get; set; } = null!;
}