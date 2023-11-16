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
    public partial class index : System.Web.UI.Page
    {

        ManageException ObjEx = new ManageException();
        Contact ObjContact = new Contact();
        CategoryData ObjCategoryData = new CategoryData();
        ProductData ObjProductData = new ProductData();
        SqlDataReader SqlReader;
        int ProductID = 0;
        int CategoryID = 0;
        string CategoryAlias = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindIndexBannerImges();
                BindCategoryImages();
            }
        }

        #region Banner Image

        private void BindIndexBannerImges()
        {

            ProductData ObjProductData = new ProductData();
            DataSet ds = new DataSet();
            ds = ObjProductData.SelectBannerImageOfProducts();
            if (ds.Tables[0].Rows.Count > 0)
            {

                RptrBannerImage.DataSource = ds.Tables[0];
                RptrBannerImage.DataBind();
                RptrBannerImage.Visible = true;
            }
            else
            {
                RptrBannerImage.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjProductData = null;
        }
    /*    private void BindIndexBannerImges2(int ProductID)
        {

            ProductData ObjProductData = new ProductData();
            DataSet ds = new DataSet();
            ObjProductData.ProductID = ProductID;
            ds = ObjProductData.SelectDisplayImage2();
            if (ds.Tables[0].Rows.Count > 0)
            {

                ReptImage2.DataSource = ds.Tables[0];
                ReptImage2.DataBind();
                ReptImage2.Visible = true;
            }
            else
            {
                ReptImage2.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjProductData = null;
        }
        */


        #endregion

        #region Category Image
           private void BindCategoryImages()
           {
            CategoryData ObjCategoryData = new CategoryData();
            DataSet ds = new DataSet();
            ds = ObjCategoryData.SelectActiveCategory();
            if (ds.Tables[0].Rows.Count > 0)
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
            ds.Clear();
            ObjCategoryData = null;
           } 
        #endregion
    }
}