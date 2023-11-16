using Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdsSprit.AdsSpritUser
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        ProductData ObjProductData = new ProductData();
        int ProductID = 0;
        int categoryID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            Session["CurrentPage"] = currentPage;
            if (!IsPostBack)
            {
                BindAllActiveProductForMenu2();
                BindAllActiveProductForFooter();
             }
         }
        private void BindAllActiveProductForFooter()
        {
            ProductData ObjProductData = new ProductData();
            DataSet ds = new DataSet();
            ds = ObjProductData.SelectAllActiveProductForFooter();
            if (ds.Tables[0].Rows.Count > 0)
            {
                reptLinks.DataSource = ds.Tables[0];
                reptLinks.DataBind();
                reptLinks.Visible = true;
            }
            else
            {
                reptLinks.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjProductData = null;
        }

        /*      private void BindAllActiveProductForMenu1()
              {
                  ProductData ObjProductData = new ProductData();
                  DataSet ds = new DataSet();
                  ds = ObjProductData.SelectAllActiveProductForMenu();
                  if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                  {
                      RptrCategoryDataForMenu.DataSource = ds.Tables[0];
                      RptrCategoryDataForMenu.DataBind();
                      RptrCategoryDataForMenu.Visible = true;

                      foreach (RepeaterItem item in RptrCategoryDataForMenu.Items)
                      {
                          HiddenField hdnCategoryID = (HiddenField)item.FindControl("hdnCatgeory");
                          Repeater RptrProductData = (Repeater)item.FindControl("RptrProductData");
                          int categoryID = Convert.ToInt32(hdnCategoryID.Value);

                          DataView dataView = new DataView(ds.Tables[0]);
                          dataView.RowFilter = "CategoryID = " + categoryID;
                          DataTable dt1 = dataView.ToTable();

                          if (dt1.Rows.Count > 0)
                          {
                              RptrProductData.DataSource = dt1;
                              RptrProductData.DataBind();
                              RptrProductData.Visible = true;
                          }
                          else
                          {
                              RptrProductData.Visible = false;
                          }
                      }
                  }
                  ds.Dispose();
                  ds.Clear();
                  ObjProductData = null;
              }*/
     
        private void BindAllActiveProductForMenu2()
        {
            ProductData ObjProductData = new ProductData();
            DataSet ds = ObjProductData.SelectAllActiveProductForMenu();

            if (ds.Tables.Count > 0)
            {
                DataTable categories = ds.Tables[0].DefaultView.ToTable(true, "CategoryID", "CategoryAlias", "CategoryName");
                RptrCategoryDataForMenu.DataSource = categories;
                RptrCategoryDataForMenu.DataBind();

                foreach (RepeaterItem categoryItem in RptrCategoryDataForMenu.Items)
                {
                    HiddenField hdnCategoryID = (HiddenField)categoryItem.FindControl("hdnCatgeory");
                    if (hdnCategoryID != null)
                    {
                        int categoryID;
                        if (int.TryParse(hdnCategoryID.Value, out categoryID))
                        {
                            Repeater RptrProductData = (Repeater)categoryItem.FindControl("RptrProductData");

                            DataView dataView = new DataView(ds.Tables[0]);
                            dataView.RowFilter = "CategoryID = " + categoryID;
                            DataTable products = dataView.ToTable();

                            if (products.Rows.Count > 0)
                            {
                                RptrProductData.DataSource = products;
                                RptrProductData.DataBind();
                                RptrProductData.Visible = true;
                            }
                            else
                            {
                                RptrProductData.Visible = false;
                            }
                        }
                    }
                }
            }
        }
       protected void btnSubmit_Click(object sender, EventArgs e)
       {
           Contact ObjContact = new Contact();
           int ret;
            try
            {
                ObjContact.EmailID = txtEmail.Text.TrimStart();
                ObjContact.PostedDate = DateTime.UtcNow;
                ret = ObjContact.SaveNewEnquiry();
                if (ret != -1)
                {
                    ObjContact = null;
                    Response.Redirect("/thankyou");
                }
            }
            catch (Exception ex)
            {
            
            }
        }  
       

    }
}