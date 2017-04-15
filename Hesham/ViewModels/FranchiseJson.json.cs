using Starcounter;

namespace Hesham
{
    partial class FranchiseJson : Json
    {
        void Handle(Input.SaveSettingsTrigger action)
        {
            Transaction.Commit();
        }
        void Handle(Input.RegisterTrigger action)
        {
            Transaction.Commit();
            Models.Transaction transaction = new Models.Transaction()
            {
                OwnerFranchise = (Models.Franchise)this.Data,
                Date = this.NewTransaction.Date,
                Address = this.NewTransaction.Street + " " + this.NewTransaction.Number + ", " + this.NewTransaction.ZipCode + " " + this.NewTransaction.City + ", " + this.NewTransaction.Country,
                Commission = this.NewTransaction.Commission,
                SalesPrice = this.NewTransaction.SalesPrice
            };
         
            AddTransaction(transaction);
        }
        void AddTransaction(Models.Transaction transaction)
        {
            var transactionJson = new TransactionJson();
            transactionJson.Data = transaction;
            this.Transactions.Add(transactionJson);
            
        }
    }
}
