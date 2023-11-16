using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;
using System.Web.UI.WebControls;

namespace Component
{
    public class ProductCockTails
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        public ProductCockTails()
        { }

        private int _ProductCockTailsID = 0;
        private int _CockTailsID = 0;
        private int _productID = 0;
        private string _productDefaultImageByCockTails = string.Empty;
        private string _productImage1ByCockTails = string.Empty;
        private string _productImage2ByCockTails = string.Empty;
        private string _productImage3ByCockTails = string.Empty;
        private int _activeStatus = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        private string _productIDs = string.Empty;

        public int ProductCockTailsID
        {
            get { return _ProductCockTailsID; }
            set { _ProductCockTailsID = value; }
        }
        public int CockTailsID
        {
            get { return _CockTailsID; }
            set { _CockTailsID = value; }
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
        public string ProductIDs
        {
            get { return _productIDs; }
            set { _productIDs = value; }
        }

        #region Admin Panel
        public int SaveProductCockTails()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SAVEProductCockTails");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                _SqlParameter[2] = new SqlParameter("@CockTailsID", CockTailsID);

                return ObjSql.ExcuteProce("Mst_Sp_ProductCockTails", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveProductCockTails()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductCockTails", _SqlParameter);
        }

        public SqlDataReader GetProductCockTailsData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];

            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "GETProductCockTailsNDATA");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.GetDatareaderProc("Mst_Sp_ProductCockTails", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetProductCockTailsData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_ProductCockTails", _SqlParameter);
        }

        public int DeleteProductByCockTails()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DELETEProductCockTails");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);


                return ObjSql.ExcuteProce("Mst_Sp_ProductCockTails", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteProductByCockTails()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductCockTails", _SqlParameter);
        }
        #endregion Admin Panel
    }
}
