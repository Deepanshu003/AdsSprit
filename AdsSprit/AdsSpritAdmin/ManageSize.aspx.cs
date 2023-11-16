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
    public partial class ManageSize : System.Web.UI.Page
    {

        ManageException ObjEx = new ManageException();
        SizeData ObjSizeData = new SizeData();
        CommanFunction ObjComm = new CommanFunction();
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
                ViewState["sortOrder"] = "";
                ViewState["sortExp"] = "";
                BindSizeGrid("", "");
            }
        }

        protected void DDSizeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjSizeData.SizeUnit = DDSizeType.SelectedValue;
            BindSizeGrid("", "");
        }

        private void BindSizeGrid(string sortExp, string sortDir)
        {
            ObjSizeData.SizeUnit = DDSizeType.SelectedValue;
            ObjSizeData.SelectAllSizeData(GvSize);
            if (GvSize.Rows.Count == 0)
            {
                GvSize.Visible = false;
                lblError.Text = "Record Not Found";
                lblTotalNoOFRow.Text = "";
                btnDownload.Visible = false;
            }
            else
            {
                btnDownload.Visible = true;
                GvSize.Visible = true;
                lblError.Text = "";
                if (GvSize.Rows.Count > 1)
                    lblTotalNoOFRow.Text = "The total number of rows available are : " + GvSize.Rows.Count.ToString();
                else
                    lblTotalNoOFRow.Text = "The total number of row available is : " + GvSize.Rows.Count.ToString();
            }
        }

        private void DeleteRecord(int PackageID)
        {
            int ret;
            try
            {
                ObjSizeData.SizeID = PackageID;
                ret = ObjSizeData.DeleteSizeDataBySizeID();
                if (ret == 547)
                {
                    lblMsg.Text = "Related Record Exist";
                }
                else
                {
                    lblMsg.Text = "Record Successfully Deleted";
                    BindSizeGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
            catch (Exception Ex)
            {
                lblError.Text = Ex.Message;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/addupd-Package");
        }

        protected void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string displayorder = string.Empty;
                for (int i = 0; i < GvSize.Rows.Count; i++)
                {
                    HiddenField HiddenField1 = (HiddenField)GvSize.Rows[i].Cells[2].FindControl("HiddenField1");
                    TextBox txtdisplayorder = (TextBox)GvSize.Rows[i].Cells[2].FindControl("txtDisplayOrder");
                    displayorder = txtdisplayorder.Text;
                    ObjSizeData.SizeID = Convert.ToInt32(HiddenField1.Value);
                    ObjSizeData.DisplayOrder = Convert.ToInt32(txtdisplayorder.Text);
                    ObjSizeData.UpdateSizeDataDisplayOrder();
                }
                Session["msg"] = "Order Updated Successfully";
                BindSizeGrid("", "");
            }

            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure UpdateDisplayOrder()", ex);
            }
        }

        protected void GvSize_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvSize.PageIndex = e.NewPageIndex;
            BindSizeGrid("", "");
        }

        protected void GvSize_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("/AdsSpritAdmin/addupd-package?SizeID=" + e.CommandArgument);
            }
            else if (e.CommandName == "Delete")
            {
                int PackageID = Convert.ToInt16(e.CommandArgument);
                DeleteRecord(PackageID);
            }
        }

        protected void GvSize_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BindSizeGrid("", "");
        }

        protected void GvSize_Sorting(object sender, GridViewSortEventArgs e)
        {
            BindSizeGrid(e.SortExpression, sortOrder);
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
            if (GvSize.Rows.Count > 0)
            {
                ObjSizeData.SizeUnit = DDSizeType.SelectedValue;
                DataSet ds = ObjSizeData.ExportEmailIDsintoExcel();
                ViewState["Data"] = ds.Tables[0];
                DataTable dt = (DataTable)ViewState["Data"];
                dt.Columns.Remove("sno");
                ObjComm.ExportGridView(dt, "ads-sprit-Size-Data");
            }
            else
                lblError.Text = "No record(s) to export";
        }
    }
}