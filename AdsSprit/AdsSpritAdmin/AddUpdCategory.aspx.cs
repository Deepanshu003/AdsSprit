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
    public partial class AddUpdCategory : System.Web.UI.Page
    {

        CategoryData ObjCategoryData = new CategoryData();
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
                if (Request.QueryString["CategoryID"] != null)
                {
                    btnSave.Text = "Update";
                    ObjCategoryData.CategoryID = Convert.ToInt16(Request.QueryString["CategoryID"]);
                    SqlReader = ObjCategoryData.SelectCategoryByCategoryID();
                    filldata(SqlReader);
                    btnSave.Attributes.Add("OnClick", "javascript:return pagecheck1();");
                }
                else
                {
                    int displayOrde = ObjCategoryData.SelectMaxDisplayOrder();
                    if (displayOrde > 0)
                        txtDisplayOrder.Text = (displayOrde + 1).ToString();
                    else
                        txtDisplayOrder.Text = "1";
                    btnSave.Attributes.Add("OnClick", "javascript:return pagecheck();");
                }
            }
            txtCategoryImage.Attributes.Add("onchange", "return validateFileUploadL(this);");
        }

        private void filldata(SqlDataReader SqlReader)
        {
            while (SqlReader.Read())
            {
                txtCategoryName.Text = SqlReader["CategoryName"].ToString();
                txtTitleURL.Text = SqlReader["CategoryAlias"].ToString();
                if (SqlReader["CategoryImage"].ToString() != "")
                {
                    CategoryImageThumb.ImageUrl = "../AdsSpritImages/CategoryImages/" + SqlReader["CategoryImage"].ToString();
                    CategoryImageThumb.Visible = true;
                }
                if (SqlReader["CategoryImage1"].ToString() != "")
                {
                    Image2.ImageUrl = "../AdsSpritImages/CategoryImages/" + SqlReader["CategoryImage1"].ToString();
                    Image2.Visible = true;
                }
                if (SqlReader["CategoryImage2"].ToString() != "")
                {
                    Image1.ImageUrl = "../AdsSpritImages/CategoryImages/" + SqlReader["CategoryImage2"].ToString();
                    Image1.Visible = true;
                }
                txtFacebookURl.Text = SqlReader["FacebookURl"].ToString();
                txtCategorySmallDesc.Text = SqlReader["CategoryDescription"].ToString();
                txtsmalldescription.Text = SqlReader["CategorysmallDescription"].ToString();
                txtdesc.Text = SqlReader["Image2Description"].ToString();
                txtDisplayOrder.Text = SqlReader["DisplayOrder"].ToString();
                txtMetaTitle.Text = SqlReader["CategoryMetaTitle"].ToString();
                txtMetaKeywords.Text = SqlReader["CategoryMetaKeywords"].ToString();
                txtMetaDescriptions.Text = SqlReader["CategoryMetaDescription"].ToString();
                txtMetaSchema.Text = SqlReader["MetaSchema"].ToString();
                if (SqlReader["ActiveStatus"].ToString() == "1")
                    chkStatus.Checked = true;
                else
                    chkStatus.Checked = false;
                if (SqlReader["DisplayOnMenu"].ToString() == "1")
                    chkDisplayOnMenu.Checked = true;
                else
                    chkDisplayOnMenu.Checked = false;

                if (SqlReader["DisplayOnHeader"].ToString() == "1")
                    chkDisplayOnHeader.Checked = true;
                else
                    chkDisplayOnHeader.Checked = false;

                if (SqlReader["DisPlayOnCategory"].ToString() == "1")
                    chkcategory.Checked = true;
                else
                    chkcategory.Checked = false;
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
            string LargeImage2 = "";
            int ret;
            try
            {
                ObjCategoryData.CategoryID = Convert.ToInt16(Request.QueryString["CategoryID"]);
                ObjCategoryData.CategoryName = txtCategoryName.Text;
                string strCategoryNameUrl = Regex.Replace(txtCategoryName.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strCategoryNameUrl = strCategoryNameUrl.ToLower();
                strCategoryNameUrl = strCategoryNameUrl.Replace("&", "and");
                strCategoryNameUrl = strCategoryNameUrl.Replace(" ", "-");
                ObjCategoryData.CategoryAlias = txtTitleURL.Text;
                if (txtCategoryImage.Value != "")
                {
                    ThumbImage1 = strCategoryNameUrl + "-ads-sprit";
                    ThumbImage1 = ThumbImage1 + getContentType(txtCategoryImage.Value);
                    ObjCategoryData.CategoryImage = ThumbImage1.ToString();
                }
                else
                {
                    ThumbImage1 = System.IO.Path.GetFileName(CategoryImageThumb.ImageUrl);
                    ObjCategoryData.CategoryImage = ThumbImage1.ToString();
                }
                if (LargeImg1.Value != "")
                {
                    LargeImage1 = strCategoryNameUrl + "-B-ads-sprit";
                    LargeImage1 = LargeImage1 + getContentType(LargeImg1.Value);
                    ObjCategoryData.CategoryImage1 = LargeImage1.ToString();
                }
                else
                {
                    LargeImage1 = System.IO.Path.GetFileName(Image2.ImageUrl);
                    ObjCategoryData.CategoryImage1 = LargeImage1.ToString();
                }
                if (LargImg2.Value != "")
                {
                    LargeImage2 = strCategoryNameUrl + "-c-ads-sprit";
                    LargeImage2 = LargeImage2 + getContentType(LargImg2.Value);
                    ObjCategoryData.CategoryImage2 = LargeImage2.ToString();
                }
                else
                {
                    LargeImage2 = System.IO.Path.GetFileName(Image1.ImageUrl);
                    ObjCategoryData.CategoryImage2 = LargeImage2.ToString();
                }
                ObjCategoryData.FacebookURl = txtFacebookURl.Text;
                ObjCategoryData.CategoryDescription = txtCategorySmallDesc.Text;
                ObjCategoryData.CategorysmallDescription = txtsmalldescription.Text;
                ObjCategoryData.Image2Description = txtdesc.Text;
                ObjCategoryData.DisplayOrder = Convert.ToInt16(txtDisplayOrder.Text);
                ObjCategoryData.CategoryMetaTitle = txtMetaTitle.Text;
                ObjCategoryData.CategoryMetaKeywords = txtMetaKeywords.Text;
                ObjCategoryData.CategoryMetaDescription = txtMetaDescriptions.Text;
                ObjCategoryData.MetaSchema = txtMetaSchema.Text;
                if (chkStatus.Checked == true)
                    ObjCategoryData.ActiveStatus = 1;
                else
                    ObjCategoryData.ActiveStatus = 0;
                if (chkDisplayOnMenu.Checked == true)
                    ObjCategoryData.DisplayOnMenu = 1;
                else
                    ObjCategoryData.DisplayOnMenu = 0;

                if (chkDisplayOnHeader.Checked == true)
                    ObjCategoryData.DisplayOnHeader = 1;
                else
                    ObjCategoryData.DisplayOnHeader = 0;
                ObjCategoryData.PhotoCategory = 0;

                if (chkcategory.Checked == true)
                    ObjCategoryData.DisPlayOnCategory = 1;
                else
                    ObjCategoryData.DisPlayOnCategory = 0;
                ObjCategoryData.PhotoCategory = 0;

                ObjCategoryData.UpdatedBy = Convert.ToString(Session["Admin"]);
                ObjCategoryData.UpdatedOn = DateTime.UtcNow;

                ret = ObjCategoryData.UpdateCategory();
                if (ret != -1)
                {
                    if (txtCategoryImage.Value != "")
                    {
                        ObjComm.fileUpLoad(txtCategoryImage, "../AdsSpritImages/CategoryImages", ThumbImage1, Server);
                        //DelImg(CategoryImageThumb.ImageUrl);
                    }
                    if (LargeImg1.Value != "")
                    {
                        ObjComm.fileUpLoad(LargeImg1, "../AdsSpritImages/CategoryImages", LargeImage1, Server);
                        //DelImg(Image2.ImageUrl);
                    }
                    if (LargImg2.Value != "")
                    {
                        ObjComm.fileUpLoad(LargImg2, "../AdsSpritImages/CategoryImages", LargeImage2, Server);
                        //DelImg(Image2.ImageUrl);
                    }
                    Session["msg"] = "Category Name Updated Successfully";
                    Response.Redirect("/AdsSpritAdmin/category");
                }
                else
                {
                    lblError.Text = "Category Name Already Exists";
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure UpdateCategory()", ex);
            }
        }

        private void SaveCategory()
        {
            CommanFunction ObjComm = new CommanFunction();
            string ThumbImage1 = "";
            string LargeImage1 = "";
            string LargeImage2 = "";
            int ret;
           // string strBrandImage = string.Empty;
            try
            {
                ObjCategoryData.CategoryName = txtCategoryName.Text;
                string strCategoryNameUrl = Regex.Replace(txtCategoryName.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strCategoryNameUrl = strCategoryNameUrl.ToLower();
                strCategoryNameUrl = strCategoryNameUrl.Replace("&", "and");
                strCategoryNameUrl = strCategoryNameUrl.Replace(" ", "-");
                ObjCategoryData.CategoryAlias = txtTitleURL.Text;
                if (txtCategoryImage.Value != "")
                {
                    ThumbImage1 = strCategoryNameUrl + "-ads-sprit";
                    ThumbImage1 = ThumbImage1 + getContentType(txtCategoryImage.Value);
                    ObjCategoryData.CategoryImage = ThumbImage1.ToString();
                }
                else
                    ObjCategoryData.CategoryImage = "";
                if (LargeImg1.Value != "")
                {
                    LargeImage1 = strCategoryNameUrl + "-b-ads-sprit";
                    LargeImage1 = LargeImage1 + getContentType(LargeImg1.Value);
                    ObjCategoryData.CategoryImage1 = LargeImage1.ToString();
                }
                else
                    ObjCategoryData.CategoryImage1 = "";
                if (LargImg2.Value != "")
                {
                    LargeImage2 = strCategoryNameUrl + "-c-ads-sprit";
                    LargeImage2 = LargeImage2 + getContentType(LargImg2.Value);
                    ObjCategoryData.CategoryImage2 = LargeImage2.ToString();
                }
                else
                    ObjCategoryData.CategoryImage2 = "";
                ObjCategoryData.FacebookURl = txtFacebookURl.Text;
                ObjCategoryData.CategoryDescription = txtCategorySmallDesc.Text;
                ObjCategoryData.CategorysmallDescription = txtsmalldescription.Text;
                ObjCategoryData.Image2Description = txtdesc.Text;
                ObjCategoryData.DisplayOrder = Convert.ToInt16(txtDisplayOrder.Text);
                ObjCategoryData.CategoryMetaTitle = txtMetaTitle.Text;
                ObjCategoryData.CategoryMetaKeywords = txtMetaKeywords.Text;
                ObjCategoryData.CategoryMetaDescription = txtMetaDescriptions.Text;
                ObjCategoryData.MetaSchema = txtMetaSchema.Text;
                if (chkStatus.Checked == true)
                    ObjCategoryData.ActiveStatus = 1;
                else
                    ObjCategoryData.ActiveStatus = 0;
                if (chkDisplayOnMenu.Checked == true)
                    ObjCategoryData.DisplayOnMenu = 1;
                else
                    ObjCategoryData.DisplayOnMenu = 0;
                if (chkDisplayOnHeader.Checked == true)
                    ObjCategoryData.DisplayOnHeader = 1;
                else
                    ObjCategoryData.DisplayOnHeader = 0;

                ObjCategoryData.PhotoCategory = 0;
                ObjCategoryData.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjCategoryData.SaveCategory();
                if (ret != -1)
                {
                    if (LargeImg1.Value != "")
                        ObjComm.fileUpLoad(txtCategoryImage, "../AdsSpritImages/CategoryImages", ThumbImage1, Server);
                    if (txtCategoryImage.Value != "")
                        ObjComm.fileUpLoad(LargeImg1, "../AdsSpritImages/CategoryImages", LargeImage1, Server);
                    if (LargImg2.Value != "")
                        ObjComm.fileUpLoad(LargImg2, "../AdsSpritImages/CategoryImages", LargeImage2, Server);

                    Session["msg"] = "Category Successfully Added";
                    Response.Redirect("/AdsSpritAdmin/category");
                }
                else
                {
                    lblError.Text = "Category Name Already Exists";
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SaveCategory()", ex);
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
                    thumbnailFilePath = HttpContext.Current.Server.MapPath("../AdsSpritAdmin/CategoryImages/" + fileNameee);
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/category");
        }
    }
}