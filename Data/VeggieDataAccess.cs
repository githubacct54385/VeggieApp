using System;
using System.Collections.Generic;
using DotNetReact.Models;

namespace DotNetReact.Data
{
  public sealed class VeggieDataAccess : IVeggieDataAccess
  {
    public bool Delete(string sql, Guid id)
    {
      throw new NotImplementedException();
    }

    public List<IVeggie> Get(string sql)
    {
      throw new NotImplementedException();
    }

    public IVeggie GetById(Guid id)
    {
      throw new NotImplementedException();
    }

    public bool Insert(string sql, IVeggie veggie)
    {
      throw new NotImplementedException();
    }

    public bool Update(string sql, IVeggie veggie)
    {
      throw new NotImplementedException();
    }
  }
}