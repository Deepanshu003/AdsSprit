using Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace AdsSprit
{
    public partial class product_details : System.Web.UI.Page
    {

        ManageException ObjEx = new ManageException();
        Contact ObjContact = new Contact();
        CategoryData ObjCategoryData = new CategoryData();
         ProductData ObjProductData = new ProductData();
        SqlDataReader SqlReader;
        int ProductID = 0;
        int CategoryID = 0;
        string ProductNameAlias = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Page.RouteData.Values["ProductNameAlias"]) != string.Empty)
                {
                    ProductID = Convert.ToInt32(ObjProductData.SelectProductIDByProductCategoryIDORProductTitleURL(Convert.ToString(Page.RouteData.Values["ProductNameAlias"])));
                    if (ProductID > 0)
                    {
  //                int categoryID = ObjProductData.GetCategoryIDByProductID(ProductID);            
                    BindIndexBannerImges(ProductID);
                    BindCategoryImages();
                    BindBannerImageDetail(ProductID);
                    BindAwardDetail(ProductID);
                    BindProductImages(ProductID, CategoryID);
                    BindBannerIndeGrientsDetail(ProductID);
                    }
               }
            }
        }

        private void BindIndexBannerImges(int ProductID)
        {
            ProductData ObjProductData = new ProductData();
            DataSet ds = new DataSet();
            ObjProductData.ProductID = ProductID;
            ds = ObjProductData.SelectProductBannerImage();
            if (ds.Tables[0].Rows.Count > 0)
            {

                RptrProductHeaderImage.DataSource = ds.Tables[0];
                RptrProductHeaderImage.DataBind();
                RptrProductHeaderImage.Visible = true;
            }
            else
            {
                RptrProductHeaderImage.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjProductData = null;
        }


        private void BindBannerImageDetail(int ProductID)
        {
            ProductData ObjProductData = new ProductData();
            DataSet ds = new DataSet();
            ObjProductData.ProductID = ProductID;
            ds = ObjProductData.SelectProductBannerImage();
            if (ds.Tables[0].Rows.Count > 0)
            {

                ReptBannerImageDetail.DataSource = ds.Tables[0];
                ReptBannerImageDetail.DataBind();
                ReptBannerImageDetail.Visible = true;
            }
            else
            {
                ReptBannerImageDetail.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjProductData = null;
        }

        private void BindAwardDetail(int ProductID)
        {
            ProductData ObjProductData = new ProductData();
            DataSet ds = new DataSet();

            ds = ObjProductData.SelectAwardDescription(ProductID);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ReptOFAWARDS.DataSource = ds.Tables[0];
                ReptOFAWARDS.DataBind();
                ReptOFAWARDS.Visible = true;
            }
            else
            {
                ReptOFAWARDS.Visible = false;
            }

            ds.Dispose();
            ds.Clear();
            ObjProductData = null;
        }

        private void BindBannerIndeGrientsDetail(int ProductID)
        {
            ProductData ObjProductData = new ProductData();
            DataSet ds = new DataSet();

            ds = ObjProductData.SelectBannerIndegrients(ProductID);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ReptBannerIndgerients.DataSource = ds.Tables[0];
                ReptBannerIndgerients.DataBind();
                ReptBannerIndgerients.Visible = true;
            }
            else
            {
                ReptBannerIndgerients.Visible = false;
            }

            ds.Dispose();
            ds.Clear();
            ObjProductData = null;
        }
        private void BindProductImages(int ProductID, int CategoryID)
        {
            ProductData ObjProductData = new ProductData();
            DataSet ds = ObjProductData.SelectRelatedProducts(ProductID, CategoryID);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ReptwhiskyRange1.DataSource = ds.Tables[0];
                ReptwhiskyRange1.DataBind();
                ReptwhiskyRange1.Visible = true;
            }
            else
            {
                ReptwhiskyRange1.Visible = false;
            }

            ds.Dispose();
            ObjProductData = null;
        }


   /*     private void BindProductImages(int ProductID)
        {
            ProductData ObjProductData = new ProductData();
            DataSet ds = ObjProductData.SelectProductImagesforWhisky1(ProductID);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ReptwhiskyRange1.DataSource = ds.Tables[0];
                ReptwhiskyRange1.DataBind();
                ReptwhiskyRange1.Visible = true;
            }
            else
            {
                ReptwhiskyRange1.Visible = false;
            }

            ds.Dispose();
            ObjProductData = null;
        }  */

     /*   private void BindProductImages(int CategoryID)
        {
            ProductData ObjProductData = new ProductData();
            DataSet ds = ObjProductData.SelectProductImagesforWhisky1(CategoryID);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ReptwhiskyRange1.DataSource = ds.Tables[0];
                ReptwhiskyRange1.DataBind();
                ReptwhiskyRange1.Visible = true;
            }
            else
            {
                ReptwhiskyRange1.Visible = false;
            }

            ds.Dispose();
            ObjProductData = null;
        } */

        #region Category Image
        private void BindCategoryImages()
        {
            CategoryData ObjCategoryData = new CategoryData();
            DataSet ds = new DataSet();
            ds = ObjCategoryData.SelectActiveCategory(); 

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ReptCategoryImage1.DataSource = ds.Tables[0];
                ReptCategoryImage1.DataBind();
                ReptCategoryImage1.Visible = true;
            }
            else
            {
                ReptCategoryImage1.Visible = false;
            }
            ds.Dispose();
            ObjCategoryData = null;
        } 

        #endregion
    }
}