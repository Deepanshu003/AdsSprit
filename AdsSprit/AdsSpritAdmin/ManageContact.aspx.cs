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
    public partial class ManageContact : System.Web.UI.Page
    {
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        Contact ObjContact = new Contact();
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
                BindContactGrid();

            }
        }

        private void BindContactGrid()
        {
            if ((DdEnquiry.SelectedValue) == "")
                ObjContact.Designation = "";
            else
                ObjContact.Designation = DdEnquiry.SelectedValue;
            ObjContact.UpdatedBy = ddProductCategory.SelectedValue; //used for product Category Name
            ObjContact.City = ddProductData.SelectedItem.Text; //used for product Name
            ObjContact.SelectAllEnquiry(GvContact);
            if (GvContact.Rows.Count == 0)
            {
                GvContact.Visible = false;
                btnDownload.Visible = false;
                lblError.Text = "Record Not Found";
                lblTotalNoOFRow.Text = "";
            }
            else
            {
                GvContact.Visible = true;
                btnDownload.Visible = true;
                lblError.Text = "";
                if (GvContact.Rows.Count > 1)
                    lblTotalNoOFRow.Text = "The total number of rows available are : " + GvContact.Rows.Count.ToString();
                else
                    lblTotalNoOFRow.Text = "The total number of row available is : " + GvContact.Rows.Count.ToString();
            }
        }

        protected void GvContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvContact.PageIndex = e.NewPageIndex;
            BindContactGrid();
        }

        protected void GvContact_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string sValue = ((HiddenField)GvOrderProduct.SelectedRow.Cells[13].FindControl("hdnOrderStatus")).Value;
                if (DdEnquiry.SelectedValue != "Normal Enquiry")
                    e.Row.Cells[4].Visible = true;
                else
                    e.Row.Cells[4].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (DdEnquiry.SelectedValue != "Normal Enquiry")
                    e.Row.Cells[4].Visible = true;
                else
                    e.Row.Cells[4].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (DdEnquiry.SelectedValue != "Normal Enquiry")
                    e.Row.Cells[4].Visible = true;
                else
                    e.Row.Cells[4].Visible = false;
            }
        }

        private void DeleteRecord(int ContactID)
        {
          int ret;
          try
          {
              ObjContact.ContactID = ContactID;
              ret = ObjContact.DeleteEnquiryByEnquiryID();
              if (ret == 547)
              {
                  lblMsg.Text = "Related Record Exist";
              }
              else
              {
                  lblMsg.Text = "Record Successfully Deleted";
                  BindContactGrid();
              }
          }
          catch (Exception Ex)
          {
              lblError.Text = Ex.Message;
          }
        }

        protected void GvContact_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BindContactGrid();
        }

        protected void GvContact_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          if (e.CommandName == "Delete")
          {
              int ContactID = Convert.ToInt16(e.CommandArgument);
              DeleteRecord(ContactID);
          }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            if (GvContact.Rows.Count > 0)
            {
                if ((DdEnquiry.SelectedValue) == "")
                    ObjContact.Designation = "";
                else
                    ObjContact.Designation = DdEnquiry.SelectedValue;
                DataSet ds = ObjContact.ExportEmailIDsintoExcel();
                ViewState["Data"] = ds.Tables[0];
                DataTable dt = (DataTable)ViewState["Data"];
                dt.Columns.Remove("sno");
                ObjComm.ExportGridView(dt, "Ads-Spirit-Contact");
            }
            else
                lblError.Text = "No record(s) to export";
        }

        protected void DdEnquiry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddProductData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}