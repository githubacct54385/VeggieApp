using System;

namespace DotNetReact.Models
{
  public interface IVeggie
  {
    Guid Id { get; set; }
    string Name { get; set; }
    double Price { get; set; }
  }
}