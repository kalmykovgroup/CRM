using KTSF.Core.ABAC;
using KTSF.Core;

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
