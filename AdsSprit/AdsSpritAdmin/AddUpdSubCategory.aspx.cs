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
    public partial class AddUpdSubCategory : System.Web.UI.Page
    {

        SubCategoryData ObjSubCategoryData = new SubCategoryData();
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
                BindDdCategory();
                if (Request.QueryString["SubCategoryID"] != null)
                {
                    btnSave.Text = "Update";
                    ObjSubCategoryData.SubCategoryID = Convert.ToInt16(Request.QueryString["SubCategoryID"]);
                    SqlReader = ObjSubCategoryData.SelectSubCategoryBySubCategoryID();
                    filldata(SqlReader);
                    btnSave.Attributes.Add("OnClick", "javascript:return pagecheck1();");
                }
                else
                {
                    int displayOrde = ObjSubCategoryData.SelectMaxDisplayOrder();
                    if (displayOrde > 0)
                        txtDisplayOrder.Text = (displayOrde + 1).ToString();
                    else
                        txtDisplayOrder.Text = "1";
                    btnSave.Attributes.Add("OnClick", "javascript:return pagecheck();");
                }
            }
            txtCategoryImage.Attributes.Add("onchange", "return validateFileUploadL(this);");
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
                txtFacebookURl.Text = SqlReader["FacebookURl"].ToString();
                DdCategory.SelectedValue = SqlReader["CategoryID"].ToString();
                txtCategoryName.Text = SqlReader["SubCategoryName"].ToString();
                txtTitleURL.Text = SqlReader["SubCategoryAlias"].ToString();
                if (SqlReader["SubCategoryImage"].ToString() != "")
                {
                    CategoryImageThumb.ImageUrl = "../AdsSpritImages/SubCategoryImages/" + SqlReader["SubCategoryImage"].ToString();
                    CategoryImageThumb.Visible = true;
                }
                if (SqlReader["SubCategoryImage1"].ToString() != "")
                {
                    Image2.ImageUrl = "../AdsSpritImages/SubCategoryImages/" + SqlReader["SubCategoryImage1"].ToString();
                    Image2.Visible = true;
                }
                txtCategorySmallDesc.Text = SqlReader["SubCategoryDescription"].ToString();
                txtDisplayOrder.Text = SqlReader["DisplayOrder"].ToString();
                txtMetaTitle.Text = SqlReader["SubCategoryMetaTitle"].ToString();
                txtMetaKeywords.Text = SqlReader["SubCategoryMetaKeywords"].ToString();
                txtMetaDescriptions.Text = SqlReader["SubCategoryMetaDescription"].ToString();
                txtMetaSchema.Text = SqlReader["MetaSchema"].ToString();
                if (SqlReader["ActiveStatus"].ToString() == "1")
                    chkStatus.Checked = true;
                else
                    chkStatus.Checked = false;
                if (SqlReader["DisplayOnHome"].ToString() == "1")
                    chkDisplayOnHome.Checked = true;
                else
                    chkDisplayOnHome.Checked = false;

                if (SqlReader["DisplayOnHeader"].ToString() == "1")
                    chkDisplayOnHeader.Checked = true;
                else
                    chkDisplayOnHeader.Checked = false;

                if (SqlReader["PartyItems"].ToString() == "1")
                    chkPartyItems.Checked = true;
                else
                    chkPartyItems.Checked = false;


                if (SqlReader["LookingForSomethingExpensive"].ToString() == "1")
                    chkLookingForSomethingExpensive.Checked = true;
                else
                    chkLookingForSomethingExpensive.Checked = false;
                if (SqlReader["PhotoCategory"].ToString() == "1")
                    chkPhotoCategory.Checked = true;
                else
                    chkPhotoCategory.Checked = false;
            }
            SqlReader.Close();
            SqlReader.Dispose();
        }

        protected void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                string strTitle = Regex.Replace(txtCategoryName.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strTitle = strTitle.ToLower();
                strTitle = strTitle.Replace("&", "and");
                strTitle = strTitle.Replace(" ", "-");
                txtTitleURL.Text = strTitle;
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
            CommanFunction ObjComm = new CommanFunction();
            string ThumbImage1 = "";
            string LargeImage1 = "";
            int ret;
            try
            {
                ObjSubCategoryData.SubCategoryID = Convert.ToInt16(Request.QueryString["SubCategoryID"]);
                ObjSubCategoryData.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
                ObjSubCategoryData.SubCategoryName = txtCategoryName.Text;
                string strCategoryNameUrl = Regex.Replace(txtCategoryName.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strCategoryNameUrl = strCategoryNameUrl.ToLower();
                strCategoryNameUrl = strCategoryNameUrl.Replace("&", "and");
                strCategoryNameUrl = strCategoryNameUrl.Replace(" ", "-");
                ObjSubCategoryData.SubCategoryAlias = txtTitleURL.Text;
                if (txtCategoryImage.Value != "")
                {
                    ThumbImage1 = strCategoryNameUrl + "ads-sprit";
                    ThumbImage1 = ThumbImage1 + getContentType(txtCategoryImage.Value);
                    ObjSubCategoryData.SubCategoryImage = ThumbImage1.ToString();
                }
                else
                {
                    ThumbImage1 = System.IO.Path.GetFileName(CategoryImageThumb.ImageUrl);
                    ObjSubCategoryData.SubCategoryImage = ThumbImage1.ToString();
                }
                if (LargeImg1.Value != "")
                {
                    LargeImage1 = strCategoryNameUrl + "-B-ads-sprit";
                    LargeImage1 = LargeImage1 + getContentType(LargeImg1.Value);
                    ObjSubCategoryData.SubCategoryImage1 = LargeImage1.ToString();
                }
                else
                {
                    LargeImage1 = System.IO.Path.GetFileName(Image2.ImageUrl);
                    ObjSubCategoryData.SubCategoryImage1 = LargeImage1.ToString();
                }

                ObjSubCategoryData.SubCategoryDescription = txtCategorySmallDesc.Text;
                ObjSubCategoryData.DisplayOrder = Convert.ToInt16(txtDisplayOrder.Text);
                ObjSubCategoryData.SubCategoryMetaTitle = txtMetaTitle.Text;
                ObjSubCategoryData.SubCategoryMetaKeywords = txtMetaKeywords.Text;
                ObjSubCategoryData.SubCategoryMetaDescription = txtMetaDescriptions.Text;
                ObjSubCategoryData.MetaSchema = txtMetaSchema.Text;
                if (chkStatus.Checked == true)
                    ObjSubCategoryData.ActiveStatus = 1;
                else
                    ObjSubCategoryData.ActiveStatus = 0;
                if (chkDisplayOnHome.Checked == true)
                    ObjSubCategoryData.DisplayOnHome = 1;
                else
                    ObjSubCategoryData.DisplayOnHome = 0;

                if (chkDisplayOnHeader.Checked == true)
                    ObjSubCategoryData.DisplayOnHeader = 1;
                else
                    ObjSubCategoryData.DisplayOnHeader = 0;

                if (chkPartyItems.Checked == true)
                    ObjSubCategoryData.PartyItems = 1;
                else
                    ObjSubCategoryData.PartyItems = 0;

                if (chkLookingForSomethingExpensive.Checked == true)
                    ObjSubCategoryData.LookingForSomethingExpensive = 1;
                else
                    ObjSubCategoryData.LookingForSomethingExpensive = 0;
                if (chkPhotoCategory.Checked == true)
                    ObjSubCategoryData.PhotoCategory = 1;
                else
                    ObjSubCategoryData.PhotoCategory = 0;

                ObjSubCategoryData.UpdatedBy = Convert.ToString(Session["Admin"]);
                ObjSubCategoryData.UpdatedOn = DateTime.UtcNow;
                ObjSubCategoryData.FacebookURl = txtFacebookURl.Text;
                ret = ObjSubCategoryData.UpdateSubCategory();
                if (ret != -1)
                {
                    if (txtCategoryImage.Value != "")
                    {
                        ObjComm.fileUpLoad(txtCategoryImage, "../AdsSpritImages/SubCategoryImages", ThumbImage1, Server);
                        DelImg(CategoryImageThumb.ImageUrl);
                    }
                    if (LargeImg1.Value != "")
                    {
                        ObjComm.fileUpLoad(LargeImg1, "../AdsSpritImages/SubCategoryImages", LargeImage1, Server);
                        DelImg(Image2.ImageUrl);
                    }

                    Session["msg"] = "Sub Category Name Updated Successfully";
                    Response.Redirect("/AdsSpritAdmin/sub-category");
                }
                else
                {
                    lblError.Text = "Category Name Already Exists";
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure UpdateSubCategory()", ex);
            }
        }

        private void SaveCategory()
        {
            CommanFunction ObjComm = new CommanFunction();
            string ThumbImage1 = "";
            string LargeImage1 = "";
            int ret;
            string strBrandImage = string.Empty;
            try
            {
                ObjSubCategoryData.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
                ObjSubCategoryData.SubCategoryName = txtCategoryName.Text;
                string strCategoryNameUrl = Regex.Replace(txtCategoryName.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strCategoryNameUrl = strCategoryNameUrl.ToLower();
                strCategoryNameUrl = strCategoryNameUrl.Replace("&", "and");
                strCategoryNameUrl = strCategoryNameUrl.Replace(" ", "-");
                ObjSubCategoryData.SubCategoryAlias = txtTitleURL.Text;
                if (txtCategoryImage.Value != "")
                {
                    ThumbImage1 = strCategoryNameUrl + "ads-sprit";
                    ThumbImage1 = ThumbImage1 + getContentType(txtCategoryImage.Value);
                    ObjSubCategoryData.SubCategoryImage = ThumbImage1.ToString();
                }
                else
                    ObjSubCategoryData.SubCategoryImage = "";
                if (LargeImg1.Value != "")
                {
                    LargeImage1 = strCategoryNameUrl + "-B-ads-sprit";
                    LargeImage1 = LargeImage1 + getContentType(LargeImg1.Value);
                    ObjSubCategoryData.SubCategoryImage1 = LargeImage1.ToString();
                }
                else
                    ObjSubCategoryData.SubCategoryImage1 = "";

                ObjSubCategoryData.SubCategoryDescription = txtCategorySmallDesc.Text;
                ObjSubCategoryData.DisplayOrder = Convert.ToInt16(txtDisplayOrder.Text);
                ObjSubCategoryData.SubCategoryMetaTitle = txtMetaTitle.Text;
                ObjSubCategoryData.SubCategoryMetaKeywords = txtMetaKeywords.Text;
                ObjSubCategoryData.SubCategoryMetaDescription = txtMetaDescriptions.Text;
                ObjSubCategoryData.MetaSchema = txtMetaSchema.Text;
                if (chkStatus.Checked == true)
                    ObjSubCategoryData.ActiveStatus = 1;
                else
                    ObjSubCategoryData.ActiveStatus = 0;
                if (chkDisplayOnHome.Checked == true)
                    ObjSubCategoryData.DisplayOnHome = 1;
                else
                    ObjSubCategoryData.DisplayOnHome = 0;
                if (chkDisplayOnHeader.Checked == true)
                    ObjSubCategoryData.DisplayOnHeader = 1;
                else
                    ObjSubCategoryData.DisplayOnHeader = 0;

                if (chkPartyItems.Checked == true)
                    ObjSubCategoryData.PartyItems = 1;
                else
                    ObjSubCategoryData.PartyItems = 0;

                if (chkLookingForSomethingExpensive.Checked == true)
                    ObjSubCategoryData.LookingForSomethingExpensive = 1;
                else
                    ObjSubCategoryData.LookingForSomethingExpensive = 0;
                if (chkPhotoCategory.Checked == true)
                    ObjSubCategoryData.PhotoCategory = 1;
                else
                    ObjSubCategoryData.PhotoCategory = 0;
                ObjSubCategoryData.FacebookURl = txtFacebookURl.Text;
                ObjSubCategoryData.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjSubCategoryData.SaveSubCategory();
                if (ret != -1)
                {
                    if (LargeImg1.Value != "")
                        ObjComm.fileUpLoad(LargeImg1, "../AdsSpritImages/SubCategoryImages", LargeImage1, Server);
                    if (txtCategoryImage.Value != "")
                        ObjComm.fileUpLoad(txtCategoryImage, "../AdsSpritImages/SubCategoryImages", ThumbImage1, Server);

                    Session["msg"] = "Sub Category Successfully Added";
                    Response.Redirect("/AdsSpritAdmin/sub-category");
                }
                else
                {
                    lblError.Text = "Category Name Already Exists";
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SaveSubCategory()", ex);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/sub-category");
        }

        private void SaveComboImage(int widthhhh, int heightttt, string fileNameee)
        {
            CommanFunction ObjComm = new CommanFunction();
            try
            {
                string originalFilePath;
                //filepath = HttpContext.Current.Server.MapPath("../temp/");
                ObjComm.fileUpLoad(txtCategoryImage, "../AdsSpritAdmin/temp/", fileNameee, Server);
                //FileUpload1.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("temp/" + ProductSmallImg));
                originalFilePath = HttpContext.Current.Server.MapPath("../AdsSpritAdmin/temp/" + fileNameee);
                string thumbnailFilePath = string.Empty;

                Size newSize = new Size(widthhhh, heightttt);
                using (Bitmap bmp = new Bitmap(originalFilePath))
                {
                    thumbnailFilePath = HttpContext.Current.Server.MapPath("../AdsSpritAdmin/SubCategoryImages/" + fileNameee);
                    using (Bitmap thumb = new Bitmap((System.Drawing.Image)bmp, newSize))
                    {
                        using (Graphics g = Graphics.FromImage(thumb)) // Create Graphics object from original ImagC:\Users\_)\Documents\Visual Studio 2010\Projects\May2019\24-05-19\CentreForAmbitionWeb\CentreForAmbitionWeb\AdsSpritAdmin\e
                        {
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                            //Set Image codec of JPEG type, the index of JPEG codec is "1"
                            System.Drawing.Imaging.ImageCodecInfo codec = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];
                            //Set the parameters for defining the quality of the thumbnail... here it is set to 100%
                            System.Drawing.Imaging.EncoderParameters eParams = new System.Drawing.Imaging.EncoderParameters(1);
                            eParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                            //Now draw the image on the instance of thumbnail Bitmap object
                            g.DrawImage(bmp, new Rectangle(0, 0, thumb.Width, thumb.Height));
                            thumb.Save(thumbnailFilePath, codec, eParams);
                        }
                    }
                }
                DelImg(Server.MapPath("../AdsSpritAdmin/temp/" + fileNameee));
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            ObjComm = null;
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
    }
}