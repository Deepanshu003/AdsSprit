using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Component;
using Utility;
using System.Text.RegularExpressions;
using System.Drawing;


namespace AdsSprit.AdsSpritAdmin
{
    public partial class AddUpdSize : System.Web.UI.Page
    {

        SizeData ObjSizeData = new SizeData();
        ManageException ObjEx = new ManageException();
        CommanFunction ObjComm = new CommanFunction();
        SqlDataReader SqlReader;
        protected void Page_Load(object sender, EventArgs e)
        {

            lblMsg.Text = Convert.ToString(Session["msg"]);
            Session["msg"] = null;
            if (Session["Admin"] == null)
            {
                Response.Redirect("/AdsSpritAdmin/login");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["SizeID"] != null)
                {
                    btnSave.Text = "Update";
                    ObjSizeData.SizeID = Convert.ToInt16(Request.QueryString["SizeID"]);
                    SqlReader = ObjSizeData.SelectSizeDataBySizeID();
                    filldata(SqlReader);
                    btnSave.Attributes.Add("OnClick", "javascript:return pagecheck1();");
                }
                else
                {
                    int displayOrde = ObjSizeData.SelectMaxDisplayOrder();
                    if (displayOrde > 0)
                        txtDisplayOrder.Text = (displayOrde + 1).ToString();
                    else
                        txtDisplayOrder.Text = "1";
                    btnSave.Attributes.Add("OnClick", "javascript:return pagecheck();");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (btnSave.Text == "Save")
                SaveCategory();
            else if (btnSave.Text == "Update")
                UpdateCategoryData();
        }

        private void UpdateCategoryData()
        {
            int ret;
            try
            {
                ObjSizeData.SizeID = Convert.ToInt16(Request.QueryString["SizeID"]);
                ObjSizeData.SizeName = txtCategoryName.Text + " " + DDSizeType.SelectedValue;
                ObjSizeData.SizeType = txtCategoryName.Text;
                ObjSizeData.SizeUnit = DDSizeType.SelectedValue;
                string strCategoryNameUrl = Regex.Replace(txtCategoryName.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strCategoryNameUrl = strCategoryNameUrl.ToLower();
                strCategoryNameUrl = strCategoryNameUrl.Replace("&", "and");
                strCategoryNameUrl = strCategoryNameUrl.Replace(" ", "-");
                ObjSizeData.SizeNameURL = strCategoryNameUrl.ToString();
                ObjSizeData.DisplayOrder = Convert.ToInt16(txtDisplayOrder.Text);
                if (chkStatus.Checked == true)
                    ObjSizeData.ActiveStatus = 1;
                else
                    ObjSizeData.ActiveStatus = 0;
                ObjSizeData.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjSizeData.UpdateSizeDataBySizeID();
                if (ret != -1)
                {

                    Session["msg"] = "Size Updated Successfully";
                    Response.Redirect("/AdsSpritAdmin/Size");
                }
                else
                {
                    lblError.Text = "Size Name Already Exists";
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure UpdateCategory()", ex);
            }
        }

        private void SaveCategory()
        {
            int ret;
            try
            {
                ObjSizeData.SizeName = txtCategoryName.Text + " " + DDSizeType.SelectedValue;
                ObjSizeData.SizeType = txtCategoryName.Text;
                ObjSizeData.SizeUnit = DDSizeType.SelectedValue;
                string strCategoryNameUrl = Regex.Replace(txtCategoryName.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strCategoryNameUrl = strCategoryNameUrl.ToLower();
                strCategoryNameUrl = strCategoryNameUrl.Replace("&", "and");
                strCategoryNameUrl = strCategoryNameUrl.Replace(" ", "-");
                ObjSizeData.SizeNameURL = strCategoryNameUrl.ToString();
                ObjSizeData.DisplayOrder = Convert.ToInt16(txtDisplayOrder.Text);
                if (chkStatus.Checked == true)
                    ObjSizeData.ActiveStatus = 1;
                else
                    ObjSizeData.ActiveStatus = 0;
                ObjSizeData.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjSizeData.SaveNewSize();
                if (ret != -1)
                {

                    Session["msg"] = "Size Successfully Added";
                    Response.Redirect("/AdsSpritAdmin/Size");
                }
                else
                {
                    lblError.Text = "Size Name Already Exists";
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SaveCategory()", ex);
            }
        }

        private void filldata(SqlDataReader SqlReader)
        {
            while (SqlReader.Read())
            {
                DDSizeType.SelectedValue = SqlReader["SizeUnit"].ToString();
                txtCategoryName.Text = SqlReader["SizeType"].ToString();
                txtDisplayOrder.Text = SqlReader["DisplayOrder"].ToString();
                if (SqlReader["ActiveStatus"].ToString() == "1")
                    chkStatus.Checked = true;
                else
                    chkStatus.Checked = false;
            }
            SqlReader.Close();
            SqlReader.Dispose();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/Size");
        }
    }
}