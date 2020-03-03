using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetReact.Data;
using DotNetReact.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetReact.Controllers {
  [ApiController]
  [Route ("[controller]")]
  public class VeggiesController : ControllerBase {
    private readonly IVeggieProcessor _veggieProcessor;

    public VeggiesController () {
      _veggieProcessor = new VeggieProcessor ();
    }

    [HttpGet]
    [Route ("/Veggies/GetVeggies")]
    public async Task<VeggiesPayload> GetVeggies () {
      try {
        List<Veggie> veggies = await _veggieProcessor.Get ();
        return new VeggiesPayload (veggies, "", true);
      } catch (System.Exception ex) {
        return new VeggiesPayload (new List<Veggie> (), "Server Error!  Did you check the connection string?", false);
      }
    }

    [HttpPost]
    [Route ("/Veggies/CreateVeggie")]
    public async Task<CreateVeggiePayload> CreateVeggie ([FromBody] CreateVeggieParams payload) {
      try {
        Veggie createdVeggie = _veggieProcessor.Create (payload.Name, Convert.ToDouble (payload.Price));
        bool inserted = await _veggieProcessor.Insert (createdVeggie);
        if (inserted) {
          return new CreateVeggiePayload (true, "");
        }
        return new CreateVeggiePayload (false, "Insert Veggie failed at the Data Access layer.");

      } catch (System.Exception ex) {
        return new CreateVeggiePayload (false, $"Server Error! {payload.Name}, {payload.Price}  Did you check your connection string?");
      }
    }
  }

  public class CreateVeggieParams {
    public string Name { get; set; }
    public string Price { get; set; }

    public CreateVeggieParams () {

    }
  }

}