using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.Product_
{
    public class ProductInformation
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;


        [MaxLength(255)]
        public string? NameToPrint { get; set; } //Имя для печати этикеток

        [MaxLength(255)]
        public string? Description { get; set; }

        //Габбариты  
        public int? Width { get; set; }

        public int? Height { get; set; }

        public int? Length { get; set; }

        public double? Weight { get; set; } //Вес


        //Цены
        public List<Price> PriceHistory { get; } = []; //История изменения цен

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
