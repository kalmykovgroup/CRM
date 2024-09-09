namespace KTSF.Dto.Receipt_;

    public class ReceiptDTO
    {
        public int Id { get; set; }
    
        public double? Discount { get; set; }

        public PaymentInfoDTO ReceiptPaymentInfo { get; set; }
    
        public List<BuyProductDTO> BuyProducts { get; set; } = []; 
        
    }

