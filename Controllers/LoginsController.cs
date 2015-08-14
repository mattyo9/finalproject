using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProject.Models;
using FinalProject.Services;
using System.Web.Routing;


namespace FinalProject.Controllers
{
    [Authorize]
    public class LoginsController : ApiController
    {
        static Random rnd = new Random();
        List<Login> loginAttempts = new List<Login> 
        { 
            new Login { id = 1, username = "fido", timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 2, username = "fido", timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
            new Login { id = 3, username = "fido", timestamp = new DateTime(2015,rnd.Next(1,12),rnd.Next(1,28),rnd.Next(1,24),rnd.Next(0,59),rnd.Next(0,59))},
           
        };
        public string Get()
        {
            string finalOut = "<table>";
            foreach (Login l in loginAttempts)
            {
                finalOut += "<tr><td>"+l.id+"</td><td>Username: " + l.username + "</td><td>Timestamp: " + l.timestamp + "</td></tr>";
            }
            finalOut += "</table>";
            return finalOut;
        }
        public string Get(int id)
        {
            string finalOut = "<table>";
            foreach (Login l in loginAttempts)
            {
                if (l.id == id)
                {
                    finalOut += "<tr><td>" + l.id + "</td><td>Username: " + l.username +"</td><td>Timestamp: " + l.timestamp + "</td></tr>";
                }
            }
            finalOut += "</table>";
            return finalOut;
        }
        public string Delete(int id)
        {
            string finalOut = "<table>";
            foreach (Login l in loginAttempts)
            {
                if (l.id != id)
                {
                    finalOut += "<tr><td>" + l.id + "</td><td>Username: " + l.username + "</td><td>Timestamp: " + l.timestamp + "</td></tr>";
                }
            }
            finalOut += "</table>";
            return finalOut;
        }
    }
}
