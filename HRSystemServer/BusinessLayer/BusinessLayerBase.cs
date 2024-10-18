using System;
using System.Data;
using System.Data.SqlClient;
using HRSystemServer.DataLayer;

namespace HRSystemServer.BusinessLayer
{
    public class BusinessLayerBase
    {
        private int _systemUser = -1;
        private Exception _lastException = null;
        private IDataLayer _dataLayer = null;


        //****************************************************
        //****************************************************
        public BusinessLayerBase()
        {
        }


        //****************************************************
        //****************************************************
        public virtual IDataLayer DataLayer
        {
            get { return _dataLayer; }
            set { _dataLayer = value; }
        }


        //****************************************************
        //****************************************************
        public virtual void ClearLastException()
        {
            LastException = null;
        }


        //****************************************************
        //****************************************************
        public virtual int SystemUser
        {
            get { return _systemUser; }
            set { _systemUser = value; }
        }


        //****************************************************
        //****************************************************
        public virtual Exception LastException
        {
            get { return _lastException; }
            set { _lastException = value; }
        }


        //****************************************************
        //****************************************************
        public virtual bool Save(DataSet aDataSet)
        {
            return Execute(SqlAction.Save, aDataSet);
        }
        public virtual bool SQLBulkInsert(DataSet aDataSet)
        {
            return Execute(SqlAction.SQLBulkInsert, aDataSet);
        }


        //****************************************************
        //****************************************************
        public virtual bool BulkInsert(DataSet aDataSet)
        {
            return Execute(SqlAction.BulkInsert, aDataSet);
        }

        //****************************************************
        //****************************************************
        public virtual bool Fetch(DataSet aDataSet, int aKey)
        {
            return Execute(SqlAction.Fetch, aDataSet, aKey);
        }


        //****************************************************
        //****************************************************
        public virtual bool FetchAll(DataSet aDataSet)
        {
            return Execute(SqlAction.FetchAll, aDataSet);
        }


        //****************************************************
        //****************************************************
        protected virtual bool Execute(SqlAction aSqlAction, DataSet aDataSet)
        {
            return Execute(aSqlAction, aDataSet, null);
        }

        //****************************************************
        //****************************************************
        protected virtual bool Execute(SqlAction aSqlAction, params Object[] aParams)
        {
            return Execute(aSqlAction, null, aParams);
        }


        //****************************************************
        //****************************************************
        public virtual bool Clear(DataSet ds)
        {
            return Execute(SqlAction.Clear, ds);

        }
        //****************************************************
        //****************************************************
        public virtual bool Delete(string Key)
        {
            return Execute(SqlAction.Delete, Key);
        }

        //****************************************************
        //****************************************************
        //Execute a SQL query (aSqlAction)
        protected virtual bool Execute(SqlAction aSqlAction, DataSet aDataSet, params Object[] aParams)
        {
            bool result = true;
            DataLayerMessage message = new DataLayerMessage(aSqlAction, BusinessLayerUtility.GetConnection(SystemUser), aDataSet, aParams);
            try
            {
                DataLayer.Execute(message);
            }
            catch (Exception ex)
            {
                result = false;
                LastException = ex;
            }
            finally
            {
                message.SqlConnection.Close();
            }
            return result;
        }


        //****************************************************
        //****************************************************
        public virtual SqlEntity SqlEntity
        {
            get { return DataLayer.SqlEntity; }
        }


        //****************************************************
        //****************************************************
        public virtual string SqlEntityX
        {
            get { return DataLayer.SqlEntityX; }
        }

        //****************************************************
        //****************************************************
        public virtual string ShortSqlEntityX
        {
            get { return DataLayer.ShortSqlEntityX; }
        }

        //****************************************************
        //****************************************************
        public virtual DataRow GetRow(int aKey)
        {
            DataRow result = null;
            try
            {
                DataSet ds = new DataSet();
                Fetch(ds, aKey);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = ds.Tables[0].Rows[0];
                    }
                }
            }
            catch
            {
            }
            return result;
        }


    }
}
