using System.ComponentModel.DataAnnotations.Schema;

namespace KTSF.Core.Object.Receipt_;

[Table("payment_methods")]
public class PaymentMethod
{
    public int Id { get; set; }
    public string Name { get; set; }
}