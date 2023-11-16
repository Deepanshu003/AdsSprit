using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class CockTails
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public CockTails()
        {
        }

        int _CockTailsCockTailsID = 0;
        string _CockTailsName = string.Empty;
        string _CockTailsNameURL = string.Empty;
        string _LargeImage = string.Empty;
        string _Description = string.Empty;
        int _activeStatus = 0;
        int _CategoryID = 0;
        int _ProductID = 0;
        string _updatedBy = string.Empty;
        DateTime _updatedOn = DateTime.UtcNow;
        string _metaTitle = string.Empty;
        string _metaKeywords = string.Empty;
        string _metaDescriptions = string.Empty;

        public int CockTailsID
        {
            get { return _CockTailsCockTailsID; }
            set { _CockTailsCockTailsID = value; }
        }
        public string CockTailsName
        {
            get { return _CockTailsName; }
            set { _CockTailsName = value; }
        }

        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }


        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        public string CockTailsNameURL
        {
            get { return _CockTailsNameURL; }
            set { _CockTailsNameURL = value; }
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
        public void SelectAllCockTails(System.Web.UI.WebControls.GridView CockTailsGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllCockTails");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(CockTailsGrid, "Mst_Sp_CockTails", _SqlParameter);
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

        public DataSet SelectAllCockTailsforProductadd()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllCockTailsforProductadd");
                return ObjSql.GetDsetProc("Mst_Sp_CockTails", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllCockTailsforProductadd()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CockTails", _SqlParameter);
        }

        public void SelectAllCockTailsForDD(System.Web.UI.WebControls.DropDownList DdCockTails, string CockTailsName, string CockTailsID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllCockTailsForDD");
                ObjSql.DdBing(DdCockTails, "Mst_Sp_CockTails", "CockTailsName", "CockTailsID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdCockTails()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectCockTailsByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCockTailsByID");
                _SqlParameter[1] = new SqlParameter("@CockTailsID", CockTailsID);
                return ObjSql.GetDatareaderProc("Mst_Sp_CockTails", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetCockTailsData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_CockTails", _SqlParameter);
        }

        public int SaveNewCockTails()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[12];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewCockTails");
                _SqlParameter[1] = new SqlParameter("@CockTailsName", CockTailsName);
                _SqlParameter[2] = new SqlParameter("@LargeImage", LargeImage);
                _SqlParameter[3] = new SqlParameter("@Description", Description);
                _SqlParameter[4] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[5] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[6] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[7] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[8] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[9] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[10] = new SqlParameter("@ProductID", ProductID);
                _SqlParameter[11] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_CockTails", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveCockTails()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CockTails", _SqlParameter);
        }

        public int UpdateCockTailsByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[14];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateCockTailsByID");
                _SqlParameter[1] = new SqlParameter("@CockTailsID", CockTailsID);
                _SqlParameter[2] = new SqlParameter("@CockTailsName", CockTailsName);
                _SqlParameter[3] = new SqlParameter("@LargeImage", LargeImage);
                _SqlParameter[4] = new SqlParameter("@Description", Description);
                _SqlParameter[5] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[6] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[7] = new SqlParameter("@Updatedon", UpdatedOn);
                _SqlParameter[8] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[9] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[10] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[11] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[12] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[13] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.ExcuteProce("Mst_Sp_CockTails", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateCockTailsByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CockTails", _SqlParameter);
        }

        public int UpdateCockTailsDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateCockTailsDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@CockTailsID", CockTailsID);
                return ObjSql.ExcuteProce("Mst_Sp_CockTails", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateMainMenuDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CockTails", _SqlParameter);
        }

        public int DeletCockTailsByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeletCockTailsByID");
                _SqlParameter[1] = new SqlParameter("@CockTailsID", CockTailsID);
                return ObjSql.ExcuteProce("Mst_Sp_CockTails", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeletCockTailsByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CockTails", _SqlParameter);
        }
        #endregion

        #region Front End PAnel
        public void SelectAllAllCockTailsForDD(System.Web.UI.WebControls.DropDownList DdCockTails, string CockTailsName, string CockTailsID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllAllCockTailsForDD");
                ObjSql.DdBing(DdCockTails, "Mst_Sp_CockTails", "CockTailsName", "CockTailsID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllAllCockTailsForDD()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public int SelectCockTailsIDbyURL(string CockTailsNameURL1)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCockTailsIDbyURL");
                _SqlParameter[1] = new SqlParameter("@CockTailsNameURL", CockTailsNameURL1);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_CockTails", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectCockTailsIDbyURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public void BindDdProduct(System.Web.UI.WebControls.DropDownList DdProduct, string CockTailsName, string CockTailsID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectSubCategoryDataForDD");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                ObjSql.DdBing(DdProduct, "Mst_Sp_CockTails", "CockTailsName", "CockTailsID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdProduct()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public DataSet SelectCockTails()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCocktails");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectCockTails()", ex);
                return null; // You should return null on error to handle it appropriately
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        #endregion
    }
}
