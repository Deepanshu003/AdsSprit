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
    public partial class Brands : System.Web.UI.Page
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
              BindProductImages();
            }
        }
          private void BindProductImages()
          {
              ProductData ObjProductData = new ProductData();
              DataSet ds = new DataSet();
              ds = ObjProductData.SelectProductData();

              if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
              {
                  ReptProduct.DataSource = ds.Tables[0];
                  ReptProduct.DataBind();
                  ReptProduct.Visible = true;
              }
              else
              {
                  ReptProduct.Visible = false;
              }

              ds.Dispose();
              ObjProductData = null;
          }   
    }
}