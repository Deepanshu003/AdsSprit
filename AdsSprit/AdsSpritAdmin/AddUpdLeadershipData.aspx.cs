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
    public partial class AddUpdLeadershipData : System.Web.UI.Page
    {

        ManageException ObjEx = new ManageException();
        CommanFunction ObjComm = new CommanFunction();
        LeaderCategory ObjLeaderCategory = new LeaderCategory();
        LeaderData ObjLeaderData = new LeaderData();
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
                BindDdLeaderCategory();
                if (Request.QueryString["ID"] != null)
                {
                    trImageTArea.Visible = true;
                    trImageLArea.Visible = true;
                    btnSave.Text = "Update";
                    ObjLeaderData.LeaderDataID = Convert.ToInt16(Request.QueryString["ID"]);
                    SqlReader = ObjLeaderData.SelectLeaderDataByLeaderDataID();
                    filldata(SqlReader);
                    btnSave.Attributes.Add("OnClick", "return pagecheck1();");
                }
                else
                {
                    trImageTArea.Visible = false;
                    trImageLArea.Visible = false;
                    btnSave.Attributes.Add("OnClick", "return pagecheck();");

                    int displayOrde = ObjLeaderCategory.SelectMaxDisplayOrder();
                    if (displayOrde > 0)
                        txtDisplayOrder.Text = (displayOrde + 1).ToString();
                    else
                        txtDisplayOrder.Text = "1";
                    btnSave.Attributes.Add("OnClick", "javascript:return pagecheck();");
                }
            }
            ThumbImg1.Attributes.Add("onchange", "return validateFileUploadT(this);");
            LargeImg1.Attributes.Add("onchange", "return validateFileUploadL(this);");
        }

        private void BindDdLeaderCategory()
        {
            ObjLeaderCategory.SelectAllAllLeaderForDD(DdLeaderCategory, "LeaderName", "LeaderID");
            DdLeaderCategory.Items.Insert(0, new ListItem("Select LEADERSHIP Category", "0"));
        }

        private void filldata(SqlDataReader SqlReader)
        {
            while (SqlReader.Read())
            {
                DdLeaderCategory.SelectedValue = SqlReader["LeaderID"].ToString();
                txtLeaderTitle.Text = SqlReader["LeaderTitle"].ToString();
                txtTitleURL.Text = SqlReader["LeaderTitleURL"].ToString();
               // txtleaderrole.Text = SqlReader["LeaderRole"].ToString();
                if (SqlReader["DefaultImg"].ToString() != "")
                    Image1.ImageUrl = "../AdsSpritImages/LeaderImage/" + SqlReader["DefaultImg"].ToString();

                if (SqlReader["LargeImg"].ToString() != "")
                    Image2.ImageUrl = "../AdsSpritImages/LeaderImage/" + SqlReader["LargeImg"].ToString();

                txtBlogSmallDesc.Text = SqlReader["SmallDescription"].ToString();
                textarea1.Value = SqlReader["Descriptions"].ToString();
                txtVideoURl.Text = SqlReader["VideoURl"].ToString();
                txtDisplayOrder.Text = SqlReader["SortOrder"].ToString();
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


        protected void txtLeaderTitle_TextChanged(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                string strTitle = Regex.Replace(txtLeaderTitle.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strTitle = strTitle.ToLower();
                strTitle = strTitle.Replace("&", "and");
                strTitle = strTitle.Replace(" ", "-");
                txtTitleURL.Text = strTitle;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
                SaveLeaderData();
            if (btnSave.Text == "Update")
                UpdateLeaderData();
        }

        private void SaveLeaderData()
        {
            string ThumbImage1 = "";
            string LargeImage1 = "";
            int ret;
            try
            {
                ObjLeaderData.LeaderID = Convert.ToInt16(DdLeaderCategory.SelectedValue);
                ObjLeaderData.LeaderTitle = txtLeaderTitle.Text;
                string strBlogTitleURL = Regex.Replace(txtLeaderTitle.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strBlogTitleURL = strBlogTitleURL.ToLower();
                strBlogTitleURL = strBlogTitleURL.Replace("&", "and");
                strBlogTitleURL = strBlogTitleURL.Replace(" ", "-");
                ObjLeaderData.LeaderTitleURL = txtLeaderTitle.Text;
                ObjLeaderData.LeaderRole = txtleaderrole.Text;

                if (ThumbImg1.Value != "")
                {
                    ThumbImage1 = ObjComm.UniqueFileName(Session);
                    ThumbImage1 = ThumbImage1 + getContentType(ThumbImg1.Value);
                    ObjLeaderData.DefaultImg = ThumbImage1.ToString();
                }
                else
                    ObjLeaderData.DefaultImg = "";

                if (LargeImg1.Value != "")
                {
                    LargeImage1 = ObjComm.UniqueFileName(Session);
                    LargeImage1 = LargeImage1 + getContentType(LargeImg1.Value);
                    ObjLeaderData.LargeImg = LargeImage1.ToString();
                }
                else
                    ObjLeaderData.LargeImg = "";

                ObjLeaderData.SmallDescription = txtBlogSmallDesc.Text;
                ObjLeaderData.Descriptions = textarea1.Value;
                ObjLeaderData.SortOrder = Convert.ToInt16(txtDisplayOrder.Text);
                ObjLeaderData.VideoURl = txtVideoURl.Text;
                ObjLeaderData.MetaTitle = txtMetaTitle.Text;
                ObjLeaderData.MetaKeywords = txtMetaKeywords.Text;
                ObjLeaderData.MetaDescriptions = txtMetaDescriptions.Text;
                ObjLeaderData.MetaSchema = txtMetaSchema.Text;

                if (CheckBox1.Checked == true)
                    ObjLeaderData.ActiveStatus = 1;
                else
                    ObjLeaderData.ActiveStatus = 0;
                ObjLeaderData.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjLeaderData.SaveNewLeaderData();
                if (ret == 1)
                {
                    if (ThumbImg1.Value != "")
                        ObjComm.fileUpLoad(ThumbImg1, "../AdsSpritImages/LeaderImage", ThumbImage1, Server);

                    if (LargeImg1.Value != "")
                        ObjComm.fileUpLoad(LargeImg1, "../AdsSpritImages/LeaderImage", LargeImage1, Server);

                    Session["msg"] = "Record Added Successfully";
                    Response.Redirect("/AdsSpritAdmin/manage-Leader");
                }
                else if (ret != -1)
                    lblError.Text = "Title Already Exists in the same category";
                else
                    lblError.Text = "An error occured !! Please try after some time.";
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SaveLeaderData()", ex);
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

        private void UpdateLeaderData()
        {
            int ret;
            string ThumbImage1 = "";
            string LargeImage1 = "";
            try
            {
                ObjLeaderData.LeaderDataID = Convert.ToInt16(Request.QueryString["ID"].ToString());
                ObjLeaderData.LeaderID = Convert.ToInt16(DdLeaderCategory.SelectedValue);
                ObjLeaderData.LeaderTitle = txtLeaderTitle.Text;
                string strBlogTitleURL = Regex.Replace(txtLeaderTitle.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strBlogTitleURL = strBlogTitleURL.ToLower();
                strBlogTitleURL = strBlogTitleURL.Replace("&", "and");
                strBlogTitleURL = strBlogTitleURL.Replace(" ", "-");
                ObjLeaderData.LeaderTitleURL = txtTitleURL.Text;
                ObjLeaderData.LeaderRole = txtleaderrole.Text;
                if (ThumbImg1.Value != "")
                {
                    ThumbImage1 = ObjComm.UniqueFileName(Session);
                    ThumbImage1 = ThumbImage1 + getContentType(ThumbImg1.Value);
                    ObjLeaderData.DefaultImg = ThumbImage1.ToString();
                }
                else
                {
                    ThumbImage1 = System.IO.Path.GetFileName(Image1.ImageUrl);
                    ObjLeaderData.DefaultImg = ThumbImage1.ToString();
                }

                if (LargeImg1.Value != "")
                {
                    LargeImage1 = ObjComm.UniqueFileName(Session);
                    LargeImage1 = LargeImage1 + getContentType(LargeImg1.Value);
                    ObjLeaderData.LargeImg = LargeImage1.ToString();
                }
                else
                {
                    LargeImage1 = System.IO.Path.GetFileName(Image2.ImageUrl);
                    ObjLeaderData.LargeImg = LargeImage1.ToString();
                }
                ObjLeaderData.SortOrder = Convert.ToInt16(txtDisplayOrder.Text);
                ObjLeaderData.VideoURl = txtVideoURl.Text;
                ObjLeaderData.SmallDescription = txtBlogSmallDesc.Text;
                ObjLeaderData.Descriptions = textarea1.Value;

                ObjLeaderData.MetaTitle = txtMetaTitle.Text;
                ObjLeaderData.MetaKeywords = txtMetaKeywords.Text;
                ObjLeaderData.MetaDescriptions = txtMetaDescriptions.Text;
                ObjLeaderData.MetaSchema = txtMetaSchema.Text;

                if (CheckBox1.Checked == true)
                    ObjLeaderData.ActiveStatus = 1;
                else
                    ObjLeaderData.ActiveStatus = 0;
                ObjLeaderData.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjLeaderData.UpdateLeaderDataByLeaderDataID();
                if (ret == 1)
                {
                    if (ThumbImg1.Value != "")
                    {
                        ObjComm.fileUpLoad(ThumbImg1, "../AdsSpritImages/LeaderImage", ThumbImage1, Server);
                        DelImg(Image1.ImageUrl);
                    }
                    if (LargeImg1.Value != "")
                    {
                        ObjComm.fileUpLoad(LargeImg1, "../AdsSpritImages/LeaderImage", LargeImage1, Server);
                        DelImg(Image2.ImageUrl);
                    }
                    Session["msg"] = "File updated Successfully";
                    Response.Redirect("/AdsSpritAdmin/manage-Leader");
                }
                else if (ret != -1)
                    lblError.Text = "Blog Title Already Exists in the same category";
                else
                    lblError.Text = "An error occured !! Please try after some time.";

                ObjLeaderData = null;
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure UpdateLeaderData()", ex);
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
            Response.Redirect("/AdsSpritAdmin/manage-Leader");
        }

        protected void txtLeaderRole_TextChanged(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                string strTitle = Regex.Replace(txtLeaderTitle.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strTitle = strTitle.ToLower();
                strTitle = strTitle.Replace("&", "and");
                strTitle = strTitle.Replace(" ", "-");
                txtTitleURL.Text = strTitle;
            }
        }
    }
}