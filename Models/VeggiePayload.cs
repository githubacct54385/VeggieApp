using System.Collections.Generic;
using DotNetReact.Models;

namespace DotNetReact.Models
{
  public class VeggiesPayload
  {
    public List<Veggie> Veggies { get; set; }
    public string Error { get; set; }
    public bool Success { get; set; }

    public VeggiesPayload(List<Veggie> veggies, string error, bool success)
    {
      Veggies = veggies;
      Error = error;
      Success = success;
    }
  }
}