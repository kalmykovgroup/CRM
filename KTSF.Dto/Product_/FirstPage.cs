using KTSF.Core.Product_;

namespace KTSF.Dto.Product_
{
    public class FirstPage
    {
        public int pageCount {  get; set; }

        public Product[] Products { get; set; } = [];
    }
}
