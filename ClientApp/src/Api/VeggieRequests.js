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
        .catch(err => resolve({ veggies: [], error: err, success: false }));
    });
  };

  addVeggie = (name, price) => {
    console.log(typeof name, Number(price));
    const payload = { Name: name, Price: price };
    return new Promise(resolve => {
      const body = JSON.stringify(payload);
      console.log(body);
      const config = {
        headers: {
          "Content-Type": "application/json"
        }
      };
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
      //resolve();
      // axios
      //   .post("/Veggies/CreateVeggie", body, config)
      //   .then(res => {
      //     const { data } = res;
      //     resolve(data);
      //   })
      //   .catch(err => resolve({ success: false, msg: err }));
    });
  };
}
