using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace Hesham.Models
{
    [Database]
    public class Transaction
    {
        public Franchise OwnerFranchise;
        public string Date, Address;
        public Decimal SalesPrice, Commission;

    }
}
