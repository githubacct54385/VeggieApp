import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import Error from "./Error";
import VeggieRequests from "../Api/VeggieRequests";
import UpdateVeggieValidation from "../FormValidation/UpdateVeggieValidation";

const UpdateVeggiePage = ({
  match: {
    params: { id }
  }
}) => {
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const [err, setErr] = useState("");

  useEffect(() => {
    // get name and price
    getVeggieForPage();
  }, []);

  const getVeggieForPage = () => {
    if (id === null || id === undefined) {
      setErr("Veggie Id is missing.  Unable to request data.");
    } else {
      const api = new VeggieRequests();
      api.getVeggieById(id).then(data => {
        if (data.success) {
          setName(data.veggie.name);
          setPrice(data.veggie.price);
        } else {
          setErr(data.msg);
        }
      });
    }
  };

  const handleLocalUpdate = e => {
    e.preventDefault();
    setErr("");

    const validationResult = UpdateVeggieValidation(name, price);

    if (validationResult.hasError) {
      setErr(validationResult.err);
    } else {
      // make update request
      const api = new VeggieRequests();
      api.updateVeggie(id, name, price).then(data => {
        if (data.success) {
          // performing redirect this way since
          // React Router DOM redirect was failing
          window.location.href = "/veggies";
        } else {
          setErr(data.msg);
        }
      });
    }
  };

  return (
    <div className="container">
      <Link to="/veggies" className="btn btn-dark m-2">
        All Veggies
      </Link>
      {err.length > 0 && <Error err={err} />}
      <form onSubmit={handleLocalUpdate}>
        <div className="row">
          <input
            type="text"
            name="name"
            value={name}
            placeholder="Veggie Name"
            onChange={e => setName(e.target.value)}
          />
        </div>
        <div className="row">
          <input
            type="text"
            name="price"
            value={price}
            placeholder="Veggie Price"
            onChange={e => setPrice(e.target.value)}
          />
        </div>
        <div className="row">
          <button className="btn btn-primary">Update</button>
        </div>
      </form>
    </div>
  );
};

UpdateVeggiePage.propTypes = {};

export default UpdateVeggiePage;
