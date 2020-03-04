import axios from "axios";

// Class:   VeggieRequests
// Purpose: Make requests to the backend api
// Notes:   All required API routes are listed here
//          I usually prefer Promises to async/await
//          but can also do this with async/await
export default class VeggieRequests {
  // get all veggies
  getVeggies = () => {
    return new Promise(resolve => {
      axios
        .get("/Veggies/GetVeggies")
        .then(res => {
          const { data } = res;
          resolve(data);
        })
        .catch(err => resolve({ veggies: [], msg: err, success: false }));
    });
  };

  // get veggie by id
  getVeggieById = veggieId => {
    return new Promise(resolve => {
      axios
        .get(`/Veggies/GetVeggieById?id=${veggieId}`)
        .then(res => {
          const { data } = res;
          resolve(data);
        })
        .catch(err =>
          resolve({ id: "", name: "", price: "", msg: err, success: false })
        );
    });
  };

  // update veggie using the id, name, and price
  updateVeggie = (veggieId, name, price) => {
    return new Promise(resolve => {
      axios({
        url: "/Veggies/UpdateVeggie",
        method: "put",
        data: {
          Id: veggieId,
          Name: name,
          Price: `${price}`
        }
      })
        .then(res => {
          const { data } = res;
          resolve(data);
        })
        .catch(err => resolve({ success: false, msg: err }));
    });
  };

  // delete veggie using the id
  deleteVeggie = veggieId => {
    return new Promise(resolve => {
      axios({
        url: "/Veggies/DeleteVeggie",
        method: "DELETE",
        data: {
          Id: veggieId
        }
      })
        .then(res => {
          const { data } = res;
          resolve(data);
        })
        .catch(err => resolve({ success: false, msg: err }));
    });
  };

  // insert (add) veggie name and price
  // Guid is provided by the backend
  addVeggie = (name, price) => {
    return new Promise(resolve => {
      axios({
        url: "/Veggies/CreateVeggie",
        method: "POST",
        data: {
          Name: name,
          Price: `${price}`
        }
      })
        .then(res => {
          const { data } = res;
          resolve(data);
        })
        .catch(err => resolve({ success: false, msg: err }));
    });
  };
}
