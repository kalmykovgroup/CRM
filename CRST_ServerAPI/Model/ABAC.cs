namespace CRST_ServerAPI.Model
{
    public class ABAC : Attribute
    {
        public string TableName { get; }
        public string ColumnName { get; }
        public int EmployeeId { get; }
        public int ActionId { get; }

        public ABAC(string tableName, string columnName, int employeeId, int actionId)
        {
            TableName = tableName;
            ColumnName = columnName;
            EmployeeId = employeeId;
            ActionId = actionId;
        }
    }
}
