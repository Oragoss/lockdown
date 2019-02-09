import React, { Component } from 'react';
import logo from './LockIcon.svg';
import './App.css';

class App extends Component {
  render() {
    return (
      //TODO: Add the user context
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          {
            //TODO: Add the dashboard here
          }
        </header>
      </div>
    );
  }
}

export default App;
