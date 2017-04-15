using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

using System.Collections;

namespace Hesham.Models
{
    
    [Database]
    public class Corporation
    {
        public string Name;
        public RealEstateAgency Agency;
        public IEnumerable Franchises
        {
            get { return Db.SQL<Transaction>("SELECT f FROM Hesham.Models.Franchise f WHERE f.Franchisee = ?", this); }
        }
    }
    
}
