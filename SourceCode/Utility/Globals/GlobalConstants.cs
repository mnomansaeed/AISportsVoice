using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
namespace Utility
{
    public static class GlobalConstants
    {
        public static UserProfile UserProfile;
        public static AccessRights Rights;
        public static List<int> UserRole;

        public static string UserIP;
        public static string AppVersion = "1.0";
        public static string CompanyName = "EGT";
        public static string IssuerSigningKey = "Tas16936661***++Tas16936661***++";
        public static string ClientId = "1";
        public static string ClientSecret = "secretEGT123456";
        public static string ValidIssuer = "http://localhost/AISportsRESTServiceAPI";
        public static string Audiance = "egt-tenants";

        // public static List<User> UserRightsList = new List<User>();

        public static string IPAddress
        {
            get
            {
                System.Web.HttpContext context = System.Web.HttpContext.Current;
                string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (!string.IsNullOrEmpty(ipAddress))
                {
                    string[] addresses = ipAddress.Split(',');
                    if (addresses.Length != 0)
                    {
                        return addresses[0];
                    }
                }

                return context.Request.ServerVariables["REMOTE_ADDR"];
            }
        }

        public const bool DefaultBoolean = false;
        public const int DefaultInteger = 0;
        public const long DefaultLong = 0;

        public const decimal DefaultDecimal = 0.00m;
        public const float DefaultFloat = 0.0f;
        public const string DefaultString = "";
        public const string DefaultDateTime = "1/1/1900 00:00:00 AM";
        public const int DefaultIsActive = 1;
        public const int DefaultAuditId = 1;
        public const string DefaultUserIP = "";
        public const int DefaultSiteId = 1;
        public const int DefaultCreatedBy = 1;
        public const int DefaultModifiedBy = 1;

        public const string REQUIRED_MESSAGE = "{0} is required.";
        public const string RANGE_MESSAGE = "{0} can only be between {1} and {2}";
        public const string MAXLENGTH_MESSAGE = "{0} lengh is exceeding the limit {1}";

        public enum LocationId
        {
            AdminLocation = 1,
            ClientLocation = 2
        }

        //end        
       
        public static void GetUserRights(string ScreenName)
        {
            //Rights = new AccessRights();
            //var res = (from a in UserRightsList
            //           where a.ScreenName.ToLower() == ScreenName.ToLower()
            //           select a).ToList();

            //if (res != null)
            //    if (res.Count > 0)
            //    {
            //        Rights.View = (bool)res[0].ViewRights;
            //        Rights.Add = (bool)res[0].AddRights;
            //        Rights.Edit = (bool)res[0].EditRights;
            //        Rights.Delete = (bool)res[0].DeleteRights;
            //        Rights.Print = (bool)res[0].ReportRights;
            //    }
            //if (res == null || res.Count == 0)
            //{
            //    Rights.View = false;
            //    Rights.Add = false;
            //    Rights.Edit = false;
            //    Rights.Delete = false;
            //    Rights.Print = false;
            //}
        }
    }
}

