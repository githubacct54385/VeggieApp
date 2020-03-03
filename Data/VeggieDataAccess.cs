using System;
using System.Collections.Generic;
using DotNetReact.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Threading.Tasks;
using System.Linq;

namespace DotNetReact.Data
{
  public sealed class VeggieDataAccess : IVeggieDataAccess
  {
    public async Task<bool> Delete(string sql, Guid id)
    {
      throw new NotImplementedException();
    }

    public async Task<List<Veggie>> Get(string sql)
    {
      using (SqlConnection conn = new SqlConnection("Connection goes here"))
      {
        IEnumerable<Veggie> rows = await conn.QueryAsync<Veggie>(sql, commandType: CommandType.StoredProcedure);
        return rows.ToList();
      }
    }

    public async Task<IVeggie> GetById(Guid id)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> Insert(string sql, IVeggie veggie)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> Update(string sql, IVeggie veggie)
    {
      throw new NotImplementedException();
    }
  }
}