using System;
using DotNetReact.Models;
using System.Collections.Generic;

namespace DotNetReact.Data
{
  public interface IVeggieDataAccess
  {
    List<IVeggie> Get(string sql);
    IVeggie GetById(Guid id);
    bool Insert(string sql, IVeggie veggie);
    bool Update(string sql, IVeggie veggie);
    bool Delete(string sql, Guid id);
  }
}