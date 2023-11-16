<%@ Page Title="" Language="C#" MasterPageFile="~/AdsSpirit.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AdsSprit.index" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <main>
        <!-- Index page Html Code  -->
        <!-- Banner section html -->
        <section>           
            <div class="CmnPage SldrPgrAds">
                <!-- <img src="asset/images/bnrshwn.jpg"> -->
                <div class="SrcoSldrCn owl-carousel owl-theme">
                 <asp:Repeater ID="RptrBannerImage" runat="server">
                   <ItemTemplate>
                    <div class="imtmnVrSwn">                         
                        <div class="ImgSurmn">
                          <img src="/AdsSpritImages/ProductImages/<%# Eval("ProductImage1") %>" />
                        </div>
                        <div class="CntSemnSldr"> 
                         <h1><%#Eval("ProductName")%></h1>
                        <p><%#Eval("SmallDescription")%></p>
                         <div class="BtnAllSemn">
                           <a href="/<%#Eval("CategoryAlias")%>/<%#Eval("ProductNameAlias")%>">Explore <img class="arwmove" src="asset/icon/icnlnvr.png"></a>
                         </div>
                        </div>                                                
                     </div>
                     </ItemTemplate>
                  </asp:Repeater>                   
                </div>

            </div>
        </section>

        <section class="AnimateSec">
            <div class="OurStrmnVr">
                <div class="container">
                    <div class="CntTltTtle">
                        <small class="ac">Since 1998</small>
                        <h3 class="ac">OUR STORY</h3>
                        <p>Fastest growing liquor conglomerate in the Indian alcobev space known for its customer-first approach in the Indian Market. </p>
                        <div class="BtnAllSemn">
                            <a href="ourstory"> Read More  <img class="arwmove" src="asset/icon/icnlnvr.png"></a>
                        </div>
                    </div>

                    <div class="Cl12SemnvrTuv">
                       

                        <div class="cl10navSemnvr">
                            <img src="asset/images/bottle/bottleimg4.png">
                        </div>

                        <div class="cl10navSemnvr">
                            <img src="asset/images/bottle/bottleimg3.png">
                        </div>
                        <div class="cl10navSemnvr">
                            <img src="asset/images/bottle/bottleimg7.png">
                        </div>

                        <div class="cl10navSemnvr">
                            <img src="asset/images/bottle/calender-brandy.png">
                        </div>
                        <div class="cl10navSemnvr">
                            <img src="asset/images/bottle/bottleimg1.png">
                        </div>
                        <div class="cl10navSemnvr">
                            <img src="asset/images/bottle/bottleimg2.png">
                        </div>

                        <div class="cl10navSemnvr">
                            <img src="asset/images/bottle/bottleimg5.png">
                        </div>

                        <div class="cl10navSemnvr">
                            <img src="asset/images/bottle/bottleimg6.png">
                        </div>
                        <div class="cl10navSemnvr">
                            <img src="asset/images/bottle/calender-rum.png">
                        </div>

                        

                       

                        
                    </div>
                </div>
            </div>
        </section>


        <section>

            <div class="FlwDrecmn">

                <div class="DRcmnmsgSecmn LndHeadr">
                    <img class="bg" src="asset/images/directrs.jpg">
                </div>

                <div class="DrcCmtMsvr">
                    <img src="asset/icon/quote.png">
                    <h3>Directors Message </h3>
                    <p>We at ADS Group believe in Win – Win approach with all our stake holders. Whether it’s our Consumers, for whom we offer superior products at reasonable value, our business partners, for whom we offer long term, transparent, fair business
                        practices or our employees whom we treat like members of our extended family and we want them to work with full freedom to unleash the entrepreneur spirit in each one of them</p>
                    <small>Mr. Ashok Maan</small>
                    <em>MD – ADS Group summarises the Group Philosophy</em>
                </div>

            </div>

        </section>

        <section>

            <div class="ExplreYurBrns">

                <div class="container">

                    <div class="TleMnvr">
                        <h5>EXPLORE OUR Brands</h5>
                        <p>Today the company boasts of having products across categories in the major consumptions segments and is proud to be creator of highly successful brands.</p>
                    </div>

                    <div class="cl12WskySwnmn">
                        <asp:Repeater ID="ReptCategoryImage1" runat="server">
                         <ItemTemplate>
                          <div class="cl6mnvrSet">                                                 
                            <div class="Brnsclimg">
                              <figure class="BannerImage">
                               <img class="cloud1" src="/AdsSpritImages/CategoryImages/<%# Eval("CategoryImage") %>" alt="<%# Eval("CategoryName") %>" />
                                </figure>
                                 </div>
                                 <div class="EngWhsyMntSevr">
                                  <h3><%# Eval("CategoryName") %></h3>
                                  <p><%# Eval("CategorysmallDescription") %></p>                             
                                <div class="BtnAllSemn">  
                            <%--<a href="/<%#Eval("CategoryAlias")%>/<%#Eval("CategoryName")%>">Explore</a> --%>
                               <a href="/Category/<%#Eval("CategoryAlias")%>">Explore</a>
                             </div>
                            </div>                      
                           </div>
                          </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

            </div>

        </section>

    </main>

    <div class="mobile-top-header">
        <ul>
            <li><a href="product.html">Brands </a></li>       
            <li><a class="EnqPhone" href="javascript:void(0);">Call Us</a></li>
            <li><a href="https://api.whatsapp.com/send?phone=919810012753&amp;text=Hi Team ads, I'm interested in Your Product. Could you please connect me?"> Chat  </a></li>
        </ul>
    </div>
</asp:Content>
