using System;
using Starcounter;

namespace Hesham
{
    [Database]
    public class Corporation
    {
        public string Name;
        public RealEstateAgency Agency;
    }
    [Database]
    public class RealEstateAgency
    {
        public QueryResultRows<Corporation> Corporations => Db.SQL<Corporation>("SELECT c FROM Hesham.Corporation WHERE c.Agency = ?", this);
    }
    [Database]
    public class Franchise
    {
        public string Name;
        public string Street, ZipCode, City, Country, Number;
        public string Address => Street + " " + Number + ", " + ZipCode + " " + City + ", " + Country;
    }
    
   
    class Program
    {
        static void Main()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());

            Db.Transact(() =>
            {
                var mainAgency = Db.SQL<RealEstateAgency>("SELECT a FROM RealEstateAgency a").First;
                if(mainAgency == null)
                {
                    new RealEstateAgency();
                }
                
            });
            Handle.GET("/Hesham", () =>
            {
                return Db.Scope(() =>
                {
                    var mainAgency = Db.SQL<RealEstateAgency>("SELECT a FROM RealEstateAgency a").First;
                    var json = new RealEstateAgencyJson { Data = mainAgency };
                    if (Session.Current == null)
                    {
                        Session.Current = new Session(SessionOptions.PatchVersioning);
                    }
                    json.Session = Session.Current;
                    return json;
                });
                
            });
            Handle.GET("/Hesham/partial/corporation/{?}", (string id) =>
            {
                var json = new CorporationJson();
                json.Data = DbHelper.FromID(DbHelper.Base64DecodeObjectID(id));
                return json;
            });

            Handle.GET("/Hesham/franchise/{?}", (string id) =>
            {
                return Db.Scope(() =>
                {
                    var franchise = new FranchiseJson();
                    franchise.Data = DbHelper.FromID(DbHelper.Base64DecodeObjectID(id));
                    if (Session.Current == null)
                    {
                        Session.Current = new Session(SessionOptions.PatchVersioning);
                    }
                    franchise.Session = Session.Current;
                    
                    return franchise;
                });
                
            });

        }
    }
}