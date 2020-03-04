import React, { Fragment, useState } from "react";
import AddVeggieValidation from "../FormValidation/AddVeggieValidation";
import Error from "./Error";
import PropTypes from "prop-types";

// Component
// AddVeggie
// The add veggie form
const AddVeggie = ({ onSubmit }) => {
  // form data
  const [formData, setFormData] = useState({ veggieName: "", veggiePrice: "" });
  // error
  const [err, setErr] = useState("");

  // event handler for submit
  const handleSubmit = e => {
    e.preventDefault();
    setErr("");

    // validate
    const validationResult = AddVeggieValidation(
      formData.veggieName,
      formData.veggiePrice
    );

    if (validationResult.hasError) {
      setErr(validationResult.err);
    } else {
      // run add veggie
      onSubmit(formData);
      setFormData({ veggieName: "", veggiePrice: "" });
    }
  };

  // handle input changes
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

AddVeggie.propTypes = {
  onSubmit: PropTypes.func.isRequired
};

export default AddVeggie;
