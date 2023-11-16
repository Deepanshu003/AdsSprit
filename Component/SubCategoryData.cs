using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class SubCategoryData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public SubCategoryData()
        {
        }

        private int _SubCategoryID = 0;
        private string _SubCategoryName = string.Empty;
        private string _SubCategoryAlias = string.Empty;
        private string _SubCategoryImage = string.Empty;
        private string _SubCategoryDescription = string.Empty;
        private int _displayOrder = 0;
        private int _activeStatus = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        private string _SubCategoryMetaTitle = string.Empty;
        private string _SubCategoryMetaKeywords = string.Empty;
        private string _SubCategoryMetaDescription = string.Empty;

        public int SubCategoryID
        {
            get { return _SubCategoryID; }
            set { _SubCategoryID = value; }
        }
        public string SubCategoryName
        {
            get { return _SubCategoryName; }
            set { _SubCategoryName = value; }
        }
        public string SubCategoryAlias
        {
            get { return _SubCategoryAlias; }
            set { _SubCategoryAlias = value; }
        }
        public string SubCategoryImage
        {
            get { return _SubCategoryImage; }
            set { _SubCategoryImage = value; }
        }

        public string SubCategoryDescription
        {
            get { return _SubCategoryDescription; }
            set { _SubCategoryDescription = value; }
        }
        public int DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }
        public int ActiveStatus
        {
            get { return _activeStatus; }
            set { _activeStatus = value; }
        }
        public string UpdatedBy
        {
            get { return _updatedBy; }
            set { _updatedBy = value; }
        }
        public DateTime UpdatedOn
        {
            get { return _updatedOn; }
            set { _updatedOn = value; }
        }
        public string SubCategoryMetaTitle
        {
            get { return _SubCategoryMetaTitle; }
            set { _SubCategoryMetaTitle = value; }
        }
        public string SubCategoryMetaKeywords
        {
            get { return _SubCategoryMetaKeywords; }
            set { _SubCategoryMetaKeywords = value; }
        }
        public string SubCategoryMetaDescription
        {
            get { return _SubCategoryMetaDescription; }
            set { _SubCategoryMetaDescription = value; }
        }

        string _MetaSchema = string.Empty;

        public string MetaSchema
        {
            get { return _MetaSchema; }
            set { _MetaSchema = value; }
        }
        private string _SubCategoryImage1 = string.Empty;

        public string SubCategoryImage1
        {
            get { return _SubCategoryImage1; }
            set { _SubCategoryImage1 = value; }
        }
        private int _DisplayOnHome = 0;

        public int DisplayOnHome
        {
            get { return _DisplayOnHome; }
            set { _DisplayOnHome = value; }
        }
        private int _DisplayOnHeader = 0;

        public int DisplayOnHeader
        {
            get { return _DisplayOnHeader; }
            set { _DisplayOnHeader = value; }
        }
        private int _CategoryID = 0;

        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        private int _PartyItems = 0;

        public int PartyItems
        {
            get { return _PartyItems; }
            set { _PartyItems = value; }
        }
        private int _LookingForSomethingExpensive = 0;

        public int LookingForSomethingExpensive
        {
            get { return _LookingForSomethingExpensive; }
            set { _LookingForSomethingExpensive = value; }
        }
        private string _FacebookURl = string.Empty;

        public string FacebookURl
        {
            get { return _FacebookURl; }
            set { _FacebookURl = value; }
        }
        private int _PhotoCategory = 0;

        public int PhotoCategory
        {
            get { return _PhotoCategory; }
            set { _PhotoCategory = value; }
        }
        #region Admin Panel
        public void SelectAllSubCategory(System.Web.UI.WebControls.GridView SubCategoryGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllSubCategoryData");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                _SqlParameter[2] = new SqlParameter("@CategoryID", CategoryID);
                ObjSql.GdBind_SNO(SubCategoryGrid, "Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllSubCategory()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public void BindDdSubCategory(System.Web.UI.WebControls.DropDownList DdSubCategory, string SubCategoryName, string SubCategoryID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectSubCategoryDataForDD");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                ObjSql.DdBing(DdSubCategory, "Mst_Sp_SubCategoryData", "SubCategoryName", "SubCategoryID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdSubCategory()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectSubCategoryBySubCategoryID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectSubCategoryDataBySubCategoryID");
                _SqlParameter[1] = new SqlParameter("@SubCategoryID", SubCategoryID);
                return ObjSql.GetDatareaderProc("Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectSubCategoryBySubCategoryID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_SubCategoryData", _SqlParameter);
        }

        public int SaveSubCategory()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[20];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveSubCategory");
                _SqlParameter[1] = new SqlParameter("@SubCategoryName", SubCategoryName);
                _SqlParameter[2] = new SqlParameter("@SubCategoryAlias", SubCategoryAlias);
                _SqlParameter[3] = new SqlParameter("@SubCategoryImage", SubCategoryImage);
                _SqlParameter[4] = new SqlParameter("@SubCategoryDescription", SubCategoryDescription);
                _SqlParameter[5] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[6] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[7] = new SqlParameter("@SubCategoryMetaTitle", SubCategoryMetaTitle);
                _SqlParameter[8] = new SqlParameter("@SubCategoryMetaKeywords", SubCategoryMetaKeywords);
                _SqlParameter[9] = new SqlParameter("@SubCategoryMetaDescription", SubCategoryMetaDescription);
                _SqlParameter[10] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[11] = new SqlParameter("@SubCategoryImage1", SubCategoryImage1);
                _SqlParameter[12] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
                _SqlParameter[13] = new SqlParameter("@DisplayOnHeader", DisplayOnHeader);
                _SqlParameter[14] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[15] = new SqlParameter("@PartyItems", PartyItems);
                _SqlParameter[16] = new SqlParameter("@LookingForSomethingExpensive", LookingForSomethingExpensive);
                _SqlParameter[17] = new SqlParameter("@UpdatedBy", UpdatedBy);
                _SqlParameter[18] = new SqlParameter("@FacebookURl", FacebookURl);
                _SqlParameter[19] = new SqlParameter("@PhotoCategory", PhotoCategory);
                return ObjSql.ExcuteProce("Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveSubCategory()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_SubCategoryData", _SqlParameter);
        }

        public int UpdateSubCategory()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[22];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateSubCategoryData");
                _SqlParameter[1] = new SqlParameter("@SubCategoryID", SubCategoryID);
                _SqlParameter[2] = new SqlParameter("@SubCategoryName", SubCategoryName);
                _SqlParameter[3] = new SqlParameter("@SubCategoryAlias", SubCategoryAlias);
                _SqlParameter[4] = new SqlParameter("@SubCategoryImage", SubCategoryImage);
                _SqlParameter[5] = new SqlParameter("@SubCategoryDescription", SubCategoryDescription);
                _SqlParameter[6] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[7] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[8] = new SqlParameter("@SubCategoryMetaTitle", SubCategoryMetaTitle);
                _SqlParameter[9] = new SqlParameter("@SubCategoryMetaKeywords", SubCategoryMetaKeywords);
                _SqlParameter[10] = new SqlParameter("@SubCategoryMetaDescription", SubCategoryMetaDescription);
                _SqlParameter[11] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[12] = new SqlParameter("@Updatedon", UpdatedOn);
                _SqlParameter[13] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[14] = new SqlParameter("@SubCategoryImage1", SubCategoryImage1);
                _SqlParameter[15] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
                _SqlParameter[16] = new SqlParameter("@DisplayOnHeader", DisplayOnHeader);
                _SqlParameter[17] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[18] = new SqlParameter("@PartyItems", PartyItems);
                _SqlParameter[19] = new SqlParameter("@LookingForSomethingExpensive", LookingForSomethingExpensive);
                _SqlParameter[20] = new SqlParameter("@FacebookURl", FacebookURl);
                _SqlParameter[21] = new SqlParameter("@PhotoCategory", PhotoCategory);
                return ObjSql.ExcuteProce("Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateSubCategory()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_SubCategoryData", _SqlParameter);
        }

        public int DeleteSubCategoryByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteSubCategoryDataByID");
                _SqlParameter[1] = new SqlParameter("@SubCategoryID", SubCategoryID);
                return ObjSql.ExcuteProce("Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteSubCategoryByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_SubCategoryData", _SqlParameter);
        }

        public int UpdateSubCategoryDataDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateSubCategoryDataDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@SubCategoryID", SubCategoryID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateSubCategoryDataDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_SubCategoryData", _SqlParameter);
        }

        public void SelectTop10SubCategoryDataForAdminHome(System.Web.UI.WebControls.GridView DoctorGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop10SubCategoryDataForAdminHome");
                ObjSql.GdBind_SNO(DoctorGrid, "Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop10SubCategoryDataForAdminHome()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public DataSet SelectAllSubCategoryDataForRptr()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllSubCategoryDataForRptr");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                return ObjSql.GetDsetProc("Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllSubCategoryDataForRptr()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_SubCategoryData", _SqlParameter);
        }

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_SubCategoryData", _SqlParameter);
        }

        public DataSet ExportEmailIDsintoExcel()
        {
            SqlParameter[] arrparam = new SqlParameter[2];
            try
            {
                arrparam[0] = new SqlParameter("@Action", "ExportEmailIDsintoExcel");
                arrparam[1] = new SqlParameter("@CategoryID", CategoryID);
                return ObjSql.GetDsetProc1("Mst_Sp_SubCategoryData", arrparam);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure BindEmailIDsintoExcel()", ex);
            }
            finally
            {
                arrparam = (SqlParameter[])null;
                ObjSql = (Connect)null;
                ObjEx = (ManageException)null;
            }

            return ObjSql.GetDsetProc1("Mst_Sp_SubCategoryData", arrparam);
        }
        #endregion Admin Panel

        #region Front End Panle
        public DataSet SelectTop6ActiveSubCategoryDataForHeaderByDisplayOnHeaderAndCategoryID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop6ActiveSubCategoryDataForHeaderByDisplayOnHeaderAndCategoryID");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                return ObjSql.GetDsetProc("Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop6ActiveSubCategoryDataForHeaderByDisplayOnHeaderAndCategoryID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_SubCategoryData", _SqlParameter);
        }

        public DataSet SelectTop8ActiveSubCategoryDataForHeaderByDisplayOnHomeAndCategoryID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop8ActiveSubCategoryDataForHeaderByDisplayOnHomeAndCategoryID");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                return ObjSql.GetDsetProc("Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop8ActiveSubCategoryDataForHeaderByDisplayOnHomeAndCategoryID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_SubCategoryData", _SqlParameter);
        }

        public DataSet SelectTop8ActiveSubCategoryDataForPartyItems()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop8ActiveSubCategoryDataForPartyItems");
                return ObjSql.GetDsetProc("Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop8ActiveSubCategoryDataForPartyItems()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_SubCategoryData", _SqlParameter);
        }

        public DataSet SelectTop3ActiveSubCategoryDataForLookingForSomethingExpensive()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop3ActiveSubCategoryDataForLookingForSomethingExpensive");
                return ObjSql.GetDsetProc("Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop3ActiveSubCategoryDataForLookingForSomethingExpensive()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_SubCategoryData", _SqlParameter);
        }

        public DataSet SelectAllActiveSubCategoryDataForProductListing()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveSubCategoryDataForProductListing");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                return ObjSql.GetDsetProc("Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveSubCategoryDataForProductListing()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_SubCategoryData", _SqlParameter);
        }

        public int SelectSubCategoryIDbySubCategoryAliasAndCategoryID(string SubCategoryAlias)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectSubCategoryIDbySubCategoryAliasAndCategoryID");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[2] = new SqlParameter("@SubCategoryAlias", SubCategoryAlias);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_SubCategoryData", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectSubCategoryIDbyAndCategoryID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public SqlDataReader SelectActiveSubCategoryDataBySubCategoryID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectActiveSubCategoryDataBySubCategoryID");
                _SqlParameter[1] = new SqlParameter("@SubCategoryID", SubCategoryID);
                return ObjSql.GetDatareaderProc("Mst_Sp_SubCategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectActiveSubCategoryDataBySubCategoryID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_SubCategoryData", _SqlParameter);
        }
        #endregion
    }
}
