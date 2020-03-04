using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using DotNetReact.Config;
using DotNetReact.Models;

namespace DotNetReact.Data {
  // Data Access methods implemented 
  public sealed class VeggieDataAccess : IVeggieDataAccess {

    private readonly string _connString;
    public VeggieDataAccess () {
      // inject the connection string from Db.cs
      _connString = Db.ConnectionString ();

    }
    public async Task<bool> Delete (string sql, Guid id) {
      using (TransactionScope scope = new TransactionScope (TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled)) {
        using (SqlConnection conn = new SqlConnection (_connString)) {

          DynamicParameters dynamicParameters = new DynamicParameters ();
          dynamicParameters.Add ("Id", id, DbType.Guid, ParameterDirection.Input);

          int rowsAffected = await conn.ExecuteAsync (sql, dynamicParameters, commandType : CommandType.StoredProcedure);
          if (rowsAffected == 1) {
            // commit this transaction since only one row was deleted
            scope.Complete ();
            return true;
          }
          throw new Exception ("Something went wrong with the delete command.  The command did not return 1 row.");
        }
      }
    }

    public async Task<List<Veggie>> Get (string sql) {
      using (SqlConnection conn = new SqlConnection (_connString)) {
        IEnumerable<Veggie> rows = await conn.QueryAsync<Veggie> (sql, commandType : CommandType.StoredProcedure);
        return rows.ToList ();
      }
    }

    public async Task<Veggie> GetById (string sql, Guid id) {
      using (SqlConnection conn = new SqlConnection (_connString)) {
        DynamicParameters dynamicParameters = new DynamicParameters ();
        dynamicParameters.Add ("Id", id, DbType.Guid, ParameterDirection.Input);
        Veggie thisVeggie = await conn.QueryFirstAsync<Veggie> (sql, dynamicParameters, commandType : CommandType.StoredProcedure);
        return thisVeggie;
      }
    }

    public async Task<bool> Insert (string sql, Veggie veggie) {
      using (TransactionScope scope = new TransactionScope (TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled)) {
        using (SqlConnection conn = new SqlConnection (_connString)) {

          DynamicParameters dynamicParameters = new DynamicParameters ();
          dynamicParameters.Add ("Id", veggie.Id, DbType.Guid, ParameterDirection.Input);
          dynamicParameters.Add ("Name", veggie.Name, DbType.String, ParameterDirection.Input);
          dynamicParameters.Add ("Price", veggie.Price, DbType.Decimal, ParameterDirection.Input);

          int rowsAffected = await conn.ExecuteAsync (sql, dynamicParameters, commandType : CommandType.StoredProcedure);
          if (rowsAffected == 1) {
            // commit this transaction since only one row was added
            scope.Complete ();
            return true;
          }
          throw new Exception ("Something went wrong with the Insert command.  The command did not return 1 row.");
        }
      }
    }

    public async Task<bool> Update (string sql, Veggie veggie) {
      using (TransactionScope scope = new TransactionScope (TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled)) {
        using (SqlConnection conn = new SqlConnection (_connString)) {

          DynamicParameters dynamicParameters = new DynamicParameters ();
          dynamicParameters.Add ("Id", veggie.Id, DbType.Guid, ParameterDirection.Input);
          dynamicParameters.Add ("Name", veggie.Name, DbType.String, ParameterDirection.Input);
          dynamicParameters.Add ("Price", veggie.Price, DbType.Decimal, ParameterDirection.Input);

          int rowsAffected = await conn.ExecuteAsync (sql, dynamicParameters, commandType : CommandType.StoredProcedure);
          if (rowsAffected == 1) {
            // commit this transaction since only one row was updated
            scope.Complete ();
            return true;
          }
          throw new Exception ("Something went wrong with the Update command.  The command did not return 1 row.");
        }

      }
    }
  }
}