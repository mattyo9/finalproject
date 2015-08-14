using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProject.Models;
using FinalProject.Services;
using System.Web.Routing;
using System.Web;
using System.Security.Principal;
using System.Threading;
using System.Text;
using System.Net.Http.Headers;


namespace FinalProject.Controllers
{
    [Authorize]
    public class AuthController : ApiController
    {
        List<User> user = new List<User> 
        { 
            new User { Id = 1, Username = "fido", Password = "1234pass",} 
        };

        public string Get(string username)
        {
            foreach (User u in user)
            {
                if (u.Username == username)
                    return "User: " + u.Username + " Pass: " + u.Password;
            }
            return "There are no users with that ID"; 
        }

        public string Post(string username, string password)
        {
            foreach (User u in user)
            {
                if (u.Username == username && u.Password == password)
                    return "User: " + u.Username + " Congradumalations! You've been Authentimacated!";
            }
            return "Invalid Username and/or Password";
        }
       
        public class loginInfo
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        public string Post(loginInfo logininfor)
        {
            foreach (User u in user)
            {
                if (u.Username == logininfor.username && u.Password == logininfor.password)
                {
                    return "true";
                }
            }
            return "false";
        }
    }
}


namespace WebHostBasicAuth.Modules
{
    public class BasicAuthHttpModule : IHttpModule
    {
        private const string Realm = "My Realm";

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
        private static bool CheckPassword(string username, string password)
        {
            return username == "api-user" && password == "1234pass";
        }

        private static void AuthenticateUser(string credentials)
        {
            try
            {
                var encoding = Encoding.GetEncoding("iso-8859-1");
                credentials = encoding.GetString(Convert.FromBase64String(credentials));

                int separator = credentials.IndexOf(':');
                string name = credentials.Substring(0, separator);
                string password = credentials.Substring(separator + 1);

                if (CheckPassword(name, password))
                {
                    var identity = new GenericIdentity(name);
                    SetPrincipal(new GenericPrincipal(identity, null));
                }
                else
                {
                    HttpContext.Current.Response.StatusCode = 401;
                }
            }
            catch (FormatException)
            {
                HttpContext.Current.Response.StatusCode = 401;
            }
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                if (authHeaderVal.Scheme.Equals("basic",
                        StringComparison.OrdinalIgnoreCase) &&
                    authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate",
                    string.Format("Basic realm=\"{0}\"", Realm));
            }
        }

        public void Dispose()
        {
        }
    }
}