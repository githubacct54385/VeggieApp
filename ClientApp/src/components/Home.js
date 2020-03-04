import React, { Component } from "react";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Hello, Veggie Maniacs!</h1>
        <p>Welcome to our inventory system for Veggies.</p>
        <p>Please click the Veggies link in the Navbar to get started</p>
        <hr />
        <h2>Seeding the database and adding your connection string</h2>
        <p>
          If you haven't followed the steps on seeding the database and adding
          the connection string, then you'll probably not be able to use this
          app yet.
        </p>
        <p>Follow the instructions in the README</p>
      </div>
    );
  }
}
