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
    public partial class AddUpdAwards : System.Web.UI.Page
    {
        ManageException ObjEx = new ManageException();
        CommanFunction ObjComm = new CommanFunction();
        Awards ObjAwards = new Awards();
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
                BindDdCategory();
                if (Request.QueryString["ID"] != null)
                {
                    trImageLArea.Visible = true;
                    btnSave.Text = "Update";
                    ObjAwards.AwardsID = Convert.ToInt16(Request.QueryString["ID"]);
                    SqlReader = ObjAwards.SelectAwardsByID();
                    filldata(SqlReader);
                    btnSave.Attributes.Add("OnClick", "return pagecheck1();");
                }
                else
                {
                    btnSave.Attributes.Add("OnClick", "return pagecheck();");
                    btnSave.Attributes.Add("OnClick", "javascript:return pagecheck();");
                }
            }
            LargeImg1.Attributes.Add("onchange", "return validateFileUploadL(this);");
        }

        private void filldata(SqlDataReader SqlReader)
        {
            while (SqlReader.Read())
            {
                DdCategory.SelectedValue = SqlReader["CategoryID"].ToString();
                txtAwardsTitle.Text = SqlReader["AwardsName"].ToString();
                if (SqlReader["LargeImage"].ToString() != "") {
                 Image2.ImageUrl = "../AdsSpritImages/AwardsImage/" + SqlReader["LargeImage"].ToString();
                 Image2.Visible = true;
                }
                textarea1.Value = SqlReader["Description"].ToString();
                if (SqlReader["ActiveStatus"].ToString() == "1")
                    CheckBox1.Checked = true;
                else
                    CheckBox1.Checked = false;
            }
            SqlReader.Close();
            SqlReader.Dispose();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
                SaveNewAwards();
            if (btnSave.Text == "Update")
                UpdateAwards();
        }

        private void BindDdCategory()
        {
            CategoryData ObjCategoryData = new CategoryData();
            ObjCategoryData.BindDdCategory(DdCategory, "CategoryName", "CategoryID");
            DdCategory.Items.Insert(0, new ListItem("Select Category", "0"));
            ObjCategoryData = null;
        }

        private void SaveNewAwards()
        {
            string LargeImage1 = "";
            int ret;
            try
            {
                ObjAwards.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
                ObjAwards.AwardsName = txtAwardsTitle.Text;

                if (LargeImg1.Value != "")
                {
                    LargeImage1 = ObjComm.UniqueFileName(Session);
                    LargeImage1 = LargeImage1 + getContentType(LargeImg1.Value);
                    ObjAwards.LargeImage = LargeImage1.ToString();
                }
                else
                    ObjAwards.LargeImage = "";

                ObjAwards.Description = textarea1.Value;
                if (CheckBox1.Checked == true)
                    ObjAwards.ActiveStatus = 1;
                else
                    ObjAwards.ActiveStatus = 0;
                ObjAwards.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjAwards.SaveNewAwards();
                if (ret == 1)
                {
                    if (LargeImg1.Value != "")
                        ObjComm.fileUpLoad(LargeImg1, "../AdsSpritImages/AwardsImage", LargeImage1, Server);

                    Session["msg"] = "Record Added Successfully";
                    Response.Redirect("/AdsSpritAdmin/manage-awards");
                }
                else if (ret != -1)
                    lblError.Text = "Title Already Exists in the same category";
                else
                    lblError.Text = "An error occured !! Please try after some time.";
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SaveAwards()", ex);
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

        private void UpdateAwards()
        {
            int ret;
            string LargeImage1 = "";
            try
            {
                ObjAwards.AwardsID = Convert.ToInt16(Request.QueryString["ID"].ToString());
                ObjAwards.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
                ObjAwards.AwardsName = txtAwardsTitle.Text;
                if (LargeImg1.Value != "")
                {
                    LargeImage1 = ObjComm.UniqueFileName(Session);
                    LargeImage1 = LargeImage1 + getContentType(LargeImg1.Value);
                    ObjAwards.LargeImage = LargeImage1.ToString();
                }
                else
                {
                    LargeImage1 = System.IO.Path.GetFileName(Image2.ImageUrl);
                    ObjAwards.LargeImage = LargeImage1.ToString();
                }
                ObjAwards.Description = textarea1.Value;

                if (CheckBox1.Checked == true)
                    ObjAwards.ActiveStatus = 1;
                else
                    ObjAwards.ActiveStatus = 0;
                ObjAwards.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjAwards.UpdateAwardsByID();
                if (ret == 1)
                {
                    if (LargeImg1.Value != "")
                    {
                        ObjComm.fileUpLoad(LargeImg1, "../AdsSpritImages/AwardsImage", LargeImage1, Server);
                        DelImg(Image2.ImageUrl);
                    }
                    Session["msg"] = "File updated Successfully";
                    Response.Redirect("/AdsSpritAdmin/manage-awards");
                }
                else if (ret != -1)
                    lblError.Text = "Blog Title Already Exists in the same category";
                else
                    lblError.Text = "An error occured !! Please try after some time.";

                ObjAwards = null;
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure UpdateAwards()", ex);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/manage-awards");
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
        protected void txtCelebrationTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}