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
    public partial class AddUpdBanner : System.Web.UI.Page
    {
        ManageException ObjEx = new ManageException();
        CommanFunction ObjComm = new CommanFunction();
        Banner ObjBanner = new Banner();
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
                    ObjBanner.BannerID = Convert.ToInt16(Request.QueryString["ID"]);
                    SqlReader = ObjBanner.SelectBannerByID();
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
                txtBannerTitle.Text = SqlReader["BannerName"].ToString();
                txtTitleURL.Text = SqlReader["BannerNameURL"].ToString();
                if (SqlReader["LargeImage"].ToString() != "")
                {
                    Image2.ImageUrl = "../AdsSpritImages/CockTailImages/" + SqlReader["LargeImage"].ToString();
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

        private void SaveNewBanner()
        {
            string ThumbImage1 = "";
            string LargeImage1 = "";
            int ret;
            try
            {
                ObjBanner.BannerName = txtBannerTitle.Text;
                string strBlogTitleURL = Regex.Replace(txtBannerTitle.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strBlogTitleURL = strBlogTitleURL.ToLower();
                strBlogTitleURL = strBlogTitleURL.Replace("&", "and");
                strBlogTitleURL = strBlogTitleURL.Replace(" ", "-");
                ObjBanner.BannerNameURL = txtBannerTitle.Text;

                if (ThumbImg1.Value != "")
                {
                    ThumbImage1 = ObjComm.UniqueFileName(Session);
                    ThumbImage1 = ThumbImage1 + getContentType(ThumbImg1.Value);
                    ObjBanner.LargeImage = ThumbImage1.ToString();
                }
                else
                    ObjBanner.LargeImage = "";

                if (LargeImg1.Value != "")
                {
                    LargeImage1 = ObjComm.UniqueFileName(Session);
                    LargeImage1 = LargeImage1 + getContentType(LargeImg1.Value);
                    ObjBanner.LargeImage = LargeImage1.ToString();
                }
                else
                    ObjBanner.LargeImage = "";

                ObjBanner.Description = textarea1.Value;
                ObjBanner.MetaTitle = txtMetaTitle.Text;
                ObjBanner.MetaKeywords = txtMetaKeywords.Text;
                ObjBanner.MetaDescriptions = txtMetaDescriptions.Text;
                ObjBanner.MetaSchema = txtMetaSchema.Text;

                if (CheckBox1.Checked == true)
                    ObjBanner.ActiveStatus = 1;
                else
                    ObjBanner.ActiveStatus = 0;
                ObjBanner.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjBanner.SaveNewBanner();
                if (ret == 1)
                {
                    if (ThumbImg1.Value != "")
                        ObjComm.fileUpLoad(ThumbImg1, "../AdsSpritImages/CockTailImages", ThumbImage1, Server);

                    if (LargeImg1.Value != "")
                        ObjComm.fileUpLoad(LargeImg1, "../AdsSpritImages/CockTailImages", LargeImage1, Server);

                    Session["msg"] = "Record Added Successfully";
                    Response.Redirect("/AdsSpritAdmin/manage-Banner");
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

        private void UpdateBanner()
        {
            int ret;
            string ThumbImage1 = "";
            string LargeImage1 = "";
            try
            {
                ObjBanner.BannerID = Convert.ToInt16(Request.QueryString["ID"].ToString());
                ObjBanner.BannerName = txtBannerTitle.Text;
                string strBlogTitleURL = Regex.Replace(txtBannerTitle.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strBlogTitleURL = strBlogTitleURL.ToLower();
                strBlogTitleURL = strBlogTitleURL.Replace("&", "and");
                strBlogTitleURL = strBlogTitleURL.Replace(" ", "-");
                ObjBanner.BannerNameURL = txtTitleURL.Text;
                if (ThumbImg1.Value != "")
                {
                    ThumbImage1 = ObjComm.UniqueFileName(Session);
                    ThumbImage1 = ThumbImage1 + getContentType(ThumbImg1.Value);
                    ObjBanner.LargeImage = ThumbImage1.ToString();
                }
                else
                {
                    ThumbImage1 = System.IO.Path.GetFileName(Image1.ImageUrl);
                    ObjBanner.LargeImage = ThumbImage1.ToString();
                }

                if (LargeImg1.Value != "")
                {
                    LargeImage1 = ObjComm.UniqueFileName(Session);
                    LargeImage1 = LargeImage1 + getContentType(LargeImg1.Value);
                    ObjBanner.LargeImage = LargeImage1.ToString();
                }
                else
                {
                    LargeImage1 = System.IO.Path.GetFileName(Image2.ImageUrl);
                    ObjBanner.LargeImage = LargeImage1.ToString();
                }
                ObjBanner.Description = textarea1.Value;

                ObjBanner.MetaTitle = txtMetaTitle.Text;
                ObjBanner.MetaKeywords = txtMetaKeywords.Text;
                ObjBanner.MetaDescriptions = txtMetaDescriptions.Text;
                ObjBanner.MetaSchema = txtMetaSchema.Text;

                if (CheckBox1.Checked == true)
                    ObjBanner.ActiveStatus = 1;
                else
                    ObjBanner.ActiveStatus = 0;
                ObjBanner.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjBanner.UpdateBannerByID();
                if (ret == 1)
                {
                    if (ThumbImg1.Value != "")
                    {
                        ObjComm.fileUpLoad(ThumbImg1, "../AdsSpritImages/CockTailImages", ThumbImage1, Server);
                        DelImg(Image1.ImageUrl);
                    }
                    if (LargeImg1.Value != "")
                    {
                        ObjComm.fileUpLoad(LargeImg1, "../AdsSpritImages/CockTailImages", LargeImage1, Server);
                        DelImg(Image2.ImageUrl);
                    }
                    Session["msg"] = "File updated Successfully";
                    Response.Redirect("/AdsSpritAdmin/manage-Banner");
                }
                else if (ret != -1)
                    lblError.Text = "Blog Title Already Exists in the same category";
                else
                    lblError.Text = "An error occured !! Please try after some time.";

                ObjBanner = null;
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
                SaveNewBanner();
            if (btnSave.Text == "Update")
                UpdateBanner();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/manage-Banner");
        }

        protected void txtBannerTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}