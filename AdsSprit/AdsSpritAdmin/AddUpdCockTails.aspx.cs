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
    public partial class AddUpdCockTails : System.Web.UI.Page
    {

        ManageException ObjEx = new ManageException();
        CommanFunction ObjComm = new CommanFunction();
        CockTails ObjCockTails = new CockTails();
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
                    ObjCockTails.CockTailsID = Convert.ToInt16(Request.QueryString["ID"]);
                    SqlReader = ObjCockTails.SelectCockTailsByID();
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
        private void BindDdCategory()
        {
            CategoryData ObjCategoryData = new CategoryData();
            ObjCategoryData.BindDdCategory(DdCategory, "CategoryName", "CategoryID");
            DdCategory.Items.Insert(0, new ListItem("Select Category", "0"));
            ObjCategoryData = null;
        }
        private void filldata(SqlDataReader SqlReader)
        {
            while (SqlReader.Read())
            {
                DdCategory.SelectedValue = SqlReader["CategoryID"].ToString();
                txtAwardsTitle.Text = SqlReader["CockTailsName"].ToString();
                BindDdProduct();
                DdProduct.SelectedValue = SqlReader["ProductID"].ToString();
                if (SqlReader["LargeImage"].ToString() != "")
                {
                    Image2.ImageUrl = "../AdsSpritImages/CockTailImages/" + SqlReader["LargeImage"].ToString();
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

        private void SaveNewCockTails()
        {
            string LargeImage1 = "";
            int ret;
            try
            {
                ObjCockTails.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
                ObjCockTails.CockTailsName = txtAwardsTitle.Text;
                ObjCockTails.ProductID = Convert.ToInt32(DdProduct.SelectedValue);

                if (LargeImg1.Value != "")
                {
                    LargeImage1 = ObjComm.UniqueFileName(Session);
                    LargeImage1 = LargeImage1 + getContentType(LargeImg1.Value);
                    ObjCockTails.LargeImage = LargeImage1.ToString();
                }
                else
                    ObjCockTails.LargeImage = "";

                ObjCockTails.Description = textarea1.Value;

                if (CheckBox1.Checked == true)
                    ObjCockTails.ActiveStatus = 1;
                else
                    ObjCockTails.ActiveStatus = 0;
                ObjCockTails.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjCockTails.SaveNewCockTails();
                if (ret == 1)
                {
                    if (LargeImg1.Value != "")
                        ObjComm.fileUpLoad(LargeImg1, "../AdsSpritImages/CockTailImages", LargeImage1, Server);

                    Session["msg"] = "Record Added Successfully";
                    Response.Redirect("/AdsSpritAdmin/manage-cocktails");
                }
                else if (ret != -1)
                    lblError.Text = "Title Already Exists in the same category";
                else
                    lblError.Text = "An error occured !! Please try after some time.";
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SaveCockTails()", ex);
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

        private void UpdateCockTails()
        {
            int ret;
            string LargeImage1 = "";
            try
            {
                ObjCockTails.CockTailsID = Convert.ToInt16(Request.QueryString["ID"].ToString());
                ObjCockTails.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
                ObjCockTails.CockTailsName = txtAwardsTitle.Text;
                ObjCockTails.ProductID = Convert.ToInt32(DdProduct.SelectedValue);

                if (LargeImg1.Value != "")
                {
                    LargeImage1 = ObjComm.UniqueFileName(Session);
                    LargeImage1 = LargeImage1 + getContentType(LargeImg1.Value);
                    ObjCockTails.LargeImage = LargeImage1.ToString();
                }
                else
                {
                    LargeImage1 = System.IO.Path.GetFileName(Image2.ImageUrl);
                    ObjCockTails.LargeImage = LargeImage1.ToString();
                }
                ObjCockTails.Description = textarea1.Value;

                if (CheckBox1.Checked == true)
                    ObjCockTails.ActiveStatus = 1;
                else
                    ObjCockTails.ActiveStatus = 0;
                ObjCockTails.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjCockTails.UpdateCockTailsByID();
                if (ret == 1)
                {
                    if (LargeImg1.Value != "")
                    {
                        ObjComm.fileUpLoad(LargeImg1, "../AdsSpritImages/CockTailImages", LargeImage1, Server);
                        DelImg(Image2.ImageUrl);
                    }
                    Session["msg"] = "File updated Successfully";
                    Response.Redirect("/AdsSpritAdmin/manage-cocktails");
                }
                else if (ret != -1)
                    lblError.Text = "Blog Title Already Exists in the same category";
                else
                    lblError.Text = "An error occured !! Please try after some time.";

                ObjCockTails = null;
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

        protected void txtAwardsTitle_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
                SaveNewCockTails();
            if (btnSave.Text == "Update")
                UpdateCockTails();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/manage-cocktails");
        }

        protected void DdCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDdProduct(); 
        }

        private void BindDdProduct()
        {
          ProductData ObjProductData = new ProductData();
          ObjProductData.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
          ObjProductData.BindDdProduct(DdProduct, "ProductName", "ProductID");
          DdProduct.Items.Insert(0, new ListItem("Select Product Category", "0"));
          ObjProductData = null;
        }

    }
}