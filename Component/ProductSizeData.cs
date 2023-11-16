using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class ProductSizeData
    {
        public ProductSizeData()
        { }
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        private int _ProductSizeID = 0;
        private int _SizeID = 0;
        private int _productID = 0;
        private Int64 _DefaultMRP = 0;
        public Int64 DefaultMRP
        {
            get { return _DefaultMRP; }
            set { _DefaultMRP = value; }
        }
        private Int64 _DefaultPrice = 0;

        public Int64 DefaultPrice
        {
            get { return _DefaultPrice; }
            set { _DefaultPrice = value; }
        }
        private int _activeStatus = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;

        public int ProductSizeID
        {
            get { return _ProductSizeID; }
            set { _ProductSizeID = value; }
        }
        public int SizeID
        {
            get { return _SizeID; }
            set { _SizeID = value; }
        }
        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
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
        private string _COD = string.Empty;

        public string COD
        {
            get { return _COD; }
            set { _COD = value; }
        }
        private string _Availability = string.Empty;

        public string Availability
        {
            get { return _Availability; }
            set { _Availability = value; }
        }
        private string _SizeType = string.Empty;

        public string SizeType
        {
            get { return _SizeType; }
            set { _SizeType = value; }
        }
        #region Admin Panel
        public int SaveProductSizePrice()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[8];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveProductSizePrice");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                _SqlParameter[2] = new SqlParameter("@SizeID", SizeID);
                _SqlParameter[3] = new SqlParameter("@DefaultMRP", DefaultMRP);
                _SqlParameter[4] = new SqlParameter("@DefaultPrice", DefaultPrice);
                _SqlParameter[5] = new SqlParameter("@COD", COD);
                _SqlParameter[6] = new SqlParameter("@Availability", Availability);
                _SqlParameter[7] = new SqlParameter("@SizeType", SizeType);
                return ObjSql.ExcuteProce("Mst_Sp_ProductSize", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveProductSize()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductSize", _SqlParameter);
        }

        public SqlDataReader GetProductSizeData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];

            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "GETPRODUCTSizeNDATA");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.GetDatareaderProc("Mst_Sp_ProductSize", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetProductSizeData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_ProductSize", _SqlParameter);
        }

        public int DeleteProductBySize()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DELETEPRODUCTSize");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);


                return ObjSql.ExcuteProce("Mst_Sp_ProductSize", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteProductBySize()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductSize", _SqlParameter);
        }
        #endregion Admin Panel

        #region Front Website Panel
        public DataSet SelectTopOneActiveProductPriceDataByProductID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTopOneActiveProductPriceDataByProductID");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.GetDsetProc("Mst_Sp_ProductSize", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTopOneActiveProductPriceDataByProductID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductSize", _SqlParameter);
        }

        public DataSet SelectAllActiveProductSizeByProductID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveProductSizeByProductID");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.GetDsetProc("Mst_Sp_ProductSize", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveProductSizeByProductID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductSize", _SqlParameter);
        }
        #endregion Front Website Panel
    }
}
