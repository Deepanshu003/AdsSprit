<%@ Page Title="" Language="C#" MasterPageFile="~/AdsSpirit.Master" AutoEventWireup="true" CodeBehind="Values.aspx.cs" Inherits="AdsSprit.Values" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <main>
         <section>
         <div class="IfrCtSwMnVr VlsMnswVr">
          <div class="InfrActyeMnu owl-carousel owl-theme">
            <asp:Repeater ID="RptrBannerImage" runat="server">
              <ItemTemplate>
               <div class="ProBnrSemn contactBanner">
                 <div class="BnseSeSwnMnvr">
                   <img class="cloud2" src="/AdsSpritImages/CockTailImages/<%# Eval("LargeImage") %>" />
                  </div>
                  <div class="OrWskWrlmn">
                   <p><%#Eval("Description")%></p>
                  </div>                                                
               </div>
              </ItemTemplate>
            </asp:Repeater>
          </div>
         </div>      
        </section>


        <section>
            <div class="InsftMn">
                <div class="container">
                    <div class="InfrtureViwe">                     
                       <p> ADS Spirits is committed to being the most trusted name in the Alcohol-beverage Industry, providing best-in-class products, exceptional brands and display consistent passion for quality and customer satisfaction.</p>
                    </div>
                </div>
            </div>
        </section>



        <section>
            <div class="BckImgBreSwn value-bg">
                <div class="InfrUnSwnvr">
                    <div class="container">
                        <h5>Our Values</h5>
                        <div class="Clrptcl12Swn values">
                            <div class="cl6clmnvr">
                                <div class="cl12MigSvrInf">
                                    <img src="asset/images/values/team-work.png"/>
                                </div>
                                <div class="ClcntSwnvr">
                                    <h3>TEAM WORK – THE POWER</h3>
                                    <p>We believe in Team Work which is reflected in its inception and genesis and is demonstrated in its business growth. Our progress and growth, as one of the fastest growing company in the liquor industry is the result of our synergistic team work.</p>
                                </div>
                            </div>
                            <div class="cl6clmnvr">
                                <div class="cl12MigSvrInf">
                                    <img src="asset/images/values/innovation.png">
                                </div>
                                <div class="ClcntSwnvr">
                                    <h3>INNOVATION </h3>
                                    <p>We encourage and motivate our employees at all levels to innovate and be creative, across all areas of operations. Ability to understand the consumer’s mind-set, and roll out of the same using differential tactics, empowers our team towards achievement of its goals.</p>
                                </div>
                            </div>
                            <div class="cl6clmnvr">
                                <div class="cl12MigSvrInf">
                                    <img src="asset/images/values/integration.png">
                                </div>
                                <div class="ClcntSwnvr">
                                    <h3>PROFESSIONAL AND PERSONAL INTEGRITY</h3>
                                    <p>We follow, adopt and persistently maintain professional integrity at our work place to enhance productivity, performance and reputation. Every employee at ADS, is encouraged to be a custodian of professional and personal reliability and honesty</p>
                                </div>
                            </div>
                            <div class="cl6clmnvr">
                                <div class="cl12MigSvrInf">
                                    <img src="asset/images/values/excellence.png">
                                </div>
                                <div class="ClcntSwnvr">
                                    <h3>PASSION TOWARDS EXCELLENCE </h3>
                                    <p>We, at ADS, are passionate and driven to achieve excellence in our work.  Passion is our driving force to be the Best in Industry.</p>
                                </div>
                            </div>
                            <div class="cl6clmnvr">
                                <div class="cl12MigSvrInf">
                                    <img src="asset/images/values/respect.png">
                                </div>
                                <div class="ClcntSwnvr">
                                    <h3>RESPECT & HUMILTY  </h3>
                                    <p>ADS treats and advocates its people with kindness, courtesy and politeness and encourage-workers in all respects both professionally and personally. They are encouraged for this as brand ambassadors of the company. </p>
                                </div>
                            </div>
                            <div class="cl6clmnvr">
                                <div class="cl12MigSvrInf">
                                    <img src="asset/images/infra/icon5.png">
                                </div>
                                <div class="ClcntSwnvr">
                                    <h3>PROUD OF WHAT WE DO  </h3>
                                    <p> ADS employees display extreme pride being an integral part of a team in a progressive and futuristic company dedicated to make an impact in the industry and the society. </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>                
         <!--  LEADERSHIP section html  -->
         <section>
            <div class="LedrShp-Wppr">
                <div class="container">
                    <div class="row">
                        <div class="LedrHdng-Wppr">
                            <div class="title">
                                <h5>Leadership</h5>
                                <p>At ADS Spirits, leadership is all about bringing together individuals with complementary backgrounds and ensuring adherence to the organizational strategy in the best interests of the company and its shareholders.</p>
                            </div>
                     <div class="ledrShip-Tbng-Wppr">
                      <div class="LdrTbngBtn-Itm">
                       <div class="title">
                         <ul>
                          <asp:Repeater ID="rptTabs"  runat="server">
                           <ItemTemplate>
                            <li class='<%# Container.ItemIndex == 0 ? "Actv" : " " %>' data-tbid='<%# Eval("LeaderName")  %>'>
                            <%# Eval("LeaderName") %>
                            </li>  
                           </ItemTemplate>
                          </asp:Repeater>
                         </ul>
                        </div>
                       </div>  


                         <div class="LdrTbngContc-Wppr">
                           <asp:Repeater ID="rptcONTENT" runat="server">
                               <ItemTemplate>
                                   <div class="LdrTbCont-Itm" data-tbcntc='<%# Eval("LeaderName") %>' <%# Container.ItemIndex == 0 ? "style='display: block;'":"style='display:none;'" %>>
                                       <div class="title">
                                           <%# Eval("Description") %>
                                       </div>
                                       <div class="TeamCont-Wppr">
                                        <div class="Clm-xl-4">
                                         <div class="Tem-Img">
                                          <span>
                                           <img src="/AdsSpritImages/LeaderImage/<%# Eval("DefaultImg") %>" />
                                            </span>
                                             </div>                
                                              <div class="title">
                                            <small><%#Eval("LeaderTitle")%></small>
                                           <em><%#Eval("VideoURl")%></em>
                                          </div>                                                
                                         </div>
                                       </div>
                                   </div>
                               </ItemTemplate>
                           </asp:Repeater>
                            </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- End Here -->
        <!--  Team Contct PopUp section html  -->
    <asp:Repeater ID="reptDescriptions" runat="server">
     <ItemTemplate>
      <div class="TemContct-Wppr">
       <div class="TeamPop-Wppr">                
        <div class="PopClsBtn">
         <button type="button" class="ClsPopBtn"></button>
          </div>
           <div class="TeamContct-Wppr">
            <div class="TeamImg-Wppr">
             <span>
                <img  src="/AdsSpritImages/LeaderImage/<%# Eval("DefaultImg") %>" />
               </span>
                </div>
                 <div class="TmTxt-Wppr">                    
                <div class="TemTxtItm-Wppr CrntData" data-tbid='<%# Eval("LeaderName")  %>'>
               <div class="title">
              <small class="TeamName"><%# Eval("LeaderTitle") %></small>
             <em class="TeamPrfl"><%# Eval("VideoURl") %></em>
            </div>
           <div class="title">
          <%# Eval("Descriptions") %>
         </div>
        </div>
       </div>
      </div>                
     </div>
    </div>
   </ItemTemplate>
  </asp:Repeater>

    </main>

  <div class="mobile-top-header">
        <ul>
            <li><a href="product.html">Brands </a></li>       
            <li><a class="EnqPhone" href="javascript:void(0);">Call Us</a></li>
            <li><a href="https://api.whatsapp.com/send?phone=919810012753&amp;text=Hi Team ads, I'm interested in Your Product. Could you please connect me?"> Chat  </a></li>
        </ul>
    </div>
</asp:Content>
