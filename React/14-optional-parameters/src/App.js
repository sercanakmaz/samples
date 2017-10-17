import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

import _ from 'lodash'

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      pageNumber: 1,
      pageSize: 10,
      searchText: null
    }
  }
  loadData({ pageNumber, pageSize, searchText } = {}) {
    console.log(_.defaults({ pageNumber, pageSize, searchText }, this.state));
  }

  render() {
    this.loadData({ searchText: "wqdqwd" });
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <p className="App-intro">
          To get started, edit <code>src/App.js</code> and save to reload.
        </p>
      </div>
    );
  }
}

export default App;
