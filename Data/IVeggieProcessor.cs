using System.Collections.Generic;
using DotNetReact.Models;

namespace DotNetReact.Data
{
  public interface IVeggieProcessor
  {
    // Gets all the veggies
    public List<IVeggie> Get();

    // Validates a veggie's data before insertion
    public IVeggie Create(string name, double price);

    // Inserts a veggie into the database
    public bool Insert(IVeggie veggie);
  }
}