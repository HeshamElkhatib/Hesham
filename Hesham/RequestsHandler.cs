using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;
namespace Hesham
{
    public class RequestsHandler
    {
        public void AddHandlers()
        {
            Handle.GET("/Hesham", () =>
            {
                return Db.Scope(() =>
                {
                    var mainAgency = Db.SQL<Models.RealEstateAgency>("SELECT a FROM RealEstateAgency a").First;
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
            Handle.GET("/Hesham/partial/franchise/{?}", (string id) =>
            {
                var franchise = new FranchiseJson();
                franchise.Data = DbHelper.FromID(DbHelper.Base64DecodeObjectID(id));
                return franchise;
            });
        }
    }
}
