using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.Product_
{
    [Table("product")]
    public class Product
    { 
        public int Id { get; set; }

        [MaxLength(255)] 
        public string Name { get; set; } = String.Empty;

        [MaxLength(255)] 
        public string? NameToPrint { get; set; } //Имя для печати этикеток

        [MaxLength(255)] 
        public string? Description { get; set; }

        //Разные постащики могут давать накладные без штрих-кода но со свои артиклом
        //Артикул - это сокращенное название товара.
        //Артикул `Y-100` - это вполне легальный артикул у китайцев, например для пассатижей.
        public List<Article> Articles { get; } = new();
         
        public int GroupId { get; set; }
        public Group? Group { get; set; } //Например (пассатижи и шуруповерт фирмы bosch из разных категорий но вполне могут быть в одной группе, так так фирма одна)
         
        public int UnitId { get; set; }
        public Unit Unit { get; set; } //шт. л. кг.

        //Габбариты  
        public int? Width { get; set; }
         
        public int? Height { get; set; }
         
        public int? Length { get; set; }
         
        public int? Weight { get; set; } //Вес

        //Список штрих-кодов (Разные поставщики могут поставлять один и тот-же товар с разными штрих-кодами)
        public List<Barcode> Barcodes { get; } = new();

        //Цены
        public List<Price> PriceHistory { get; } = new(); //История изменения цен
         
        public ulong BuyPrice { get; set; } //Цена закупки
         
        public ulong BuySales { get; set; } //Цена продажи
         
        public ulong? OldPrice { get; set; } //Это маркетинговая цена (зачеркнутая), нужна для сайтов.
         
        public DateTime CreatedAt { get; set; }
         
        public DateTime UpdatedAt { get; set; }

    }
}
