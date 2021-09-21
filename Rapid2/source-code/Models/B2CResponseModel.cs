﻿using System;
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

        public B2CResponseModel(string message, HttpStatusCode status)
        {
            this.userMessage = message;
            this.status = (int)status;
            this.version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
