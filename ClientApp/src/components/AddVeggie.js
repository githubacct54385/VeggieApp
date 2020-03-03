import React, { Fragment, useState } from "react";
import AddVeggieValidation from "../FormValidation/AddVeggieValidation";
import Error from "./Error";

const AddVeggie = () => {
  const [formData, setFormData] = useState({ veggieName: "", veggiePrice: "" });
  const [err, setErr] = useState("");
  const handleSubmit = e => {
    e.preventDefault();
    setErr("");

    const validationResult = AddVeggieValidation(
      formData.veggieName,
      formData.veggiePrice
    );

    if (validationResult.hasError) {
      setErr(validationResult.err);
    }
  };

  const onChange = e => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  return (
    <Fragment>
      {err.length > 0 && <Error err={err} />}
      <form onSubmit={e => handleSubmit(e)}>
        <div className="row">
          <input
            type="text"
            name="veggieName"
            value={formData.veggieName}
            placeholder="Veggie Name"
            onChange={e => onChange(e)}
          />
        </div>
        <div className="row">
          <input
            type="text"
            name="veggiePrice"
            placeholder="Veggie Price"
            value={formData.veggiePrice}
            onChange={e => onChange(e)}
          />
        </div>
        <div className="row">
          <button onClick={e => handleSubmit(e)} className="btn btn-primary">
            Add Veggie
          </button>
        </div>
      </form>
    </Fragment>
  );
};

export default AddVeggie;
