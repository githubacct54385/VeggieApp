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
