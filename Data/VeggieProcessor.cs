using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetReact.Models;

namespace DotNetReact.Data {

  public class VeggieProcessor : IVeggieProcessor {
    private readonly IVeggieDataAccess _dataAccess;
    public VeggieProcessor () {
      // inject the data access class
      // I do this because I may want to do TDD on this
      // at a later date and not have to deal with real data
      _dataAccess = new VeggieDataAccess ();
    }

    public Veggie Create (string name, double price) {
      // just in case the front end react didn't get everything validated
      // let's make sure all the inputs are good
      if (string.IsNullOrEmpty (name)) {
        throw new ArgumentException ("Argument name for class Veggie cannot be null or empty.", nameof (name));
      }

      if (price <= 0) {
        throw new ArgumentException ("Argument price for class Veggie cannot be less than or equal to zero.", nameof (price));
      }

      // return a valid veggie
      // no need to validate the Guid because Microsoft tested it for me :)
      return new Veggie (Guid.NewGuid (), name, price);
    }

    public async Task<List<Veggie>> Get () {
      const string sql = "SP_GetVeggies";
      return await _dataAccess.Get (sql);
    }

    public async Task<Veggie> GetById (Guid id) {
      const string sql = "SP_GetVeggieById";
      return await _dataAccess.GetById (sql, id);
    }

    public async Task<bool> Insert (Veggie veggie) {
      const string sql = "SP_InsertVeggie";
      return await _dataAccess.Insert (sql, veggie);
    }

    public async Task<bool> Update (Veggie veggie) {
      const string sql = "SP_UpdateVeggie";
      return await _dataAccess.Update (sql, veggie);
    }

    public async Task<bool> Delete (Guid id) {
      const string sql = "SP_DeleteVeggie";
      return await _dataAccess.Delete (sql, id);
    }
  }
}