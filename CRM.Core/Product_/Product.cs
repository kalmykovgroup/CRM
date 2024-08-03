using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTSF.Core.PackingList_;

namespace KTSF.Core.Product_
{
    [Table("products")]
    public class Product
    { 
        public int Id { get; set; }


        [MaxLength(255)] 
        public string Name { get; set; } = String.Empty;

        public ulong BuyPrice { get; set; } //Цена закупки
         
        public ulong SalePrice { get; set; } //Цена продажи
         
        public ulong? OldPrice { get; set; } //Это маркетинговая цена (зачеркнутая), нужна для сайтов.
          
         
        // ОБНУЛИМЫЙ ????
        public DateTime UpdatedAt { get; set; }


        //'Bosh' 'Перфоратор' 'SDS-Plus' 'Бесчеточные' - Все эти категории могут пресутствовать у одного товара
        //Поэтому связь многие ко многим
        public List<Category> Categories { get; } = [];
        public List<ProductToCategoryJoinTable> ProductToCategoryJoinTables { get; } = [];


        [ForeignKey(nameof(Unit))]
        public int UnitId { get; set; }
        public Unit Unit { get; set; } = null!; //шт. л. кг.

     
        public ProductInformation? ProductInformation { get; set; }


        //Разные постащики могут давать накладные без штрих-кода но со свои артиклом
        //Артикул - это сокращенное название товара.
        //Артикул `Y-100` - это вполне легальный артикул у китайцев, например для пассатижей.
        public List<Article> Articles { get; } = [];

        //Список штрих-кодов (Разные поставщики могут поставлять один и тот-же товар с разными штрих-кодами)
        public List<Barcode> Barcodes { get; } = [];

        //Для связи многие ко многим
        public List<PackingList> PackingLists { get; } = [];
        public List<PackingListToProductJoinTable> PackingListToProductJoinTables { get; } = [];

    }
}
