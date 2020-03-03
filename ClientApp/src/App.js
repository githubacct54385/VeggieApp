import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import Veggies from "./components/Veggies";
import UpdateVeggiePage from "./components/UpdateVeggiePage";

import "./custom.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/veggies" component={Veggies} />
        <Route exact path="/updateVeggie/:id" component={UpdateVeggiePage} />
      </Layout>
    );
  }
}
