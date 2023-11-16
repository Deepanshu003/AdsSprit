using Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AdsSprit
{
    public partial class Values : System.Web.UI.Page
    {

        Banner ObjBanner = new Banner();
        int BannerID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindIndexBannerImges();
               BindValues();
                BindTabs();
                BindDescriptions();
             //   BindAllActiveProductForMenu2();
            }

        }

        private void BindIndexBannerImges()
        {

            Banner ObjBanner = new Banner();
            DataSet ds = new DataSet();
            ds = ObjBanner.SelectValueBanner();
            if (ds.Tables[0].Rows.Count > 0)
            {

                RptrBannerImage.DataSource = ds.Tables[0];
                RptrBannerImage.DataBind();
                RptrBannerImage.Visible = true;
            }
            else
            {
                RptrBannerImage.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjBanner = null;
        }

 /*       private void BindAllActiveProductForMenu2()
        {
            LeaderData ObjBanner = new LeaderData();
            DataSet ds = ObjBanner.SelectLeaderData();

            if (ds.Tables.Count > 0)
            {
                DataTable categories = ds.Tables[0].DefaultView.ToTable(true, "LeaderID", "LeaderName");
                rEPTaLL.DataSource = categories;
                rEPTaLL.DataBind();

                foreach (RepeaterItem categoryItem in rEPTaLL.Items)
                {
                    HiddenField hdnLeaderID = (HiddenField)categoryItem.FindControl("hdnLeader");
                    if (hdnLeaderID != null)
                    {
                        int categoryID;
                        if (int.TryParse(hdnLeaderID.Value, out categoryID))
                        {
                            Repeater rptcONTENT = (Repeater)categoryItem.FindControl("rptcONTENT");

                            DataView dataView = new DataView(ds.Tables[0]);
                            dataView.RowFilter = "LeaderID = " + categoryID;
                            DataTable products = dataView.ToTable();

                            if (products.Rows.Count > 0)
                            {
                                rptcONTENT.DataSource = products;
                                rptcONTENT.DataBind();
                                rptcONTENT.Visible = true;
                            }
                            else
                            {
                                rptcONTENT.Visible = false;
                            }
                        }
                    }
                }
            }
        }
        */


 /*       private DataTable RemoveDuplicateTitles(DataTable source)
        {
            DataView view = new DataView(source);
            DataTable distinctTitles = view.ToTable(true, "LeaderTitle", "Descriptions", "VideoURl");
            return distinctTitles;
        } */
       private void BindValues()
        {

            LeaderData ObjBanner = new LeaderData();
            DataSet ds = new DataSet();
            ds = ObjBanner.SelectLeaderData();
            if (ds.Tables[0].Rows.Count > 0)
            {

                rptcONTENT.DataSource = ds.Tables[0];
                rptcONTENT.DataBind();
                rptcONTENT.Visible = true;
            }
            else
            {
                rptcONTENT.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjBanner = null;
        } 

       private void BindTabs()
        {

            LeaderData ObjBanner = new LeaderData();
            DataSet ds = new DataSet();
            ds = ObjBanner.SelectLeader();
            if (ds.Tables[0].Rows.Count > 0)
            {

                rptTabs.DataSource = ds.Tables[0];
                rptTabs.DataBind();
                rptTabs.Visible = true;
            }
            else
            {
                rptTabs.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjBanner = null;
        }
        
        private void BindDescriptions()
        {

            LeaderData ObjBanner = new LeaderData();
            DataSet ds = new DataSet();
            ds = ObjBanner.SelectLeaderData();
            if (ds.Tables[0].Rows.Count > 0)
            {
   //             DataTable distinctData = RemoveDuplicateTitles(ds.Tables[0]);
                reptDescriptions.DataSource = ds.Tables[0];
                reptDescriptions.DataBind();
                reptDescriptions.Visible = true;
            }
            else
            {
                reptDescriptions.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjBanner = null;
        }

       
    }
}