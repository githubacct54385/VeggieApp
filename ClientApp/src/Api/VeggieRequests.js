import axios from "axios";

export default class VeggieRequests {
  constructor() {}

  getVeggies = () => {
    return new Promise(resolve => {
      axios
        .get("/Veggies/GetVeggies")
        .then(res => {
          const { data } = res;
          resolve(data);
        })
        .catch(err => resolve({ veggies: [], error: err, success: false }));
    });
  };
}
