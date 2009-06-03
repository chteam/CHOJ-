using System;
using System.Linq;
using System.Web;

namespace CHOJ
{
    public class HalfoxUser
    {
        const string Cookiekey = "chojcki";
        static readonly DateTime ExpireCookie = DateTime.Now.AddYears(-10);
        //  public static string UserId { get; set; }

        static public Boolean IsExists
        {
            get
            {
                if (!HttpContext.Current.Request.Cookies.AllKeys.Contains(Cookiekey))
                    return false;
                return RequestCookie != null;
            }
        }

        static HttpCookie RequestCookie
        {
            get { return HttpContext.Current.Request.Cookies[Cookiekey]; }
        }

        static HttpCookie ResponseCookie
        {
            get
            {
                if (HttpContext.Current.Response.Cookies[Cookiekey]==null)
                {
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie(Cookiekey));
                }
                return HttpContext.Current.Response.Cookies[Cookiekey];
            }
            set
            {
                value.Name =Cookiekey;
                HttpContext.Current.Response.Cookies.Add(value);
            }
        }

        static string GetCookieItem(string field)
        {

            if (!IsExists)
                return "";
            return RequestCookie[field] ?? "";
        }

        static void SetCookieItem(string field, string value)
        {
            ResponseCookie[field] = value;
        }

        ///<summary>����Cookie
        ///</summary>
       static  public void Clear()
        {
            ResponseCookie = new HttpCookie(Cookiekey) { Expires = ExpireCookie };
        }

        static public bool HasLogOn
        {
            get { return !string.IsNullOrEmpty(Id); }
        }

        static public string Id
        {
            get
            {
                return GetCookieItem("id");
            }
            set
            {
                SetCookieItem("id", value);
            }
        }
        static public string Value
        {
            get
            {
                return GetCookieItem("Value");
            }
            set
            {
                SetCookieItem("Value", value);
            }
        }
        static public string Name
        {
            get
            {
                return GetCookieItem("Name");
            }
            set
            {
                SetCookieItem("Name", value);
            }
        }
        /// <summary>
        /// �û�Cookie��Ϣ������ DateTime.Now.AddDays(365);
        /// </summary>
        static public DateTime Expires
        {
            set
            {
                ResponseCookie.Expires = value;
            }
        }


    }
}