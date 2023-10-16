using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyJWTWebApp.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext():base("conStrDbConnectionString")
        {
                
        }
    }
}