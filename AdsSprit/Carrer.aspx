<%@ Page Title="" Language="C#" MasterPageFile="~/AdsSpirit.Master" AutoEventWireup="true" CodeBehind="Carrer.aspx.cs" Inherits="AdsSprit.Carrer" %>
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
            <div class="WhyusSwhmn">
                <div class="container">
                    <h2>Why Us</h2>
                    <p>ADS Spirits is a first-generation, self-made company that brings together some of the biggest names in alcohol distilling and brewing, building robust distribution networks across India and ensuring ethical business at reasonable prices. Our team already consists of some of the most experienced players nationally and we are looking to add to our team at all levels. If you have any experience working in the manufacturing, marketing, finance or accounting sector or even if you are just a highly motivated person looking for the next leap to a growing company, send us your resume below. In case you are a fit, our HR team will get back to you.
                    </p>
                </div>
            </div>
        </section>


        <section>

            <div class="CrPgeGrwthSemn">

                <div class="GrwthPge LndHeadr">
                    <img class="bg" src="asset/images/carpgebnner.jpg">
                </div>

                <div class="GrwthSemSwn">

                    <div class="cl4RptGrwth">
                        <div class="grwthdiveSec">
                            <img src="asset/icon/growth.png">
                        </div>
                        <div class="CntGrwthSemn">
                            <h3>TEAM WORK – THE POWER
                            </h3>
                            
                        </div>
                    </div>

                    <div class="cl4RptGrwth">
                        <div class="grwthdiveSec">
                            <img src="asset/icon/network.png">
                        </div>
                        <div class="CntGrwthSemn">
                            <h3>INNOVATION</h3>
                          
                        </div>
                    </div>

                    <div class="cl4RptGrwth">
                        <div class="grwthdiveSec">
                            <img src="asset/icon/excellence.png">
                        </div>
                        <div class="CntGrwthSemn">
                            <h3>PROFESSIONAL AND PERSONAL INTEGRITY
                            </h3>
                            
                        </div>
                    </div>

                    <div class="cl4RptGrwth">
                        <div class="grwthdiveSec">
                            <img src="asset/icon/teamwork.png">
                        </div>
                        <div class="CntGrwthSemn">
                            <h3>PASSION TOWARDS EXCELLENCE
                            </h3>
                           
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section>
             <div class="CrSecFrm">
               <div class="container">
                <div class="CarfOpperSec">
                 <div class="ColCr9">
                 <p> VACANCIES </p>
                 <h4> We're hiring. </h4>
                 <asp:Repeater ID="ReptJobOpening" runat="server">
                   <ItemTemplate>                    
                         <div class="OppSecRpt">                                                                 
                           <div class="CreNameSec">
                            <h6><%#Eval("JobName")%></h6>
                             <div class="DrpDownSec">
                              <span class="DrpDeownImgSec"> <img src="asset/icon/down-arrow-select1.png"> </span>
                             </div>
                            </div>                                            
                          <div class="CntSecDrpDown">
                        <div class="CntReslity">
                      <p>Type: <%#Eval("JobType")%></p>
                    <h4>Responsibilities: </h4>
                     <%#Eval("JobDescription")%>
                   </div>
                 </div>                                                                                                                                        
                </div>               
              </ItemTemplate>
             </asp:Repeater>
            </div>
         
             <div class="ColCr3">
                 <div class="FrmSecShowCr">
                     <h6>Interested in joining us?</h6>
                     <div class="frm-body">
                         <div class="from-grp">
                             <fieldset>
                              <label class="label-wrap">Name</label><br />
                              <span class="border-bottom-animation left"></span>
                              <asp:TextBox ID="txtFirstName" runat="server" CssClass="frm-cntrl border-bottom form-control"></asp:TextBox>
                            </fieldset>
                         </div>
                        <div class="from-grp">
                             <fieldset>                                                      
                                 <label class="label-wrap">Email</label><br />
                                 <span class="border-bottom-animation left"></span>
                                 <asp:TextBox ID="txtEmail" runat="server" CssClass="frm-cntrl border-bottom form-control"></asp:TextBox>
                             </fieldset>
                         </div>
                         <div class="from-grp">
                             <fieldset class="PhoneNoSho">
                                 <label class="label-wrap">Phone</label><br />
                                 <span class="border-bottom-animation left"></span>
                                 <asp:TextBox ID="txtPhone" runat="server" CssClass="frm-cntrl border-bottom form-control" MaxLength="10"></asp:TextBox>
                             </fieldset>
                         </div>
                         <div class="from-grp">
                          <div class="sectBox">
                              <asp:DropDownList ID="ddJobCategory" runat="server" CssClass="form-control">
                                  <asp:ListItem Text="Select Job Category" Value="" />
                              </asp:DropDownList>
                          </div>
                      </div>
                         <div class="from-grp">
                             <fieldset class="MessageSec">
                                 <textarea class="frm-cntrl border-bottom" id="message" runat="server"></textarea>
                                 <label class="label-wrap"> Message </label>
                                 <span class="border-bottom-animation left"></span>
                             </fieldset>
                         </div>
                         <div class="FrmGrp">
                              <div class="banForm-grp_ImgH">
                                  <label for="ContentPlaceHolder1_SelectSec" class="fileLbl_ImgH" title="Attach CV">
                                      <small>Attach CV</small>
                                      <span>
                                          <span class="fileUp_ImgH"></span>
                                      </span>
                                  </label>
                                  <input type="file" id="SelectSec" class="fileInpt_ImgH banFrm-cntrl_ImgH" runat="server" name="FILE" />
                                  <br />
                                  <br />
                                  <asp:Label ID="errorLabel" runat="server" CssClass="error-message" Visible="false" ForeColor="Red"></asp:Label>
                              </div>
                             </div>

                         <div class="BtnPopup">
                              <asp:Button ID="linkSubmit" runat="server" class="btn-form" OnClick="linkSubmit_Click"  OnClientClick="return validateForm();"  Text="Apply Now"/>
                         </div>
                     </div>
                 </div>
             </div>                   
                </div>
            </div>
            </div>
        </section>
  <%--       <script type="text/javascript">
         function pagecheck() {
           if (!req(document.getElementById("txtFirstName"), "Enter Category Name"))
               return false;
           if (!req(document.getElementById("txtEmail"), "Enter Email"))
               return false;
           if (!req(document.getElementById("txtPhone"), "Enter mobile number"))
               return false;
           if (!req(document.getElementById("ddJobCategory"), "Select Category"))
               return false;
           if (!req(document.getElementById("message"), "Enter Message"))
               return false;
         }
             </script> --%>

         <script type="text/javascript">
             function validateForm() {
                 var firstName = document.getElementById('<%= txtFirstName.ClientID %>').value.trim();
                  var email = document.getElementById('<%= txtEmail.ClientID %>').value.trim();
                  var phone = document.getElementById('<%= txtPhone.ClientID %>').value.trim();
                  var message = document.getElementById('<%= message.ClientID %>').value.trim();
                  //    var emailValue = emailTextBox.value.trim();
                  //     var emailPattern = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/;
                  if (firstName === "") {
                      alert("Please enter your First Name.");
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
