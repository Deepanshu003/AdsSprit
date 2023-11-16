<%@ Page Title="" Language="C#" MasterPageFile="~/AdsSpirit.Master" AutoEventWireup="true" CodeBehind="Brands.aspx.cs" Inherits="AdsSprit.Brands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section>
            <div class="ProBnrSemn">
                <div class="BnseSeSwnMnvr">
                    <img class="cloud2" src="asset/images/wskybanner.jpg">
                </div>
                <div class="OrWskWrlmn">
                    <h3>Brands </h3>
                </div>
            </div>
        </section>
     <section>
            <div class="GerSemnSen">
                <div class="container">
                  <div class="cl12SemnvrtLstRyl">
                <asp:Repeater ID="ReptProduct" runat="server">
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

                <div class="Imgsmvrtum">
                    <img src="asset/images/infra/videbanner.jpg">
                </div>

                <div class="CntVseVrmn">
                    <div class="VdeClalSec VideObtnSec" data-atrshw="https://www.youtube.com/embed/J-hvUwN39Fg?autoplay=0"><img src="asset/images/infra/plyiocn.png"></div>

                    <h4> Our Scotch partner </h4>

                    <p> ADS Spirits aspires to be the real brand that brings you great times. We believe Indians have a taste and preference for textures that are slightly different when compared to the international market.</p>


                </div>

            </div>


        </section>

</asp:Content>
