import React, { Fragment, useState, useEffect } from "react";
import VeggieRequests from "../Api/VeggieRequests";
import "../Veggie.css";
import styled from "styled-components";

const QueryVeggiesError = ({ error }) => {
  return (
    <div className="alert alert-danger" role="alert">
      {error}
    </div>
  );
};

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

const Veggie = ({ veggieId, veggieName, veggiePrice }) => {
  return (
    <VeggieFlexContainer>
      <VeggieName>{veggieName}</VeggieName>
      <VeggiePrice>{veggiePrice}</VeggiePrice>
      <VeggieButtons>
        <button className="btn btn-light m-2">Update</button>
        <button className="btn btn-danger m-2">Delete</button>
      </VeggieButtons>
    </VeggieFlexContainer>
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
            <Veggie
              key={veg.id}
              veggieId={veg.id}
              veggieName={veg.name}
              veggiePrice={veg.price}
            />
          ))}
        </Fragment>
      )}
    </Fragment>
  );
};

export default Veggies;
