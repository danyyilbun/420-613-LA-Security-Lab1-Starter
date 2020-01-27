using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SecurityLab1_Starter.Infrastructure.Abstract {
    public interface IAuthProvider {
        bool Authenticate(string username, string password);
        void Logout();
        string getUsername(HttpCookie authCookie);
        string getCookieName();
    }
}
