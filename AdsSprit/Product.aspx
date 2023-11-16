<%@ Page Title="" Language="C#" MasterPageFile="~/AdsSpirit.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="AdsSprit.Product" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <main>
       <section>
        <div class="ProBnrSemn">
         <asp:Repeater ID="RptrGalleryData1" runat="server">
          <ItemTemplate>
           <div class="BnseSeSwnMnvr">
            <img class="cloud2" src="/AdsSpritImages/CategoryImages/<%# Eval("CategoryImage") %>" />
              </div>
              <div class="OrWskWrlmn">
             <h3><%#Eval("CategoryDescription")%></h3>
            <p><%#Eval("CategorysmallDescription")%></p>
           </div>                
          </ItemTemplate>
         </asp:Repeater>                
        </div>
       </section>

        <section>

        <div class="GerSemnSen">
           <div class="container">
            <div class="cl12SemnvrtLstRyl">
             <asp:Repeater ID="ReptProductImages" runat="server">
              <ItemTemplate>
                 <div class="Cl4GrSemn">
                  <a href="/<%#Eval("ProductNameAlias")%>" class="linkall"></a> 
                   <div class="PrlClSemnLst">
                    <img class="ByDefultimg" src="/AdsSpritImages/ProductImages/<%# Eval("ProductDefaultImage") %>"/>
                     <img class="HovrImgSemn" src="/AdsSpritImages/ProductImages/<%# Eval("ProductImage2") %>" />
                      </div>
                     <div class="theCntSwnGen">
                    <h5><%#Eval("ProductName")%></h5>                             
                   </div>
                  </div>                                          
                 </ItemTemplate>
               </asp:Repeater>
              </div>
            </div>
         </div>

        </section>


        <section>
          <div class="OrscMnrSwvr">
            <asp:Repeater ID="ReptFooter" runat="server">
              <ItemTemplate>
                <div class="Imgsmvrtum">
                 <img src="/AdsSpritImages/CategoryImages/<%# Eval("CategoryImage2") %>"/>
                   </div>
                 <div class="CntVseVrmn">
                <div class="VdeClalSec VideObtnSec" data-atrshw="<%# Eval("FacebookURl") %>"></div>
               <h4> Our Scotch partner </h4>
              <p> ADS Spirits aspires to be the real brand that brings you great times. We believe Indians have a taste and preference for textures that are slightly different when compared to the international market.</p>
             </div>                                                                         
            </ItemTemplate>
           </asp:Repeater>
          </div>
        </section>
    </main>


    <div class="pop_up_vdo1">
        <div class="vdo_onply1 vdo_onply_ad1">
            <div class="cls_vdo1 ClseIfrmSec"> <span class="PopBxClsVde"> <img src="asset/images/infra/close.png"> </span> </div>
            <iframe id="iframe1" class="TstIfrmeSec iframecls" allow="autoplay;" src=""></iframe>
        </div>
    </div>
    
    <div class="mobile-top-header">
        <ul>
            <li><a href="product.html">Brands </a></li>       
            <li><a class="EnqPhone" href="javascript:void(0);">Call Us</a></li>
            <li><a href="https://api.whatsapp.com/send?phone=919810012753&amp;text=Hi Team ads, I'm interested in Your Product. Could you please connect me?"> Chat  </a></li>
        </ul>
    </div>

</asp:Content>
