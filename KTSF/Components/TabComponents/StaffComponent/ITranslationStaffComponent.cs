using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Components.TabComponents.StaffComponent
{
    public interface ITranslationStaffComponent
    {
        public string Name { get; }
        public string Employed {  get; }
        public string Fired { get; }
        public string Unemployed { get; }
        public string Search { get; }
        public string ProbationPeriod { get; }
        public string Add { get; }
        public string Edit { get; }
        public string MoreDetailed { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string Address{ get; }
        public string Passport { get; }
        public string INN { get; }
        public string SNILS { get; }
        public string DateOfEmployment { get; }
        public string DateOfEditing { get; }
        public string DateOfLayoff { get; }
    }
}
