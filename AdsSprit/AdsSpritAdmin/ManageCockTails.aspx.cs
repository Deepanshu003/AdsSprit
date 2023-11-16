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
    public partial class ManageCockTails : System.Web.UI.Page
    {
        ManageException ObjEx = new ManageException();
        CockTails objCockTails = new CockTails();
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
                BindSubscriptionGrid("", "");
            }
        }

        protected void GvCockTails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvCockTails.PageIndex = e.NewPageIndex;
            BindSubscriptionGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
        }

        private void BindSubscriptionGrid(string sortExp, string sortDir)
        {
            objCockTails.UpdatedBy = txtSerachData.Text;
            objCockTails.SelectAllCockTails(GvCockTails);
            if (GvCockTails.Rows.Count == 0)
            {
                GvCockTails.Visible = false;
                lblError.Text = "Record Not Found";
                lblTotalNoOFStore.Text = "";
            }
            else
            {
                DataTable dt = (DataTable)GvCockTails.DataSource;
                DataView dv = new DataView();
                dv = dt.DefaultView;
                if (sortExp != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}", sortExp, sortDir);
                }
                GvCockTails.DataSource = dv;
                GvCockTails.DataBind();

                GvCockTails.Visible = true;
                lblError.Text = "";
                lblTotalNoOFStore.Text = "Total no of Blogs : " + dt.Rows.Count.ToString();
            }
        }

        protected void GvCockTails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int CockTailsID = Convert.ToInt16(e.CommandArgument);
                DeleteRecord(CockTailsID);
            }
            if (e.CommandName == "Edit")
            {
                Response.Redirect("/AdsSpritAdmin/add-cocktails?ID=" + e.CommandArgument);
            }
        }

        protected void GvCockTails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BindSubscriptionGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
        }

        private void DeleteRecord(int CockTailsID)
        {
            int ret = 0;
            try
            {
                objCockTails.CockTailsID = CockTailsID;
                ret = objCockTails.DeletCockTailsByID();
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

        protected void GvCockTails_Sorting(object sender, GridViewSortEventArgs e)
        {
            BindSubscriptionGrid(e.SortExpression, sortOrder);
            ViewState["sortExp"] = e.SortExpression;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            objCockTails.UpdatedBy = txtSerachData.Text;
            BindSubscriptionGrid("", "");
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/add-cocktails");
        }
    }
}