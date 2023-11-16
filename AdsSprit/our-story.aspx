<%@ Page Title="" Language="C#" MasterPageFile="~/AdsSpirit.Master" AutoEventWireup="true" CodeBehind="our-story.aspx.cs" Inherits="AdsSprit.our_story" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <main>
        <!-- About us page section html  -->
        <!-- Bnner section html  -->
        <section>
            <div class="ProBnrSemn">
                <div class="BnseSeSwnMnvr">
                    <asp:Repeater ID="ReptBannerImage1" runat="server">
                           <ItemTemplate>
                             <div class="Brnsclimg">
                               <img class="cloud2" src="/AdsSpritImages/CockTailImages/<%# Eval("LargeImage") %>" />
                             </div>
                          </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="OrWskWrlmn">
                    <h3>Our story</h3>
                    <p>Fastest growing liquor conglomerate in the Indian alcobev space known for its customer-first approach in the Indian Market. </p>
                </div>
            </div>
        </section>
        <!-- End Here -->
        <!-- ADS Group Section html  -->
        <section class="AnimateSec">
            <div class="OurStrmnVr">
                <div class="container">
                    <div class="CntTltTtle TheBrng-Wppr story-wrapper">
                        <!-- <small>Since 1998</small> -->
                        <h3>ADS Group</h3>
                        <p>ADS Group is one of the fastest growing liquor conglomerate in the Indian alcobev space. With interest in Retail, Distillation, branded IMFL Category and Country Liquor and the group is known for its customer-first approach in
                            the Indian Market. </p>
                        <p>Our belief is in providing high quality and well-engineered packaged products than the competition. </p>
                        <p>Setup by first-generation of entrepreneurs, ADS group has its roots in liquor retailing since 1998.
                            <p>
                    </div>
                    <div class="CntTltTtle TheBrng-Wppr story-wrapper">
                        <!-- <small>Since 1998</small> -->
                        <h3>ADS Spirits Pvt Ltd. </h3>
                        <p>ADS Spirits Pvt Ltd was incorporated in 2010 in Delhi and started its operation with state-of-the-art 60 KLPD distillation Unit and a huge bottling unit at Beri – Jhajjar Haryana in 2012.</p>
                        <p>After establishing itself as a significant player in Country Liquor Business in Haryana, company forayed into branded IMFL segment in 2013. With its unique business approach of offering high quality and good packaged products which
                            are better Value-for- Money to consumers and a Win – Win approach with channel partners, the company rapidly commenced creating winning brands in the market.</p>
                        <p>Today the company boasts of having products in the major consumptions segments and is proud to be creator of brands like The Generation Premium Blended Whisky, Royal Green Whisky, Double Blue Whisky, Episode Whisky, Hi Impact Whisky
                            in tetra pack, Calenter VSOP Brandy & Calenter Premium Rum and Moonwalk Vodka series & Gin.</p>
                        <p><b>ADS Agro Pvt Ltd –Rengus – </b> A state of the art distillery located in Rajasthan with exclusive access to top quality ground water. Its portfolio includes manufacture of the group IMFL brands, Country Liquor in various flavours
                            and Rajasthan Made Foreign Liquor.</p>
                        <p><b>ADS Distillers Pvt Ltd </b> a sister concern unit in Uttar Pradesh Market with an impressive infrastructure of distillery and bottling plant.</p>
                        <p>ADS Group is pursuing its immediate goal to augment its existing portfolio of brands so as to cater to consumers across categories and segments. The company is also gearing up to establish its footprint across India and overseas
                            markets. We are inspired to build and establish self-sustainable brands in every market and further harmonise our infrastructure, system and people for a profitable growth. Keep visiting for an update on new brand launches
                            coming soon.</p>
                    </div>
                </div>
            </div>
        </section>
        <!-- End Here -->
    
        <!--  Journey so far section html  -->
        <section>
            <div class="JurnyTxt-Wppr">
                <div class="container">
                    <div class="row">
                        <div class="JrnyTxt-Wppr">
                            <div class="title">
                                <h4>Journey so far</h4>
                            </div>
                            <div class="JrnySldr-Wppr ">
                                <div class="JrnySldr owl-carousel owl-theme">
                                    <div class="JrnySldr-Itm">
                                        <div class="jnr1">
                                            <div class="title">
                                                <small>2012</small>
                                                <h4>Beri Factory Operations commenced</h4>
                                            </div>
                                            <div class="title">
                                                <small>2013 </small>
                                                <h4>Country Liquor, IMFL roll out</h4>
                                            </div>
                                            <div class="title">
                                                <small> 2014  </small>
                                                <h4>16 Royal Green, Double Blue launched across multiple states </h4>
                                            </div>

                                            <div class="title">
                                                <small> 2016  </small>
                                                <h4>1 Million cases of IMFL crossed</h4>
                                            </div>

                                            <div class="title">
                                                <small> 2017  </small>
                                                <h4>1 Million Cases of Royal Green</h4>
                                            </div>

                                            <div class="title">
                                                <small> 2018  </small>
                                                <h4>2 Million Cases of Royal Green</h4>
                                            </div>

                                            

                                        </div>
                                                                            
                                    </div>
                                    <div class="JrnySldr-Itm">
                                    <div class="jnr1">
                                        <div class="title">
                                            <small> 2018 </small>
                                            <h4>Rajasthan Unit started </h4>
                                        </div>
                                        <div class="title">
                                            <small> 2019  </small>
                                            <h4>3 Million Cases of Royal Green</h4>
                                        </div>
                                        <div class="title">
                                            <small>  2019   </small>
                                            <h4>Royal Green adjudged as Fastest Growing Millionaire Whisky Brand in the WORLD </h4>
                                        </div>

                                        <div class="title">
                                            <small> 	2019   </small>
                                            <h4>UP Unit started </h4>
                                        </div>

                                        <div class="title">
                                            <small> 	2020   </small>
                                            <h4>Launch of Calenter Premium Rum  </h4>
                                        </div>

                                        <div class="title">
                                            <small>  2021   </small>
                                            <h4>Launch of Royal Green TVC </h4>
                                        </div>

                                        

                                    </div>

                                    </div>
                              
                               
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- End Here -->
        <!-- Our Vision section html  -->
        <section>
            <div class="prodlmnvrSe OrStymn">
                <div class="container">
                    <div class="row">
                        <div class="Vsn-Msn-Wppr">
                            <div class="title">
                                <h3>Our Vision</h3>
                            </div>
                            <div class="VsnMsnTxt-Wppr VstnTxt">
                              
                                <div class="Clm-6">
                                    <div class="QutTxt-Wppr ">
                                        <!-- <span class="Qut-Img">
                                    <img src="asset/images/about/quote.png" alt="">
                                  </span> -->
                                        <div class="title">
                                            <p>ADS Spirits is committed to being the most trusted name in the Alcohol-beverage Industry, providing best-in-class products, exceptional brands and display consistent passion for quality and customer satisfaction.</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- End Here -->
     
       

    </main>

    <div class="mobile-top-header">
        <ul>
            <li><a href="product.html">Brands </a></li>       
            <li><a class="EnqPhone" href="javascript:void(0);">Call Us</a></li>
            <li><a href="https://api.whatsapp.com/send?phone=919810012753&amp;text=Hi Team ads, I'm interested in Your Product. Could you please connect me?"> Chat  </a></li>
        </ul>
    </div>
</asp:Content>
