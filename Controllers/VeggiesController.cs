using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetReact.Data;
using DotNetReact.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetReact.Controllers {
  // Class:   VeggiesController
  // Use:     This contains all API methods for veggies and communicates
  //          with the SQL server
  // Notes:   This controller uses dependency injection.  The VeggieProcessor
  //          is injected into this app to perform database actions.
  //          All API endpoints are here:
  //          GetVeggies()
  //          GetVeggieById(Guid)
  //          CreateVeggie(CreateVeggieParams)
  //          UpdateVeggie(UpdateVeggieParams)
  //          DeleteVeggie(DeleteVeggieParams)

  [ApiController]
  [Route ("[controller]")]
  public class VeggiesController : ControllerBase {
    private readonly IVeggieProcessor _veggieProcessor;

    public VeggiesController () {
      // injected dependency for db actions
      _veggieProcessor = new VeggieProcessor ();
    }

    // Get all veggies
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

    // Get veggie by Id.
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

    // Create a brand new veggie
    [HttpPost]
    [Route ("/Veggies/CreateVeggie")]
    public async Task<CreateVeggiePayload> CreateVeggie ([FromBody] CreateVeggieParams payload) {
      try {
        // create method does server validation of from body arguments
        // if doesn't pass, an exception is thrown
        Veggie createdVeggie = _veggieProcessor.Create (payload.Name, Convert.ToDouble (payload.Price));

        // inserts into the db
        bool inserted = await _veggieProcessor.Insert (createdVeggie);
        if (inserted) {
          return new CreateVeggiePayload (true, "");
        }
        return new CreateVeggiePayload (false, "Insert Veggie failed at the Data Access layer.");

      } catch (System.Exception) {
        return new CreateVeggiePayload (false, "Server Error!  Did you check your connection string?");
      }
    }

    // Updates a veggie
    [HttpPut]
    [Route ("/Veggies/UpdateVeggie")]
    public async Task<CreateVeggiePayload> UpdateVeggie ([FromBody] UpdateVeggieParams payload) {
      try {
        // validate Id
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

    // Delete a veggie by Id
    [HttpDelete]
    [Route ("/Veggies/DeleteVeggie")]
    public async Task<CreateVeggiePayload> DeleteVeggie ([FromBody] DeleteVeggieParams payload) {
      try {
        // check the Id from the request body
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

  // All HTTP payloads
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