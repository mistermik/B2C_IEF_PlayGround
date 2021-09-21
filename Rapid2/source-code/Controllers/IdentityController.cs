using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AADB2C.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace AADB2C.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class IdentityController : Controller
    {
        Random rnd = new Random();
        // Mik changes
        private static readonly string[] house = new[]
         {
            "Single", "MultiFamily", "Apartment", "Townhouse", "Condos"
         };
        private static readonly string[] rate = new[]
        {
            "Premium", "PayAsYouGo", "Monthly", "VIP"
         };
        private static readonly string[] color = new[]
         {
            "Red","Orange","Yellow","Green","Blue","Purple","Pink","Brown","Black","Gray","White","Red"
         };
        //End Mik changes


        /// <summary>
        /// Generates Random Claims.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Identity/Loyalty
        ///     {
        ///        "objectId" : "972vf6b1-2a74-4045-aadc-77d2f4c40611"
        ///     }
        ///
        /// </remarks>
        /// <param name="inputClaims">Required parameter ObjectId: Example: </param>
        /// <response code="200">Returns the newly created claims</response>
        /// <response code="409">If the item is null</response> 
        [HttpPost(Name = "loyalty")]
        public async Task<ActionResult> Loyalty([FromBody] InputClaimsModel inputClaims)
        {

            /// <summary>The unique identifier</summary>
            if (inputClaims == null)
            {
                return StatusCode((int)HttpStatusCode.Conflict, new B2CResponseModel("Request content is null", HttpStatusCode.Conflict));
            }
            //Check if the objectId parameter is presented
            if (inputClaims.objectId == null)
            {
                return StatusCode((int)HttpStatusCode.Conflict, new B2CResponseModel("User object Id is null or empty", HttpStatusCode.Conflict));
            }

            try
            {
                // IList<string> myclaims = new List<string>() { "valuea", "valueb", "valuec" };

                Boolean EnforceMFA = inputClaims.EnforceMFA;
                Boolean ForceChangePassword = inputClaims.ForceChangePassword;
                Boolean AllowedToLogin = inputClaims.AllowedToLogin;
                string displayname = inputClaims.displayname;
                string house_claim = house[rnd.Next(house.Length)];
                string rate_claim = rate[rnd.Next(rate.Length)];
                string color_claim = color[rnd.Next(color.Length)];

                if (displayname.Contains("mfa=true")) {
                    EnforceMFA = true;
                }

                if (displayname.Contains("pwdreset=true"))
                {
                    ForceChangePassword = true;
                }

                if (displayname.Contains("AllowedToLogin=false"))
                {
                    AllowedToLogin = false;
                }
                else { 
                    AllowedToLogin = true; 
                    }

                string random_field_claim = rnd.Next(1000, 9999).ToString();

                return StatusCode((int)HttpStatusCode.OK, new B2CResponseModel(string.Empty, HttpStatusCode.OK)
                {
                    //loyaltyNumber = inputClaims.language + "-" + rnd.Next(1000, 9999).ToString(),
                    

                    AllowedToLogin = AllowedToLogin,
                    EnforceMFA = EnforceMFA,
                    ForceChangePassword = ForceChangePassword,
                    house = house_claim,
                    rate = rate_claim,
                    color = color_claim,
                    random_field = random_field_claim,
                    Custom_payload = new List<string>() { house_claim, rate_claim, color_claim, random_field_claim},
                    action = "Continue",
                    //house = house[rnd.Next(house.Length)],
                    //house = house[rnd.Next(house.Length)],
                    //rate = rate[rnd.Next(rate.Length)],
                    //color = color[rnd.Next(color.Length)],
                    //random_field =  rnd.Next(1000, 9999).ToString(),
                    //custom_payload = "One,two,three,four",
                    //custom_payload2 = new List<string>() { house }
                    //custom_payload = B2CResponseModel.house, rate, color, random_field
                });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.Conflict, new B2CResponseModel($"General error (REST API): {ex.Message}", HttpStatusCode.Conflict));
            }
        }

        [HttpPost(Name = "validate")]
        public async Task<ActionResult> validate()
        {
            string input = null;

            // If not data came in, then return
            if (this.Request.Body == null)
            {
                return StatusCode((int)HttpStatusCode.Conflict, new B2CResponseModel("Request content is null", HttpStatusCode.Conflict));
            }

            // Read the input claims from the request body
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                input = await reader.ReadToEndAsync();
            }

            // Check input content value
            if (string.IsNullOrEmpty(input))
            {
                return StatusCode((int)HttpStatusCode.Conflict, new B2CResponseModel("Request content is empty", HttpStatusCode.Conflict));
            }

            // Convert the input string into InputClaimsModel object
            InputClaimsModel inputClaims = InputClaimsModel.Parse(input);

            if (inputClaims == null)
            {
                return StatusCode((int)HttpStatusCode.Conflict, new B2CResponseModel("Can not deserialize input claims", HttpStatusCode.Conflict));
            }

            //Check if the language parameter is presented
            if (string.IsNullOrEmpty(inputClaims.language))
            {
                return StatusCode((int)HttpStatusCode.Conflict, new B2CResponseModel("Language code is null or empty", HttpStatusCode.Conflict));
            }

            //Check if the email parameter is presented
            if (string.IsNullOrEmpty(inputClaims.email))
            {
                return StatusCode((int)HttpStatusCode.Conflict, new B2CResponseModel("Email is null or empty", HttpStatusCode.Conflict));
            }

            // Validate the email address 
            if (inputClaims.email.ToLower().StartsWith("test"))
            {
                return StatusCode((int)HttpStatusCode.Conflict, new B2CResponseModel("Your email address can't start with 'test'", HttpStatusCode.Conflict));
            }

            try
            {
                // Return the email in lower case format
                return StatusCode((int)HttpStatusCode.OK, new B2CResponseModel(string.Empty, HttpStatusCode.OK) {
                    loyaltyNumber = inputClaims.language + "-" + rnd.Next(1000, 9999).ToString(),
                    email = inputClaims.email.ToLower()
                });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.Conflict, new B2CResponseModel($"General error (REST API): {ex.Message}", HttpStatusCode.Conflict));
            }
        }

    }
}