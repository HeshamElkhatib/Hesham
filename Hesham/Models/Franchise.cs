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
    public class Franchise
    {
        public string Name, Street, ZipCode, City, Country, Number;
        public string Address => Street + " " + Number + ", " + ZipCode + " " + City + ", " + Country;
        public IEnumerable Transactions
        {
            get { return Db.SQL<Transaction>("SELECT t FROM Hesham.Models.Transaction t WHERE t.OwnerFranchise = ?", this); }
        }
        public Corporation Franchisee;
        public Decimal TotalSales => Db.SQL<Decimal>("SELECT SUM(t.SalesPrice) FROM Hesham.Models.Transaction t WHERE t.OwnerFranchise = ?", this).First;
        public Decimal TotalCommissions => Db.SQL<Decimal>("SELECT SUM(t.Commission) FROM Hesham.Models.Transaction t WHERE t.OwnerFranchise = ?", this).First;
        public Decimal AvgCommissions => Db.SQL<Decimal>("SELECT AVG(t.Commission) FROM Hesham.Models.Transaction t WHERE t.OwnerFranchise = ?", this).First;
        public Int32 SoldHomes => Db.SQL<Int32>("SELECT COUNT(*) FROM Hesham.Models.Transaction t WHERE t.OwnerFranchise = ?", this).First;

    }
}
