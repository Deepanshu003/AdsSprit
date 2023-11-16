<%@ Page Title="" Language="C#" MasterPageFile="~/AdsSpirit.Master" AutoEventWireup="true" CodeBehind="international-business.aspx.cs" Inherits="AdsSprit.international_business" %>
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
            <div class="ExplreYurBrns ExpReBnrds">
                <div class="TleMnvr">
                    <h5>Our Brand Offerings </h5>
                    <p>Our mission is to follow international practices and processes with customers and oursupply partners.</p>
                </div>
                <div class="cl12WskySwnmn">
                  <asp:Repeater ID="ReptCategoryImage1" runat="server">
                    <ItemTemplate>
                   <div class="cl6mnvrSet">
                      <div class="Brnsclimg">
                        <img class="cloud1" src="/AdsSpritImages/CategoryImages/<%# Eval("CategoryImage") %>" />
                      </div>
                      <div class="EngWhsyMntSevr"> 
                        <h3><%#Eval("CategoryName")%></h3>
                        <p><%#Eval("CategorysmallDescription")%></p>
                       <div class="BtnAllSemn">
                        <a href="/Category/<%#Eval("CategoryAlias")%>">Explore</a>
                       </div>
                       </div>                       
                       </div>
                    </ItemTemplate>
                </asp:Repeater>                      
              </div>
            </div>
        </section>


        <section>
            <div class="CapSevrMn">
                <div class="container">
                    <h2>Export Capabilities </h2>
                    <div class="ClExcplSemvr">
                        <div class="ClmnVeSh4">
                            <div class="IcmnSevr">
                                <img src="asset/images/infra/icon1.png">
                            </div>
                            <p>Offering our products to inter buyers from 2 finest plants – Beri – Reengus </p>
                        </div>
                        <div class="ClmnVeSh4">
                            <div class="IcmnSevr">
                                <img src="asset/images/infra/icon2.png">
                            </div>
                            <p> Facilities have all the necessary infrastructure and are situated close to the freight corridors which help in smooth and fast movement of containers to the ports. </p>
                        </div>
                        <div class="ClmnVeSh4">
                            <div class="IcmnSevr">
                                <img src="asset/images/infra/icon3.png">
                            </div>
                            <p> We provide goods in 20 ft + 40 ft containers and can be customised to the need of the international markets. </p>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section>
            <div class="CmnPage CrefFrmSec CrsShwSec">
                <div class="row">
                    <div class="IqryFrmBx-Wppr">
                        <div class="Clm-sm-7">
                            <div class="IqryFrmBx">
                                <span id="ContentPlaceHolder1_lblMessage"></span>
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter the Email" ControlToValidate="txtEmail" Text="*" forecolor="red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="Please Enter Correct Mail"  ForeColor="red"    ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
                                       <asp:TextBox ID="txtEmail" runat="server" CssClass="FtrInpt"></asp:TextBox>
                                       <label class="InptTxtName">Email</label>
                                   </fieldset>
                                   <fieldset>
                                       <asp:TextBox ID="txtDesignation" runat="server" CssClass="FtrInpt"></asp:TextBox>
                                       <label class="InptTxtName">Designation</label>
                                   </fieldset>
                                   <fieldset>
                                       <asp:TextBox ID="txtOrganisation" runat="server" CssClass="FtrInpt"></asp:TextBox>
                                       <label class="InptTxtName">Organisation</label>
                                   </fieldset>
                                   <fieldset>
                                       <asp:TextBox ID="txtAddress" runat="server" CssClass="FtrInpt"></asp:TextBox>
                                       <label class="InptTxtName">Address</label>
                                   </fieldset>
                                   <fieldset>
                                       <asp:TextBox ID="txtTelephone" runat="server" CssClass="FtrInpt" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                       <label class="InptTxtName">Telephone</label>
                                   </fieldset>
                                   <fieldset>
                                       <asp:TextBox ID="txtMobile" runat="server" CssClass="FtrInpt"></asp:TextBox>
                                       <label class="InptTxtName">Mobile</label>
                                   </fieldset>
                                   <fieldset>
                                       <asp:TextBox ID="txtWebsite" runat="server" CssClass="FtrInpt"></asp:TextBox>
                                       <label class="InptTxtName">Company website</label>
                                   </fieldset>
                                   <fieldset>
                                       <asp:TextBox ID="txtQuery" runat="server" CssClass="FtrInpt"></asp:TextBox>
                                       <label class="InptTxtName">Query regarding</label>
                                   </fieldset>
                                   <div class="BtnAllSemn">                                       
                                       <a href="#"> <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" style="background-color: transparent; color:white; border:none;" OnClientClick="return validateForm();" /> <img class="arwmove" src="asset/icon/icnlnvr.png" ></a>
                                    </div>
                                 </div>
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
                     var designation = document.getElementById('<%= txtDesignation.ClientID %>').value.trim();
                     var organization = document.getElementById('<%= txtOrganisation.ClientID %>').value.trim();
                     var address = document.getElementById('<%= txtAddress.ClientID %>').value.trim();
                     var telephone = document.getElementById('<%= txtTelephone.ClientID %>').value.trim();
                     var phone = document.getElementById('<%= txtMobile.ClientID %>').value.trim();
                     var website = document.getElementById('<%= txtWebsite.ClientID %>').value.trim();
                  var message = document.getElementById('<%= txtQuery.ClientID %>').value.trim();
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
                  if (designation === "") {
                      alert("Please enter your designation.");
                      return false;
                  }
                  if (organization === "") {
                      alert("Please enter your organization.");
                      return false;
                  }
                  if (address === "") {
                      alert("Please enter your address.");
                      return false;
                  }



                  if (telephone === "") {
                      alert("Please enter your telephone number.");
                      return false;
                  } else if (!validatePhone(telephone)) {
                      alert("Please enter a valid telephone number.");
                      return false;
                  }
                  



                  if (phone === "") {
                      alert("Please enter your Phone number.");
                      return false;
                  } else if (!validatePhone(phone)) {
                      alert("Please enter a valid Phone number.");
                      return false;
                  }
                  if (website === "") {
                      alert("Please enter your website.");
                      return false;
                  }
                  if (message === "") {
                      alert("Please enter a query.");
                      return false;
                  }
                  return true;
              }

              function validateEmail(email) {
                  var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
                  return emailRegex.test(email);
              }

              function validatePhone(telephone) {
                  var phoneRegex = /^\d{10}$/;
                  return phoneRegex.test(telephone);
              }

              function validatePhone(phone) {
                  var phoneRegex = /^\d{10}$/;
                  return phoneRegex.test(phone);
              }
    </script>

    </main>

   <div class="mobile-top-header">
        <ul>
            <li><a href="product.html">Brands </a></li>       
            <li><a class="EnqPhone" href="javascript:void(0);">Call Us</a></li>
            <li><a href="https://api.whatsapp.com/send?phone=919810012753&amp;text=Hi Team ads, I'm interested in Your Product. Could you please connect me?"> Chat  </a></li>
        </ul>
    </div>
</asp:Content>
