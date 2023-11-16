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
    public partial class Manageleader : System.Web.UI.Page
    {

        ManageException ObjEx = new ManageException();
        LeaderCategory objLeaderCategory = new LeaderCategory();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            objLeaderCategory.UpdatedBy = txtSerachData.Text;
            BindSubscriptionGrid("", "");
        }

        private void BindSubscriptionGrid(string sortExp, string sortDir)
        {
            objLeaderCategory.UpdatedBy = txtSerachData.Text;
            objLeaderCategory.SelectAllLeader(GvLeaderData);
            if (GvLeaderData.Rows.Count == 0)
            {
                GvLeaderData.Visible = false;
                lblError.Text = "Record Not Found";
                lblTotalNoOFStore.Text = "";
            }
            else
            {
                DataTable dt = (DataTable)GvLeaderData.DataSource;
                DataView dv = new DataView();
                dv = dt.DefaultView;
                if (sortExp != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}", sortExp, sortDir);
                }
                GvLeaderData.DataSource = dv;
                GvLeaderData.DataBind();

                GvLeaderData.Visible = true;
                lblError.Text = "";
                lblTotalNoOFStore.Text = "Total no of Leaderships : " + dt.Rows.Count.ToString();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/addupd-Leader-category");
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

        protected void GvLeaderData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvLeaderData.PageIndex = e.NewPageIndex;
            BindSubscriptionGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
        }

        protected void GvLeaderData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int BlogDataID = Convert.ToInt16(e.CommandArgument);
                DeleteRecord(BlogDataID);
            }
            if (e.CommandName == "Edit")
            {
                Response.Redirect("/AdsSpritAdmin/addupd-Leader-category?ID=" + e.CommandArgument);
            }
        }

        protected void GvLeaderData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BindSubscriptionGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
        }

        private void DeleteRecord(int BlogDataID)
        {
            int ret = 0;
            try
            {
                objLeaderCategory.LeaderID = BlogDataID;
                ret = objLeaderCategory.DeletLeaderByID();
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

        protected void GvLeaderData_Sorting(object sender, GridViewSortEventArgs e)
        {
            BindSubscriptionGrid(e.SortExpression, sortOrder);
            ViewState["sortExp"] = e.SortExpression;
        }
    }
}