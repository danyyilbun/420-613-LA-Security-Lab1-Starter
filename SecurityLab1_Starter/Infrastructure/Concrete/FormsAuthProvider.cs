
using SecurityLab1_Starter.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SecurityLab1_Starter.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
        public string getUsername(HttpCookie authCookie)
        {
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
            string UserName = ticket.Name; //You have the UserName!}
            return UserName;
        }
        public string getCookieName()
        {
            return FormsAuthentication.FormsCookieName; //Find cookie name
        }
    }
}