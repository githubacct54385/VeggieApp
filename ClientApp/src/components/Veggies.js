import React, { Fragment, useState, useEffect } from "react";
import VeggieRequests from "../Api/VeggieRequests";
import "../Veggie.css";
import styled from "styled-components";
import AddVeggie from "./AddVeggie";
import Error from "./Error";

const VeggieFlexContainer = styled.div`
  background-color: #46d646;
  font-size: 14px;
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  border-radius: 10px;
  margin: 15px 0;
  padding: 10px 10px;
`;

const VeggieName = styled.div`
  font-size: 20px;
  flex: 2;
`;

const VeggiePrice = styled.div`
  font-size: 20px;
  flex: 2;
`;

const VeggieButtons = styled.div`
  flex: 1;
`;

const Veggie = ({ veggieId, veggieName, veggiePrice, onDeleteClicked }) => {
  return (
    <VeggieFlexContainer>
      <VeggieName>{veggieName}</VeggieName>
      <VeggiePrice>${veggiePrice}</VeggiePrice>
      <VeggieButtons>
        <button className="btn btn-light m-2">Update</button>
        <button
          onClick={e => {
            e.preventDefault();
            onDeleteClicked(veggieId);
          }}
          className="btn btn-danger m-2"
        >
          Delete
        </button>
      </VeggieButtons>
    </VeggieFlexContainer>
  );
};

const Veggies = () => {
  const [loading, setLoading] = useState(true);
  const [veggies, setVeggies] = useState([]);
  const [err, setErr] = useState("");
  useEffect(() => {
    queryData().then(() => {
      setLoading(false);
    });
  }, []);

  const queryData = () => {
    clearErr();
    return new Promise(resolve => {
      const api = new VeggieRequests();
      api.getVeggies().then(data => {
        if (data.success) {
          setVeggies(data.veggies);
        } else {
          setErr(data.msg);
        }
        resolve();
      });
    });
  };

  const handleAddVeggie = formData => {
    clearErr();
    const api = new VeggieRequests();
    api.addVeggie(formData.veggieName, formData.veggiePrice).then(data => {
      if (data.success) {
        queryData().then(() => {});
      } else {
        setErr(data.msg);
      }
    });
  };

  const handleDelete = veggieId => {
    clearErr();
    const api = new VeggieRequests();
    api.deleteVeggie(veggieId).then(data => {
      if (data.success) {
        queryData().then(() => {});
      } else {
        setErr(data.msg);
      }
    });
  };

  // clear error helper
  // I clear the error before every HTTP request
  const clearErr = () => setErr("");

  if (loading) {
    return <p>Loading...</p>;
  }

  return (
    <Fragment>
      <h1>Inventory Management for Veggies</h1>
      {err.length > 0 && <Error err={err} />}
      <AddVeggie onSubmit={handleAddVeggie} />
      {veggies !== null && veggies.length === 0 && <p>Veggies in database</p>}
      {veggies !== null && veggies.length > 0 && (
        <Fragment>
          {veggies.map(veg => (
            <Veggie
              key={veg.id}
              veggieId={veg.id}
              veggieName={veg.name}
              veggiePrice={veg.price}
              onDeleteClicked={handleDelete}
            />
          ))}
        </Fragment>
      )}
    </Fragment>
  );
};

export default Veggies;
