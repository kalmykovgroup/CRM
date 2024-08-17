using KTSF.Core.ABAC;
using KTSF.Core;

namespace KTSF.Dto.Employee_
{
    public class EmployeeVM
    {
        public Employee Employee { get; set; } = new Employee();
        public List<Appointment> Appointments { get; } = [];
        public List<EmployeeStatus> EmployeeStatuses { get; } = [];
        public List<ASetOfRules> ASetOfRules { get; } = [];
    }
}
