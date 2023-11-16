<%@ Page Title="" Language="C#" MasterPageFile="~/AdsSpirit.Master" AutoEventWireup="true" CodeBehind="contactus.aspx.cs" Inherits="AdsSprit.contactus" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main>

        <section>
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
        </section>


        <section>

            <div class="cntSemnVrSwhw contact-form">
                <div class="PstAbSemn">
                    <img src="asset/images/bckvectimg.png">
                </div>
                <h2>DISTILLERIES</h2>
                <div class="container">
                
                    <div class="cl12cntSemnvr">
                       
                        <div class="cl6cntpage">
                            <h4>Beri - haryana</h4>
                            <p> <img src="asset/icon/location.png"> ADS Spirits Pvt. Ltd.
                                Village - Bhutiyan, Beri – Kalanaur Road,
                                Tehsil - Beri, Distt - Jhajjar, Haryana,
                                Pin Code-124201,
                                
                            </p>
                          
                        </div>

                        <div class="cl6cntpage">
                            <h4>Reengus – Rajasthan  </h4>
                            <p> <img src="asset/icon/location.png">ADS Agro Industries Pvt. Ltd.,
                                Sp 67 SKS Industrial Area Reengus Sikar,
                                Rajasthan - 332404 
                                
                            </p>
                            
                        </div>
                        <div class="cl6cntpage">
                            <h4>Sikandrabad – Uttar Pradesh</h4>
                           
                            <p> <img src="asset/icon/location.png">Plot Number-4A-1/1, ½ & A3/4, Industrial Area, Sikandrabad, District-Bulandshahr, UP
                            </p>
                        </div>
                  
                        <h2>Directors Office</h2>
                        <div class="cl6cntpage">
                            <h4>BahadurGarh - Haryana </h4>
                            <p> <img src="asset/icon/location.png">
                                ADS SPIRITS Pvt. Ltd.<br>
                                Office : ADS Tower, Dharampura, Near Metro Pillar No.839
                                Bahadurgarh – 124507, Distt: Jhajjar (Haryana)
                                
                            </p>
                          
                        </div>
                        <h2>REGISTERED OFFICE</h2>
                        <div class="cl6cntpage">
                            <h4>ADS Spirits Pvt. Ltd. </h4>
                            <p> <img src="asset/icon/location.png">
                                FF-2, Harmony Apartment 52/78,
                                Punjabi Bagh West, Delhi
                                Pin Code-110026
                                
                                
                            </p>
                          
                        </div>
                        <h2>Marketing & Sales Office</h2>
                        <div class="cl6cntpage">
                           
                            <p> <img src="asset/icon/location.png">SCO No. 6
                                Sec 39, Behind Unitech Cyber Park, Gurgaon, Haryana
                                Pin Code 122001
                                
                                
                                
                            </p>
                          
                        </div>

                      


                    </div>
                </div>
            </div>
        </section>

        <section>
            <div class="CmnPage CrefFrmSec CrsShwSec">
                <asp:ScriptManager ID="scm" runat="server"></asp:ScriptManager>
                <div class="row">
                    <div class="IqryFrmBx-Wppr">
                        <div class="Clm-sm-7">
                            <div class="IqryFrmBx">
                                  <asp:UpdatePanel ID="UpdpnlContact" runat="server">
                                     <ContentTemplate>
                                <div class="title">
                                    <h2> GET IN TOUCH </h2>
                                    <p> Alternatively please complete the enquiry form below or email contact@adsspirits.com. We aim to respond to your enquiry within 2 working days. </p>
                                </div>
                               <div class="IqryFrm-Wppr">
                               <fieldset>
                                   <asp:TextBox ID="txtFirstName" runat="server" CssClass="FtrInpt"></asp:TextBox>
                                   <label class="InptTxtName">First Name</label>
                               </fieldset>
                               <fieldset>
                                   <asp:TextBox ID="txtLastName" runat="server" CssClass="FtrInpt"></asp:TextBox>
                                   <label class="InptTxtName">Last Name</label>
                               </fieldset>
                               <fieldset>
                                   <asp:TextBox ID="txtEmail" runat="server" CssClass="FtrInpt"></asp:TextBox>
                                   <label class="InptTxtName">Email</label>
                               </fieldset>
                               <fieldset>
                                   <asp:TextBox ID="txtPhone" runat="server" CssClass="FtrInpt" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                   <label class="InptTxtName">Phone</label>
                               </fieldset>
                               <fieldset class="Wthfullpge">
                                   <asp:TextBox ID="txtMessage" runat="server" CssClass="FtrInpt" TextMode="MultiLine"></asp:TextBox>
                                   <label class="InptTxtName">Message</label>
                               </fieldset>
                               <div class="BtnAllSemn">
                                   <a href=""><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"  style="background-color: transparent; color:white; border:none;"  OnClientClick="return validateForm();" />  <img class="arwmove" src="asset/icon/icnlnvr.png"></a>                                                                  
                               </div>
                             </div>
                                    </ContentTemplate>
                               </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>


          <script type="text/javascript">
              function validateForm() {
            var firstName = document.getElementById('<%= txtFirstName.ClientID %>').value.trim();
            var lastName = document.getElementById('<%= txtLastName.ClientID %>').value.trim();
            var email = document.getElementById('<%= txtEmail.ClientID %>').value.trim();
            var phone = document.getElementById('<%= txtPhone.ClientID %>').value.trim();
            var message = document.getElementById('<%= txtMessage.ClientID %>').value.trim();
        //    var emailValue = emailTextBox.value.trim();
       //     var emailPattern = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/;
            if (firstName === "") {
                alert("Please enter your First Name.");
                return false;
            }
            if (lastName === "") {
                alert("Please enter your Last Name.");
                return false;
            }
            if (email === "") {
                alert("Please enter your Email.");
                return false;
            } 
            if (phone === "") {
                alert("Please enter your Phone number.");
                return false;
            } else if (!validatePhone(phone)) {
                alert("Please enter a valid Phone number.");
                return false;
            }
            if (message === "") {
                alert("Please enter a Message.");
                return false;
            }
            return true;
        }

        function validateEmail(email) {
            var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            return emailRegex.test(email);
        }

        function validatePhone(phone) {
            var phoneRegex = /^\d{10}$/;
            return phoneRegex.test(phone);
        }
    </script>
    </main>
</asp:Content>
