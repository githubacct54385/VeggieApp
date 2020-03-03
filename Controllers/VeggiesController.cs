﻿using System;
using System.Collections.Generic;
using DotNetReact.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotNetReact.Data;
using System.Threading.Tasks;

namespace DotNetReact.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class VeggiesController : ControllerBase
  {
    private readonly IVeggieProcessor _veggieProcessor;

    public VeggiesController()
    {
      _veggieProcessor = new VeggieProcessor();
    }

    [HttpGet]
    [Route("/Veggies/GetVeggies")]
    public async Task<VeggiesPayload> GetVeggies()
    {
      try
      {
        List<Veggie> veggies = await _veggieProcessor.Get();
        return new VeggiesPayload(veggies, "", true);
      }
      catch (System.Exception)
      {
        return new VeggiesPayload(new List<Veggie>(), "Server Error!", false);
      }
    }
  }
}