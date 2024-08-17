namespace KTSF.Dto.Product_
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ulong BuyPrice { get; set; }
        public ulong SalePrice { get; set; }
        public ulong? OldPrice { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UnitInfo { get; set; } = string.Empty;

        public ProductInformationDTO? ProductInformation { get; set; }

        public List<CategoryDTO> Categories { get; set; } = [];
        

        public List<ArticleDTO> Articles { get; set; } = [];
        public List<BarcodeDTO> Barcodes { get; set; } = [];

        public List<PackingListDTO> PackingLists { get; set; } = [];
        
    }
}
