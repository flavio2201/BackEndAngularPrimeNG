using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Repository.Repositories
{
    public abstract class BaseRepository
    {

        private IDbTransaction Transaction { get; set; }
        private IDbConnection Connection { get { return Transaction.Connection; } }

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseRepository(IDbTransaction transaction)
        {
            Transaction = transaction;
        }

        #region Execute by Dapper Contrib
        //
        // Summary:
        //     Delete entity in table "Ts".
        //
        // Parameters:
        //   connection:
        //     Open SqlConnection
        //
        //   entityToDelete:
        //     Entity to delete
        //
        //   transaction:
        //     The transaction to run under, null (the default) if none
        //
        //   commandTimeout:
        //     Number of seconds before command execution timeout
        //
        // Type parameters:
        //   T:
        //     Type of entity
        //
        // Returns:
        //     true if deleted, false if not found
        public bool Delete<T>(T entityToDelete) where T : class
        {
            return Connection.Delete<T>(entityToDelete, transaction: Transaction);
        }

        //
        // Summary:
        //     Delete all entities in the table related to the type T.
        //
        // Parameters:
        //   connection:
        //     Open SqlConnection
        //
        //   transaction:
        //     The transaction to run under, null (the default) if none
        //
        //   commandTimeout:
        //     Number of seconds before command execution timeout
        //
        // Type parameters:
        //   T:
        //     Type of entity
        //
        // Returns:
        //     true if deleted, false if none found
        public bool DeleteAll<T>() where T : class
        {
            return Connection.DeleteAll<T>(transaction: Transaction);
        }

        //
        // Summary:
        //     Delete all entities in the table related to the type T asynchronously using .NET
        //     4.5 Task.
        //
        // Parameters:
        //   connection:
        //     Open SqlConnection
        //
        //   transaction:
        //     The transaction to run under, null (the default) if none
        //
        //   commandTimeout:
        //     Number of seconds before command execution timeout
        //
        // Type parameters:
        //   T:
        //     Type of entity
        //
        // Returns:
        //     true if deleted, false if none found        
        public Task<bool> DeleteAllAsync<T>() where T : class
        {
            return Connection.DeleteAllAsync<T>(transaction: Transaction);
        }

        //
        // Summary:
        //     Delete entity in table "Ts" asynchronously using .NET 4.5 Task.
        //
        // Parameters:
        //   connection:
        //     Open SqlConnection
        //
        //   entityToDelete:
        //     Entity to delete
        //
        //   transaction:
        //     The transaction to run under, null (the default) if none
        //
        //   commandTimeout:
        //     Number of seconds before command execution timeout
        //
        // Type parameters:
        //   T:
        //     Type of entity
        //
        // Returns:
        //     true if deleted, false if not found
        public Task<bool> DeleteAsync<T>(T entityToDelete) where T : class
        {
            return Connection.DeleteAsync<T>(entityToDelete, transaction: Transaction);
        }

        //
        // Summary:
        //     Returns a single entity by a single id from table "Ts". Id must be marked with
        //     [Key] attribute. Entities created from interfaces are tracked/intercepted for
        //     changes and used by the Update() extension for optimal performance.
        //
        // Parameters:
        //   connection:
        //     Open SqlConnection
        //
        //   id:
        //     Id of the entity to get, must be marked with [Key] attribute
        //
        //   transaction:
        //     The transaction to run under, null (the default) if none
        //
        //   commandTimeout:
        //     Number of seconds before command execution timeout
        //
        // Type parameters:
        //   T:
        //     Interface or type to create and populate
        //
        // Returns:
        //     Entity of T
        public T Get<T>(int id) where T : class
        {
            return Connection.Get<T>(id, transaction: Transaction);
        }

        //
        // Summary:
        //     Returns a list of entites from table "Ts". Id of T must be marked with [Key]
        //     attribute. Entities created from interfaces are tracked/intercepted for changes
        //     and used by the Update() extension for optimal performance.
        //
        // Parameters:
        //   connection:
        //     Open SqlConnection
        //
        //   transaction:
        //     The transaction to run under, null (the default) if none
        //
        //   commandTimeout:
        //     Number of seconds before command execution timeout
        //
        // Type parameters:
        //   T:
        //     Interface or type to create and populate
        //
        // Returns:
        //     Entity of T
        public IEnumerable<T> GetAll<T>() where T : class
        {
            return Connection.GetAll<T>(transaction: Transaction);
        }

        //
        // Summary:
        //     Returns a list of entites from table "Ts". Id of T must be marked with [Key]
        //     attribute. Entities created from interfaces are tracked/intercepted for changes
        //     and used by the Update() extension for optimal performance.
        //
        // Parameters:
        //   connection:
        //     Open SqlConnection
        //
        //   transaction:
        //     The transaction to run under, null (the default) if none
        //
        //   commandTimeout:
        //     Number of seconds before command execution timeout
        //
        // Type parameters:
        //   T:
        //     Interface or type to create and populate
        //
        // Returns:
        //     Entity of T
        public Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            return Connection.GetAllAsync<T>(transaction: Transaction);
        }

        //
        // Summary:
        //     Returns a single entity by a single id from table "Ts" asynchronously using .NET
        //     4.5 Task. T must be of interface type. Id must be marked with [Key] attribute.
        //     Created entity is tracked/intercepted for changes and used by the Update() extension.
        //
        // Parameters:
        //   connection:
        //     Open SqlConnection
        //
        //   id:
        //     Id of the entity to get, must be marked with [Key] attribute
        //
        //   transaction:
        //     The transaction to run under, null (the default) if none
        //
        //   commandTimeout:
        //     Number of seconds before command execution timeout
        //
        // Type parameters:
        //   T:
        //     Interface type to create and populate
        //
        // Returns:
        //     Entity of T
        public Task<T> GetAsync<T>(int id) where T : class
        {
            return Connection.GetAsync<T>(id, transaction: Transaction);
        }

        //
        // Summary:
        //     Inserts an entity into table "Ts" and returns identity id or number of inserted
        //     rows if inserting a list.
        //
        // Parameters:
        //   connection:
        //     Open SqlConnection
        //
        //   entityToInsert:
        //     Entity to insert, can be list of entities
        //
        //   transaction:
        //     The transaction to run under, null (the default) if none
        //
        //   commandTimeout:
        //     Number of seconds before command execution timeout
        //
        // Type parameters:
        //   T:
        //     The type to insert.
        //
        // Returns:
        //     Identity of inserted entity, or number of inserted rows if inserting a list
        public int Insert<T>(T entityToInsert) where T : class
        {
            return (int)Connection.Insert<T>(entityToInsert, transaction: Transaction);
        }

        //
        // Summary:
        //     Inserts an entity into table "Ts" asynchronously using .NET 4.5 Task and returns
        //     identity id.
        //
        // Parameters:
        //   connection:
        //     Open SqlConnection
        //
        //   entityToInsert:
        //     Entity to insert
        //
        //   transaction:
        //     The transaction to run under, null (the default) if none
        //
        //   commandTimeout:
        //     Number of seconds before command execution timeout
        //
        //   sqlAdapter:
        //     The specific ISqlAdapter to use, auto-detected based on connection if null
        //
        // Type parameters:
        //   T:
        //     The type being inserted.
        //
        // Returns:
        //     Identity of inserted entity
        public Task<int> InsertAsync<T>(T entityToInsert) where T : class
        {
            return Connection.InsertAsync<T>(entityToInsert, transaction: Transaction);
        }

        //
        // Summary:
        //     Updates entity in table "Ts", checks if the entity is modified if the entity
        //     is tracked by the Get() extension.
        //
        // Parameters:
        //   connection:
        //     Open SqlConnection
        //
        //   entityToUpdate:
        //     Entity to be updated
        //
        //   transaction:
        //     The transaction to run under, null (the default) if none
        //
        //   commandTimeout:
        //     Number of seconds before command execution timeout
        //
        // Type parameters:
        //   T:
        //     Type to be updated
        //
        // Returns:
        //     true if updated, false if not found or not modified (tracked entities)
        public bool Update<T>(T entityToUpdate) where T : class
        {
            return Connection.Update<T>(entityToUpdate, transaction: Transaction);
        }

        //
        // Summary:
        //     Updates entity in table "Ts" asynchronously using .NET 4.5 Task, checks if the
        //     entity is modified if the entity is tracked by the Get() extension.
        //
        // Parameters:
        //   connection:
        //     Open SqlConnection
        //
        //   entityToUpdate:
        //     Entity to be updated
        //
        //   transaction:
        //     The transaction to run under, null (the default) if none
        //
        //   commandTimeout:
        //     Number of seconds before command execution timeout
        //
        // Type parameters:
        //   T:
        //     Type to be updated
        //
        // Returns:
        //     true if updated, false if not found or not modified (tracked entities)        
        public Task<bool> UpdateAsync<T>(T entityToUpdate) where T : class
        {
            return Connection.UpdateAsync<T>(entityToUpdate, transaction: Transaction);
        }

        #endregion

        #region Execute by CommandTypes Text, TableDirect, Procedure (default)
        /// <summary>
        /// Execute parameterized SQL, returning the Number of rows affected.
        /// </summary>
        protected int Execute(string proc, DynamicParameters vParams = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return Connection.Execute(proc, vParams, commandType: commandType, transaction: Transaction);
        }

        /// <summary>
        /// Execute parameterized SQL that selects a single value, returning the first cell selected.
        /// </summary>
        protected int ExecuteScalar(string proc, DynamicParameters vParams = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return Connection.ExecuteScalar<int>(proc, vParams, commandType: commandType, transaction: Transaction);
        }

        /// <summary>
        /// Execute parameterized SQL that selects a single value, returning the first cell selected.
        /// </summary>
        protected string ExecuteScalarString(string proc, DynamicParameters vParams = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return Connection.ExecuteScalar<string>(proc, vParams, commandType: commandType, transaction: Transaction);
        }

        /// <summary>
        ///     Executes a query, returning the data typed as per T
        /// </summary>
        protected IEnumerable<T> Query<T>(string proc, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return this.Connection.Query<T>(proc, param, Transaction, true, commandType: commandType);
        }

        /// <summary>
        /// Perform a multi mapping query with arbitrary input parameters
        /// </summary>
        protected IEnumerable<T> Query<T>(string proc, Type[] types, Func<object[], T> map, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return this.Connection.Query<T>(proc, types, map, param, Transaction, true, "Id", commandType: commandType);
        }

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn
        /// </summary>
        protected GridReader QueryMultiple(string proc, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return this.Connection.QueryMultiple(proc, param, Transaction, commandType: commandType);
        }

        /// <summary>
        ///     Maps a query to objects
        ///
        /// Parameters:
        ///   cnn:
        ///
        ///   sql:
        ///
        ///   map:
        ///
        ///   param:
        ///
        ///   transaction:
        ///
        ///   buffered:
        ///
        ///   splitOn:
        ///     The Field we should split and read the second object from (default: id)
        ///
        ///   commandTimeout:
        ///     Number of seconds before command execution timeout
        ///
        ///   commandType:
        ///
        /// Type parameters:
        ///   TFirst:
        ///
        ///   TSecond:
        ///
        ///   TThird:
        ///
        ///   TFourth:
        ///   
        ///   TFifth:
        ///
        ///   TReturn:
        /// </summary>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string proc, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return this.Connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(proc, map, param, Transaction, commandType: commandType);
        }

        /// <summary>
        ///     Maps a query to objects
        ///
        /// Parameters:
        ///   cnn:
        ///
        ///   sql:
        ///
        ///   map:
        ///
        ///   param:
        ///
        ///   transaction:
        ///
        ///   buffered:
        ///
        ///   splitOn:
        ///     The Field we should split and read the second object from (default: id)
        ///
        ///   commandTimeout:
        ///     Number of seconds before command execution timeout
        ///
        ///   commandType:
        ///
        /// Type parameters:
        ///   TFirst:
        ///
        ///   TSecond:
        ///
        ///   TThird:
        ///
        ///   TFourth:
        ///   
        ///   TFifth:
        ///
        ///   TSixth
        /// 
        ///   TReturn:
        /// </summary>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string proc, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return this.Connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(proc, map, param, Transaction, commandType: commandType);
        }

        /// <summary>
        ///     Maps a query to objects
        ///
        /// Parameters:
        ///   cnn:
        ///
        ///   sql:
        ///
        ///   map:
        ///
        ///   param:
        ///
        ///   transaction:
        ///
        ///   buffered:
        ///
        ///   splitOn:
        ///     The Field we should split and read the second object from (default: id)
        ///
        ///   commandTimeout:
        ///     Number of seconds before command execution timeout
        ///
        ///   commandType:
        ///
        /// Type parameters:
        ///   TFirst:
        ///
        ///   TSecond:
        ///
        ///   TThird:
        ///
        ///   TFourth:
        ///   
        ///   TFifth:
        ///
        ///   TSixth
        ///   
        ///   TSeventh
        /// 
        ///   TReturn:
        /// </summary>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string proc, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return this.Connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(proc, map, param, Transaction, commandType: commandType);
        }

        /// <summary>
        ///     Maps a query to objects
        ///
        /// Parameters:
        ///   cnn:
        ///
        ///   sql:
        ///
        ///   map:
        ///
        ///   param:
        ///
        ///   transaction:
        ///
        ///   buffered:
        ///
        ///   splitOn:
        ///     The Field we should split and read the second object from (default: id)
        ///
        ///   commandTimeout:
        ///     Number of seconds before command execution timeout
        ///
        ///   commandType:
        ///
        /// Type parameters:
        ///   TFirst:
        ///
        ///   TSecond:
        ///
        ///   TThird:
        ///
        ///   TFourth:
        ///
        ///   TReturn:
        /// </summary>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string proc, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return this.Connection.Query<TFirst, TSecond, TThird, TFourth, TReturn>(proc, map, param, Transaction, commandType: commandType);
        }

        /// <summary>
        ///     Maps a query to objects
        ///
        /// Parameters:
        ///   cnn:
        ///
        ///   sql:
        ///
        ///   map:
        ///
        ///   param:
        ///
        ///   transaction:
        ///
        ///   buffered:
        ///
        ///   splitOn:
        ///     The Field we should split and read the second object from (default: id)
        ///
        ///   commandTimeout:
        ///     Number of seconds before command execution timeout
        ///
        ///   commandType:
        ///
        /// Type parameters:
        ///   TFirst:
        ///
        ///   TSecond:
        ///
        ///   TThird:
        ///
        ///   TReturn:
        /// </summary>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string proc, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return this.Connection.Query<TFirst, TSecond, TThird, TReturn>(proc, map, param, Transaction, commandType: commandType);
        }

        /// <summary>
        ///     Maps a query to objects
        ///
        /// Parameters:
        ///   cnn:
        ///
        ///   sql:
        ///
        ///   map:
        ///
        ///   param:
        ///
        ///   transaction:
        ///
        ///   buffered:
        ///
        ///   splitOn:
        ///     The Field we should split and read the second object from (default: id)
        ///
        ///   commandTimeout:
        ///     Number of seconds before command execution timeout
        ///
        ///   commandType:
        ///
        /// Type parameters:
        ///   TFirst:
        ///
        ///   TSecond:
        ///
        ///   TReturn:
        /// </summary>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string proc, Func<TFirst, TSecond, TReturn> map, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return this.Connection.Query<TFirst, TSecond, TReturn>(proc, map, param, Transaction, commandType: commandType);
        }        
        #endregion
    }
}
