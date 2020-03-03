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
      } catch (System.Exception) {
        return new VeggiesPayload (new List<Veggie> (), "Server Error!  Did you check the connection string?", false);
      }
    }

    [HttpGet]
    [Route ("/Veggies/GetVeggieById")]
    public async Task<SingleVeggiePayload> GetVeggieById (Guid id) {
      try {
        Veggie foundVeggie = await _veggieProcessor.GetById (id);
        if (foundVeggie != null) {
          return new SingleVeggiePayload (foundVeggie, true, "");
        } else {
          return new SingleVeggiePayload (null, false, "Failed to find the Veggie in the database with the Id.  This is odd...");

        }
      } catch (System.Exception) {
        return new SingleVeggiePayload (null, false, "Server Error!  Did you check the connection string.");
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

      } catch (System.Exception) {
        return new CreateVeggiePayload (false, "Server Error!  Did you check your connection string?");
      }
    }

    [HttpPut]
    [Route ("/Veggies/UpdateVeggie")]
    public async Task<CreateVeggiePayload> UpdateVeggie ([FromBody] UpdateVeggieParams payload) {
      try {

        if (payload.Id == Guid.Empty) {
          throw new Exception ("Payload Id is empty.");
        }
        // find this veggie
        Veggie foundVeggie = await _veggieProcessor.GetById (payload.Id);
        if (foundVeggie == null) {
          throw new Exception ($"Unable to find Veggie by Id {payload.Id}");
        }

        // update the name and price
        foundVeggie.Name = payload.Name;
        foundVeggie.Price = Convert.ToDouble (payload.Price);

        // update it
        bool inserted = await _veggieProcessor.Update (foundVeggie);
        if (inserted) {
          return new CreateVeggiePayload (true, "");
        }
        return new CreateVeggiePayload (false, "Update failed at the Data Access layer.");

      } catch (System.Exception) {
        return new CreateVeggiePayload (false, "Server Error! Did you check your connection string?");
      }
    }

    [HttpDelete]
    [Route ("/Veggies/DeleteVeggie")]
    public async Task<CreateVeggiePayload> DeleteVeggie ([FromBody] DeleteVeggieParams payload) {
      try {
        if (payload.Id == Guid.Empty) {
          throw new Exception ("Delete Id was an empty Guid.");
        }
        bool deleted = await _veggieProcessor.Delete (payload.Id);
        if (deleted) {
          return new CreateVeggiePayload (true, "");
        }
        return new CreateVeggiePayload (false, "Delete failed at the Data Access layer.");
      } catch (System.Exception) {
        return new CreateVeggiePayload (false, "Server Error! Did you check your connection string?");
      }
    }

  }

  public class DeleteVeggieParams {
    public Guid Id { get; set; }
    public DeleteVeggieParams () {

    }
  }

  public class CreateVeggieParams {
    public string Name { get; set; }
    public string Price { get; set; }

    public CreateVeggieParams () {

    }
  }

  public class UpdateVeggieParams {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }

    public UpdateVeggieParams () {

    }
  }

}