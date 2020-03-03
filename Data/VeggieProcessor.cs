using System.Collections.Generic;
using DotNetReact.Models;
using System;
using System.Threading.Tasks;

namespace DotNetReact.Data
{

  public class VeggieProcessor : IVeggieProcessor
  {
    private readonly IVeggieDataAccess _dataAccess;
    public VeggieProcessor()
    {
      _dataAccess = new VeggieDataAccess();
    }


    public IVeggie Create(string name, double price)
    {
      // just in case the front end react didn't get everything validated
      // let's make sure all the inputs are good
      if (string.IsNullOrEmpty(name))
      {
        throw new ArgumentException("Argument name for class Veggie cannot be null or empty.", nameof(name));
      }

      if (price <= 0)
      {
        throw new ArgumentException("Argument price for class Veggie cannot be less than or equal to zero.", nameof(price));
      }

      // return a valid veggie
      // no need to validate the Guid because Microsoft tested it for me :)
      return new Veggie(Guid.NewGuid(), name, price);
    }

    public async Task<List<Veggie>> Get()
    {
      const string sql = "SP_GetVeggies";
      return await _dataAccess.Get(sql);
    }

    public bool Insert(IVeggie veggie)
    {
      throw new System.NotImplementedException();
    }
  }
}