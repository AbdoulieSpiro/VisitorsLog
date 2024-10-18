using System;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;



namespace HRSystemServer.DataLayer
{
    public class DataLayerBase
    {
        protected SqlEntity _sqlEntity;
        protected const string ReturnValueParamName = "@retval";


        //****************************************************
        //****************************************************
        public DataLayerBase()
        {
        }

        //****************************************************
        //****************************************************
        public virtual SqlEntity SqlEntity
        {
            get { return _sqlEntity; }
        }


        //****************************************************
        //****************************************************
        protected virtual SqlCommand GetCommand(SqlConnection aSqlConnection, SqlAction aSqlAction)
        {
            return null;
        }


        //****************************************************
        //****************************************************
        public virtual void Execute(DataLayerMessage aMessage)
        {
            switch (aMessage.SqlAction)
            {

                case SqlAction.Save:

                    Save(aMessage);
                    break;

                case SqlAction.Fetch:
                    Fetch(aMessage);
                    break;

                case SqlAction.FetchAll:
                    FetchAll(aMessage);
                    break;

                case SqlAction.Commit:
                case SqlAction.Rollback:
                case SqlAction.Delete:
                case SqlAction.Clone:
                case SqlAction.Upsert:
                case SqlAction.InsertUpdateMultiple:
                    ExecuteNonQuery(aMessage);
                    break;

                default:
                    Fetch(aMessage);
                    break;

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aMessage"></param>
        protected void ExecuteFetchForAll(DataLayerMessage aMessage)
        {

            Fetch(aMessage);
        }
        //****************************************************
        //****************************************************
        protected void ExecuteNonquery(DataLayerMessage aMessage)
        {
            SqlCommand cmd = null;
            int Count = 0;
            try
            {
                cmd = DataLayerUtility.NewSqlCommand();
                cmd = GetCommand(aMessage.SqlConnection, aMessage.SqlAction);
                aMessage.ApplyParams(cmd.Parameters);
                Count = cmd.ExecuteNonQuery();

                if (cmd.Parameters.Contains("@error"))
                {
                    if (cmd.Parameters["@error"].Value.ToString() != "")
                    {
                        throw new Exception(cmd.Parameters["@error"].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
        }
        protected virtual void AddReturnValueParameter(SqlParameterCollection aParameters)
        {
            SqlParameter newParam = aParameters.Add(ReturnValueParamName, SqlDbType.Int);
            newParam.Direction = ParameterDirection.ReturnValue;
        }

        //****************************************************
        //****************************************************
        protected virtual SqlDataAdapter GetDataAdapter(SqlConnection aSqlConnection)
        {
            SqlDataAdapter result = DataLayerUtility.NewDataAdapter();
            result.InsertCommand = GetCommand(aSqlConnection, SqlAction.Insert);

            result.UpdateCommand = GetCommand(aSqlConnection, SqlAction.Update);
            result.DeleteCommand = GetCommand(aSqlConnection, SqlAction.Delete);
            return result;
        }
        //****************************************************
        //****************************************************
        public virtual string SqlEntityX
        {
            get { return SqlEntity.ToString(); }
        }
        //****************************************************
        //****************************************************
        public virtual string ShortSqlEntityX
        {
            get
            {
                string result = SqlEntityX;
                if (result.Substring(0, 2).ToLower().Equals("tb"))
                {
                    result = result.Substring(2);
                }
                return result;
            }
        }
        //****************************************************
        //****************************************************
        protected virtual void Save(DataLayerMessage aMessage)
        {
            SqlDataAdapter da = GetDataAdapter(aMessage.SqlConnection);
            da.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
            da.Update(aMessage.DataSet.Tables[SqlEntityX]);
            da.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
        }
        /* Bulk Insert */
        public void BulkInsert(DataLayerMessage aMessage)
        {
            SqlBulkCopy SqlBulkCopy = null;
            SqlBulkCopy = new SqlBulkCopy(aMessage.SqlConnection);
            SqlBulkCopy.BulkCopyTimeout = 0;
            SqlBulkCopy.DestinationTableName = "tb" + ShortSqlEntityX;
            SqlBulkCopy.WriteToServer(aMessage.DataSet.Tables[0]);
        }
        //**************************************************** Fetch single row
        //****************************************************
        protected virtual void Fetch(DataLayerMessage aMessage)
        {
            SqlDataAdapter da = GetDataAdapter(aMessage.SqlConnection);
            da.SelectCommand = GetCommand(aMessage.SqlConnection, aMessage.SqlAction);
            aMessage.ApplyParams(da.SelectCommand.Parameters);
            da.Fill(aMessage.DataSet, SqlEntityX);
        }
        //****************************************************
        //****************************************************
        protected virtual void FetchAll(DataLayerMessage aMessage)
        {
            SqlDataAdapter da = GetDataAdapter(aMessage.SqlConnection);
            da.SelectCommand = GetCommand(aMessage.SqlConnection, SqlAction.FetchAll);
            da.SelectCommand.Connection = aMessage.SqlConnection;
            da.Fill(aMessage.DataSet, SqlEntityX);
        }
        //****************************************************
        //****************************************************
        protected virtual void ExecuteNonQuery(DataLayerMessage aMessage)
        {
            SqlCommand cmd = GetCommand(aMessage.SqlConnection, aMessage.SqlAction);
            aMessage.ApplyParams(cmd.Parameters);
            aMessage.Count = cmd.ExecuteNonQuery();
            aMessage.Key = 0;
            try
            {
                aMessage.Key = (int)cmd.Parameters[ReturnValueParamName].Value;
            }
            catch { }
        }
        //****************************************************
        //****************************************************
        protected virtual void FetchSchema(DataLayerMessage aMessage)
        {
            SqlDataAdapter da = GetDataAdapter(aMessage.SqlConnection);
            da.SelectCommand = GetCommand(aMessage.SqlConnection, SqlAction.Fetch);
            da.FillSchema(aMessage.DataSet, SchemaType.Mapped, SqlEntityX);
        }
        //****************************************************
        //****************************************************
        //protected static void OnRowUpdated(object sender, SqlRowUpdatedEventArgs e)
        protected void OnRowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            try
            {
                if (e.Status == UpdateStatus.ErrorsOccurred)
                {
                    e.Status = UpdateStatus.ErrorsOccurred;
                }
                else
                {
                    if (e.Row.RowState != DataRowState.Deleted)
                        if (e.Command.Parameters.Contains(ReturnValueParamName))
                            if (((int)e.Command.Parameters[ReturnValueParamName].Value) != 0)
                                if (e.Row.Table.Columns.Contains(ShortSqlEntityX))
                                {
                                    e.Row[ShortSqlEntityX] = e.Command.Parameters[ReturnValueParamName].Value;
                                    e.Row.AcceptChanges();
                                }
                }
            }
            catch (Exception ex)
            {
            }
        }

        //****************************************************
        //****************************************************
        public virtual string SqlActionX(SqlAction aSqlAction)
        {
            return Enum.GetName(typeof(SqlAction), aSqlAction);
        }

    }
}
