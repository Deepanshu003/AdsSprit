using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdsSprit.AdsSpritAdmin
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Page.ClientScript.RegisterStartupScript(typeof(Page), "logout", "<SCRIPT LANGUAGE='JAVASCRIPT'>history.go(-history.length);document.location.href='/AdsSpritAdmin/login';</SCRIPT>");
        
        }
    }
}