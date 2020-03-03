using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetReact.Models;

namespace DotNetReact.Data {
  public interface IVeggieProcessor {
    // Gets all the veggies
    Task<List<Veggie>> Get ();
    Task<Veggie> GetById (Guid id);

    // Validates a veggie's data before insertion
    Veggie Create (string name, double price);

    // Inserts a veggie into the database
    Task<bool> Insert (Veggie veggie);

    //Update a veggie in the database
    Task<bool> Update (Veggie veggie);

    // delete a veggie in the database
    Task<bool> Delete (Guid id);

  }
}