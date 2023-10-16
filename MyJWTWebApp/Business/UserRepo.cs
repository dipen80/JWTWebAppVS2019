using MyJWTWebApp.Data;
using MyJWTWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyJWTWebApp.Business
{
    public class UserRepo: IDisposable
    {
        ApplicationDBContext dbContext = new ApplicationDBContext();

        public User ValidateUser(string userName, string password)
        {       

            User _user = null;
            if (userName == "dipen" && password == "123")
            {
                _user = new User();
                _user.Email = "dipen.bhadra@tcs.com";
                _user.Roles = "Developer";
                _user.UserID = "dipen_bhadra";
            }

            return _user;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}