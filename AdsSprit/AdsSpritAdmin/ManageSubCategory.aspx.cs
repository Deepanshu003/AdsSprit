using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Component;
using Utility;
using System.Data;
using System.Data.SqlClient;

namespace AdsSprit.AdsSpritAdmin
{
    public partial class ManageSubCategory : System.Web.UI.Page
    {
        ManageException ObjEx = new ManageException();
        CommanFunction ObjComm = new CommanFunction();
        SubCategoryData ObjSubCategoryData = new SubCategoryData();
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
                BindCategoryGrid("", "");
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
            ObjSubCategoryData.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
            BindCategoryGrid("", "");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ObjSubCategoryData.UpdatedBy = txtSerachData.Text;
            BindCategoryGrid("", "");
        }

        private void BindCategoryGrid(string sortExp, string sortDir)
        {
            ObjSubCategoryData.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
            ObjSubCategoryData.UpdatedBy = txtSerachData.Text;
            ObjSubCategoryData.SelectAllSubCategory(GvCategory);
            if (GvCategory.Rows.Count == 0)
            {
                GvCategory.Visible = false;
                lblError.Text = "Record Not Found";
                lblTotalNoOFRow.Text = "";
                btnDownload.Visible = false;
            }
            else
            {
                btnDownload.Visible = true;
                GvCategory.Visible = true;
                lblError.Text = "";
                if (GvCategory.Rows.Count > 1)
                    lblTotalNoOFRow.Text = "The total number of rows available are : " + GvCategory.Rows.Count.ToString();
                else
                    lblTotalNoOFRow.Text = "The total number of row available is : " + GvCategory.Rows.Count.ToString();
            }
        }

        protected void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string displayorder = string.Empty;
                for (int i = 0; i < GvCategory.Rows.Count; i++)
                {
                    HiddenField HiddenField1 = (HiddenField)GvCategory.Rows[i].Cells[2].FindControl("HiddenField1");
                    TextBox txtdisplayorder = (TextBox)GvCategory.Rows[i].Cells[2].FindControl("txtDisplayOrder");
                    displayorder = txtdisplayorder.Text;
                    ObjSubCategoryData.SubCategoryID = Convert.ToInt32(HiddenField1.Value);
                    ObjSubCategoryData.DisplayOrder = Convert.ToInt32(txtdisplayorder.Text);
                    ObjSubCategoryData.UpdateSubCategoryDataDisplayOrder();
                }
                Session["msg"] = "Order Updated Successfully";
                BindCategoryGrid("", "");
            }

            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure UpdateDisplayOrder()", ex);
            }
        }

        private void DeleteRecord(int CategoryID)
        {
            int ret;
            try
            {
                ObjSubCategoryData.SubCategoryID = CategoryID;
                ret = ObjSubCategoryData.DeleteSubCategoryByID();
                if (ret == 547)
                {
                    lblMsg.Text = "Related Record Exist";
                }
                else
                {
                    lblMsg.Text = "Record Successfully Deleted";
                    BindCategoryGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
            catch (Exception Ex)
            {
                lblError.Text = Ex.Message;
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/addupd-sub-category");
        }

        protected void GvCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvCategory.PageIndex = e.NewPageIndex;
            BindCategoryGrid("", "");
        }

        protected void GvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("/AdsSpritAdmin/addupd-sub-category?SubCategoryID=" + e.CommandArgument);
            }
            else if (e.CommandName == "Delete")
            {
                int CategoryID = Convert.ToInt16(e.CommandArgument);
                DeleteRecord(CategoryID);
            }
        }

        protected void GvCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BindCategoryGrid("", "");
        }

        protected void GvCategory_Sorting(object sender, GridViewSortEventArgs e)
        {
            BindCategoryGrid(e.SortExpression, sortOrder);
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


        protected void btnDownload_Click(object sender, EventArgs e)
        {

            if (GvCategory.Rows.Count > 0)
            {
                ObjSubCategoryData.CategoryID = Convert.ToInt32(DdCategory.SelectedValue);
                DataSet ds = ObjSubCategoryData.ExportEmailIDsintoExcel();
                ViewState["Data"] = ds.Tables[0];
                DataTable dt = (DataTable)ViewState["Data"];
                dt.Columns.Remove("sno");
                if (DdCategory.SelectedValue != "0")
                    ObjComm.ExportGridView(dt, "Bakers-Oven-" + DdCategory.SelectedItem.Text.Replace(" ", "-") + "-Sub-Catgeory");
                else
                    ObjComm.ExportGridView(dt, "Bakers-Oven-Sub-Catgeory");
            }
            else
                lblError.Text = "No record(s) to export";
        }
    }
}