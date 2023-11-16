using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Utility;
using System.Data;

namespace Component
{
    public class SizeData
    {
        public SizeData()
        {
        }

        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        private int _SizeID = 0;
        private string _SizeName = string.Empty;
        private string _SizeNameURL = string.Empty;
        private int _activeStatus = 0;
        private int _DisplayOrder = 0;
        public int SizeID
        {
            get { return _SizeID; }
            set { _SizeID = value; }
        }
        public string SizeName
        {
            get { return _SizeName; }
            set { _SizeName = value; }
        }
        public string SizeNameURL
        {
            get { return _SizeNameURL; }
            set { _SizeNameURL = value; }
        }
        public int ActiveStatus
        {
            get { return _activeStatus; }
            set { _activeStatus = value; }
        }
        public int DisplayOrder
        {
            get { return _DisplayOrder; }
            set { _DisplayOrder = value; }
        }
        private string _UpdatedBy = string.Empty;

        public string UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        private string _SizeType = string.Empty;

        public string SizeType
        {
            get { return _SizeType; }
            set { _SizeType = value; }
        }
        private string _SizeUnit = string.Empty;

        public string SizeUnit
        {
            get { return _SizeUnit; }
            set { _SizeUnit = value; }
        }
        #region Admin Panel
        public void SelectAllSizeData(System.Web.UI.WebControls.GridView CategoryGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllSizeData");
                _SqlParameter[1] = new SqlParameter("@SizeUnit", SizeUnit);
                ObjSql.GdBind_SNO(CategoryGrid, "Mst_Sp_SizeData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllSizeData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public void BindDdCategory(System.Web.UI.WebControls.DropDownList DdCategory, string SizeName, string SizeID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectSizeDataForDD");
                ObjSql.DdBing(DdCategory, "Mst_Sp_SizeData", "SizeName", "SizeID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectSizeDataForDD()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectSizeDataBySizeID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectSizeDataBySizeID");
                _SqlParameter[1] = new SqlParameter("@SizeID", SizeID);
                return ObjSql.GetDatareaderProc("Mst_Sp_SizeData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectSizeDataBySizeID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_SizeData", _SqlParameter);
        }

        public int SaveNewSize()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[7];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewSize");
                _SqlParameter[1] = new SqlParameter("@SizeName", SizeName);
                _SqlParameter[2] = new SqlParameter("@SizeNameURL", SizeNameURL);
                _SqlParameter[3] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[4] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[5] = new SqlParameter("@SizeType", SizeType);
                _SqlParameter[6] = new SqlParameter("@SizeUnit", SizeUnit);
                return ObjSql.ExcuteProce("Mst_Sp_SizeData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewSize()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_SizeData", _SqlParameter);
        }

        public int UpdateSizeDataBySizeID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[8];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateSizeDataBySizeID");
                _SqlParameter[1] = new SqlParameter("@SizeID", SizeID);
                _SqlParameter[2] = new SqlParameter("@SizeName", SizeName);
                _SqlParameter[3] = new SqlParameter("@SizeNameURL", SizeNameURL);
                _SqlParameter[4] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[5] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[6] = new SqlParameter("@SizeType", SizeType);
                _SqlParameter[7] = new SqlParameter("@SizeUnit", SizeUnit);
                return ObjSql.ExcuteProce("Mst_Sp_SizeData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateSizeDataBySizeID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_SizeData", _SqlParameter);
        }

        public int DeleteSizeDataBySizeID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteSizeDataBySizeID");
                _SqlParameter[1] = new SqlParameter("@SizeID", SizeID);
                return ObjSql.ExcuteProce("Mst_Sp_SizeData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteSizeDataBySizeID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_SizeData", _SqlParameter);
        }

        public int UpdateSizeDataDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateSizeDataDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@SizeID", SizeID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_SizeData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateSizeDataDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_SizeData", _SqlParameter);
        }

        public DataSet SelectAllSizeDataBySizeUnit()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllSizeDataBySizeUnit");
                _SqlParameter[1] = new SqlParameter("@SizeUnit", SizeUnit);
                return ObjSql.GetDsetProc("Mst_Sp_SizeData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllSizeDataBySizeUnit()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_SizeData", _SqlParameter);
        }

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_SizeData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_SizeData", _SqlParameter);
        }

        public DataSet ExportEmailIDsintoExcel()
        {
            SqlParameter[] arrparam = new SqlParameter[2];
            try
            {
                arrparam[0] = new SqlParameter("@Action", "ExportEmailIDsintoExcel");
                arrparam[1] = new SqlParameter("@SizeUnit", SizeUnit);
                return ObjSql.GetDsetProc1("Mst_Sp_SizeData", arrparam);
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

            return ObjSql.GetDsetProc1("Mst_Sp_SizeData", arrparam);
        }
        #endregion

        #region Front End Panel
        public DataSet SelectAllActiveSizeData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveSizeData");
                return ObjSql.GetDsetProc("Mst_Sp_SizeData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveSizeData()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_SizeData", _SqlParameter);
        }

        public DataSet SelectAllActiveSizeDataForProductListing()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveSizeDataForProductListing");
                return ObjSql.GetDsetProc("Mst_Sp_SizeData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveSizeDataForProductListing()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_SizeData", _SqlParameter);
        }
        #endregion

    }
}
