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

namespace AdsSprit.AdsSpritAdmin
{
    public partial class AddUpdSpiritsSource : System.Web.UI.Page
    {

        ManageException ObjEx = new ManageException();
        CommanFunction ObjComm = new CommanFunction();
        Detail ObjDetail = new Detail();
        SqlDataReader SqlReader;
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
                    trImageTArea.Visible = true;
                    trImageLArea.Visible = true;
                    btnSave.Text = "Update";
                    ObjDetail.DetailID = Convert.ToInt16(Request.QueryString["ID"]);
                    SqlReader = ObjDetail.SelectDetailByID();
                    filldata(SqlReader);
                    btnSave.Attributes.Add("OnClick", "return pagecheck1();");
                }
                else
                {
                    btnSave.Attributes.Add("OnClick", "return pagecheck();");
                    btnSave.Attributes.Add("OnClick", "javascript:return pagecheck();");
                }
            }
            ThumbImg1.Attributes.Add("onchange", "return validateFileUploadT(this);");
            LargeImg1.Attributes.Add("onchange", "return validateFileUploadL(this);");
        }

        private void filldata(SqlDataReader SqlReader)
        {
            while (SqlReader.Read())
            {
                txtSPIRITSSOURCETitle.Text = SqlReader["DetailName"].ToString();
                txtabv.Text = SqlReader["DetailColor"].ToString();
                txtColor.Text = SqlReader["DetailNOSE"].ToString();
                txtNose.Text = SqlReader["DetailPalate"].ToString();
                txtPlalate.Text = SqlReader["DetailABV"].ToString();
               // txtTitleURL.Text = SqlReader["AwardsNameURL"].ToString();
                if (SqlReader["LargeImage"].ToString() != "")
                {
                    Image2.ImageUrl = "../AdsSpritImages/SpiritSourceImage/" + SqlReader["LargeImage"].ToString();
                    Image2.Visible = true;
                }
                textarea1.Value = SqlReader["Description"].ToString();
                txtMetaTitle.Text = SqlReader["MetaTitle"].ToString();
                txtMetaKeywords.Text = SqlReader["MetaKeywords"].ToString();
                txtMetaDescriptions.Text = SqlReader["MetaDescriptions"].ToString();
                txtMetaDescriptions.Text = SqlReader["MetaDescriptions"].ToString();
                txtMetaSchema.Text = SqlReader["MetaSchema"].ToString();
                if (SqlReader["ActiveStatus"].ToString() == "1")
                    CheckBox1.Checked = true;
                else
                    CheckBox1.Checked = false;
            }
            SqlReader.Close();
            SqlReader.Dispose();
        }



        protected void txtSPIRITSSOURCETitle_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
                SaveNewSpirit();
            if (btnSave.Text == "Update")
                UpdateSpirit();
        }

        private void SaveNewSpirit()
        {
            string ThumbImage1 = "";
            string LargeImage1 = "";
            int ret;
            try
            {
                ObjDetail.DetailName = txtSPIRITSSOURCETitle.Text;
                ObjDetail.DetailColor = txtColor.Text;
                ObjDetail.DetailNOSE = txtNose.Text;
                ObjDetail.DetailPalate = txtPlalate.Text;
                ObjDetail.DetailABV = txtabv.Text;
                string strBlogTitleURL = Regex.Replace(txtSPIRITSSOURCETitle.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strBlogTitleURL = strBlogTitleURL.ToLower();
                strBlogTitleURL = strBlogTitleURL.Replace("&", "and");
                strBlogTitleURL = strBlogTitleURL.Replace(" ", "-");
                ObjDetail.DetailNameURL = txtSPIRITSSOURCETitle.Text;

                if (ThumbImg1.Value != "")
                {
                    ThumbImage1 = ObjComm.UniqueFileName(Session);
                    ThumbImage1 = ThumbImage1 + getContentType(ThumbImg1.Value);
                    ObjDetail.LargeImage = ThumbImage1.ToString();
                }
                else
                    ObjDetail.LargeImage = "";

                if (LargeImg1.Value != "")
                {
                    LargeImage1 = ObjComm.UniqueFileName(Session);
                    LargeImage1 = LargeImage1 + getContentType(LargeImg1.Value);
                    ObjDetail.LargeImage = LargeImage1.ToString();
                }
                else
                    ObjDetail.LargeImage = "";

                ObjDetail.Description = textarea1.Value;
                ObjDetail.MetaTitle = txtMetaTitle.Text;
                ObjDetail.MetaKeywords = txtMetaKeywords.Text;
                ObjDetail.MetaDescriptions = txtMetaDescriptions.Text;
                ObjDetail.MetaSchema = txtMetaSchema.Text;

                if (CheckBox1.Checked == true)
                    ObjDetail.ActiveStatus = 1;
                else
                    ObjDetail.ActiveStatus = 0;
                ObjDetail.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjDetail.SaveNewDetail();
                if (ret == 1)
                {
                    if (ThumbImg1.Value != "")
                        ObjComm.fileUpLoad(ThumbImg1, "../AdsSpritImages/SpiritSourceImage", ThumbImage1, Server);

                    if (LargeImg1.Value != "")
                        ObjComm.fileUpLoad(LargeImg1, "../AdsSpritImages/SpiritSourceImage", LargeImage1, Server);

                    Session["msg"] = "Record Added Successfully";
                    Response.Redirect("/AdsSpritAdmin/manage-spirits");
                }
                else if (ret != -1)
                    lblError.Text = "Title Already Exists in the same category";
                else
                    lblError.Text = "An error occured !! Please try after some time.";
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SaveBlogData()", ex);
            }
        }

        private string getContentType(string strPath)
        {

            string StrPath = Path.GetExtension(strPath).ToString();
            string StrExt = "";
            if (StrPath.ToLower().Equals(".jpg"))
                StrExt = ".jpg";
            else if (StrPath.ToLower().Equals(".jpeg"))
                StrExt = ".jpg";
            else if (StrPath.ToLower().Equals(".gif"))
                StrExt = ".gif";
            else if (StrPath.ToLower().Equals(".png"))
                StrExt = ".png";

            return StrExt;
        }

        private void UpdateSpirit()
        {
            int ret;
            string ThumbImage1 = "";
            string LargeImage1 = "";
            try
            {
                ObjDetail.DetailID = Convert.ToInt16(Request.QueryString["ID"].ToString());
                ObjDetail.DetailName = txtSPIRITSSOURCETitle.Text;
                ObjDetail.DetailColor = txtColor.Text;
                ObjDetail.DetailNOSE = txtNose.Text;
                ObjDetail.DetailPalate = txtPlalate.Text;
                ObjDetail.DetailABV = txtabv.Text;
                string strBlogTitleURL = Regex.Replace(txtSPIRITSSOURCETitle.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strBlogTitleURL = strBlogTitleURL.ToLower();
                strBlogTitleURL = strBlogTitleURL.Replace("&", "and");
                strBlogTitleURL = strBlogTitleURL.Replace(" ", "-");
                ObjDetail.DetailNameURL = txtTitleURL.Text;
                if (ThumbImg1.Value != "")
                {
                    ThumbImage1 = ObjComm.UniqueFileName(Session);
                    ThumbImage1 = ThumbImage1 + getContentType(ThumbImg1.Value);
                    ObjDetail.LargeImage = ThumbImage1.ToString();
                }
                else
                {
                    ThumbImage1 = System.IO.Path.GetFileName(Image1.ImageUrl);
                    ObjDetail.LargeImage = ThumbImage1.ToString();
                }

                if (LargeImg1.Value != "")
                {
                    LargeImage1 = ObjComm.UniqueFileName(Session);
                    LargeImage1 = LargeImage1 + getContentType(LargeImg1.Value);
                    ObjDetail.LargeImage = LargeImage1.ToString();
                }
                else
                {
                    LargeImage1 = System.IO.Path.GetFileName(Image2.ImageUrl);
                    ObjDetail.LargeImage = LargeImage1.ToString();
                }
                ObjDetail.Description = textarea1.Value;

                ObjDetail.MetaTitle = txtMetaTitle.Text;
                ObjDetail.MetaKeywords = txtMetaKeywords.Text;
                ObjDetail.MetaDescriptions = txtMetaDescriptions.Text;
                ObjDetail.MetaSchema = txtMetaSchema.Text;

                if (CheckBox1.Checked == true)
                    ObjDetail.ActiveStatus = 1;
                else
                    ObjDetail.ActiveStatus = 0;
                ObjDetail.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjDetail.UpdateDetailByID();
                if (ret == 1)
                {
                    if (ThumbImg1.Value != "")
                    {
                        ObjComm.fileUpLoad(ThumbImg1, "../AdsSpritImages/AwardsImage", ThumbImage1, Server);
                        DelImg(Image1.ImageUrl);
                    }
                    if (LargeImg1.Value != "")
                    {
                        ObjComm.fileUpLoad(LargeImg1, "../AdsSpritImages/AwardsImage", LargeImage1, Server);
                        DelImg(Image2.ImageUrl);
                    }
                    Session["msg"] = "File updated Successfully";
                    Response.Redirect("/AdsSpritAdmin/manage-spirits");
                }
                else if (ret != -1)
                    lblError.Text = "Blog Title Already Exists in the same category";
                else
                    lblError.Text = "An error occured !! Please try after some time.";

                ObjDetail = null;
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure UpdateBlogData()", ex);
            }
        }

        private void DelImg(string Path)
        {
            try
            {
                File.Delete(Path);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/manage-spirits");
        }
    }
}