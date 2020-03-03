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
  public sealed class VeggieDataAccess : IVeggieDataAccess {

    private readonly string _connString;
    public VeggieDataAccess () {
      _connString = Db.ConnectionString ();

    }
    public async Task<bool> Delete (string sql, Guid id) {
      throw new NotImplementedException ();
    }

    public async Task<List<Veggie>> Get (string sql) {
      using (SqlConnection conn = new SqlConnection (_connString)) {
        IEnumerable<Veggie> rows = await conn.QueryAsync<Veggie> (sql, commandType : CommandType.StoredProcedure);
        return rows.ToList ();
      }
    }

    public async Task<Veggie> GetById (Guid id) {
      throw new NotImplementedException ();
    }

    public async Task<bool> Insert (string sql, Veggie veggie) {
      using (TransactionScope scope = new TransactionScope (TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled)) {
        using (SqlConnection conn = new SqlConnection (_connString)) {

          DynamicParameters dynamicParameters = new DynamicParameters ();
          dynamicParameters.Add ("Id", Guid.NewGuid (), DbType.Guid, ParameterDirection.Input);
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
      throw new NotImplementedException ();
    }
  }
}