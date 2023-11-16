<%@ Page Title="" Language="C#" MasterPageFile="~/AdsSpirit.Master" AutoEventWireup="true" CodeBehind="product-details.aspx.cs" Inherits="AdsSprit.product_details" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <section>
         <div class="GrseMnShwHmePge">
          <div class="AbsplsSemn">
           <img src="asset/images/Prdct-Dtl-Logo.jpg"/>
            </div>
             <div class="container">
              <div class="Cl12MnSwnVr">
               <asp:Repeater ID="RptrProductHeaderImage" runat="server">
                <ItemTemplate>
                 <div class="cldl4pgesecmn"> 
                  <h4><%#Eval("ProductName")%></h4> 
                   <div class="ImgMobMnVr">
                    <img class="ApndMnsvr" src="">
                     </div> 
                      <div class="PeraHgt">
                      <p><%#Eval("ProductDescription")%></p>
                     </div>                                                
                    <div class="BtnAllSemn">
                   <a href="javascript:void(0)" class="RdMrBtn">Read More <img class="arwmove" src="asset/icon/icnlnvr.png"></a>
                  </div>
                 </div>
                <div class="cldl4pgesecmn GrnbSecmn">                                   
               <div class="cldl4pgesecmn GrnbSecmn">
              <img class="PrpndImgSwnvr" src="/AdsSpritImages/ProductImages/<%# Eval("ProductDefaultImage") %>" />
            </div>                                                                
           </div>

         <div class="cldl4pgesecmn">
          <h5>Tasting Notes </h5>
           <p><%#Eval("TastingNotes")%></p>
            <span>
             <small>Pack Sizes/SKU</small>
              <p>750 ml 375 ml 180 ml </p>
               </span>
                <span class="brand-social">
                 <small>Connect us</small>
                  <p>
                   <a href="#"><i class="fab fa-instagram"></i></a> 
                   <a href="#"><i class="fab fa-facebook-square"></i></i></a>
                   <a href="#"><i class="fab fa-youtube"></i></a>
                  </p>
               </span>
              </div>
             </ItemTemplate>
            </asp:Repeater> 
           </div>
          </div>
         </div>
        </section>

        <section>
         <div class="prDlPgeMnvr AdsSprtMnvr"> 
          <asp:Repeater ID="ReptBannerImageDetail" runat="server">
           <ItemTemplate>
            <div class="SrcoSldrCnDlpge owl-carousel owl-theme">
             <div class="imtmnVrSwn">
              <div class="ImgSurmn">
               <img src="/AdsSpritImages/ProductImages/<%# Eval("ProductImage1") %>" />
                </div>
                 <div class="CntSemnSldr">
                   <h1><%# Eval("DetailName") %></h1>
                   <div class="RdpDvSemnVr">
                   <h3>COlor </h3>
                   <p><%# Eval("DetailColor") %></p>
                   </div>
                   <div class="RdpDvSemnVr">
                    <h3>Nose </h3>
                    <p><%# Eval("DetailNOSE") %></p>
                    </div>
                    <div class="RdpDvSemnVr">
                    <h3>PALATE </h3>
                    <p><%# Eval("DetailPalate") %></p>
                    </div>
                    <div class="RdpDvSemnVr">
                    <h3>ABV </h3>
                    <p><%# Eval("DetailABV") %></p>
                   </div>
                  </div>
                 </div>
                </div>
               </ItemTemplate>
              </asp:Repeater>              
            </div>
        </section>

        <section>
            <div class="AwrdMnVr">
             <asp:Repeater ID="ReptOFAWARDS" runat="server">
              <ItemTemplate>
               <div class="container">
                <div class="AwrSemn">                     
                 <div class="awrdSldrMn owl-theme owl-carousel">
                  <div class="ArsCl12Sldrmn">
                   <div class="Cl6mnvrSwn">
                    <img src="/AdsSpritImages/ProductImages/<%# Eval("AwardImage") %>" />
                   </div>
                  <div class="Cl6mnvrSwn">
                 <h4><%# Eval("AwardName") %> </h4>
                <small><%# Eval("AwardDescription") %></small>
               </div>
              </div>
             </div>                       
            </div>
           </div>
          </ItemTemplate>
         </asp:Repeater> 
        </div>
       </section>

        <section>
         <div class="RylTxt-Wppr PrDlmnVrDlSwn">
          <div class="RylSlr-Wppr owl-carousel owl-theme ">
           <asp:Repeater ID="ReptBannerIndgerients" runat="server">
            <ItemTemplate>
             <div class="RylSldr-Itm">
              <div class="RylSldr-Img">
               <span>
                <img src="/AdsSpritImages/ProductImages/<%# Eval("ProductIngredients") %>" />
                 </span>
                  </div>
                   <div class="RylSldrTxt-Wpr">
                    <div class="container">
                     <div class="row">
                      <div class="RylTxtBx">
                       <div class="title">
                       <p><%# Eval("ProductDetailDescription") %></p>
                      </div>
                     </div>
                    </div>
                   </div>
                  </div>
                 </div>
                </ItemTemplate>
               </asp:Repeater>
              </div>
             </div>                 
         </section>

        <section>            
        <asp:Repeater ID="ReptwhiskyRange1" runat="server">
          <ItemTemplate>
              <div class="rltdProMnSec">
              <div class="container">
                <h6> MORE RANGE OF WHISKY </h6>
                  <div class="RldtdProSecmn owl-carousel owl-theme">
                    <div class="Cl4GrSemn">
                      <a href="/<%#Eval("ProductNameAlias")%>" class="linkall"></a>                        
                       <div class="PrlClSemnLst">
                        <img class="ByDefultimg" src="/AdsSpritImages/ProductImages/<%# Eval("ProductDefaultImage") %>" />
                        <img class="HovrImgSemn" src="/AdsSpritImages/ProductImages/<%# Eval("ProductImage2") %>" />
                         </div>
                         <div class="theCntSwnGen"> 
                           <h5><%#Eval("ProductName")%></h5>
                         <div class="BtnAllSemn">
                         <a href="/<%#Eval("ProductNameAlias")%>">Explore <img class="arwmove" src="asset/icon/icnlnvr.png"></a>
                       </div>
                     </div>
                   </div>                  
                 </div>
              </div>
             </div>
            </ItemTemplate>
         </asp:Repeater>
           
        </section>

              <section>
                   <div class="ExplreYurBrns">
                    <div class="container">
                     <div class="TleMnvr ExplrHdng-Wppr">
                     <h5>EXPLORE OUR Brands</h5>
                     <p>Our mission is to follow international practices and processes with customers and oursupply partners. </p>
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
