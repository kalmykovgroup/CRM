using KTSF.Core.Object.Product_; 

namespace KTSF.Dto.Product_
{
    public class FirstPage<T>
    {
        public int CountAllItems { get; set; }
        public int PageCount {  get; set; }

        public T[] Items { get; set; } = [];

        public FirstPage<object> ToObjectList()
        {
            return new FirstPage<object>{ CountAllItems = CountAllItems, PageCount = PageCount, Items = Items.Cast<object>().ToArray() };
        }
    }
}
