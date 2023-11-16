using Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdsSprit
{
    public partial class Infrastructure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategoryImages();
            }
        }

        private void BindCategoryImages()
        {
            Banner ObjBannerData = new Banner();
            DataSet ds = new DataSet();
            ds = ObjBannerData.SelectBannerDisplay1();
            if (ds.Tables[0].Rows.Count > 0)
            {

                ReptBannerImage1.DataSource = ds.Tables[0];
                ReptBannerImage1.DataBind();
                ReptBannerImage1.Visible = true;
            }
            else
            {
                ReptBannerImage1.Visible = false;
            }
            ds.Dispose();
            ds.Clear();
            ObjBannerData = null;
        }
    }
}