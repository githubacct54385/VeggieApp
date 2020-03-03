using System;
using System.Collections.Generic;
using DotNetReact.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotNetReact.Data;

namespace DotNetReact.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class VeggiesController : ControllerBase
  {
    private readonly ILogger<VeggiesController> _logger;
    private readonly IVeggieProcessor _veggieProcessor;

    public VeggiesController(ILogger<VeggiesController> logger, IVeggieProcessor processor)
    {
      _logger = logger;
      _veggieProcessor = processor;
    }

    [HttpGet]
    [Route("/Veggies/GetVeggies")]
    public VeggiesPayload GetVeggies()
    {

      try
      {
        List<Veggie> veggies = new List<Veggie>();
        veggies.Add(new Veggie(Guid.NewGuid(), "Carrot", 3.50));
        veggies.Add(new Veggie(Guid.NewGuid(), "Radish", 2.20));

        return new VeggiesPayload(veggies, "", true);
      }
      catch (System.Exception)
      {
        return new VeggiesPayload(new List<Veggie>(), "Server Error!", false);
      }
    }
  }
}