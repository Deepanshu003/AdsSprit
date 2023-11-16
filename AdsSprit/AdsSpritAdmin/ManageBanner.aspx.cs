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
    public partial class ManageBanner : System.Web.UI.Page
    {
        ManageException ObjEx = new ManageException();
        Banner objBanner = new Banner();
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
           
        }

        private void BindSubscriptionGrid(string sortExp, string sortDir)
        {
            objBanner.UpdatedBy = txtSerachData.Text;
            objBanner.SelectAllBanner(GvBanner);
            if (GvBanner.Rows.Count == 0)
            {
                GvBanner.Visible = false;
                lblError.Text = "Record Not Found";
                lblTotalNoOFStore.Text = "";
            }
            else
            {
                DataTable dt = (DataTable)GvBanner.DataSource;
                DataView dv = new DataView();
                dv = dt.DefaultView;
                if (sortExp != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}", sortExp, sortDir);
                }
                GvBanner.DataSource = dv;
                GvBanner.DataBind();

                GvBanner.Visible = true;
                lblError.Text = "";
                lblTotalNoOFStore.Text = "Total no of BANNER : " + dt.Rows.Count.ToString();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/add-Banner");
        }

        private void DeleteRecord(int BannerID)
        {
            int ret = 0;
            try
            {
                objBanner.BannerID = BannerID;
                ret = objBanner.DeletBannerByID();
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

        protected void GvBanner_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvBanner.PageIndex = e.NewPageIndex;
            BindSubscriptionGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
        }

        protected void GvBanner_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int BannerID = Convert.ToInt16(e.CommandArgument);
                DeleteRecord(BannerID);
            }
            if (e.CommandName == "Edit")
            {
                Response.Redirect("/AdsSpritAdmin/add-Banner?ID=" + e.CommandArgument);
            }
        }

        protected void GvBanner_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BindSubscriptionGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
        }

        protected void GvBanner_Sorting(object sender, GridViewSortEventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/add-Banner");
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