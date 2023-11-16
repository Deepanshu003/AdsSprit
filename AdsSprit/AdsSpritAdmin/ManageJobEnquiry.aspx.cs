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
    public partial class ManageJobEnquiry : System.Web.UI.Page
    {
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        Applicant ObjApplicant = new Applicant();
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
            ObjApplicant.SelectAllApplicants(GvJobEnquiry);
            if (GvJobEnquiry.Rows.Count == 0)
            {
                GvJobEnquiry.Visible = false;
                lblError.Text = "Record Not Found";
                lblTotalNoOFRow.Text = "";
            }
            else
            {
                GvJobEnquiry.Visible = true;
                lblError.Text = "";
                if (GvJobEnquiry.Rows.Count > 1)
                    lblTotalNoOFRow.Text = "The total number of rows available are : " + GvJobEnquiry.Rows.Count.ToString();
                else
                    lblTotalNoOFRow.Text = "The total number of row available is : " + GvJobEnquiry.Rows.Count.ToString();
            }
        }
        protected void GvJobEnquiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvJobEnquiry_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GvJobEnquiry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}