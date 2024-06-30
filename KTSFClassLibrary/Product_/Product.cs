using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.Product_
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? NameToPrint { get; set; } //Имя для печати этикеток
        public string? Description { get; set; }

        //Разные постащики могут давать накладные без штрих-кода но со свои артикулом
        //Артикул - это сокращенное название товара.
        //Артикул `Y-100` - это вполне легальный артикул у китайцев, например для пассатижей.
        public List<Article> Articles { get; } = new();

        public Group? Group { get; set; } //Например (пассатижи и шуруповерт фирмы bosch из разных категорий но вполне могут быть в одной группе, так так фирма одна)
       
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

        public int BuyPrice { get; set; } //Цена закупки
        public int BuySales { get; set; } //Цена продажи
        public int? OldPrice { get; set; } //Это маркетинговая цена (зачеркнутая), нужна для сайтов.


        public DateTime CreatedAt { get; set; }

    }
}
