

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Core.Product_
{
    public enum Type
    { Unspecified, UpcA, UpcE, UpcSupplemental2Digit, UpcSupplemental5Digit, Ean13, Ean8, Interleaved2Of5, Interleaved2Of5Mod10, Standard2Of5, Standard2Of5Mod10, Industrial2Of5, Industrial2Of5Mod10, Code39, Code39Extended, Code39Mod43, Codabar, PostNet, Bookland, Isbn, Jan13, MsiMod10, Msi2Mod10, MsiMod11, MsiMod11Mod10, ModifiedPlessey, Code11, Usd8, Ucc12, Ucc13, Logmars, Code128, Code128A, Code128B, Code128C, Itf14, Code93, Telepen, Fim, Pharmacode, IATA2of5 }


    [Table("barcodes")] 
    public class Barcode
    { 
        public int Id { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [MaxLength(512)]
        [Key]
        public string Code { get; set; } = String.Empty;

        public Type Type {  get; set; } 
    }
}
