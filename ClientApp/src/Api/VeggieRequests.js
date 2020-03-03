import axios from "axios";

export default class VeggieRequests {
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
