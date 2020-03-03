using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetReact.Models;

namespace DotNetReact.Data {
  public interface IVeggieDataAccess {
    Task<List<Veggie>> Get (string sql);
    Task<Veggie> GetById (string sql, Guid id);
    Task<bool> Insert (string sql, Veggie veggie);
    Task<bool> Update (string sql, Veggie veggie);
    Task<bool> Delete (string sql, Guid id);
  }
}