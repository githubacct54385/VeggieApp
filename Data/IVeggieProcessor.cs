using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetReact.Models;

namespace DotNetReact.Data {
  public interface IVeggieProcessor {
    // Gets all the veggies
    public Task<List<Veggie>> Get ();

    // Validates a veggie's data before insertion
    public Veggie Create (string name, double price);

    // Inserts a veggie into the database
    public Task<bool> Insert (Veggie veggie);
  }
}