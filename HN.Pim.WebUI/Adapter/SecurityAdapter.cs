using System.ComponentModel.Composition;
using HN.Pim.WebUI.Core;
using WebMatrix.WebData;

namespace HN.Pim.WebUI.Adapter
{
    [Export(typeof(ISecurityAdapter))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SecurityAdapter : ISecurityAdapter
    {

        public void Initialize()
        {
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("HN-Pim-Dev", "Account", "AccountId", "LoginEmail", autoCreateTables: true);
        }

        public void Register(string loginEmail, string password, object propertyValues)
        {
            WebSecurity.CreateUserAndAccount(loginEmail, password, propertyValues);
        }

        public bool Login(string loginEmail, string password, bool rememberMe)
        {
            return WebSecurity.Login(loginEmail, password, persistCookie: rememberMe);
        }

        public bool ChangePassword(string loginEmail, string oldPassword, string newPassword)
        {
            return WebSecurity.ChangePassword(loginEmail, oldPassword, newPassword);
        }

        public bool UserExists(string loginEmail)
        {
            return WebSecurity.UserExists(loginEmail);
        }
    }
}