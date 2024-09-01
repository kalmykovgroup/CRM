using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Components.TabComponents.StaffComponent
{
    public interface ITranslationEditStaffWindow
    {
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
        public string Passport { get; }
        public string INN { get; }
        public string SNILS { get; }
        public string Position { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string Address { get; }
        public string EmployeeStatus { get; }
        public string EmployeePermissions { get; }
        public string ApplyingDate { get; }
        public string Editing { get; }
        public string Attributes { get; }
        public string Save { get; }
        public string Cancel { get; }
    }
}
