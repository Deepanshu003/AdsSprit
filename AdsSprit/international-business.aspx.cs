using Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;
namespace AdsSprit
{
    public partial class international_business : System.Web.UI.Page
    {

        ManageException ObjEx = new ManageException();
        Contact ObjContact = new Contact();
        CategoryData ObjCategoryData = new CategoryData();
        ProductData ObjProductData = new ProductData();
        SqlDataReader SqlReader;
        int ProductID = 0;
        int CategoryID = 0;
        string ProductNameAlias = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategoryImages();
                BindIndexBannerImges();
            }
        }

        private void BindIndexBannerImges()
        {

            Banner ObjBanner = new Banner();
            DataSet ds = new DataSet();
            ds = ObjBanner.SelectBusinessBanner();
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
        #region Category Image       
        private void BindCategoryImages()
        {
            CategoryData ObjCategoryData = new CategoryData();
            DataSet ds = new DataSet();
            ds = ObjCategoryData.SelectActiveCategory();
            if (ds.Tables[0].Rows.Count > 0)
            {

                ReptCategoryImage1.DataSource = ds.Tables[0];
                ReptCategoryImage1.DataBind();
                ReptCategoryImage1.Visible = true;
            }
            else
            {
                ReptCategoryImage1.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjCategoryData = null;
        } 
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Contact ObjContact = new Contact();
            int ret;
            bool containsLetter = Regex.IsMatch(txtTelephone.Text.TrimStart(), "[A-Z]");
            if (containsLetter == false)
            {
                try
                {
                    ObjContact.FirstName = txtFirstName.Text.TrimStart();
                    ObjContact.LastName = txtLastName.Text.TrimStart();
                    ObjContact.EmailID = txtEmail.Text.TrimStart();
                    ObjContact.Message = txtQuery.Text.TrimStart();
                    ObjContact.Companywebsite = txtWebsite.Text.TrimStart();
                    ObjContact.Organisation = txtOrganisation.Text.TrimStart();
                    ObjContact.Designation = txtDesignation.Text.TrimStart();
                    ObjContact.PhoneNo = txtTelephone.Text.TrimStart();
                    ObjContact.Address = txtAddress.Text.TrimStart();
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
    }
}