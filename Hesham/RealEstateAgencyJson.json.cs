using Starcounter;

namespace Hesham
{
    partial class RealEstateAgencyJson : Json
    {
        void Handle(Input.CreateNewCorporationTrigger action)
        {
            Transaction.Commit();
            var corporation = new Corporation()
            {
                Name = this.NewCorporationName,
                Agency = (RealEstateAgency)this.Data
            };
            AddCorporation(corporation);
          
        }
        void AddCorporation(Corporation corporation)
        {
            var corporationJson = Self.GET("/Hesham/partial/corporation/" + corporation.GetObjectID());
            this.Corporations.Add(corporationJson);
        }
    }
}
