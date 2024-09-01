

using KTSF.Core.Object;
using KTSF.Core.Object.ABAC;

namespace KTSF.Dto.Employee_
{
    public class EmployeeVM
    {
        public Employee Employee { get; set; } = new Employee();
        public List<Appointment> Appointments { get; set; } = [];
        public List<EmployeeStatus> EmployeeStatuses { get; set; } = [];
        public List<ASetOfRules> ASetOfRules { get; set; } = [];
    }
}
