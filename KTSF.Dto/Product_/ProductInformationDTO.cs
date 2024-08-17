namespace KTSF.Dto.Product_
{
    public class ProductInformationDTO
    {
        public int Id { get; set; }
        public string? NameToPrint { get; set; }
        public string? Description { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Length { get; set; }
        public double? Weight { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}