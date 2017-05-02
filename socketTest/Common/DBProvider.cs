using System;
using System.Data.Common;
using System.Data;

namespace socketTest.Common
{
    public class DBProvider : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public DBProvider()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="conn"></param>
        public void CreateConnection(ref String provider, ref String conn)
        {
            do
            {
                try
                {
                    DbProviderFactory dbFactory = DbProviderFactories.GetFactory(provider);
                    _dbConn = dbFactory.CreateConnection();
                    _dbConn.ConnectionString = conn;

                    _dbConn.Open();

                    _dbTrans = _dbConn.BeginTransaction();
                    _dbCmd = _dbConn.CreateCommand();
                    _dbCmd.Transaction = _dbTrans;
                    _dbAdapter = dbFactory.CreateDataAdapter();
                    _dbAdapter.SelectCommand = _dbCmd;
                }
                catch (Exception e)
                {
#if BUSINESS_DEBUG

#endif
                }
            } while (false);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <param name="paramValue"></param>
        /// <param name="clear"></param>
        public void SetInParameter(ref String paramName, DbType dbType, object paramValue, bool clear)
        {
            do
            {
                try
                {
                    if (clear)
                    {
                        _dbCmd.Parameters.Clear();
                    }

                    DbParameter dbParameter = _dbCmd.CreateParameter();
                    dbParameter.ParameterName = paramName;
                    dbParameter.DbType = dbType;
                    dbParameter.Value = paramValue;
                    dbParameter.Direction = ParameterDirection.Input;
                    _dbCmd.Parameters.Add(dbParameter);
                }
                catch (Exception e)
                {
#if BUSINESS_DEBUG

#endif
                }
            } while (false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <param name="clear"></param>
        public void SetOutParameter(ref String paramName, DbType dbType, int size, bool clear)
        {
            do
            {
                try
                {
                    if (clear)
                    {
                        _dbCmd.Parameters.Clear();
                    }

                    DbParameter dbParameter = _dbCmd.CreateParameter();
                    dbParameter.ParameterName = paramName;
                    dbParameter.DbType = dbType;
                    dbParameter.Direction = ParameterDirection.Output;
                    dbParameter.Size = size;
                    _dbCmd.Parameters.Add(dbParameter);
                }
                catch (Exception e)
                {
#if BUSINESS_DEBUG
                    
#endif
                }
            } while (false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public object GetParameterValue(ref String paramName)
        {
            return _dbCmd.Parameters[paramName] as object;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <param name="clear"></param>
        public void SetReturnParameter(ref String paramName, DbType dbType, bool clear)
        {
            do
            {
                try
                {
                    if (clear)
                    {
                        _dbCmd.Parameters.Clear();
                    }

                    DbParameter dbParameter = _dbCmd.CreateParameter();
                    dbParameter.ParameterName = paramName;
                    dbParameter.DbType = dbType;
                    dbParameter.Direction = ParameterDirection.ReturnValue;
                    _dbCmd.Parameters.Add(dbParameter);
                }
                catch (Exception e)
                {
#if BUSINESS_DEBUG

#endif
                }
            } while (false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ExecuteBatchNotQuery()
        {
            int iRet = -1;

            do
            {
                try
                {
                    if (_dbConn.State == ConnectionState.Broken || _dbConn.State == ConnectionState.Closed)
                    {
                        _dbConn.Open();
                    }

                    iRet = _dbCmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
#if BUSINESS_DEBUG

#endif
                }
            } while (false);

            return iRet;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Commit()
        {
            if (null != _dbTrans)
            {
                _dbTrans.Commit();
            }
        }

        public void RollBack()
        {
            if (null != _dbTrans)
            {
                _dbTrans.Rollback();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ExecuteNotQuery()
        {
            int iRet = -1;

            do
            {
                try
                {
                    if (_dbConn.State == ConnectionState.Broken || _dbConn.State == ConnectionState.Closed)
                    {
                        _dbConn.Open();
                    }

                    iRet = _dbCmd.ExecuteNonQuery();
                    _dbTrans.Commit();

                }
                catch (Exception e)
                {
                    _dbTrans.Rollback();
#if BUSINESS_DEBUG

#endif
                }
            } while (false);

            return iRet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object ExecuteScalar()
        {
            object cRet = null;

            do
            {
                try
                {
                    if (_dbConn.State == ConnectionState.Broken || _dbConn.State == ConnectionState.Closed)
                    {
                        _dbConn.Open();
                    }

                    cRet = _dbCmd.ExecuteScalar();
                    _dbTrans.Commit();

                }
                catch (Exception e)
                {
                    _dbTrans.Rollback();
#if BUSINESS_DEBUG

#endif
                }
            } while (false);

            return cRet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void QueryData(ref DataSet data)
        {
            do
            {
                try
                {
                    if (_dbConn.State == ConnectionState.Broken || _dbConn.State == ConnectionState.Closed)
                    {
                        _dbConn.Open();
                    }

                    _dbAdapter.Fill(data);
                }
                catch (Exception e)
                {
#if BUSINESS_DEBUG

#endif
                }

            } while (false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void SetStoreCmdText(ref String text)
        {
            do
            {
                if (null != _dbCmd)
                {
                    _dbCmd.CommandType = CommandType.StoredProcedure;
                    _dbCmd.CommandText = text;
                }
            } while (false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void SetSqlCmdText(ref String text)
        {
            do
            {
                if (null != _dbCmd)
                {
                    _dbCmd.CommandType = CommandType.Text;
                    _dbCmd.CommandText = text;
                }
            } while (false);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Terminate()
        {
            do
            {
                try
                {
                    if (null != _dbConn)
                    {
                        _dbConn.Close();
                    }
                }
                catch (Exception e)
                {
#if BUSINESS_DEBUG

#endif
                }
            } while (false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispose"></param>
        protected virtual void Dispose(bool dispose)
        {
            if (dispose)
            {
                if (null != _dbConn)
                {
                    _dbConn.Dispose();
                    _dbConn = null;
                }

                if (null != _dbCmd)
                {
                    _dbCmd.Dispose();
                    _dbCmd = null;
                }

                if (null != _dbAdapter)
                {
                    _dbAdapter.Dispose();
                    _dbAdapter = null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        private DbConnection _dbConn;

        /// <summary>
        /// 
        /// </summary>
        private DbCommand _dbCmd;

        /// <summary>
        /// 
        /// </summary>
        private DbDataAdapter _dbAdapter;

        /// <summary>
        /// 
        /// </summary>
        private DbTransaction _dbTrans;
    }
}
