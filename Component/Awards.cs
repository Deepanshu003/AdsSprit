using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class Awards
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public Awards()
        {
        }

        int _AwardsAwardsID = 0;
        string _AwardsName = string.Empty;
        string _AwardsNameURL = string.Empty;
        string _LargeImage = string.Empty;
        string _Description = string.Empty;
        int _activeStatus = 0;
        int _CategoryID = 0;
        string _updatedBy = string.Empty;
        DateTime _updatedOn = DateTime.UtcNow;
        string _metaTitle = string.Empty;
        string _metaKeywords = string.Empty;
        string _metaDescriptions = string.Empty;

        public int AwardsID
        {
            get { return _AwardsAwardsID; }
            set { _AwardsAwardsID = value; }
        }

        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        public string AwardsName
        {
            get { return _AwardsName; }
            set { _AwardsName = value; }
        }
        public string AwardsNameURL
        {
            get { return _AwardsNameURL; }
            set { _AwardsNameURL = value; }
        }

        public string LargeImage
        {
            get { return _LargeImage; }
            set { _LargeImage = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
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
        public string MetaTitle
        {
            get { return _metaTitle; }
            set { _metaTitle = value; }
        }
        public string MetaKeywords
        {
            get { return _metaKeywords; }
            set { _metaKeywords = value; }
        }
        public string MetaDescriptions
        {
            get { return _metaDescriptions; }
            set { _metaDescriptions = value; }
        }
        string _MetaSchema = string.Empty;

        public string MetaSchema
        {
            get { return _MetaSchema; }
            set { _MetaSchema = value; }
        }

        #region Admin Panle
        public void SelectAllAwards(System.Web.UI.WebControls.GridView AwardsGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllAwards");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(AwardsGrid, "Mst_Sp_Awards", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAll()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public DataSet SelectAllAwardsforProductadd()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllAwardsforProductadd");
                return ObjSql.GetDsetProc("Mst_Sp_Awards", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllAwardsforProductadd()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_Awards", _SqlParameter);
        }

        public SqlDataReader SelectAwardsByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAwardsByID");
                _SqlParameter[1] = new SqlParameter("@AwardsID", AwardsID);
                return ObjSql.GetDatareaderProc("Mst_Sp_Awards", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetAwardsData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_Awards", _SqlParameter);
        }

        public int SaveNewAwards()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[11];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewAwards");
                _SqlParameter[1] = new SqlParameter("@AwardsName", AwardsName);
                _SqlParameter[2] = new SqlParameter("@LargeImage", LargeImage);
                _SqlParameter[3] = new SqlParameter("@Description", Description);
                _SqlParameter[4] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[5] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[6] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[7] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[8] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[9] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[10] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_Awards", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveAwards()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Awards", _SqlParameter);
        }

        public int UpdateAwardsByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[13];
            try
            {
                _SqlParameter[0]  = new SqlParameter("@Action", "UpdateAwardsByID");
                _SqlParameter[1]  = new SqlParameter("@AwardsID", AwardsID);
                _SqlParameter[2]  = new SqlParameter("@AwardsName", AwardsName);
                _SqlParameter[3]  = new SqlParameter("@LargeImage", LargeImage);
                _SqlParameter[4]  = new SqlParameter("@Description", Description);
                _SqlParameter[5]  = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[6]  = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[7]  = new SqlParameter("@Updatedon", UpdatedOn);
                _SqlParameter[8]  = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[9]  = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[10] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[11] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[12] = new SqlParameter("@CategoryID", CategoryID);
                return ObjSql.ExcuteProce("Mst_Sp_Awards", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateAwardsByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Awards", _SqlParameter);
        }

        public int DeletAwardsByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeletAwardsByID");
                _SqlParameter[1] = new SqlParameter("@AwardsID", AwardsID);
                return ObjSql.ExcuteProce("Mst_Sp_Awards", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeletAwardsByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Awards", _SqlParameter);
        }

        public DataSet SelectAwardDescription(int categoryID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAwardDescription");
                _SqlParameter[1] = new SqlParameter("@CategoryID", categoryID);
                return ObjSql.GetDsetProc("Mst_Sp_Awards", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectProductBannerImage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_Awards", _SqlParameter);
        }


        #endregion

        #region Front End PAnel
       
        #endregion
    }
}
