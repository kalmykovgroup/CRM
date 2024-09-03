using KTSF.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Application.Service
{
    public class ReceiptService
    {
        private AppDbContext dbContext;

        public ReceiptService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }




    }
}
