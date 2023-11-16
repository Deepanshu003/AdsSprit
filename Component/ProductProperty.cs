using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class ProductProperty
    {
        public ProductProperty()
        {
        }
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        private int _ProductPropertyID = 0;

        public int ProductPropertyID
        {
            get { return _ProductPropertyID; }
            set { _ProductPropertyID = value; }
        }

        private int _ProductID = 0;

        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }

        private string _ProductPropertyName = string.Empty;

        public string ProductPropertyName
        {
            get { return _ProductPropertyName; }
            set { _ProductPropertyName = value; }
        }
        private string _ProductPropertyAlias = string.Empty;

        public string ProductPropertyAlias
        {
            get { return _ProductPropertyAlias; }
            set { _ProductPropertyAlias = value; }
        }
        private string _ProductPropertyImage = string.Empty;

        public string ProductPropertyImage
        {
            get { return _ProductPropertyImage; }
            set { _ProductPropertyImage = value; }
        }
        private int _ProductPropertyPrice = 0;

        public int ProductPropertyPrice
        {
            get { return _ProductPropertyPrice; }
            set { _ProductPropertyPrice = value; }
        }
        private int _ActiveStatus = 0;

        public int ActiveStatus
        {
            get { return _ActiveStatus; }
            set { _ActiveStatus = value; }
        }
        private int _DisplayOrder = 0;

        public int DisplayOrder
        {
            get { return _DisplayOrder; }
            set { _DisplayOrder = value; }
        }
        private string _updatedBy = string.Empty;

        public string UpdatedBy
        {
            get { return _updatedBy; }
            set { _updatedBy = value; }
        }
        private DateTime _updatedOn = DateTime.UtcNow;

        public DateTime UpdatedOn
        {
            get { return _updatedOn; }
            set { _updatedOn = value; }
        }
        private int _TaxAmountPercentage = 0;

        public int TaxAmountPercentage
        {
            get { return _TaxAmountPercentage; }
            set { _TaxAmountPercentage = value; }
        }
        private string _GSTHSNCode = string.Empty;

        public string GSTHSNCode
        {
            get { return _GSTHSNCode; }
            set { _GSTHSNCode = value; }
        }
        #region Admin
        public void SelectAllProductProperty(System.Web.UI.WebControls.GridView CategoryGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllProductProperty");
                ObjSql.GdBind_SNO(CategoryGrid, "Mst_Sp_ProductProperty", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllProductProperty()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectProductPropertyByProductPropertyID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductPropertyByProductPropertyID");
                _SqlParameter[1] = new SqlParameter("@ProductPropertyID", ProductPropertyID);
                return ObjSql.GetDatareaderProc("Mst_Sp_ProductProperty", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectProductPropertyByProductPropertyID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_ProductProperty", _SqlParameter);
        }

        public int SaveProductProperty()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[11];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveProductProperty");
                _SqlParameter[1] = new SqlParameter("@ProductPropertyName", ProductPropertyName);
                _SqlParameter[2] = new SqlParameter("@ProductPropertyAlias", ProductPropertyAlias);
                _SqlParameter[3] = new SqlParameter("@ProductPropertyImage", ProductPropertyImage);
                _SqlParameter[4] = new SqlParameter("@ProductPropertyPrice", ProductPropertyPrice);
                _SqlParameter[5] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[6] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[7] = new SqlParameter("@TaxAmountPercentage", TaxAmountPercentage);
                _SqlParameter[8] = new SqlParameter("@GSTHSNCode", GSTHSNCode);
                _SqlParameter[9] = new SqlParameter("@UpdatedBy", UpdatedBy);
                _SqlParameter[10] = new SqlParameter("@UpdatedOn", UpdatedOn);
                return ObjSql.ExcuteProce("Mst_Sp_ProductProperty", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveProductProperty()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductProperty", _SqlParameter);
        }

        public int UpdateProductProperty()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[12];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateProductProperty");
                _SqlParameter[1] = new SqlParameter("@ProductPropertyID", ProductPropertyID);
                _SqlParameter[2] = new SqlParameter("@ProductPropertyName", ProductPropertyName);
                _SqlParameter[3] = new SqlParameter("@ProductPropertyAlias", ProductPropertyAlias);
                _SqlParameter[4] = new SqlParameter("@ProductPropertyImage", ProductPropertyImage);
                _SqlParameter[5] = new SqlParameter("@ProductPropertyPrice", ProductPropertyPrice);
                _SqlParameter[6] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[7] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[8] = new SqlParameter("@TaxAmountPercentage", TaxAmountPercentage);
                _SqlParameter[9] = new SqlParameter("@GSTHSNCode", GSTHSNCode);
                _SqlParameter[10] = new SqlParameter("@UpdatedBy", UpdatedBy);
                _SqlParameter[11] = new SqlParameter("@UpdatedOn", UpdatedOn);
                return ObjSql.ExcuteProce("Mst_Sp_ProductProperty", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateProductProperty()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductProperty", _SqlParameter);
        }

        public int DeleteProductPropertyByProductPropertyID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteProductPropertyByProductPropertyID");
                _SqlParameter[1] = new SqlParameter("@ProductPropertyID", ProductPropertyID);
                return ObjSql.ExcuteProce("Mst_Sp_ProductProperty", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteProductPropertyByProductPropertyID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductProperty", _SqlParameter);
        }

        public int UpdateProductPropertyDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateProductPropertyDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@ProductPropertyID", ProductPropertyID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateProductPropertyDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductProperty", _SqlParameter);
        }

        public DataSet ExportEmailIDsintoExcel()
        {
            SqlParameter[] arrparam = new SqlParameter[1];
            try
            {
                arrparam[0] = new SqlParameter("@Action", "ExportEmailIDsintoExcel");
                return ObjSql.GetDsetProc1("Mst_Sp_ProductProperty", arrparam);
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

            return ObjSql.GetDsetProc1("Mst_Sp_ProductProperty", arrparam);
        }

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_ProductProperty", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductProperty", _SqlParameter);
        }
        #endregion

        #region FRont End PAnel
        public SqlDataReader SelectProductPropertyByProductPropertyIDAndProductID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductPropertyByProductPropertyIDAndProductID");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                _SqlParameter[2] = new SqlParameter("@ProductPropertyID", ProductPropertyID);
                return ObjSql.GetDatareaderProc("Mst_Sp_ProductProperty", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectProductPropertyByProductPropertyIDAndProductID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_ProductProperty", _SqlParameter);
        }

        public DataSet SelectProductPropertyByProductPropertyIDForDashBoard()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductPropertyByProductPropertyID");
                _SqlParameter[1] = new SqlParameter("@ProductPropertyID", ProductPropertyID);
                return ObjSql.GetDsetProc("Mst_Sp_ProductProperty", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectProductPropertyByProductPropertyIDForDashBoard()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductProperty", _SqlParameter);
        }
        #endregion
    }
}
