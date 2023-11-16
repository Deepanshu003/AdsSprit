﻿using System;
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
    public partial class ManageSpiritSource : System.Web.UI.Page
    {
        ManageException ObjEx = new ManageException();
        Detail ObjAwards = new Detail();
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
                BindSpiritGrid("", "");
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdsSpritAdmin/addupd-spirits");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ObjAwards.UpdatedBy = txtSerachData.Text;
            BindSpiritGrid("", "");
        }

        protected void GvAwards_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvSpiritSource_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvSpiritSource.PageIndex = e.NewPageIndex;
            BindSpiritGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
        }

        protected void GvSpiritSource_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("/AdsSpritAdmin/addupd-spirits?ID=" + e.CommandArgument);
            }
            else if (e.CommandName == "Delete")
            {
                int AwardsID = Convert.ToInt16(e.CommandArgument);
                DeleteRecord(AwardsID);
            }
        }

        protected void GvSpiritSource_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BindSpiritGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
        }

        private void DeleteRecord(int CelebrationDataID)
        {
            int ret;
            try
            {
                ObjAwards.DetailID = CelebrationDataID;
                ret = ObjAwards.DeletDetailByID();
                if (ret == 547)
                {
                    lblMsg.Text = "Related Record Exist";
                }
                else
                {
                    lblMsg.Text = "Record Successfully Deleted";
                    BindSpiritGrid(ViewState["sortExp"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
            catch (Exception Ex)
            {
                lblError.Text = Ex.Message;
            }
        }

        private void BindSpiritGrid(string sortExp, string sortDir)
        {
            ObjAwards.UpdatedBy = txtSerachData.Text;
            ObjAwards.SelectAllDetail(GvSpiritSource);
            if (GvSpiritSource.Rows.Count == 0)
            {
                GvSpiritSource.Visible = false;
                lblError.Text = "Record Not Found";
                lblTotalNoOFRow.Text = "";
                btnDownload.Visible = false;
            }
            else
            {
                DataTable dt = (DataTable)GvSpiritSource.DataSource;
                DataView dv = new DataView();
                dv = dt.DefaultView;
                if (sortExp != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}", sortExp, sortDir);
                }
                GvSpiritSource.DataSource = dv;
                GvSpiritSource.DataBind();

                GvSpiritSource.Visible = true;
                btnDownload.Visible = true;
                lblError.Text = "";
                if (dt.Rows.Count > 1)
                    lblTotalNoOFRow.Text = "The total number of rows available are : " + dt.Rows.Count.ToString();
                else
                    lblTotalNoOFRow.Text = "The total number of row available is : " + dt.Rows.Count.ToString();
            }
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

        protected void GvSpiritSource_Sorting(object sender, GridViewSortEventArgs e)
        {
            BindSpiritGrid(e.SortExpression, sortOrder);
            ViewState["sortExp"] = e.SortExpression;
        }
    }
}