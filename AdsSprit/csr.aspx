<%@ Page Title="" Language="C#" MasterPageFile="~/AdsSpirit.Master" AutoEventWireup="true" CodeBehind="csr.aspx.cs" Inherits="AdsSprit.csr" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <main>
        <section>
            <asp:Repeater ID="RptrBannerImage" runat="server">
              <ItemTemplate>
               <div class="ProBnrSemn contactBanner">
                 <div class="BnseSeSwnMnvr">
                      <img class="cloud2" src="/AdsSpritImages/CockTailImages/<%# Eval("LargeImage") %>" />
                    </div>
                    <div class="OrWskWrlmn CSRHdng">
                     <p><%#Eval("Description")%></p>
                    </div>                                                
               </div>
              </ItemTemplate>
            </asp:Repeater>
        </section>
        <section>
            <div class="WhyusSwhmn OurBlfTxt_Wppr csr-new ">
                <div class="container">
                    <h2>Our belief</h2>
                    <p>We, at ADS Spirits, believe in giving back to society whatever we have created through our business.  It is our “sense of responsibility” towards the community and surrounding in which we operate. Our aim is to create a positive impact on society by doing something to the society.</p> 

                <p>CSR is not a compulsion for us but a way of life! </p>

                <h2>Our endeavours</h2>
                <p>Our major focus is to save environment and water for the generations to come and therefore we are actively participating in the activities of sapling trees and conserving water in the villages near us. </p> 

            <p>Apart from above, we are setting up a dispensary near to our Beri Plant in Jhajjar District to provide better and free health services to the needy villagers </p>
                </div>
            </div>
        </section>
        <section>
            <div class="Contct-Wppr">
                <div class="container">
                    <div class="row">
                        <div class="CSRTxt_wppr">
                            <div class="col-xl-3">
                                <div class="CSRImg_wppr">
                                    <span>
                                  <img src="asset/images/CSR/csr-clm-img-1.jpg" alt="">
                                </span>
                                </div>
                                <div class="CSR_txt-Wppr">
                                    <div class="title">
                                        <small>Product and Services</small>
                                        <p>To Create Harmony with Customers and Partners</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3">
                                <div class="CSRImg_wppr">
                                    <span>
                                <img src="asset/images/CSR/csr-clm-img-2.jpg" alt="">
                              </span>
                                </div>
                                <div class="CSR_txt-Wppr">
                                    <div class="title">
                                        <small>Environment</small>
                                        <p>To Create Harmony with Nature</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3">
                                <div class="CSRImg_wppr">
                                    <span>
                                <img src="asset/images/CSR/csr-clm-img-3.jpg" alt="">
                              </span>
                                </div>
                                <div class="CSR_txt-Wppr">
                                    <div class="title">
                                        <small>Cultural and Social Contribution</small>
                                        <p>To Create Harmony with Society</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3">
                                <div class="CSRImg_wppr">
                                    <span>
                                <img src="asset/images/CSR/csr-clm-img-4.jpg" alt="">
                              </span>
                                </div>
                                <div class="CSR_txt-Wppr">
                                    <div class="title">
                                        <small>Deversity Management</small>
                                        <p>To Create Harmony with Employee</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section>
            <div class="CrPgeGrwthSemn">
                <div class="GrwthPge LndHeadr EvntBg-Wppr">
                    <img class="bg" src="asset/images/CSR/Environment-Bg.jpg">
                </div>
                <div class="EnvrmentTxt-Wppr">
                    <div class="title">
                        <h3>Environment </h3>
                        <p>We are only Unit in India who is having Bag filter and ESP on Power Generation Unit to achieved Zero AIR Pollution </p>
                    </div>
                </div>
            </div>
        </section>
        <section>
            <div class="WhyusSwhmn RspnbDrnk-Wppr">
                <div class="container">
                    <div class="title">
                        <h2>Responsible drinking</h2>
                        <p>We believe in propagating responsible drinking so that adults of LDA who choose to consume alcohol do so in a manner that does not harm others and minimizes risk of harm to the consumer.  </p>
                    </div>
                </div>
                <div class="Rsnsv-Bnr-Img">
                    <span>
                    <img src="asset/images/CSR/rspnsv-drnk.jpg" alt="">
                  </span>
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
