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

        public List<Article> Articles { get; set; } //Текстовое имя."Y-100" - это вполне легальный артикул у китайцев, например для пассатижей.

        public Group? Group { get; set; } //Например (пассатижи и шуруповерт фирмы bosch из разных категорий но вполне могут быть в одной группе, так так фирма одна)
       
        public Unit Unit { get; set; } //шт. л. кг.

        //Габбариты
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }

        public int Weight { get; set; } //Вес

        public List<Barcode> Barcodes { get; } = new();

        //Цены

    }
}
