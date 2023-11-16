using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Component;
using Utility;
using System.Data;
using System.Text;

namespace AdsSprit
{
    public partial class Header : System.Web.UI.UserControl
    {
        AdminLogin ObjAdminLogin = new AdminLogin();
        UserPermission objUserPermission = new UserPermission();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] != null)
            {
                if (!IsPostBack)
                {
                    if (Session["AdminID"] != null)
                    {
                        BindSideBarDataWithPermission(Session["AdminID"].ToString());
                    }
                }
            }
            else
                Response.Redirect("/AdsSpritAdmin/login");
        }

        public void BindSideBarDataWithPermission(string UserID)
        {
            StringBuilder sb = new StringBuilder();
            DataSet ds = new DataSet();
            objUserPermission.UserID = Convert.ToInt32(UserID);
            ds = objUserPermission.SelectPageHeaderDatabyUserID();
            DataTable filterTable = ds.Tables[0].DefaultView.ToTable(true, "MenuHeader");
            if (filterTable.Rows.Count > 0)
            {
                for (int i = 0; i < filterTable.Rows.Count; i++)
                {
                    DataView dv = ds.Tables[0].DefaultView;
                    dv.RowFilter = "MenuHeader = '" + filterTable.Rows[i]["MenuHeader"] + "'";
                    DataTable dt = dv.ToTable();
                    if (dt.Rows.Count > 0)
                    {
                        sb.Append("<li><a href='javascript:void(0);'><i class='fa fa-sitemap'></i>" + filterTable.Rows[i]["MenuHeader"] + "<span class='fa arrow'></span></a>");
                        sb.Append("<ul class='nav nav-second-level'>");
                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
                            sb.Append("<li><a href='" + dt.Rows[k]["PageUrl"].ToString() + "'><i class='fa fa-arrow-right'></i>" + dt.Rows[k]["PageName"].ToString() + "</a></li>");
                        }
                        sb.Append("</ul>");
                    }
                }
            }
            ltrHeaderMenu.Text = sb.ToString();
            sb.Clear();
            ds.Dispose();
        }
    }
}