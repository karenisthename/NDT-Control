using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;

namespace NDT_Control
{
    public abstract class SQLDataBaseConnection : IDisposable
    {
          //Properties
        public abstract string StoredProcedure
        {
            get;
            set;
        }
        public abstract System.Data.Common.DbConnection dbconnection
        {
            get;
        }
        
        static string _connectionString;
        public virtual string conString
        {
            get{ return _connectionString;}
            set { _connectionString = value; }
        }

        System.Data.Common.DbParameterCollection _parameterCollection;
        public virtual System.Data.Common.DbParameterCollection paramscollection
        {
            get { return _parameterCollection; }
            set { _parameterCollection = value; }
        }

        //Constructor
        public SQLDataBaseConnection()
            : this("")
        { }
        public SQLDataBaseConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        //Methods
        public abstract void Dispose();
        public abstract bool isDataBaseConnected();
        public abstract System.Data.DataTable PerformCommand();
        public abstract System.Data.DataTable PerformCommand(string storedProcedure, System.Data.Common.DbParameter[] parameter);
        public abstract System.Data.DataTable PerformQuery(string sqlQuery);
        public abstract System.Data.DataTable PerformQuery(string sqlQuery, System.Data.Common.DbParameter[] parameter);

        //Events
        public delegate void connectionEventHandler(object sender, ConnectionServerStateEventArgs e);
        public virtual event connectionEventHandler connectionServerStateEvent;
        protected virtual void OnconnectionStateChange(ConnectionServerStateEventArgs e)
        {
            if (connectionServerStateEvent != null)
            {
                connectionServerStateEvent(this, e);
                e.statusMessage = "Connection Status is OPEN.";
            }
            else
            {
                e.statusMessage = "Connection Status is CLOSED.";
            }
        }
    }

    public sealed class ConnectionServerStateEventArgs : EventArgs
    {
        ConnectionServerStateEnum statusConnection;
        private string connectionMessage;

        //constructor
        public ConnectionServerStateEventArgs()
        { }
        public ConnectionServerStateEventArgs(System.Data.Common.DbConnection connection)
        {
            if (connection != null)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connectionMessage = "Connection Status: OPEN";
                    statusConnection = ConnectionServerStateEnum.Open;
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    try
                    {
                        connection.Open();
                        statusConnection = ConnectionServerStateEnum.Open;
                        connectionMessage = "Connection Status Changed to: CLOSED";
                    }
                    catch (Exception e)
                    {
                        connection.Close();
                        statusConnection = ConnectionServerStateEnum.Closed;
                        throw new Exception(e.Message);
                    }
                }
                else
                {
                    statusConnection = ConnectionServerStateEnum.Unknown;
                    connectionMessage = "Connection Status: UNKNOWN";
                }
            }
            else {
                connection.Close();
                statusConnection = ConnectionServerStateEnum.Closed;
                connectionMessage = "Connection Status: CLOSED.";
            }
        }

        public string statusMessage
        {
            get { return connectionMessage; }
            set{ connectionMessage = value; }
        }

        public ConnectionServerStateEnum ConnectionServerState
        {
            get { return statusConnection; }
        }
    }
    public enum ConnectionServerStateEnum
    {
        Closed=0,
        Open=1,
        Unknown= 2
    }

    namespace useSQL
    {
        public sealed class useSQL : SQLDataBaseConnection
        {
            System.Data.Common.DbCommand newcommand = new SqlCommand();

            //Properties
            private string _storedProcedure;
            public override string StoredProcedure
            {
                get { return _storedProcedure; }
                set
                {
                    _storedProcedure = value;

                    newcommand.CommandType = System.Data.CommandType.StoredProcedure;
                    newcommand.CommandText = value;
                    newcommand.Parameters.Clear();
                }
            }

            private System.Data.Common.DbConnection _dbConnection;
            public override System.Data.Common.DbConnection dbconnection
            {
                get { return _dbConnection; }
            }

            static string _connectionString;
            public override string conString
            {
                get
                {
                    return _connectionString;
                }
                set
                {
                    base.conString = value;
                    base.paramscollection = newcommand.Parameters;

                    _connectionString = value;

                    _dbConnection = new SqlConnection(value);
                    if (_dbConnection.State == System.Data.ConnectionState.Closed)
                    {
                        _dbConnection.ConnectionString = value;
                    }
                }
            }

            //Constructor   
            public useSQL()
                : this("")
            {
            }
            public useSQL(string connectionString)
                : base(connectionString)
            {
                conString = connectionString;

                if (_dbConnection.State == System.Data.ConnectionState.Closed)
                    _dbConnection.ConnectionString = _connectionString;
            }

            //Methods
            public override void Dispose()
            {
                newcommand.Dispose();
                _dbConnection.Close();
            }
            public override bool isDataBaseConnected()
            {
                try
                {
                    if (dbconnection.State == System.Data.ConnectionState.Closed)
                        dbconnection.Open();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                    throw e;
                }
            }
            public override System.Data.DataTable PerformCommand()
            {
                System.Data.DataTable dtable = new System.Data.DataTable();
                try
                {
                    using (System.Data.Common.DbConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        newcommand.Connection = con;
                        dtable.Load(newcommand.ExecuteReader());

                        return dtable;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    dbconnection.Dispose();
                    newcommand.Dispose();
                }
            }
            public override System.Data.DataTable PerformCommand(string storedProcedure, System.Data.Common.DbParameter[] parameter)
            {
                System.Data.DataTable dtable = new System.Data.DataTable();

                try
                {
                    if (isDataBaseConnected())
                    {
                        newcommand.CommandType = System.Data.CommandType.StoredProcedure;
                        newcommand.CommandText = StoredProcedure;
                        newcommand.Parameters.Clear();

                        for (int intIndex = 0; intIndex <= parameter.Length - 1; intIndex++)
                            newcommand.Parameters.Add(parameter[intIndex]);

                        if (dbconnection.State == System.Data.ConnectionState.Closed)
                            dbconnection.Open();

                        newcommand.Connection = dbconnection;
                        dtable.Load(newcommand.ExecuteReader());
                    }
                    else
                    {
                        throw new Exception("ExecuteCommand(string, DbParameter): Connection not established.");
                    }

                    return dtable;

                }
                catch (SqlException sqlex)
                {
                    throw new Exception(sqlex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (dbconnection != null)
                        dbconnection.Close();

                    dbconnection.Dispose();
                    newcommand.Dispose();
                }

            }
            public override System.Data.DataTable PerformQuery(string sqlQuery)
            {
                System.Data.DataTable dtable = new System.Data.DataTable();

                try
                {

                    if (isDataBaseConnected())
                    {
                        newcommand.CommandTimeout = 0;
                        newcommand.CommandType = System.Data.CommandType.Text;
                        newcommand.CommandText = sqlQuery;

                        newcommand.Parameters.Clear();
                        newcommand.Connection = dbconnection;
                        dtable.Load(newcommand.ExecuteReader());
                    }
                    else
                    {
                        throw new Exception("ExecuteQuery(string): Connection not established.");
                    }
                    return dtable;
                }
                catch (SqlException sqlex)
                {
                    throw new Exception(sqlex.Message);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    if (dbconnection != null)
                        dbconnection.Close();

                    dbconnection.Dispose();
                    newcommand.Dispose();
                }
            }
            public override System.Data.DataTable PerformQuery(string sqlQuery, System.Data.Common.DbParameter[] parameter)
            {
                System.Data.DataTable dtable = new System.Data.DataTable();

                try
                {
                    if (isDataBaseConnected())
                    {
                        newcommand.CommandType = System.Data.CommandType.Text;
                        newcommand.CommandText = sqlQuery;

                        newcommand.Parameters.Clear();
                        for (int i = 0; i <= parameter.Length - 1; i++)
                            newcommand.Parameters.Add(parameter[i]);

                        if (dbconnection.State == System.Data.ConnectionState.Closed)
                            dbconnection.Open();

                        dtable.Load(newcommand.ExecuteReader());
                    }
                    else
                    {
                        throw new Exception("ExecuteQuery(String, DbParameter): Connection not established.");
                    }

                    return dtable;
                }
                catch (System.Data.Common.DbException sqlex)
                {
                    throw new Exception(sqlex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (dbconnection != null)
                        dbconnection.Close();

                    dbconnection.Dispose();
                    newcommand.Dispose();
                }

            }

           
            //Events
            public override event SQLDataBaseConnection.connectionEventHandler connectionServerStateEvent;
            protected override void OnconnectionStateChange(ConnectionServerStateEventArgs e)
            {
                if (connectionServerStateEvent != null)
                    connectionServerStateEvent(this, e);
            }
        }
    }
}
