using Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AdsSprit
{
    public partial class csr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Selectcsrbanner();
            }
        }

        private void Selectcsrbanner()
        {
         Banner ObjBanner = new Banner();
         DataSet ds = new DataSet();
         ds = ObjBanner.Selectcsrbanner();
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
    }
}