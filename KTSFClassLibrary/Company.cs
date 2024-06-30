using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary
{
    internal class Company
    {
        public int Id { get; }

        public int UserId { get; }
        public User User { get; }

        public string Name { get; }

    }
}
