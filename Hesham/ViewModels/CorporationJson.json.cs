using Starcounter;
namespace Hesham
{
    partial class CorporationJson : Json
    {
        void Handle(Input.NewFranchiseTrigger action)
        {
            Transaction.Commit();
            var franchise = new Models.Franchise()
            {
                Franchisee = (Models.Corporation)this.Data,
                Name = this.NewFranchiseName
            };
            AddFranchise(franchise);
        }
        void AddFranchise(Models.Franchise franchise)
        { 
            var franchiseJson = Self.GET("/Hesham/partial/franchise/" + franchise.GetObjectID());
            this.Franchises.Add(franchiseJson);
        }
    }
}
