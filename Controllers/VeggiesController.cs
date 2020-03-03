using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetReact.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class VeggiesController : ControllerBase
  {
    private readonly ILogger<VeggiesController> _logger;

    public VeggiesController(ILogger<VeggiesController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    [Route("/Veggies/GetVeggies")]
    public VeggiesPayload GetVeggies()
    {

      try
      {
        List<Veggie> veggies = new List<Veggie>();
        veggies.Add(new Veggie(Guid.NewGuid(), "Carrot"));
        veggies.Add(new Veggie(Guid.NewGuid(), "Radish"));

        //throw new Exception("Whoa");
        return new VeggiesPayload(veggies, "", true);
      }
      catch (System.Exception)
      {
        return new VeggiesPayload(new List<Veggie>(), "Server Error!", false);
      }
    }
  }
}

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

public class Veggie
{
  public Guid Id { get; set; }
  public string Name { get; set; }

  public Veggie(Guid id, string name)
  {
    Id = id;
    Name = name;
  }
}
