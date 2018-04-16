import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

import TinyEditorComponent from './TinyEditorComponent';

class App extends Component {
  render() {
    return (
      <div className="App">
        <div className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h2>Welcome to React + TinyMCE</h2>
        </div>
        <TinyEditorComponent
            id="myCoolEditor"
            onEditorChange={content => console.log(content)}
         />
      </div>
    );
  }
}

export default App;