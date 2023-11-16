﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Component;
using Utility;
using System.Data;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace AdsSprit
{
    public partial class Carrer : System.Web.UI.Page
    {

        ManageException ObjEx = new ManageException();
        CommanFunction ObjComm = new CommanFunction();
        Job ObjJobCategory = new Job();
        Applicant objApplicant = new Applicant();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAllJobData();
                BindDdJobCategory();
                BindIndexBannerImges();          
            }
        }

        public void SelectAllJobData()
        {
            DataSet ds = new DataSet();
            ds = ObjJobCategory.SelectAllActiveJob();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReptJobOpening.DataSource = ds.Tables[0];
                ReptJobOpening.DataBind();
                ReptJobOpening.Visible = true;
            }
            ds.Dispose();
            ds.Clear();
        }

        private void BindDdJobCategory()
        {
            Job ObjJobCategory = new Job();
            ObjJobCategory.SelectAllJobForDD(ddJobCategory, "JobName", "JobID");
            ddJobCategory.Items.Insert(0, new ListItem("Select Job Category", "0"));
            ObjJobCategory = null;
        }

           private string getContentType(string strPath)
           {
            string StrPath = Path.GetExtension(strPath).ToString();
            string StrExt = "";
            if (StrPath.ToLower().Equals(".pdf"))
            {
                StrExt = ".pdf";
            }
            return StrExt;
          } 

      /*   private string getContentType(string strPath)
         {
             string extension = Path.GetExtension(strPath);
             if (extension != null && extension.ToLower() == ".pdf")
             {
                 return ".pdf";
             }
             return "";
         } */
         private void BindIndexBannerImges()
         {
             Banner ObjBanner = new Banner();
             DataSet ds = new DataSet();
             ds = ObjBanner.SelectCarrerbanner();
             if (ds.Tables[0].Rows.Count > 0)
             {

                 RptrBannerImage.DataSource = ds.Tables[0];
                 RptrBannerImage.DataBind();
                 RptrBannerImage.Visible = true;
             }
             else
             {
                 RptrBannerImage.Visible = false;
             }
             ds.Dispose();
             ds.Clear();
             ObjBanner = null;
         }

  /*       protected void linkSubmit_Click(object sender, EventArgs e)
         {
             string file = "";
             int ret;
             try
             {
                 objApplicant.FirstName = txtFirstName.Text.TrimStart();
                 objApplicant.Email = txtEmail.Text.TrimStart();
                 objApplicant.Address = txtPhone.Text;
                 objApplicant.Message = message.Value;
                 objApplicant.JobID = Convert.ToInt32(ddJobCategory.SelectedValue);
                 objApplicant.JobName = ddJobCategory.SelectedItem.Text;
                 if (attach_cv.Value != "")
                 {
                     file = ObjComm.UniqueFileName(Session);
                     file = file + getContentType(attach_cv.Value);
                     objApplicant.FileData = file.ToString();
                 }
                 else
                     objApplicant.FileData = "";

                 ret = objApplicant.SaveNewApplicants();
                 if (ret == 1)
                 {
                     if (attach_cv.Value != "" && attach_cv.PostedFile.ContentLength < 2100000)
                     {
                         ObjComm.fileUpLoad(attach_cv, "/AdsSpritImages/Resume", file, Server);
                         Response.Redirect("/thankyou");
                     }
                 }
             }
             catch (Exception ex)
             {
                 ObjEx.PublishError("Error in procedure SaveData()", ex);
             }
         } */


         protected void linkSubmit_Click(object sender, EventArgs e)
         {
             string file = "";
             int ret;
             try
             {
                 objApplicant.FirstName = txtFirstName.Text.TrimStart();
                 objApplicant.Email = txtEmail.Text.TrimStart();
                 objApplicant.Address = txtPhone.Text;
                 objApplicant.Message = message.Value;
                 objApplicant.JobID = Convert.ToInt32(ddJobCategory.SelectedValue);
                 objApplicant.JobName = ddJobCategory.SelectedItem.Text;

                 if (SelectSec.Value != "")
                 {
                     file = ObjComm.UniqueFileName(Session);
                     string contentType = getContentType(SelectSec.Value);
                     if (contentType == ".pdf")
                     {
                         file = file + contentType;
                         objApplicant.FileData = file.ToString();
                     }
                     else
                     {
                         errorLabel.Text = "Only PDF files are allowed.";
                         errorLabel.Visible = true;
                     }
                 }
                 else
                 {
                     objApplicant.FileData = "";
                 }

                 ret = objApplicant.SaveNewApplicants();
                 if (ret == 1)
                 {
                     if (SelectSec.Value != "" && SelectSec.PostedFile.ContentLength < 210000000)
                     {
                         ObjComm.fileUpLoad(SelectSec, "/AdsSpritImages/Resume", file, Server);
                         Response.Redirect("/thankyou");
                     }
                 }
             }
             catch (Exception ex)
             {
                 ObjEx.PublishError("Error in procedure SaveData()", ex);
             }
         }

        } 

   }