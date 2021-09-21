using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace AADB2C.WebAPI.Models
{
    public class B2CResponseModel
    {

        public string version { get; set; }
        public int status { get; set; }
        public string userMessage { get; set; }

        // Optional claims
        public string loyaltyNumber { get; set; }
        public string email { get; set; }
        public string house { get; set; }
        public string rate { get; set; }
        public string color { get; set; }
        public string random_field { get; set; }
        public IEnumerable<string> Custom_payload { get; set; }
        public string action { get; set; }
        public Boolean AllowedToLogin { get; set; }
        public Boolean EnforceMFA { get; set; }
        public Boolean ForceChangePassword { get; set; }

        public B2CResponseModel(string message, HttpStatusCode status)
        {
            this.userMessage = message;
            this.status = (int)status;
            this.version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
