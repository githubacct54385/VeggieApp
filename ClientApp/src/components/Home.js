import React, { Component } from "react";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Hello, Veggie Maniacs!</h1>
        <p>Welcome to our inventory system for Veggies.</p>
        <p>Please click the Veggies link in the Navbar to get started</p>
      </div>
    );
  }
}
