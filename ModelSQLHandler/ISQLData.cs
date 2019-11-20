using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ModelSQLHandler
{
    /// <summary>
    /// Interface for SQL Data
    /// </summary>
    public interface ISQLData
    {
        /// <summary>
        /// Initiates the values from database to a class which implements this interface.
        /// Most appropritate use is to use inside a constructor.
        /// </summary>
        void InitiateValues();
        /// <summary>
        /// Returns a text which is associated with the class or describe its features, like: name, etc.
        /// </summary>
        /// <returns></returns>
        string GetReferenceString();
        /// <summary>
        /// Returns the primary key of any data loaded into the class.
        /// </summary>
        /// <returns></returns>
        string GetPrimaryKey();
        /// <summary>
        /// Returns the primary key type, like: int, long, string, etc.
        /// </summary>
        /// <returns></returns>
        Type GetPrimaryKeyType();
        /// <summary>
        /// Returns a list of whole data present in the database which can be loaded into the calling class.
        /// </summary>
        /// <returns></returns>
        List<ISQLData> GetAllSQLData();
        /// <summary>
        /// Returns a list of whole data present in the database which can be loaded into the calling class.
        /// </summary>
        /// <returns></returns>
        List<object> GetAllData();
        /// <summary>
        /// Connection String to the Database.
        /// </summary>
        string ConnectionString { get; }
        /// <summary>
        /// Returns the type of the object
        /// </summary>
        /// <returns></returns>
        Type GetObjectType();
    }
}
