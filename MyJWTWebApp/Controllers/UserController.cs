using MyJWTWebApp.Data;
using MyJWTWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyJWTWebApp.Controllers
{
    public class UserController : ApiController
    {
        ApplicationDBContext dbContext = new ApplicationDBContext();


        //This method will be acessable for the user those are having role type is User;
        [HttpGet]
        //[Authorize(Roles =("User"))]
        [Route("api/User/GetUserDetails")]
        public HttpResponseMessage GetUserDetails()
        {
            //Linq code
            //var user = dbContext.Employees.FirstOrDefault(e=>e.Id == userID)

            User user = new User();
            user.Email = "test.test@gmail.com";
            user.Roles = "Application User";
            user.ContactNumber = "+91-9856984533";
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }


        //This method will be acessable for the user those are having role type is Admin and Manager;
        [Authorize(Roles = ("Admin, Manager"))]
        [Route("api/User/GetAllUsers")]
        public HttpResponseMessage GetAllUsers(int userID)
        {
            //Linq code
            //var users = dbContext.Employees.Where(e=>e.userID < 10)

            User user1 = new User();
            user1.Email = "test1.test@gmail.com";
            user1.Roles = "Application User1";
            user1.ContactNumber = "+91-9856981111";

            User user2 = new User();
            user2.Email = "test2.test@gmail.com";
            user2.Roles = "Application User2";
            user2.ContactNumber = "+91-9856982222";

            List<User> users = new List<User>();
            users.Add(user1);
            users.Add(user2);

            return Request.CreateResponse(HttpStatusCode.OK, users);
        }
    }
}
