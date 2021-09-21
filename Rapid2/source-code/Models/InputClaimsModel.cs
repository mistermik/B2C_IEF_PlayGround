﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AADB2C.WebAPI.Models
{
    public class InputClaimsModel
    {
        // Demo: User's object id in Azure AD B2C
        public string email { get; set; }
        
/// <summary>The unique identifier</summary>
        public string objectId { get; set; }
        public string language { get; set; }
        public Boolean EnforceMFA { get; set; }
        public Boolean ForceChangePassword { get; set; }
        public Boolean AllowedToLogin { get; set; }
        public string displayname { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static InputClaimsModel Parse(string JSON)
        {
            return JsonConvert.DeserializeObject(JSON, typeof(InputClaimsModel)) as InputClaimsModel;
        }
    }
}
