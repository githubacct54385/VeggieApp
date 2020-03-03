using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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

    public async Task<IVeggie> GetById (Guid id) {
      throw new NotImplementedException ();
    }

    public async Task<bool> Insert (string sql, IVeggie veggie) {
      throw new NotImplementedException ();
    }

    public async Task<bool> Update (string sql, IVeggie veggie) {
      throw new NotImplementedException ();
    }
  }
}