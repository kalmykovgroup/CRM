using CommunityToolkit.Mvvm.ComponentModel;
using KTSFClassLibrary.ABAC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTSFClassLibrary
{ 
    public partial class User : ObservableObject
    { 
        public int Id { get; set; }
         
        public int ObjectId { get; set; }
        public Object Object { get; set; }

         
        [MaxLength(255)]
        public string Barcode { get; set; } //Штрих-код 
         
        [MaxLength(255)]
        public string Name { get; set; }
         
        [MaxLength(255)]
        public string Surname { get; set; }
         
        [MaxLength(255)]
        public string Patronymic { get; set; }

        public List<AccessAttribute> AccessAttibutes { get; } = new List<AccessAttribute>();

    }
}
