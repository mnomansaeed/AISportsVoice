using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;


namespace Utility
{
    public static class TicketHelper
    {
        public static void CreateAuthCookie(string userName, string userData, bool persistent)
        {
            DateTime issued = DateTime.Now;

            HttpCookie JMSAuthCookieCookie = FormsAuthentication.GetAuthCookie(userName, true);
            int formsTimeout = Convert.ToInt32((JMSAuthCookieCookie.Expires - DateTime.Now).TotalMinutes);

            DateTime expiration = DateTime.Now.AddMinutes(formsTimeout);
            string cookiePath = FormsAuthentication.FormsCookiePath;

            var ticket = new FormsAuthenticationTicket(0, userName, issued, expiration, true, userData, cookiePath);
            HttpCookie cookie = CreateAuthCookie(ticket, expiration, persistent);
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

        }

        private static HttpCookie CreateAuthCookie(FormsAuthenticationTicket ticket, DateTime expiration, bool persistent)
        {
            string Filling = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Filling)
            {
                Domain = FormsAuthentication.CookieDomain,
                Path = FormsAuthentication.FormsCookiePath
            };
            if (persistent)
            {
                cookie.Expires = expiration;
            }

            return cookie;
        }

        public static GlobalVar SetInformationAndGet(string data)
        {
            GlobalVar objGlobalVar = new GlobalVar();
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (cookie == null)
                    {
                        return null;
                    }
                    else
                    {


                        var decrypted = FormsAuthentication.Decrypt(cookie.Value);
                        if (!string.IsNullOrEmpty(decrypted.UserData))
                        {
                            objGlobalVar.SetData(decrypted.UserData);
                            objGlobalVar.UserId = Convert.ToInt32(data.Split(',')[0]);
                            objGlobalVar.CustomerId  = Convert.ToInt32(data.Split(',')[1]);
                            objGlobalVar.LocationId = Convert.ToInt32(data.Split(',')[2]);
                            objGlobalVar.UserGroupId = Convert.ToInt64(data.Split(',')[3]);
                            objGlobalVar.UserGroupName = data.Split(',')[4].ToString();

                            // Store UserData inside the Forms Ticket with all the attributes
                            // in sync with the web.config
                            var newticket = new FormsAuthenticationTicket(decrypted.Version,
                                                  decrypted.Name,
                                                  decrypted.IssueDate,
                                                  decrypted.Expiration,
                                                  true, // always persistent
                                                  objGlobalVar.GetData(),
                                                  decrypted.CookiePath);

                            // Encrypt the ticket and store it in the cookie
                            cookie.Value = FormsAuthentication.Encrypt(newticket);
                            cookie.Expires = newticket.Expiration.AddHours(1);
                            HttpContext.Current.Response.Cookies.Set(cookie);
                            var decrypted1 = FormsAuthentication.Decrypt(cookie.Value);
                            if (!string.IsNullOrEmpty(decrypted1.UserData))
                            {
                                objGlobalVar.SetData(decrypted1.UserData);

                                return objGlobalVar;
                            }
                        }
                    }

                }
            }
            return null;
        }

        public static GlobalVar GetUserData()
        {
            GlobalVar objGlobalVar = new GlobalVar();
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (cookie == null)
                    {
                        return null;
                    }
                    else
                    {
                        var decrypted = FormsAuthentication.Decrypt(cookie.Value);
                        if (!string.IsNullOrEmpty(decrypted.UserData))
                        {
                            objGlobalVar.SetData(decrypted.UserData);
                            return objGlobalVar;
                        }
                    }

                }
            }
            return null;
        }



    }
}
