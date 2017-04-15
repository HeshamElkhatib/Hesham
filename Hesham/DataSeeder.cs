using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;
namespace Hesham
{
    public class DataSeeder
    {
        public void Seed()
        {
            Db.Transact(() =>
            {
                var mainAgency = Db.SQL<Models.RealEstateAgency>("SELECT a FROM RealEstateAgency a").First;
                if (mainAgency == null)
                {
                    new Models.RealEstateAgency();
                }
                var f = Db.SQL<Models.Franchise>("SELECT f FROM Franchise f").First;
                if (f == null)
                {
                    new Models.Franchise();
                }

            });
        }
    }
}
