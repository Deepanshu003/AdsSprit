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
    public partial class AddUpdProductData : System.Web.UI.Page
    {
        ProductData ObjProductData = new ProductData();
        ManageException ObjEx = new ManageException();
        CommanFunction ObjComm = new CommanFunction();
        SqlDataReader SqlReader,SqlReaderAwards, SqlReaderProductCocktails; DataSet ds = new DataSet();
        ProductSizeData ObjProductSizeData = new ProductSizeData();
        CategoryData ObjProductCategory = new CategoryData();
        SubCategoryData ObjSubCategoryData = new SubCategoryData();
        ProductCategorySubCategoryData ObjProductCategorySubCategoryData = new ProductCategorySubCategoryData();
        Awards ObjAwardsData = new Awards();
        SizeData ObjSizeData = new SizeData();
        Awards ObjAwards = new Awards();
       // Detail ObjProductData = new Detail();
        ProductAwards ObjProductAwards = new ProductAwards();
        CockTails ObjCockTails = new CockTails();
        ProductCockTails ObjProductCocktails = new ProductCockTails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("/AdsSpritAdmin/login");
            }
            if (Session["msg"] != null)
            {
                lblError.Text = Convert.ToString(Session["msg"]);
                Session["msg"] = null;
            }
            if (!IsPostBack)
            {
                string userInput = Request.Form["textarea2"];
                string encodedInput = HttpUtility.HtmlEncode(userInput);

                BindDdCategory();
                if (Request.QueryString["ProductID"] != null)
                {
                    PnlProductCode.Visible = true;
                    btnSave.Text = "Update";
                    ObjProductData.ProductID = Convert.ToInt16(Request.QueryString["ProductID"]);
                    SqlReader = ObjProductData.SelectProductByProductID();
                    filldata(SqlReader);
                    btnSave.Attributes.Add("OnClick", "javascript:return pagecheck1();");
                }
                else
                {
                    int displayOrde = ObjProductData.SelectMaxDisplayOrder();
                    if (displayOrde > 0)
                        txtDisplayOrder.Text = (displayOrde + 1).ToString();
                    else
                        txtDisplayOrder.Text = "1";
                    btnSave.Attributes.Add("OnClick", "javascript:return pagecheck();");
                }
            }
            txtProductDefaultImage.Attributes.Add("onchange", "return validateFileUploadDefault(this);");
            txtProductImage1.Attributes.Add("onchange", "return validateFileUploadImage1(this);");
            txtProductImage2.Attributes.Add("onchange", "return validateFileUploadImage2(this);");
            File1.Attributes.Add("onchange", "return validateFileUploadImage3(this);");
        }

        private void BindDdCategory()
        {
            CategoryData ObjCategoryData = new CategoryData();
            ObjCategoryData.BindDdCategory(DdCategory, "CategoryName", "CategoryID");
            DdCategory.Items.Insert(0, new ListItem("Select Category", "0"));
            ObjCategoryData = null;
        }

        protected void DdCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDdSubCategory();
        }

        private void BindDdSubCategory()
        {
            SubCategoryData ObjSubCategoryData = new SubCategoryData();
            ObjSubCategoryData.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
            ObjSubCategoryData = null;
        }

        private void filldata(SqlDataReader SqlReader)
        {
            while (SqlReader.Read())
            {
                txtProductName.Text = SqlReader["ProductName"].ToString();
                txtTitleURL.Text = SqlReader["ProductNameAlias"].ToString();
                txtProductCode.Text = SqlReader["ProductCode"].ToString();
                DdCategory.SelectedValue = SqlReader["CategoryID"].ToString();
                txtSPIRITSSOURCETitle.Text = SqlReader["DetailName"].ToString();
                txtabv.Text = SqlReader["DetailABV"].ToString();
                txtColor.Text = SqlReader["DetailColor"].ToString();
                txtNose.Text = SqlReader["DetailNOSE"].ToString();
                txtPlalate.Text = SqlReader["DetailPalate"].ToString();
                txtTastingNotes.Text = SqlReader["TastingNotes"].ToString();
                txtAward.Text = SqlReader["AwardName"].ToString();
                txtAwardDescripton.Text = SqlReader["AwardDescription"].ToString();
                BindDdSubCategory();
                hdnDDCatgeoryID.Value = DdCategory.SelectedValue;
                txtProductSpecification.Text = SqlReader["SmallDescription"].ToString();
                if (SqlReader["ProductDefaultImage"].ToString() != "")
                {
                    ProductDefaultImageThumb.ImageUrl = "../AdsSpritImages/ProductImages/" + SqlReader["ProductDefaultImage"].ToString();
                    ProductDefaultImageThumb.Visible = true;
                }
                if (SqlReader["ProductImage1"].ToString() != "")
                {
                    ProductImage1Thumb.ImageUrl = "../AdsSpritImages/ProductImages/" + SqlReader["ProductImage1"].ToString();
                    ProductImage1Thumb.Visible = true;
                    BtnRemoveImage2.Visible = true;
                }
                if (SqlReader["ProductImage2"].ToString() != "")
                {
                    Image1.ImageUrl = "../AdsSpritImages/ProductImages/" + SqlReader["ProductImage2"].ToString();
                    Image1.Visible = true;
                    BtnRemoveImage3.Visible = true;
                }
                if (SqlReader["ProductImage3"].ToString() != "")
                {
                    Image2.ImageUrl = "../AdsSpritImages/ProductImages/" + SqlReader["ProductImage3"].ToString();
                    Image2.Visible = true;
                    BtnRemoveImage4.Visible = true;
                }

                if (SqlReader["AwardImage"].ToString() != "")
                {
                    AwardImageThumb.ImageUrl = "../AdsSpritImages/ProductImages/" + SqlReader["AwardImage"].ToString();
                    AwardImageThumb.Visible = true;
                }

                if (SqlReader["ProductIngredients"].ToString() != "")
                {
                    BannerDetailThumb.ImageUrl = "../AdsSpritImages/ProductImages/" + SqlReader["ProductIngredients"].ToString();
                    BannerDetailThumb.Visible = true;
                }


                textarea1.Value = SqlReader["ProductDescription"].ToString();

                textarea2.Value = SqlReader["ProductDetailDescription"].ToString();

                txtDisplayOrder.Text = SqlReader["DisplayOrder"].ToString();
                if (SqlReader["DisplayOnHome"].ToString() == "1")
                    chkDisplayOnHome.Checked = true;
                else
                    chkDisplayOnHome.Checked = false;

                if (SqlReader["ActiveStatus"].ToString() == "1")
                    chkStatus.Checked = true;
                else
                    chkStatus.Checked = false;
                
                txtMetaTitle.Text = SqlReader["MetaTitle"].ToString();
                txtMetaKeywords.Text = SqlReader["MetaKeyword"].ToString();
                txtMetaDescriptions.Text = SqlReader["MetaDescription"].ToString();
                txtMetaSchema.Text = SqlReader["MetaSchema"].ToString();
            }
            SqlReader.Close();
            SqlReader.Dispose();
        }

        protected void txtProductName_TextChanged(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                string strTitle = Regex.Replace(txtProductName.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strTitle = strTitle.ToLower();
                strTitle = strTitle.Replace("&", "and");
                strTitle = strTitle.Replace(" ", "-");
                txtTitleURL.Text = strTitle;
            }
        }

        protected void BtnRemoveImage2_Click(object sender, EventArgs e)
        {
            int ret = 0;
            ObjProductData.ProductID = Convert.ToInt16(Request.QueryString["ProductID"]);
            ret = ObjProductData.RemoveProductImage2ByProductID();
            if (ret == 1)
                Response.Redirect(Request.RawUrl);
        }

        protected void BtnRemoveImage3_Click(object sender, EventArgs e)
        {
            int ret = 0;
            ObjProductData.ProductID = Convert.ToInt16(Request.QueryString["ProductID"]);
            ret = ObjProductData.RemoveProductImage3ByProductID();
            if (ret == 1)
                Response.Redirect(Request.RawUrl);
        }

        protected void BtnRemoveImage4_Click(object sender, EventArgs e)
        {
            int ret = 0;
            ObjProductData.ProductID = Convert.ToInt16(Request.QueryString["ProductID"]);
            ret = ObjProductData.RemoveProductImage4ByProductID();
            if (ret == 1)
                Response.Redirect(Request.RawUrl);
        }
        private void SaveProduct_DefaultImage(int widthhhh, int heightttt, string fileNameee)
        {
            CommanFunction ObjComm = new CommanFunction();
            try
            {
                string originalFilePath;
                ObjComm.fileUpLoad(txtProductDefaultImage, "../AdsSpritImages/temp/", fileNameee, Server);
                originalFilePath = HttpContext.Current.Server.MapPath("../AdsSpritImages/temp/" + fileNameee);
                string thumbnailFilePath = string.Empty;
                Size newSize = new Size(widthhhh, heightttt);
                using (Bitmap bmp = new Bitmap(originalFilePath))
                {
                    thumbnailFilePath = HttpContext.Current.Server.MapPath("../AdsSpritImages/ProductImages/" + fileNameee);
                    using (Bitmap thumb = new Bitmap((System.Drawing.Image)bmp, newSize))
                    {
                        using (Graphics g = Graphics.FromImage(thumb)) // Create Graphics object from original Image
                        {
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                            System.Drawing.Imaging.ImageCodecInfo codec = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];
                            System.Drawing.Imaging.EncoderParameters eParams = new System.Drawing.Imaging.EncoderParameters(1);
                            eParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                            g.DrawImage(bmp, new Rectangle(0, 0, thumb.Width, thumb.Height));
                            thumb.Save(thumbnailFilePath, codec, eParams);
                        }
                    }
                }
                DelImg(Server.MapPath("../AdsSpritImages/temp/" + fileNameee));
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            ObjComm = null;
        }

        private void SaveProductImage1(int widthhhh, int heightttt, string fileNameee)
        {
            CommanFunction ObjComm = new CommanFunction();
            try
            {
                string originalFilePath;
                ObjComm.fileUpLoad(txtProductImage1, "../AdsSpritImages/temp/", fileNameee, Server);
                originalFilePath = HttpContext.Current.Server.MapPath("../AdsSpritImages/temp/" + fileNameee);
                string thumbnailFilePath = string.Empty;
                Size newSize = new Size(widthhhh, heightttt);
                using (Bitmap bmp = new Bitmap(originalFilePath))
                {
                    thumbnailFilePath = HttpContext.Current.Server.MapPath("../AdsSpritImages/ProductImages/" + fileNameee);
                    using (Bitmap thumb = new Bitmap((System.Drawing.Image)bmp, newSize))
                    {
                        using (Graphics g = Graphics.FromImage(thumb)) // Create Graphics object from original Image
                        {
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                            System.Drawing.Imaging.ImageCodecInfo codec = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];
                            System.Drawing.Imaging.EncoderParameters eParams = new System.Drawing.Imaging.EncoderParameters(1);
                            eParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
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

        private void SaveProductImage2(int widthhhh, int heightttt, string fileNameee)
        {
            CommanFunction ObjComm = new CommanFunction();
            try
            {
                string originalFilePath;
                ObjComm.fileUpLoad(txtProductImage2, "../AdsSpritAdmin/temp/", fileNameee, Server);
                originalFilePath = HttpContext.Current.Server.MapPath("../AdsSpritAdmin/temp/" + fileNameee);
                string thumbnailFilePath = string.Empty;
                Size newSize = new Size(widthhhh, heightttt);
                using (Bitmap bmp = new Bitmap(originalFilePath))
                {
                    thumbnailFilePath = HttpContext.Current.Server.MapPath("../AdsSpritAdmin/ProductImages/" + fileNameee);
                    using (Bitmap thumb = new Bitmap((System.Drawing.Image)bmp, newSize))
                    {
                        using (Graphics g = Graphics.FromImage(thumb)) // Create Graphics object from original Image
                        {
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                            System.Drawing.Imaging.ImageCodecInfo codec = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];
                            System.Drawing.Imaging.EncoderParameters eParams = new System.Drawing.Imaging.EncoderParameters(1);
                            eParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
                SaveData();
            else if (btnSave.Text == "Update")
                UpdateData();
        }

        private void SaveData()
        {
            CommanFunction ObjComm = new CommanFunction();
            string Product_DefaultImage = string.Empty;
            string Product_Image1 = string.Empty;
            string Product_Image2 = string.Empty;
            string Product_Image3 = string.Empty;
            string Product_Image4 = string.Empty;
            string Product_Image5 = string.Empty;
            int ret;
            try
            {
                ObjProductData.ProductName = txtProductName.Text;
                string strProductNameAlias = Regex.Replace(txtProductName.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strProductNameAlias = strProductNameAlias.ToLower();
                strProductNameAlias = strProductNameAlias.Replace("&", "and");
                strProductNameAlias = strProductNameAlias.Replace(" ", "-");
                ObjProductData.ProductNameAlias = txtTitleURL.Text;
                ObjProductData.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
                hdnDDCatgeoryID.Value = DdCategory.SelectedValue;
                ObjProductData.SmallDescription = txtProductSpecification.Text;
                ObjProductData.ProductCode = txtProductCode.Text;
                ObjProductData.ProductDescription = textarea1.Value;
                ObjProductData.DetailName = txtSPIRITSSOURCETitle.Text;
                ObjProductData.DetailColor = txtColor.Text;
                ObjProductData.DetailNOSE = txtNose.Text;
                ObjProductData.DetailPalate = txtPlalate.Text;
                ObjProductData.DetailABV = txtabv.Text;
                ObjProductData.TastingNotes = txtTastingNotes.Text;

                ObjProductData.AwardName = txtAward.Text;
                ObjProductData.AwardDescription = txtAwardDescripton.Text;

                ObjProductData.ProductDetailDescription = textarea2.Value;

                if (txtProductDefaultImage.Value != "")
                {
                    Product_DefaultImage = strProductNameAlias + "-ads-spirit";
                    Product_DefaultImage = Product_DefaultImage + getContentType(txtProductDefaultImage.Value);
                    ObjProductData.ProductDefaultImage = Product_DefaultImage.ToString();
                }
                else
                    ObjProductData.ProductDefaultImage = "";

                if (txtProductImage1.Value != "")
                {
                    Product_Image1 = strProductNameAlias + "-1-ads-spirit";
                    Product_Image1 = Product_Image1 + getContentType(txtProductImage1.Value);
                    ObjProductData.ProductImage1 = Product_Image1.ToString();
                }
                else
                    ObjProductData.ProductImage1 = "";

                if (txtProductImage2.Value != "")
                {
                    Product_Image2 = strProductNameAlias + "-2-ads-spirit";
                    Product_Image2 = Product_Image2 + getContentType(txtProductImage2.Value);
                    ObjProductData.ProductImage2 = Product_Image2.ToString();
                }
                else
                    ObjProductData.ProductImage2 = "";

                if (File1.Value != "")
                {
                    Product_Image3 = strProductNameAlias + "-3-ads-spirit";
                    Product_Image3 = Product_Image3 + getContentType(File1.Value);
                    ObjProductData.ProductImage3 = Product_Image3.ToString();
                }
                else
                    ObjProductData.ProductImage3 = "";

                if (txtAWARDImage.Value != "")
                {
                    Product_Image4 = strProductNameAlias + "-4-ads-spirit";
                    Product_Image4 = Product_Image4 + getContentType(txtAWARDImage.Value);
                    ObjProductData.AwardImage = Product_Image4.ToString();
                }
                else
                    ObjProductData.AwardImage = "";

                if (txtAWARDImage.Value != "")
                {
                    Product_Image5 = strProductNameAlias + "-5-ads-spirit";
                    Product_Image5 = Product_Image5 + getContentType(txtBannerDetail.Value);
                    ObjProductData.ProductIngredients = Product_Image5.ToString();
                }
                else
                    ObjProductData.ProductIngredients = "";

                if (txtDisplayOrder.Text == "")
                    ObjProductData.DisplayOrder = 0;
                else

                    ObjProductData.DisplayOrder = Convert.ToInt16(txtDisplayOrder.Text);
                if (chkDisplayOnHome.Checked == true)
                    ObjProductData.DisplayOnHome = 1;
                else
                    ObjProductData.DisplayOnHome = 0;
                if (chkStatus.Checked == true)
                    ObjProductData.ActiveStatus = 1;
                else
                    ObjProductData.ActiveStatus = 0;
                ObjProductData.MetaTitle = txtMetaTitle.Text;
                ObjProductData.MetaKeyword = txtMetaKeywords.Text;
                ObjProductData.MetaDescription = txtMetaDescriptions.Text;
                ObjProductData.MetaSchema = txtMetaSchema.Text;
                ObjProductData.UpdatedBy = Convert.ToString(Session["Admin"]);
                ret = ObjProductData.SaveNewProductData();
                if (ret != -1)
                {
                    if (txtProductDefaultImage.Value != "")
                    ObjComm.fileUpLoad(txtProductDefaultImage, "../AdsSpritImages/ProductImages", Product_DefaultImage, Server);

                    if (txtProductImage1.Value != "")
                        ObjComm.fileUpLoad(txtProductImage1, "../AdsSpritImages/ProductImages", Product_Image1, Server);
                    if (txtProductImage2.Value != "")
                        ObjComm.fileUpLoad(txtProductImage2, "../AdsSpritImages/ProductImages", Product_Image2, Server);
                    if (File1.Value != "")
                        ObjComm.fileUpLoad(File1, "../AdsSpritImages/ProductImages", Product_Image3, Server);
                    if (txtAWARDImage.Value != "")
                        ObjComm.fileUpLoad(txtAWARDImage, "../AdsSpritImages/ProductImages", Product_Image4, Server);
                    if (txtBannerDetail.Value != "")
                        ObjComm.fileUpLoad(txtBannerDetail, "../AdsSpritImages/ProductImages", Product_Image5, Server);
                    Session["msg"] = "Product Successfully Added";
                    Response.Redirect("/AdsSpritAdmin/product-data");
                }
                else
                {
                    lblError.Text = "Product Already Exists";
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SaveData()", ex);
            }
        }

        private void UpdateData()
        {
            CommanFunction ObjComm = new CommanFunction();
            string Product_DefaultImage = string.Empty;
            string Product_Image1 = string.Empty;
            string Product_Image2 = string.Empty;
            string Product_Image3 = string.Empty;
            string Product_Image4 = string.Empty;
            string Product_Image5 = string.Empty;
            int ret;
            try
            {

                ObjProductData.ProductID = Convert.ToInt16(Request.QueryString["ProductID"]);
                ObjProductData.ProductName = txtProductName.Text;
                string strProductNameAlias = Regex.Replace(txtProductName.Text, "[^a-zA-Z0-9_]+", " ").Trim();
                strProductNameAlias = strProductNameAlias.ToLower();
                strProductNameAlias = strProductNameAlias.Replace("&", "and");
                strProductNameAlias = strProductNameAlias.Replace(" ", "-");
                ObjProductData.ProductNameAlias = txtTitleURL.Text;
                ObjProductData.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
                hdnDDCatgeoryID.Value = DdCategory.SelectedValue;
                ObjProductData.SmallDescription = txtProductSpecification.Text;
                ObjProductData.DetailName = txtSPIRITSSOURCETitle.Text;
                ObjProductData.DetailColor = txtColor.Text;
                ObjProductData.DetailNOSE = txtNose.Text;
                ObjProductData.DetailPalate = txtPlalate.Text;
                ObjProductData.DetailABV = txtabv.Text;
                ObjProductData.TastingNotes = txtTastingNotes.Text;

                ObjProductData.AwardName = txtAward.Text;
                ObjProductData.AwardDescription = txtAwardDescripton.Text;

                ObjProductData.ProductDetailDescription = textarea2.Value;
                if (txtProductDefaultImage.Value != "")
                {
                    Product_DefaultImage = strProductNameAlias + "-ads-spirit";
                    Product_DefaultImage = Product_DefaultImage + getContentType(txtProductDefaultImage.Value);
                    ObjProductData.ProductDefaultImage = Product_DefaultImage.ToString();
                }
                else
                {
                    Product_DefaultImage = System.IO.Path.GetFileName(ProductDefaultImageThumb.ImageUrl);
                    ObjProductData.ProductDefaultImage = Product_DefaultImage.ToString();
                }
                if (txtProductImage1.Value != "")
                {
                    Product_Image1 = strProductNameAlias + "-1-ads-spirit";
                    Product_Image1 = Product_Image1 + getContentType(txtProductImage1.Value);
                    ObjProductData.ProductImage1 = Product_Image1.ToString();
                }
                else
                {
                    Product_Image1 = System.IO.Path.GetFileName(ProductImage1Thumb.ImageUrl);
                    ObjProductData.ProductImage1 = Product_Image1.ToString();
                }
                if (txtProductImage2.Value != "")//PDF Brochure
                {
                    Product_Image2 = strProductNameAlias + "-2-ads-spirit";
                    Product_Image2 = Product_Image2 + getContentType(txtProductImage2.Value);
                    ObjProductData.ProductImage2 = Product_Image2.ToString();
                }
                else
                {
                    Product_Image2 = System.IO.Path.GetFileName(Image1.ImageUrl);
                    ObjProductData.ProductImage2 = Product_Image2.ToString();
                }
                if (File1.Value != "")//PDF Brochure
                {
                    Product_Image3 = strProductNameAlias + "-3-ads-spirit";
                    Product_Image3 = Product_Image3 + getContentType(File1.Value);
                    ObjProductData.ProductImage3 = Product_Image3.ToString();
                }
                else
                {
                    Product_Image3 = System.IO.Path.GetFileName(Image2.ImageUrl);
                    ObjProductData.ProductImage3 = Product_Image3.ToString();
                }

                if (txtAWARDImage.Value != "")//PDF Brochure
                {
                    Product_Image4 = strProductNameAlias + "-4-ads-spirit";
                    Product_Image4 = Product_Image4 + getContentType(txtAWARDImage.Value);
                    ObjProductData.AwardImage = Product_Image4.ToString();
                }
                else
                {
                    Product_Image4 = System.IO.Path.GetFileName(AwardImageThumb.ImageUrl);
                    ObjProductData.AwardImage = Product_Image4.ToString();
                }

                if (txtBannerDetail.Value != "")//PDF Brochure
                {
                    Product_Image5 = strProductNameAlias + "-5-ads-spirit";
                    Product_Image5 = Product_Image5 + getContentType(txtBannerDetail.Value);
                    ObjProductData.ProductIngredients = Product_Image5.ToString();
                }
                else
                {
                    Product_Image5 = System.IO.Path.GetFileName(BannerDetailThumb.ImageUrl);
                    ObjProductData.ProductIngredients = Product_Image5.ToString();
                }


                ObjProductData.ProductCode = txtProductCode.Text;
                ObjProductData.ProductDescription = textarea1.Value;
                ObjProductData.DisplayOrder = Convert.ToInt16(txtDisplayOrder.Text);
                if (chkDisplayOnHome.Checked == true)
                    ObjProductData.DisplayOnHome = 1;
                else
                    ObjProductData.DisplayOnHome = 0;
                if (chkStatus.Checked == true)
                    ObjProductData.ActiveStatus = 1;
                else
                    ObjProductData.ActiveStatus = 0;
                ObjProductData.MetaTitle = txtMetaTitle.Text;
                ObjProductData.MetaKeyword = txtMetaKeywords.Text;
                ObjProductData.MetaDescription = txtMetaDescriptions.Text;
                ObjProductData.MetaSchema = txtMetaSchema.Text;
                ObjProductData.UpdatedBy = Convert.ToString(Session["Admin"]);
                ObjProductData.UpdatedOn = DateTime.UtcNow;

                ret = ObjProductData.UpdateProductByProductID();
                if (ret != -1)
                {
                    if (txtProductDefaultImage.Value != "")
                    {
                        ObjComm.fileUpLoad(txtProductDefaultImage, "../AdsSpritImages/ProductImages", Product_DefaultImage, Server);
                        DelImg(ProductDefaultImageThumb.ImageUrl);
                    }

                    if (txtProductImage1.Value != "")
                    {
                        ObjComm.fileUpLoad(txtProductImage1, "../AdsSpritImages/ProductImages", Product_Image1, Server);
                        DelImg(ProductImage1Thumb.ImageUrl);
                    }
                    if (txtProductImage2.Value != "")
                    {
                        ObjComm.fileUpLoad(txtProductImage2, "../AdsSpritImages/ProductImages", Product_Image2, Server);
                        DelImg(Image1.ImageUrl);
                    }
                    if (File1.Value != "")
                    {
                        ObjComm.fileUpLoad(File1, "../AdsSpritImages/ProductImages", Product_Image3, Server);
                        DelImg(Image2.ImageUrl);
                    }
                    if (txtAWARDImage.Value != "")
                    {
                        ObjComm.fileUpLoad(txtAWARDImage, "../AdsSpritImages/ProductImages", Product_Image4, Server);
                    //    DelImg(AwardImageThumb.ImageUrl);
                    }

                    if (txtBannerDetail.Value != "")
                    {
                        ObjComm.fileUpLoad(txtBannerDetail, "../AdsSpritImages/ProductImages", Product_Image5, Server);
                        //    DelImg(AwardImageThumb.ImageUrl);
                    }

                    Session["msg"] = "Product Updated Successfully";
                    Response.Redirect("/AdsSpritAdmin/product-data");
                }
                else
                {
                    lblError.Text = "Product Already Exists";
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure UpdateData()", ex);
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

        private string getContentType1(string strPath)
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/product-data");
        }




    }
}