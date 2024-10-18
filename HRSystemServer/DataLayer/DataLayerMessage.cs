using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace HRSystemServer.DataLayer
{
    public class DataLayerMessage
    {
        private const string PARAMPREFIX = "auto";
        private DataSet _dataSet;
        private DataRow _dataRow;
        private SqlConnection _sqlConnection;
        private SqlTransaction _sqlTransaction;
        private int _key;
        private int _count;
        private SqlAction _sqlAction;
        private Hashtable _params;

        //public DataLayerMessage(SqlAction aSqlAction, SqlConnection aSqlConnection, DataSet aDataSet, int aKey )
        //{
        //	SqlAction = aSqlAction;
        //	SqlConnection = aSqlConnection;
        //	DataSet = aDataSet;
        //	Key = aKey;
        //}

        public DataLayerMessage(SqlAction aSqlAction, SqlConnection aSqlConnection, DataSet aDataSet, params object[] aParams)
        {
            SqlAction = aSqlAction;
            SqlConnection = aSqlConnection;
            DataSet = aDataSet;
            if (aParams != null)
            {
                for (int i = 0; i < aParams.Length; i++)
                {
                    Params.Add(PARAMPREFIX + i.ToString(), aParams[i]);
                }
            }
        }


        public DataLayerMessage(SqlAction aSqlAction, SqlConnection aSqlConnection, DataSet aDataSet)
        {
            SqlAction = aSqlAction;
            SqlConnection = aSqlConnection;
            DataSet = aDataSet;
            Key = 0;
        }

        public DataLayerMessage(SqlConnection aSqlConnection, DataRow aDataRow)
        {
            SqlConnection = aSqlConnection;
            DataRow = aDataRow;
            Key = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        public DataRow DataRow
        {
            get { return _dataRow; }
            set { _dataRow = value; }
        }

        public SqlAction SqlAction
        {
            get { return _sqlAction; }
            set { _sqlAction = value; }
        }

        public DataSet DataSet
        {
            set { _dataSet = value; }
            get { return _dataSet; }
        }

        public SqlConnection SqlConnection
        {
            set { _sqlConnection = value; }
            get { return _sqlConnection; }
        }


        public SqlTransaction SqlTransaction
        {
            set { _sqlTransaction = value; }
            get { return _sqlTransaction; }
        }

        public int Key
        {
            set { _key = value; }
            get { return _key; }
        }


        public int Count
        {
            set { _count = value; }
            get { return _count; }
        }


        public Hashtable Params
        {
            get
            {
                if (_params == null)
                {
                    _params = new Hashtable();
                }
                return _params;
            }
        }

        public void AddParam(string aParamName, object aParamValue)
        {
            Params[aParamName] = aParamValue;
        }

        public void ApplyParams(SqlParameterCollection aCommandParams)
        {
            for (int i = 0; i < aCommandParams.Count; i++)
            {
                if (i < Params.Count)
                    aCommandParams[i].Value = Params[PARAMPREFIX + i.ToString()];
            }
        }


    }
}
