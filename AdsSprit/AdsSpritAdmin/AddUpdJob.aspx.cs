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
    public partial class AddUpdJob : System.Web.UI.Page
    {
        ManageException ObjEx = new ManageException();
        SqlDataReader SqlReader;
        Job objJob = new Job();
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
                    objJob.JobID = Convert.ToInt16(Request.QueryString["ID"]);
                    SqlReader = objJob.SelectJobByID();
                    filldata(SqlReader);
                }
            }
            btnSave.Attributes.Add("OnClick", "return pagecheck();");
        }

        private void filldata(SqlDataReader SqlReader)
        {
            while (SqlReader.Read())
            {
                txtJobCategory.Text = SqlReader["JobName"].ToString();
                txtJobURL.Text = SqlReader["JobNameURL"].ToString();
                txtMetaTitle.Text = SqlReader["MetaTitle"].ToString();
                txtMetaKeywords.Text = SqlReader["MetaKeywords"].ToString();
                txtMetaDescriptions.Text = SqlReader["MetaDescriptions"].ToString();
                txtMetaSchema.Text = SqlReader["MetaSchema"].ToString();
                textarea1.Value = SqlReader["JobDescription"].ToString();
                txtJobType.Text = SqlReader["JobType"].ToString();
                if (Convert.ToInt16(SqlReader["ActiveStatus"]) == 1)
                    chkStatus.Checked = true;
                else
                    chkStatus.Checked = false;
            }
            SqlReader.Close();
        }

        protected void txtJob_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
                SaveJob();
            else if (btnSave.Text == "Update")
                UpdateJob();
        }

        private void SaveJob()
        {
            int ret;
            try
            {
                objJob.JobName = txtJobCategory.Text;
                string strTitle = Regex.Replace(txtJobCategory.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strTitle = strTitle.ToLower();
                strTitle = strTitle.Replace("&", "and");
                strTitle = strTitle.Replace(" ", "-");
                objJob.JobNameURL = txtJobURL.Text;

                if (chkStatus.Checked == true)
                    objJob.ActiveStatus = 1;
                else
                    objJob.ActiveStatus = 0;
                objJob.JobDescription = textarea1.Value;
                objJob.JobType = txtJobType.Text;
                objJob.MetaTitle = txtMetaTitle.Text;
                objJob.MetaKeywords = txtMetaKeywords.Text;
                objJob.MetaDescriptions = txtMetaDescriptions.Text;
                objJob.MetaSchema = txtMetaSchema.Text;
                objJob.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = objJob.SaveNewJob();
                if (ret != -1)
                {
                    Session["msg"] = "Blog Category Added Successfully";
                    Response.Redirect("/AdsSpritAdmin/manage-Job");
                }
                else
                {
                    lblError.Text = "Duplicate Records";
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SaveJob()", ex);
            }
        }

        private void UpdateJob()
        {
            int ret;
            try
            {
                objJob.JobID = Convert.ToInt16(Request.QueryString["ID"]);
                objJob.JobName = txtJobCategory.Text;
                string strTitle = Regex.Replace(txtJobCategory.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strTitle = strTitle.ToLower();
                strTitle = strTitle.Replace("&", "and");
                strTitle = strTitle.Replace(" ", "-");
                objJob.JobNameURL = txtJobURL.Text;

                if (chkStatus.Checked == true)
                    objJob.ActiveStatus = 1;
                else
                    objJob.ActiveStatus = 0;
                objJob.JobDescription = textarea1.Value;
                objJob.JobType = txtJobType.Text;
                objJob.MetaTitle = txtMetaTitle.Text;
                objJob.MetaKeywords = txtMetaKeywords.Text;
                objJob.MetaDescriptions = txtMetaDescriptions.Text;
                objJob.MetaSchema = txtMetaSchema.Text;
                objJob.UpdatedBy = Convert.ToString(Session["Admin"]);
                objJob.UpdatedOn = DateTime.UtcNow;
                ret = objJob.UpdateJobByID();
                if (ret != -1)
                {
                    Session["msg"] = "Job Category Name Updated Successfully";
                    Response.Redirect("/AdsSpritAdmin/manage-Job");
                }
                else
                {
                    lblError.Text = "Dupicate Record";
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure UpdateJobCategory()", ex);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/manage-Job");
        }

        protected void txtJobCategory_TextChanged(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                string strTitle = Regex.Replace(txtJobCategory.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strTitle = strTitle.ToLower();
                strTitle = strTitle.Replace("&", "and");
                strTitle = strTitle.Replace(" ", "-");
                txtJobURL.Text = strTitle;
            }
        }
    }
}