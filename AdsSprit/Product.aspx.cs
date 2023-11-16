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
    public partial class Product : System.Web.UI.Page
    {

        ManageException ObjEx = new ManageException();
        Contact ObjContact = new Contact();
        CategoryData ObjCategoryData = new CategoryData();
        ProductData ObjProductData = new ProductData();
        SqlDataReader SqlReader;
        int CategoryID = 0;
        int ProductID = 0;
        string CategoryAlias = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Convert.ToString(Page.RouteData.Values["CategoryAlias"]) != string.Empty))
                  {
                    CategoryID = Convert.ToInt32(ObjCategoryData.SelectCategoryIDByCategoryTitleURL(Convert.ToString(Page.RouteData.Values["CategoryAlias"])));
                    if (CategoryID > 0)
                  {                  
                      BindCategoryImages(CategoryID);
                      BindProductImages(CategoryID);
                      BindFOOTERImages(CategoryID);
                  }
               }
             }
          }
        
        #region pRODUCT Data
        private void BindProductImages(int CategoryID)
        {
            CategoryData ObjCategoryData = new CategoryData();
            DataSet ds = ObjCategoryData.SelectProductImagesforWhisky(CategoryID);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ReptProductImages.DataSource = ds.Tables[0];
                ReptProductImages.DataBind();
                ReptProductImages.Visible = true;
            }
            else
            {
                ReptProductImages.Visible = false;
            }

            ds.Dispose();
            ObjProductData = null; 
        }
        #endregion

        #region Banner Image
     /*   private void BindAllBannerImges()
        {
            CategoryData ObjCategoryData = new CategoryData();
            DataSet ds = new DataSet();
            ds = ObjCategoryData.SelectDisplayImage();
            if (ds.Tables[0].Rows.Count > 0)
            {

                RptrGalleryData1.DataSource = ds.Tables[0];
                RptrGalleryData1.DataBind();
                RptrGalleryData1.Visible = true;
            }
            else
            {
                RptrGalleryData1.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjCategoryData = null;
        } */

        private void BindCategoryImages(int CategoryID)
        {
            CategoryData ObjCategoryData = new CategoryData();
            DataSet ds = ObjCategoryData.SelectDisplayImage(CategoryID);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                RptrGalleryData1.DataSource = ds.Tables[0];
                RptrGalleryData1.DataBind();
                RptrGalleryData1.Visible = true;
            }
            else
            {
                RptrGalleryData1.Visible = false;
            }

            // Clean up resources
            ds.Dispose();
            ObjCategoryData = null;
        }


        private void BindFOOTERImages(int CategoryID)
        {
            CategoryData ObjCategoryData = new CategoryData();
            DataSet ds = ObjCategoryData.SelectFooterImagesforCategories(CategoryID);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ReptFooter.DataSource = ds.Tables[0];
                ReptFooter.DataBind();
                ReptFooter.Visible = true;
            }
            else
            {
                ReptFooter.Visible = false;
            }

            ds.Dispose();
            ObjProductData = null;
        }
        #endregion
    }
}