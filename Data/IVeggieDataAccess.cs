using System;
using DotNetReact.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetReact.Data
{
  public interface IVeggieDataAccess
  {
    Task<List<Veggie>> Get(string sql);
    Task<IVeggie> GetById(Guid id);
    Task<bool> Insert(string sql, IVeggie veggie);
    Task<bool> Update(string sql, IVeggie veggie);
    Task<bool> Delete(string sql, Guid id);
  }
}