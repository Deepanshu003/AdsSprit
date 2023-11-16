using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Component;
using Utility;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace AdsSprit.AdsSpritAdmin
{
    public partial class LeadrCategory : System.Web.UI.Page
    {

        ManageException ObjEx = new ManageException();
        SqlDataReader SqlReader;
        LeaderCategory objLeaderCategory = new LeaderCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("/AdsSpritAdmin/login");
            }
            lblMsg.Text = Convert.ToString(Session["msg"]);
            Session["msg"] = null;
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    btnSave.Text = "Update";
                    objLeaderCategory.LeaderID = Convert.ToInt16(Request.QueryString["ID"]);
                    SqlReader = objLeaderCategory.SelectLeaderByID();
                    filldata(SqlReader);
                }
            }
            btnSave.Attributes.Add("OnClick", "return pagecheck();");
        }

        private void filldata(SqlDataReader SqlReader)
        {
            while (SqlReader.Read())
            {
                txtBlogSmallDesc.Text = SqlReader["Description"].ToString();
                txtLeaderCategory.Text = SqlReader["LeaderName"].ToString();
                txtLeaderURL.Text = SqlReader["LeaderNameURL"].ToString();
                txtLeaderRole.Text = SqlReader["LeaderRole"].ToString();
                txtMetaTitle.Text = SqlReader["MetaTitle"].ToString();
                txtMetaKeywords.Text = SqlReader["MetaKeywords"].ToString();
                txtMetaDescriptions.Text = SqlReader["MetaDescriptions"].ToString();
                txtMetaSchema.Text = SqlReader["MetaSchema"].ToString();
                if (Convert.ToInt16(SqlReader["ActiveStatus"]) == 1)
                    chkStatus.Checked = true;
                else
                    chkStatus.Checked = false;
            }
            SqlReader.Close();
        }

        protected void txtLeaderCategory_TextChanged(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                string strTitle = Regex.Replace(txtLeaderCategory.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strTitle = strTitle.ToLower();
                strTitle = strTitle.Replace("&", "and");
                strTitle = strTitle.Replace(" ", "-");
                txtLeaderURL.Text = strTitle;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
                SaveLeader();
            else if (btnSave.Text == "Update")
                UpdateLeader();
        }

        private void SaveLeader()
        {
            int ret;
            try
            {
                objLeaderCategory.LeaderName = txtLeaderCategory.Text;
                string strTitle = Regex.Replace(txtLeaderCategory.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strTitle = strTitle.ToLower();
                strTitle = strTitle.Replace("&", "and");
                strTitle = strTitle.Replace(" ", "-");
                objLeaderCategory.LeaderNameURL = txtLeaderURL.Text;
                objLeaderCategory.LeaderRole = txtLeaderRole.Text;

                if (chkStatus.Checked == true)
                    objLeaderCategory.ActiveStatus = 1;
                else
                    objLeaderCategory.ActiveStatus = 0;

                objLeaderCategory.Description = txtBlogSmallDesc.Text;

                objLeaderCategory.MetaTitle = txtMetaTitle.Text;
                objLeaderCategory.MetaKeywords = txtMetaKeywords.Text;
                objLeaderCategory.MetaDescriptions = txtMetaDescriptions.Text;
                objLeaderCategory.MetaSchema = txtMetaSchema.Text;
                objLeaderCategory.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = objLeaderCategory.SaveNewLeader();
                if (ret != -1)
                {
                    Session["msg"] = "Blog Category Added Successfully";
                    Response.Redirect("/AdsSpritAdmin/manage-Leader-events");
                }
                else
                {
                    lblError.Text = "Duplicate Records";
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SaveLeaderCategory()", ex);
            }
        }

        private void UpdateLeader()
        {
            int ret;
            try
            {
                objLeaderCategory.LeaderID = Convert.ToInt16(Request.QueryString["ID"]);
                objLeaderCategory.LeaderName = txtLeaderCategory.Text;
                string strTitle = Regex.Replace(txtLeaderCategory.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strTitle = strTitle.ToLower();
                strTitle = strTitle.Replace("&", "and");
                strTitle = strTitle.Replace(" ", "-");
                objLeaderCategory.LeaderNameURL = txtLeaderURL.Text;
                objLeaderCategory.LeaderRole = txtLeaderRole.Text;

                if (chkStatus.Checked == true)
                    objLeaderCategory.ActiveStatus = 1;
                else
                    objLeaderCategory.ActiveStatus = 0;

                objLeaderCategory.Description = txtBlogSmallDesc.Text;

                objLeaderCategory.MetaTitle = txtMetaTitle.Text;
                objLeaderCategory.MetaKeywords = txtMetaKeywords.Text;
                objLeaderCategory.MetaDescriptions = txtMetaDescriptions.Text;
                objLeaderCategory.MetaSchema = txtMetaSchema.Text;
                objLeaderCategory.UpdatedBy = Convert.ToString(Session["Admin"]);
                objLeaderCategory.UpdatedOn = DateTime.UtcNow;
                ret = objLeaderCategory.UpdateLeaderByID();
                if (ret != -1)
                {
                    Session["msg"] = "Blog Category Name Updated Successfully";
                    Response.Redirect("/AdsSpritAdmin/manage-Leader-events");
                }
                else
                {
                    lblError.Text = "Dupicate Record";
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure UpdateBlogCategory()", ex);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/manage-Leader-events");
        }
    }
}