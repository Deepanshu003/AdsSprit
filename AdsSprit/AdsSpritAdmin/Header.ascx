<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="AdsSprit.Header" %>
<nav class="navbar-default navbar-side" role="navigation">
    <div class="logo_c_n">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse"> 
            <span class="sr-only">Toggle navigation</span> 
            <span class="icon-bar"></span> 
            <span class="icon-bar"></span> 
            <span class="icon-bar"></span> 
        </button>
        <a class="navbar-brand" href='/AdsSpritAdmin/home'><img src="/AdsSpritAdmin/images/adslogo.png" width="200" style="margin-top:10px;margin-left: 22px;" /></a>      
    <div style="clear:both;"></div>
    </div>
 <div class="sidebar-collapse Header_nav_Active">
        <ul class="nav" id="main-menu">
            <asp:Literal ID="ltrHeaderMenu" runat="server"></asp:Literal>
           <li> <a href='/AdsSpritAdmin/home'><i class='fa fa-sitemap'></i>Dashboard</a></li>
            <li><a href="javascript:void(0);"><i class="fa fa-sitemap"></i>Product Master<span class="fa arrow"></span></a>
                <ul class="nav nav-second-level">
                    <li><a href='/AdsSpritAdmin/product-data'><i class="fa fa-arrow-right"></i>Manage Product Data</a></li>
                     <li><a href='/AdsSpritAdmin/category'><i class="fa fa-arrow-right"></i>Manage Product Category </a></li>
                    <li><a href='/AdsSpritAdmin/manage-cocktails'><i class="fa fa-arrow-right"></i>Manage Cocktails </a></li>
                    <li><a href='/AdsSpritAdmin/manage-awards'><i class="fa fa-arrow-right"></i>Manage Awards </a></li>
                </ul>
            </li>  
             <li><a href="javascript:void(0);"><i class="fa fa-sitemap"></i>Values Provider<span class="fa arrow"></span></a>
                <ul class="nav nav-second-level">
                    <li><a href='/AdsSpritAdmin/manage-Leader-events'><i class="fa fa-arrow-right"></i>Manage leader</a></li>
                     <li><a href='/AdsSpritAdmin/manage-Leader'><i class="fa fa-arrow-right"></i>Manage LeaderShip Data</a></li>
                </ul>
            </li> 
             <li><a href="javascript:void(0);"><i class="fa fa-sitemap"></i>Manage People<span class="fa arrow"></span></a>
                <ul class="nav nav-second-level">
                    <li><a href='/AdsSpritAdmin/manage-Job'><i class="fa fa-arrow-right"></i>Manage Job</a></li>
                    <li><a href='/AdsSpritAdmin/manage-contact'><i class="fa fa-arrow-right"></i>Manage Queries</a></li>
                    <li><a href='/AdsSpritAdmin/manage-jobEnquiry'><i class="fa fa-arrow-right"></i>Manage Job Enquery</a></li>
                </ul>
            </li>
             <li><a href="javascript:void(0);"><i class="fa fa-sitemap"></i>Manage Banner<span class="fa arrow"></span></a>
                <ul class="nav nav-second-level">
                    <li><a href='/AdsSpritAdmin/manage-Banner'><i class="fa fa-arrow-right"></i>Manage Banner</a></li>
                </ul>
            </li>  
             <li><a href="javascript:void(0);"><i class="fa fa-sitemap"></i>Setting<span class="fa arrow"></span></a>
                <ul class="nav nav-second-level">
                    <li><a href='/AdsSpritAdmin/change-password'><i class="fa fa-arrow-right"></i>Change Password</a></li>
                     <li><a href='/AdsSpritAdmin/logout'><i class="fa fa-arrow-right"></i>LogOut</a></li>
                </ul>
            </li>               
         <%--    <li><a href="javascript:void(0);"><i class="fa fa-sitemap"></i>Product Master<span class="fa arrow"></span></a>
                <ul class="nav nav-second-level">
                    <li><a href='/AdsSpritAdmin/product-data'><i class="fa fa-arrow-right"></i>Manage Product Data</a></li>
                    <li><a href='/AdsSpritAdmin/category'><i class="fa fa-arrow-right"></i>Manage Category Data</a></li>
                    <li><a href='/AdsSpritAdmin/sub-category'><i class="fa fa-arrow-right"></i>Manage Sub Category</a></li>
                    <li><a href='/AdsSpritAdmin/flavour'><i class="fa fa-arrow-right"></i>Manage Flavour Data</a></li>
                    <li><a href='/AdsSpritAdmin/package'><i class="fa fa-arrow-right"></i>Manage Size Data</a></li>
                    <li><a href='/AdsSpritAdmin/design'><i class="fa fa-arrow-right"></i>Manage Design Data</a></li>
                    <li><a href='/AdsSpritAdmin/occasion'><i class="fa fa-arrow-right"></i>Manage Occasion Data</a></li>
                    <li><a href='/AdsSpritAdmin/add-ons'><i class="fa fa-arrow-right"></i>Manage Add Ons</a></li>

                </ul>
            </li>
            <li> <a href='/AdsSpritAdmin/coupan'><i class='fa fa-sitemap'></i>Coupon Master</a></li>
            <li><a href="javascript:void(0);"><i class="fa fa-sitemap"></i>Customer Master<span class="fa arrow"></span></a>
                <ul class="nav nav-second-level">
                    <li><a href="/AdsSpritAdmin/cutomer"><i class="fa fa-sitemap"></i>Manage Customer Data</a></li>
                    <li><a href="/AdsSpritAdmin/order"><i class="fa fa-sitemap"></i>Manage Order</a></li>
                    <li><a href="/AdsSpritAdmin/wishList"><i class="fa fa-sitemap"></i>Manage WishList</a></li>
                    <li><a href="/AdsSpritAdmin/wallet"><i class="fa fa-sitemap"></i>Manage Wallet</a></li>
                    <li><a href="/AdsSpritAdmin/testinomials"><i class="fa fa-sitemap"></i>Manage Testinomials</a></li>
                </ul>
            </li>
            <li> <a href='/AdsSpritAdmin/report'><i class='fa fa-sitemap'></i>Report Master</a></li>
            <li> <a href='/AdsSpritAdmin/blog-data'><i class='fa fa-sitemap'></i>Blog Master</a></li>
            <li> <a href='/AdsSpritAdmin/contact-us'><i class='fa fa-sitemap'></i>Normal Enquiry</a></li>
            <li> <a href='/AdsSpritAdmin/subscribe'><i class='fa fa-sitemap'></i>Subscription Master</a></li>
            <li><a href='/AdsSpritAdmin/Manage-store-locator'><i class='fa fa-sitemap'></i>Store Master</a></li>
            <li><a href="javascript:void(0);"><i class="fa fa-sitemap"></i>Setting<span class="fa arrow"></span></a>
                <ul class="nav nav-second-level">
                    <li><a href='/AdsSpritAdmin/change-password'><i class="fa fa-arrow-right"></i>Change Password</a></li>
                    <li><a href='/AdsSpritAdmin/logout'><i class="fa fa-arrow-right"></i>Logout</a></li> 
                </ul>
            </li>--%>
        </ul>
    </div>
</nav>