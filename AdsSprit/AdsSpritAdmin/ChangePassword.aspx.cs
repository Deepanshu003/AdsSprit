using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Component;
using Utility;

namespace AdsSprit.AdsSpritAdmin
{
    public partial class ChangePassword : System.Web.UI.Page
    {

        ManageException ObjEx = new ManageException();
        CommanFunction ObjComm = new CommanFunction();
        AdminLogin ObjAdminLogin = new AdminLogin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("/ApnoGharAdmin/login");
            }
            lblMsg.Text = Convert.ToString(Session["msg"]);
            Session["msg"] = null;
            lblError.Text = "";
            btnSave.Attributes.Add("OnClick", "return pagecheck();");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdatePassword(); 
        }

        private void UpdatePassword()
        {
            int retval;

            try
            {
                ObjAdminLogin.OldPassword = txtOldPassword.Text;
                ObjAdminLogin.NewPasswords = txtNewPassword.Text;
                ObjAdminLogin.UserName = Convert.ToString(Session["Admin"]);
                ObjAdminLogin.UpdatedBy = Convert.ToString(Session["Admin"]);
                retval = ObjAdminLogin.ChangeAdminPassword();
                if (retval == -1)
                {
                    lblError.Text = "Invalid old Password";
                    lblMsg.Text = "";
                }
                else
                {
                    lblMsg.Text = "Password Updated Successfully";
                    lblError.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}