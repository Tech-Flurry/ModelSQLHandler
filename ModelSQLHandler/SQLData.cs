using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace ModelSQLHandler
{
    /// <summary>
    /// Class to deal with the SQL Data
    /// </summary>
    [DataContract]
    abstract public class SQLData : ISQLData
    {
        private SqlConnection dbConnection;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">Connection String of the database.</param>
        protected SQLData(string connectionString)
        {
            dbConnection = new SqlConnection(connectionString);
        }

        string ISQLData.ConnectionString
        {
            get
            {
                return dbConnection.ConnectionString;
            }
        }
        /// <summary>
        /// Connection to the Database.
        /// </summary>
        protected SqlConnection Connection => dbConnection;
        /// <summary>
        /// Used to get the data from the database into tabular form.
        /// </summary>
        /// <param name="query">Query command to fetch the data</param>
        /// <param name="type">Type of the command</param>
        /// <param name="parameters">Parameters if required</param>
        /// <returns>Iterative Dataset</returns>
        protected SqlDataReader GetIteratableData(string query, SQLCommandTypes type, params SqlParameter[] parameters)
        {
            SqlDataReader data;
            if (type == SQLCommandTypes.StoredProcedure)
            {
                SqlCommand command = new SqlCommand(query, dbConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);
                dbConnection.Open();
                try
                {
                    data = command.ExecuteReader();
                }
                catch (SqlException)
                {
                    throw;
                }
                dbConnection.Close();
            }
            else
            {
                SqlCommand command = new SqlCommand(query, dbConnection);
                dbConnection.Open();
                try
                {
                    data = command.ExecuteReader();
                }
                catch (SqlException)
                {
                    throw;
                }
                dbConnection.Close();
            }
            return data;
        }
        /// <summary>
        /// Used to get the data from the database as a single value.
        /// </summary>
        /// <param name="query">Query command to fetch the data</param>
        /// <param name="type">Type of the command</param>
        /// <param name="parameters">Parameters if required</param>
        /// <returns>Single Object Value</returns>
        protected object GetValue(string query, SQLCommandTypes type, params SqlParameter[] parameters)
        {
            object value;
            if (type == SQLCommandTypes.StoredProcedure)
            {
                SqlCommand command = new SqlCommand(query, dbConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);
                dbConnection.Open();
                try
                {
                    value = command.ExecuteScalar();
                }
                catch (SqlException)
                {
                    throw;
                }
                dbConnection.Close();
            }
            else
            {
                SqlCommand command = new SqlCommand(query, dbConnection);
                dbConnection.Open();
                try
                {
                    value = command.ExecuteScalar();
                }
                catch (SqlException)
                {
                    throw;
                }
                dbConnection.Close();
            }
            return value;
        }
        /// <summary>
        /// Used to execute query.
        /// </summary>
        /// <param name="query">Query command to fetch the data</param>
        /// <param name="type">Type of the command</param>
        /// <param name="parameters">Parameters if required</param>
        protected void ExecuteQuery(string query, SQLCommandTypes type, params SqlParameter[] parameters)
        {
            if (type == SQLCommandTypes.StoredProcedure)
            {
                SqlCommand command = new SqlCommand(query, dbConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);
                dbConnection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw;
                }
                dbConnection.Close();
            }
            else
            {
                SqlCommand command = new SqlCommand(query, dbConnection);
                dbConnection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw;
                }
                dbConnection.Close();
            }
        }
        public abstract List<ISQLData> GetAllSQLData();
        public abstract string GetPrimaryKey();
        public abstract Type GetPrimaryKeyType();
        public abstract string GetReferenceString();
        public abstract void InitiateValues();

        public abstract List<object> GetAllData();
        public abstract Type GetObjectType();

        [DataContract]
        public enum SQLCommandTypes
        {
            Query,
            StoredProcedure
        }
    }
}
