using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models;

namespace FinalProject.Models
{
    public class Login
    {
        public int id { get; set; }
        public string username { get; set; }
        public DateTime timestamp { get; set; }
    }
}