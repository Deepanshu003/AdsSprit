using Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdsSprit
{
    public partial class contactus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindIndexBannerImges();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Contact ObjContact = new Contact();
            int ret;
                bool containsLetter = Regex.IsMatch(txtPhone.Text.TrimStart(), "[A-Z]");
                if (containsLetter == false)
                {
                    try
                    {
                        ObjContact.FirstName = txtFirstName.Text.TrimStart();
                        ObjContact.LastName = txtLastName.Text.TrimStart();
                        ObjContact.EmailID = txtEmail.Text.TrimStart();
                        ObjContact.Message = txtMessage.Text.TrimStart();
                        ObjContact.PhoneNo = txtPhone.Text.TrimStart();
                        ObjContact.PostedDate = DateTime.UtcNow;
                        ret = ObjContact.SaveNewEnquiry();
                        if (ret != -1)
                        {
                            ObjContact = null;
                            Response.Redirect("/thankyou");
                        }
                    }
                    catch (Exception ex)
                    {
                
                    }
  
              }
            }

        private void BindIndexBannerImges()
        {

            Banner ObjBanner = new Banner();
            DataSet ds = new DataSet();
            ds = ObjBanner.SelectContactImage();
            if (ds.Tables[0].Rows.Count > 0)
            {

                RptrBannerImage.DataSource = ds.Tables[0];
                RptrBannerImage.DataBind();
                RptrBannerImage.Visible = true;
            }
            else
            {
                RptrBannerImage.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjBanner = null;
        }
    }
}