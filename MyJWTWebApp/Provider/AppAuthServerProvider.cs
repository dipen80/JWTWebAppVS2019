using Microsoft.Owin.Security.OAuth;
using MyJWTWebApp.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MyJWTWebApp.Provider
{
    public class AppAuthServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //return base.ValidateClientAuthentication(context);
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //return base.GrantResourceOwnerCredentials(context);

            using (UserRepo ur = new UserRepo())
            {
                var user = ur.ValidateUser(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("Invalid_Logic", "Invalid username and password");
                    return;
                }

                //context.Options.AuthenticationType ==> AuthenticationType may set in cosumer level
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Roles));
                //identity.AddClaim(new Claim(ClaimTypes.MobilePhone, user.ContactNumber));

                //For multiple roles adding claim, for ex: sample claim is coma seperated like "Admin,Client"
                foreach (var role in user.Roles.Split(','))
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role.Trim()));
                    //Or, 
                    identity.AddClaim(new Claim("OptionsRoles", role.Trim()));
                }
                context.Validated(identity);
            }
        }
    }
}
    