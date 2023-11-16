using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Component;
using Utility;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace AdsSprit.AdsSpritAdmin
{
    public partial class ManageProductData : System.Web.UI.Page
    {
        ManageException ObjEx = new ManageException();
        ProductData ObjProductData = new ProductData();

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
                ViewState["sortOrder"] = "";
                ViewState["sortExp"] = "";
                BindSubscriptionGrid("", "");
            }
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
            ObjProductData.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
            BindSubscriptionGrid("", "");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ObjProductData.UpdatedBy = txtSerachData.Text;
            BindSubscriptionGrid("", "");
        }

        private void BindSubscriptionGrid(string sortExp, string sortDir)
        {
            ObjProductData.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
            ObjProductData.UpdatedBy = txtSerachData.Text;
            ObjProductData.SelectAllProductsData(GvServiceData);
            if (GvServiceData.Rows.Count == 0)
            {
                GvServiceData.Visible = false;
                lblError.Text = "Record Not Found";
                lblTotalNoOFStore.Text = "";
            }
            else
            {
                DataTable dt = (DataTable)GvServiceData.DataSource;
                DataView dv = new DataView();
                dv = dt.DefaultView;
                if (sortExp != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}", sortExp, sortDir);
                }
                GvServiceData.DataSource = dv;
                GvServiceData.DataBind();

                GvServiceData.Visible = true;
                lblError.Text = "";
                lblTotalNoOFStore.Text = "Total no of Rooms : " + dt.Rows.Count.ToString();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/addupd-product-data");
        }

        protected void GvServiceData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvServiceData.PageIndex = e.NewPageIndex;
            BindSubscriptionGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
        }

        protected void GvServiceData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int ProductID = Convert.ToInt16(e.CommandArgument);
                DeleteRecord(ProductID);
            }
            if (e.CommandName == "Edit")
            {
                Response.Redirect("/AdsSpritAdmin/addupd-product-data?ProductID=" + e.CommandArgument);
            }
        }

        private void DeleteRecord(int ProductID)
        {
            int ret = 0;
            try
            {
                ObjProductData.ProductID = ProductID;
                ret = ObjProductData.DeleteProductByProductID();
                if (ret == 547)
                {
                    lblMsg.Text = "Related Record Exist";
                }
                else
                {
                    lblMsg.Text = "Record Successfully Deleted";
                    BindSubscriptionGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
            catch (Exception Ex)
            {
                lblError.Text = Ex.Message;
            }
        }


        protected void GvServiceData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BindSubscriptionGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
        }

        protected void GvServiceData_Sorting(object sender, GridViewSortEventArgs e)
        {
            BindSubscriptionGrid(e.SortExpression, sortOrder);
            ViewState["sortExp"] = e.SortExpression;
        }

        public string sortOrder
        {
            get
            {
                if (ViewState["sortOrder"].ToString() == "desc")
                    ViewState["sortOrder"] = "asc";
                else
                    ViewState["sortOrder"] = "desc";

                return ViewState["sortOrder"].ToString();
            }
            set
            {
                ViewState["sortOrder"] = value;
            }
        }
    }
}