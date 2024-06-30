using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.ABAC
{
    public class TableField
    {
        public int DatabaseTableId { get; set; }
        public DatabaseTable DatabaseTable { get; set; }

        public string FieldName { get; set; }
    }
}
