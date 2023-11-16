using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace AdsSprit.AdsSpritAdmin
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add(new Route("{resource}.axd/{*pathInfo}", new StopRoutingHandler()));
            routes.Add(new Route("{*favicon}", null, new RouteValueDictionary { { "favicon", @"(.*/)?favicon.ico(/.*)?" } }, new StopRoutingHandler()));
            routes.Ignore("{*alljs}", new { alljs = ".*\\.js(/.*)?" });
            routes.Ignore("{*allpng}", new { allpng = ".*\\.png(/.*)?" });
            routes.Ignore("{*allcss}", new { allcss = ".*\\.css(/.*)?" });
            routes.Ignore("{*alljpg}", new { alljpg = ".*\\.jpg(/.*)?" });
            routes.Ignore("{*alljpeg}", new { alljpeg = ".*\\.jpeg(/.*)?" });
            routes.Ignore("{*alljpeg}", new { alljpeg = ".*\\.gif(/.*)?" });
            //Admin Panel
            routes.MapPageRoute("", "AdsSpritAdmin/login", "~/AdsSpritAdmin/index.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/home", "~/AdsSpritAdmin/Home.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/change-password", "~/AdsSpritAdmin/ChangePassword.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/logout", "~/AdsSpritAdmin/LOgout.aspx");

            //Product Data Category
            routes.MapPageRoute("", "AdsSpritAdmin/addupd-category", "~/AdsSpritAdmin/AddUpdCategory.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/category", "~/AdsSpritAdmin/ManageProductCategory.aspx");
            //Product Sub Category
            routes.MapPageRoute("", "AdsSpritAdmin/addupd-sub-category", "~/AdsSpritAdmin/AddUpdSubCategory.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/sub-category", "~/AdsSpritAdmin/ManageSubCategory.aspx");
            //Product Size
            routes.MapPageRoute("", "AdsSpritAdmin/addupd-Package", "~/AdsSpritAdmin/AddUpdSize.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/Size", "~/AdsSpritAdmin/ManageSize.aspx");
            //Product DATA
            routes.MapPageRoute("", "AdsSpritAdmin/product-data", "~/AdsSpritAdmin/ManageProductData.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/addupd-product-data", "~/AdsSpritAdmin/AddUpdProductData.aspx");
            //CockTAIL dATA
            routes.MapPageRoute("", "AdsSpritAdmin/manage-cocktails", "~/AdsSpritAdmin/ManageCockTails.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/add-cocktails", "~/AdsSpritAdmin/AddUpdCocktails.aspx");
            //Awards Data
            routes.MapPageRoute("", "AdsSpritAdmin/manage-awards", "~/AdsSpritAdmin/ManageAwards.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/addupd-awards", "~/AdsSpritAdmin/AddUpdAwards.aspx");
            //Leader Category
            routes.MapPageRoute("", "AdsSpritAdmin/manage-Leader-events", "~/AdsSpritAdmin/Manageleader.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/addupd-Leader-category", "~/AdsSpritAdmin/LeadrCategory.aspx");
            //Leader Data
            routes.MapPageRoute("", "AdsSpritAdmin/manage-Leader", "~/AdsSpritAdmin/ManageLeaderData.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/addupd-Leader", "~/AdsSpritAdmin/AddUpdLeadershipData.aspx");
            //Manage job
            routes.MapPageRoute("", "AdsSpritAdmin/manage-Job", "~/AdsSpritAdmin/ManageJob.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/addupd-Job", "~/AdsSpritAdmin/AddUpdJob.aspx");
            //SpiritSource
            routes.MapPageRoute("", "AdsSpritAdmin/manage-spirits", "~/AdsSpritAdmin/ManageSpiritSource.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/addupd-spirits", "~/AdsSpritAdmin/AddUpdSpiritsSource.aspx");
            //MaNAGE CONTACT
            routes.MapPageRoute("", "AdsSpritAdmin/manage-contact", "~/AdsSpritAdmin/ManageContact.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/manage-jobEnquiry", "~/AdsSpritAdmin/ManageJobEnquiry.aspx");
            //Manage Banner
            routes.MapPageRoute("", "AdsSpritAdmin/manage-Banner", "~/AdsSpritAdmin/ManageBanner.aspx");
            routes.MapPageRoute("", "AdsSpritAdmin/add-Banner", "~/AdsSpritAdmin/AddUpdBanner.aspx");
            //AdsSpiritUser 
            routes.MapPageRoute("", "thankyou", "~/thankyou.aspx");
            routes.MapPageRoute("", "ourstory", "~/our-story.aspx");
            routes.MapPageRoute("", "Infrastructure", "~/Infrastructure.aspx");
            routes.MapPageRoute("", "internationalbusiness", "~/international-business.aspx");
            routes.MapPageRoute("", "csr", "~/csr.aspx");
            routes.MapPageRoute("", "values", "~/values.aspx");
            routes.MapPageRoute("", "Carrer", "~/Carrer.aspx");
            routes.MapPageRoute("", "ContactUs", "~/ContactUs.aspx");
            routes.MapPageRoute("", "", "~/index.aspx");
            routes.MapPageRoute("", "product", "~/Product.aspx");
            routes.MapPageRoute("", "brands", "~/Brands.aspx");
            routes.MapPageRoute("", "brands/{CategoryAlias}", "~/Brands.aspx");
            routes.MapPageRoute("", "Category/{CategoryAlias}", "~/Product.aspx");

        //    routes.MapPageRoute("", "{CategoryName}/{CategoryAlias}", "~/Product.aspx");
           routes.MapPageRoute("", "{CategoryAlias}/{CategoryName}", "~/Product.aspx");
            routes.MapPageRoute("", "{ProductNameAlias}", "~/product-details.aspx");            
        }


        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}