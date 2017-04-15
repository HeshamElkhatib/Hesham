using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace Hesham.Models
{
    [Database]
    public class RealEstateAgency
    {
        public QueryResultRows<Corporation> Corporations => Db.SQL<Corporation>("SELECT c FROM Hesham.Models.Corporation c WHERE c.Agency = ?", this);
    }
}
