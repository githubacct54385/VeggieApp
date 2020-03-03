using System;
namespace DotNetReact.Models {
  public class Veggie : IVeggie {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Veggie () {

    }

    public Veggie (Guid id, string name, double price) {
      Id = id;
      Name = name;
      Price = price;
    }
  }
}