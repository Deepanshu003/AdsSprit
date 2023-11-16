using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Component;
using Utility;
using System.Text.RegularExpressions;

namespace AdsSprit.AdsSpritAdmin
{
    public partial class ManageLeaderData : System.Web.UI.Page
    {

        ManageException ObjEx = new ManageException();
        LeaderData ObjLeaderData = new LeaderData();
        LeaderCategory ObjLeaderCategory = new LeaderCategory();
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
                BindDdLeaderCategory();
                BindLeaderGrid("", "");
            } 
        }

        private void BindDdLeaderCategory()
        {
            LeaderCategory ObjLeaderCategory = new LeaderCategory();
            ObjLeaderCategory.SelectAllLeaderForDD(DDLeaderData, "LeaderName", "LeaderID");
            DDLeaderData.Items.Insert(0, new ListItem("Select Leader Category", "0"));
            ObjLeaderCategory = null;
        }

        protected void DDLeaderData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ObjLeaderData.UpdatedBy = txtSerachData.Text;
            BindLeaderGrid("", "");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/addupd-Leader");
        }

        protected void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string displayorder = string.Empty;
                for (int i = 0; i < GvLeader.Rows.Count; i++)
                {
                    HiddenField HiddenField1 = (HiddenField)GvLeader.Rows[i].Cells[2].FindControl("HiddenField1");
                    TextBox txtdisplayorder = (TextBox)GvLeader.Rows[i].Cells[2].FindControl("txtDisplayOrder");
                    displayorder = txtdisplayorder.Text;
                    ObjLeaderData.LeaderDataID = Convert.ToInt32(HiddenField1.Value);
                    ObjLeaderData.SortOrder = Convert.ToInt32(txtdisplayorder.Text);
                    ObjLeaderData.UpdateLeaderTimeDisplayOrder();
                }
                BindLeaderGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
            }

            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure UpdateDisplayOrder()", ex);
            }
        }

        private void DeleteRecord(int LeaderDataID)
        {
            int ret;
            try
            {
                ObjLeaderData.LeaderDataID = LeaderDataID;
                ret = ObjLeaderData.DeleteLeaderByLeaderDataID();
                if (ret == 547)
                {
                    lblMsg.Text = "Related Record Exist";
                }
                else
                {
                    lblMsg.Text = "Record Successfully Deleted";
                    BindLeaderGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
            catch (Exception Ex)
            {
                lblError.Text = Ex.Message;
            }
        }

        private void BindLeaderGrid(string sortExp, string sortDir)
        {
            ObjLeaderData.LeaderID = Convert.ToInt32(DDLeaderData.SelectedValue);
            ObjLeaderData.UpdatedBy = txtSerachData.Text;
            ObjLeaderData.SelectAllLeaderByLeaderIDorNot(GvLeader);
            if (GvLeader.Rows.Count == 0)
            {
                GvLeader.Visible = false;
                lblError.Text = "Record Not Found";
                lblTotalNoOFRow.Text = "";
                btnDownload.Visible = false;
            }
            else
            {
                DataTable dt = (DataTable)GvLeader.DataSource;
                DataView dv = new DataView();
                dv = dt.DefaultView;
                if (sortExp != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}", sortExp, sortDir);
                }
                GvLeader.DataSource = dv;
                GvLeader.DataBind();

                GvLeader.Visible = true;
                btnDownload.Visible = true;
                lblError.Text = "";
                if (dt.Rows.Count > 1)
                    lblTotalNoOFRow.Text = "The total number of rows available are : " + dt.Rows.Count.ToString();
                else
                    lblTotalNoOFRow.Text = "The total number of row available is : " + dt.Rows.Count.ToString();
            }
        }

        protected void GvLeader_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvLeader.PageIndex = e.NewPageIndex;
            BindLeaderGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
        }

        protected void GvLeader_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Edit")
            {
                Response.Redirect("/AdsSpritAdmin/addupd-Leader?ID=" + e.CommandArgument);
            }
            else if (e.CommandName == "Delete")
            {
                int DeliveryID = Convert.ToInt16(e.CommandArgument);
                DeleteRecord(DeliveryID);
            }
        }

        protected void GvLeader_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BindLeaderGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
        }

        protected void GvLeader_Sorting(object sender, GridViewSortEventArgs e)
        {
            BindLeaderGrid(e.SortExpression, sortOrder);
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

        }

        protected void DDLeaderData_SelectedIndexChanged1(object sender, EventArgs e)
        {
            ObjLeaderData.LeaderID = Convert.ToInt32(DDLeaderData.SelectedValue);
            BindLeaderGrid("", "");
        }
    }
}