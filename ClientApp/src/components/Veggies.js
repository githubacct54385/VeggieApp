import React, { Fragment, useState, useEffect } from "react";
import VeggieRequests from "../Api/VeggieRequests";
import { Link } from "react-router-dom";
import "../Veggie.css";
import styled from "styled-components";
import AddVeggie from "./AddVeggie";
import Error from "./Error";

// Styled Component
// VeggieFlexConatiner
// The green flex container for each veggie
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

// Styled Component
// VeggieName
// For font and responsive design of veggie's name
const VeggieName = styled.div`
  font-size: 20px;
  flex: 2;
`;

// Styled Component
// VeggiePrice
// For font and responsive design of veggie's price
const VeggiePrice = styled.div`
  font-size: 20px;
  flex: 2;
`;

// Styled Component
// VeggieButtons
// For responsive design of veggie buttons (update and delete)
const VeggieButtons = styled.div`
  flex: 1;
`;

// Component
// Veggie
// The functional JSX of the Veggie
// Each has a link to the upate page
// Also a prop onDeleteClicked to handle passing
// the delete Veggie action up the component tree
const Veggie = ({ veggieId, veggieName, veggiePrice, onDeleteClicked }) => {
  return (
    <VeggieFlexContainer>
      <VeggieName>{veggieName}</VeggieName>
      <VeggiePrice>${veggiePrice}</VeggiePrice>
      <VeggieButtons>
        <Link to={`/updateVeggie/${veggieId}`} className="btn btn-light m-2">
          Go To Update Page
        </Link>
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

// Component
// Veggies
// This is the root of this SPA page
// State and effects are here
const Veggies = () => {
  // local useState

  // loading: (is the page loading?) [bool]
  const [loading, setLoading] = useState(true);

  // veggies: (all the veggies on the page) [array]
  const [veggies, setVeggies] = useState([]);

  // err: (any error) [string]
  const [err, setErr] = useState("");

  // Effect
  // This is my "Component Did Mount"
  // it runs on page load only
  // it queries veggies then sets loading to false
  useEffect(() => {
    queryData().then(() => {
      setLoading(false);
    });
  }, []);

  // Event Handler
  // queryData()
  // Queries veggies from the backend
  // sets error if failed
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

  // Event Handler
  // handleAddVeggie(formData)
  // adds a veggie and queries data if successful
  // sets error if failed
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

  // Event Handler
  // handleDelete(veggieId)
  // deletes a veggie and queries data if successful
  // sets error if failed
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

  // if loading, just show a loading paragraph
  if (loading) {
    return <p>Loading...</p>;
  }

  // Displays header info
  // error
  // maps through all veggies
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
