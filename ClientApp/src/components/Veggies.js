import React, { Fragment, useState, useEffect } from "react";
import VeggieRequests from "../Api/VeggieRequests";
import "../Veggie.css";

const QueryVeggiesError = ({ error }) => {
  return (
    <div className="alert alert-danger" role="alert">
      {error}
    </div>
  );
};

const Veggie = ({ veggieId, veggieName }) => {
  return (
    <div className="card card-body veggie">
      <div className="veggie-name">{veggieName}</div>
      <div className="veggie-buttons">
        <button className="btn btn-secondary">Update</button>
        <button className="btn btn-danger">Delete</button>
      </div>
    </div>
  );
};

const Veggies = () => {
  const [loading, setLoading] = useState(true);
  const [veggies, setVeggies] = useState([]);
  const [err, setErr] = useState("");
  useEffect(() => {
    const api = new VeggieRequests();
    api.getVeggies().then(data => {
      if (data.success) {
        setVeggies(data.veggies);
      } else {
        setErr(data.error);
      }
      setLoading(false);
    });
  }, []);

  if (loading) {
    return <p>Loading...</p>;
  }

  return (
    <Fragment>
      {err.length > 0 && <QueryVeggiesError error={err} />}
      {veggies !== null && veggies.length > 0 && (
        <Fragment>
          {veggies.map(veg => (
            <Veggie key={veg.id} veggieId={veg.id} veggieName={veg.name} />
          ))}
        </Fragment>
      )}
    </Fragment>
  );
};

export default Veggies;
