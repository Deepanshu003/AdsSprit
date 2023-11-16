using Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace AdsSprit.AdsSpritAdmin
{
    public partial class index : System.Web.UI.Page
    {
        ManageException ObjEx = new ManageException();
        AdminLogin ObjAdminLogin = new AdminLogin();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                ObjAdminLogin.UserName = username.Text;
                ObjAdminLogin.Passwords = password.Text;

                DataSet ds = ObjAdminLogin.CheckAdminLogin();
                foreach (DataTable table in ds.Tables)
                {
                    if (table.Rows.Count != 0)
                    {
                        Session["AdminID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                        Session["Admin"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                        Session["LastLoginDate"] = ds.Tables[0].Rows[0]["LastLoginDate"].ToString();
                        Response.Redirect("/AdsSpritAdmin/Home");
                    }
                    else
                    {
                        lblError.Text = "Invalid User Name or Password";
                    }
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in Procedure submit_Click()", ex);
            }
        }
    }
}