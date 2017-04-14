using Starcounter;

namespace Hesham
{
    partial class FranchiseJson : Json
    {
        void Handle(Input.SaveSettingsTrigger action)
        {
            Transaction.Commit();
        }
    }
}
