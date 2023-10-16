using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using MyJWTWebApp.Provider;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(MyJWTWebApp.Startup))]

namespace MyJWTWebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            
            //Here to control if get, push post methods are allowed
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                //this allows http and https both, if false then http will not work
                AllowInsecureHttp = true,

                //###########################################################################################################
                //to set the url type like for example: https://localhost:44376/token
                //for this this url have to use for api test and username: dipen; password: 123; grant_grant_type: password
                //in Body tab in POSTMAN BUDY tab not in PARAMS tab
                TokenEndpointPath = new PathString("/GenerateToken"),
                //###########################################################################################################

                //Allow token to valid till next 30 min
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new AppAuthServerProvider()
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
