using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Collections;
using System.Text.RegularExpressions;

namespace Utility
{
    public class Connect
    {
        public Connect()
        {

        }

        private Utility.ManageException ObjEx = new ManageException();
        private static string ConStr;
        public System.Data.SqlClient.SqlConnection cnn = new SqlConnection();
        public System.Data.SqlClient.SqlDataAdapter DataAdtp = new SqlDataAdapter();
        public System.Data.SqlClient.SqlCommand DataCmd = new SqlCommand();

        public bool ConnectCon()
        {
            try
            {
                ConStr = System.Configuration.ConfigurationManager.AppSettings["con"];
                SqlConnection cnn = new SqlConnection(ConStr);
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                    cnn.Dispose();
                    SqlConnection.ClearPool(cnn);
                    SqlConnection.ClearAllPools();
                }
                cnn.Open();
                DataCmd.Connection = cnn;
                DataAdtp.SelectCommand = DataCmd;
                return true;
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Connection Procedure(ConnectCon)", ex);
            }
            return true;
        }

        public void Disconnect()
        {
            try
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                    cnn.Dispose();
                    if (cnn != null)
                        cnn = null;
                    SqlConnection.ClearPool(cnn);
                    SqlConnection.ClearAllPools();
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Get Data Reader Procedure(GetDatareaderProc)", ex);
            }
            finally
            {
                cnn.Close();
                cnn.Dispose();
                SqlConnection.ClearPool(cnn);
                SqlConnection.ClearAllPools();
            }
        }

        public int ExcuteProce(string StoreprocedureName, SqlParameter[] arrProcPram)
        {
            try
            {
                ConStr = System.Configuration.ConfigurationManager.AppSettings["con"];
                SqlConnection cnn = new SqlConnection(ConStr);
                cnn.Open();
                DataCmd.Connection = cnn;
                DataAdtp.SelectCommand = DataCmd;
                int returnvalue;
                DataCmd.CommandText = StoreprocedureName;
                DataCmd.CommandType = CommandType.StoredProcedure;
                DataCmd.Parameters.Clear();
                foreach (SqlParameter pram in arrProcPram)
                {
                    DataCmd.Parameters.Add(pram);
                }
                DataCmd.Parameters.Add("returnvalue", SqlDbType.Int);
                DataCmd.Parameters["returnvalue"].Direction = ParameterDirection.ReturnValue;
                DataCmd.ExecuteNonQuery();
                returnvalue = Convert.ToInt32(DataCmd.Parameters["returnvalue"].Value);
                return Convert.ToInt32(DataCmd.Parameters["returnvalue"].Value);
            }
            catch (Exception ex)
            {
                if (((System.Data.SqlClient.SqlException)ex).Number == 547)
                {
                    return 547;
                }
                else if (((System.Data.SqlClient.SqlException)ex).Number == 2627)
                {
                    return 2627;
                }
                else
                {
                    ObjEx.PublishError("Execute Procedure(ExcuteProce)", ex);
                }
            }
            finally
            {
                cnn.Close();
                cnn.Dispose();
                SqlConnection.ClearPool(cnn);
            }
            return Convert.ToInt32(DataCmd.Parameters["returnvalue"].Value);
        }

        public int ExcuteProce(string StoreprocedureName)
        {
            try
            {
                ConnectCon();
                int returnvalue;
                DataCmd.CommandText = StoreprocedureName;
                DataCmd.CommandType = CommandType.StoredProcedure;
                DataCmd.Parameters.Clear();
                DataCmd.Parameters.Add("returnvalue", SqlDbType.Int);
                DataCmd.Parameters["returnvalue"].Direction = ParameterDirection.ReturnValue;
                DataCmd.ExecuteNonQuery();
                returnvalue = Convert.ToInt32(DataCmd.Parameters["returnvalue"].Value);
                return Convert.ToInt32(DataCmd.Parameters["returnvalue"].Value);
            }
            catch (Exception ex)
            {
                if (((System.Data.SqlClient.SqlException)ex).Number == 547)
                {
                    return 547;
                }
                else if (((System.Data.SqlClient.SqlException)ex).Number == 2627)
                {
                    return 2627;
                }
                else
                {
                    ObjEx.PublishError("Execute Procedure(ExcuteProce)", ex);
                }
            }
            finally
            {
                Disconnect();
            }
            return Convert.ToInt32(DataCmd.Parameters["returnvalue"].Value);
        }

        public string ExcuteProceOutPutParameter(String StoreprocedureName, SqlParameter[] arrProcPram)
        {
            string returnvalue;
            try
            {
                ConnectCon();
                DataCmd.CommandText = StoreprocedureName;
                DataCmd.CommandType = CommandType.StoredProcedure;
                DataCmd.Parameters.Clear();
                foreach (SqlParameter Pram in arrProcPram)
                {
                    DataCmd.Parameters.Add(Pram);
                }
                SqlParameter p = DataCmd.Parameters.Add("@EventIdentity", SqlDbType.Int);
                p.Direction = ParameterDirection.Output;
                DataCmd.ExecuteNonQuery();
                returnvalue = Convert.ToString(DataCmd.Parameters["@EventIdentity"].Value);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Execute Output Parameter Procedure(ExcuteProceOutPutParameter)", ex);
            }
            finally
            {
                Disconnect();
            }
            return returnvalue = Convert.ToString(DataCmd.Parameters["@EventIdentity"].Value);
        }

        public SqlDataReader GetDatareaderProc(string strProcName, SqlParameter[] arrparam)
        {
            try
            {
                ConnectCon();
                DataCmd.CommandType = CommandType.StoredProcedure;
                DataCmd.CommandText = strProcName;
                DataCmd.Parameters.Clear();
                foreach (SqlParameter param in arrparam)
                {
                    DataCmd.Parameters.Add(param);
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Get Data Reader Procedure(GetDatareaderProc)", ex);
            }
            finally
            {
                Disconnect();
            }
            return DataCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public SqlDataReader GetDatareaderProc(string strProcName)
        {
            try
            {
                ConnectCon();
                DataCmd.CommandType = CommandType.StoredProcedure;
                DataCmd.CommandText = strProcName;
                DataCmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Get Data Reader Procedure(GetDatareaderProc)", ex);
            }
            finally
            {
                Disconnect();
            }
            return DataCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void rptrBind_SNO(System.Web.UI.WebControls.Repeater rptrGrid, string strProcName, SqlParameter[] arrparam)
        {
            DataSet dset;
            dset = new DataSet();
            dset = GetDsetProc1(strProcName, arrparam);
            try
            {
                rptrGrid.DataSource = dset.Tables[0];
                rptrGrid.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Datagrid view Procedure(GdBind_SNO)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void DdBing(System.Web.UI.WebControls.DropDownList ddlname, string strProcName, string textfield, string valuefield, SqlParameter[] arrparam)
        {
            SqlDataReader dtr;
            try
            {
                dtr = GetDatareaderProc(strProcName, arrparam);
                ddlname.DataSource = dtr;
                ddlname.DataTextField = textfield;
                ddlname.DataValueField = valuefield;
                ddlname.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Dropdownlist Procedure(DdBing)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void DdBing(System.Web.UI.WebControls.DropDownList ddlname, string strProcName, string textfield, string valuefield)
        {
            SqlDataReader dtr;
            try
            {
                dtr = GetDatareaderProc(strProcName);
                ddlname.DataSource = dtr;
                ddlname.DataTextField = textfield;
                ddlname.DataValueField = valuefield;
                ddlname.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Dropdownlist Procedure(DdBing)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void LsBing(System.Web.UI.WebControls.ListBox lsName, string strProcName, string textfield, string valuefield, SqlParameter[] arrparam)
        {
            SqlDataReader dtr;
            try
            {
                dtr = GetDatareaderProc(strProcName, arrparam);
                lsName.DataSource = dtr;
                lsName.DataTextField = textfield;
                lsName.DataValueField = valuefield;
                lsName.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Dropdownlist Procedure(DdBing)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void LsBing(System.Web.UI.WebControls.ListBox lsName, string strProcName, string textfield, string valuefield)
        {
            SqlDataReader dtr;
            try
            {
                dtr = GetDatareaderProc(strProcName);
                lsName.DataSource = dtr;
                lsName.DataTextField = textfield;
                lsName.DataValueField = valuefield;
                lsName.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Dropdownlist Procedure(DdBing)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public System.Data.DataSet GetDsetProc(string StrProcName, SqlParameter[] arrparam, string tablename)
        {
            DataSet Dset = new DataSet();
            try
            {
                ConnectCon();
                DataCmd.CommandType = CommandType.StoredProcedure;
                DataCmd.CommandText = StrProcName;
                DataCmd.Parameters.Clear();
                foreach (SqlParameter param in arrparam)
                {
                    DataCmd.Parameters.Add(param);
                }
                DataAdtp.Fill(Dset);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Get Dataset Procedure(GetDsetProc)", ex);
            }
            finally
            {
                Disconnect();
            }
            return Dset;
        }

        public System.Data.DataSet GetDsetProc(string StrProcName, SqlParameter[] arrparam)
        {
            DataSet Dset = new DataSet();
            try
            {
                ConnectCon();
                DataCmd.CommandType = CommandType.StoredProcedure;
                DataCmd.CommandText = StrProcName;
                DataCmd.Parameters.Clear();
                foreach (SqlParameter param in arrparam)
                {
                    DataCmd.Parameters.Add(param);
                }
                DataAdtp.Fill(Dset);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Get Dataset Procedure(GetDsetProc)", ex);
            }
            finally
            {
                Disconnect();
            }
            return Dset;
        }

        public System.Data.DataSet GetDsetProc(string StrProcName)
        {
            DataSet Dset = new DataSet();
            try
            {
                ConnectCon();
                DataCmd.CommandType = CommandType.StoredProcedure;
                DataCmd.CommandText = StrProcName;
                DataCmd.Parameters.Clear();
                DataAdtp.Fill(Dset);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Get Dataset Procedure(GetDsetProc)", ex);
            }
            finally
            {
                Disconnect();
            }
            return Dset;
        }

        public System.Data.DataSet GetDsetProc1(string StrProcName, SqlParameter[] arrparam, string tablename)
        {
            DataSet Dset = new DataSet();
            DataTable dt;
            DataColumn dc;
            try
            {
                ConnectCon();
                dt = new DataTable("dt1");
                dc = new DataColumn("sno", typeof(int));
                dc.AutoIncrement = true;
                dc.AutoIncrementSeed = 1;
                dc.AutoIncrementStep = 1;
                dc.ReadOnly = true;
                dt.Columns.Add(dc);
                Dset.Tables.Add(dt);
                DataCmd.CommandType = CommandType.StoredProcedure;
                DataCmd.CommandText = StrProcName;
                DataCmd.Parameters.Clear();
                foreach (SqlParameter param in arrparam)
                {
                    DataCmd.Parameters.Add(param);
                }
                DataAdtp.Fill(Dset, "dt1");
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Get Dataset Procedure(GetDsetProc1)", ex);
            }
            finally
            {
                Disconnect();
            }
            return Dset;
        }

        public System.Data.DataSet GetDsetProc1(string StrProcName, SqlParameter[] arrparam)
        {
            DataSet Dset = new DataSet();
            DataTable dt;
            DataColumn dc;
            try
            {
                ConnectCon();
                dt = new DataTable("dt1");
                dc = new DataColumn("sno", typeof(int));
                dc.AutoIncrement = true;
                dc.AutoIncrementSeed = 1;
                dc.AutoIncrementStep = 1;
                dc.ReadOnly = true;
                dt.Columns.Add(dc);
                Dset.Tables.Add(dt);
                DataCmd.CommandType = CommandType.StoredProcedure;
                DataCmd.CommandText = StrProcName;
                DataCmd.Parameters.Clear();
                foreach (SqlParameter param in arrparam)
                {
                    DataCmd.Parameters.Add(param);
                }
                DataAdtp.Fill(Dset, "dt1");
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Get Dataset Procedure(GetDsetProc1)", ex);
            }
            finally
            {
                Disconnect();
            }
            return Dset;
        }

        public System.Data.DataSet GetDsetProc1(string StrProcName)
        {
            DataSet Dset = new DataSet();
            DataTable dt;
            DataColumn dc;
            try
            {
                ConnectCon();
                dt = new DataTable("dt1");
                dc = new DataColumn("sno", typeof(int));
                dc.AutoIncrement = true;
                dc.AutoIncrementSeed = 1;
                dc.AutoIncrementStep = 1;
                dc.ReadOnly = true;
                dt.Columns.Add(dc);
                Dset.Tables.Add(dt);
                DataCmd.CommandType = CommandType.StoredProcedure;
                DataCmd.CommandText = StrProcName;
                DataCmd.Parameters.Clear();
                DataAdtp.Fill(Dset, "dt1");
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Get Dataset Procedure(GetDsetProc1)", ex);
            }
            finally
            {
                Disconnect();
            }
            return Dset;
        }

        public void DgBind(System.Web.UI.WebControls.DataGrid dgGrid, string strProcName, SqlParameter[] arrparam)
        {
            DataSet dset;
            dset = new DataSet();
            dset = GetDsetProc(strProcName, arrparam);
            try
            {
                dgGrid.DataSource = dset.Tables[0];
                dgGrid.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Datagrid Procedure(DgBind)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void DgBind(System.Web.UI.WebControls.DataGrid dgGrid, string strProcName)
        {
            DataSet dset;
            dset = new DataSet();
            dset = GetDsetProc(strProcName);
            try
            {
                dgGrid.DataSource = dset.Tables[0];
                dgGrid.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Datagrid Procedure(DgBind)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void GviewBind(System.Web.UI.WebControls.GridView dgGrid, string strProcName, SqlParameter[] arrparam)
        {
            DataSet dset;
            dset = new DataSet();
            dset = GetDsetProc(strProcName, arrparam);
            try
            {
                dgGrid.DataSource = dset.Tables[0];
                dgGrid.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Datagrid Procedure(GviewBind)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void GviewBind(System.Web.UI.WebControls.GridView dgGrid, string strProcName)
        {
            DataSet dset;
            dset = new DataSet();
            dset = GetDsetProc(strProcName);
            try
            {
                dgGrid.DataSource = dset.Tables[0];
                dgGrid.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Datagrid Procedure(GviewBind)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void DataListBind(System.Web.UI.WebControls.DataList DList, string strProcName, SqlParameter[] arrparam)
        {
            DataSet dset;
            dset = new DataSet();
            dset = GetDsetProc(strProcName, arrparam);
            try
            {
                DList.DataSource = dset.Tables[0];
                DList.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Datagrid Procedure(DataListBind)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void DataListBind(System.Web.UI.WebControls.DataList DList, string strProcName)
        {
            DataSet dset;
            dset = new DataSet();
            dset = GetDsetProc(strProcName);
            try
            {
                DList.DataSource = dset.Tables[0];
                DList.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Datagrid Procedure(GviewBind)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void DgBind_SNO(System.Web.UI.WebControls.DataGrid dgGrid, string strProcName, SqlParameter[] arrparam)
        {
            DataSet dset;
            dset = new DataSet();
            dset = GetDsetProc1(strProcName, arrparam);
            try
            {
                dgGrid.DataSource = dset.Tables[0];
                dgGrid.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Datagrid Procedure(DgBind_SNO)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void DgBind_SNO(System.Web.UI.WebControls.DataGrid dgGrid, string strProcName)
        {
            DataSet dset;
            dset = new DataSet();
            dset = GetDsetProc1(strProcName);
            try
            {
                dgGrid.DataSource = dset.Tables[0];
                dgGrid.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Datagrid Procedure(DgBind_SNO)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void GdBind_SNO(System.Web.UI.WebControls.GridView gdGrid, string strProcName, SqlParameter[] arrparam)
        {
            DataSet dset;
            dset = new DataSet();
            dset = GetDsetProc1(strProcName, arrparam);
            try
            {
                gdGrid.DataSource = dset.Tables[0];
                gdGrid.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Datagrid view Procedure(GdBind_SNO)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void GdBind_SNO(System.Web.UI.WebControls.GridView gdGrid, string strProcName)
        {
            DataSet dset;
            dset = new DataSet();
            dset = GetDsetProc1(strProcName);
            try
            {
                gdGrid.DataSource = dset.Tables[0];
                gdGrid.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Datagrid view Procedure(GdBind_SNO)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void DataListBind_SNO(System.Web.UI.WebControls.DataList dtDataList, string strProcName, SqlParameter[] arrparam)
        {
            DataSet dset;
            dset = new DataSet();
            dset = GetDsetProc1(strProcName, arrparam);
            try
            {
                dtDataList.DataSource = dset.Tables[0];
                dtDataList.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Datagrid view Procedure(DataListBind_SNO)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void DataListBind_SNO(System.Web.UI.WebControls.DataList dtDataList, string strProcName)
        {
            DataSet dset;
            dset = new DataSet();
            dset = GetDsetProc1(strProcName);
            try
            {
                dtDataList.DataSource = dset.Tables[0];
                dtDataList.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Datagrid view Procedure(DataListBind_SNO)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public string GetScalarProc(string strProcName, SqlParameter[] arrparam)
        {
            try
            {
                ConnectCon();
                DataCmd.CommandType = CommandType.StoredProcedure;
                DataCmd.CommandText = strProcName;
                DataCmd.Parameters.Clear();
                foreach (SqlParameter param in arrparam)
                {
                    DataCmd.Parameters.Add(param);
                }
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Get Scalar Procedure(GetScalarProc)", ex);
            }
            finally
            {
                Disconnect();
            }
            return Convert.ToString(DataCmd.ExecuteScalar());
        }

        public System.Data.DataTable GetDtbleProc(string StrProcName, SqlParameter[] arrparam)
        {
            DataTable Dtbl = new DataTable();
            try
            {
                ConnectCon();
                DataCmd.CommandType = CommandType.StoredProcedure;
                DataCmd.CommandText = StrProcName;
                DataCmd.Parameters.Clear();
                foreach (SqlParameter param in arrparam)
                {
                    DataCmd.Parameters.Add(param);
                }
                DataAdtp.Fill(Dtbl);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Get Dataset Procedure(GetDtbleProc)", ex);
            }
            finally
            {
                Disconnect();
            }
            return Dtbl;
        }

        public void RbBind(System.Web.UI.WebControls.RadioButtonList RBname, string strProcName, string textfield, string valuefield, SqlParameter[] arrparam)
        {
            SqlDataReader dtr;
            try
            {
                dtr = GetDatareaderProc(strProcName, arrparam);
                RBname.DataSource = dtr;
                RBname.DataTextField = textfield;
                RBname.DataValueField = valuefield;
                RBname.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Dropdownlist Procedure(DdBing)", ex);
            }
            finally
            {
                Disconnect();
            }
        }

        public void chkBoxBind(System.Web.UI.WebControls.CheckBoxList chkname, string strProcName, string textfield, string valuefield, SqlParameter[] arrparam)
        {
            SqlDataReader dtr;
            try
            {
                dtr = GetDatareaderProc(strProcName, arrparam);
                chkname.DataSource = dtr;
                chkname.DataTextField = textfield;
                chkname.DataValueField = valuefield;
                chkname.DataBind();
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Bind Dropdownlist Procedure(DdBing)", ex);
            }
            finally
            {
                Disconnect();
            }
        }
    }
}
