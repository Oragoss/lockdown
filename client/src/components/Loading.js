import React, { Component } from "react";
import logo from '../LockIcon.svg';
import '../App.css';

export default class Loading extends Component {
  state = {};

  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
        </header>
      </div>
    );
  }
}
