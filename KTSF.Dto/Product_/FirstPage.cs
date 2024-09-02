using KTSF.Core.Product_;

namespace KTSF.Dto.Product_
{
    public class FirstPage<T>
    {
        public int PageCount {  get; set; }

        public T[]? Items { get; set; }
    }
}
