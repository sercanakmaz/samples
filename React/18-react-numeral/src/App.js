import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';


class App extends Component {
  componentWillMount() {
    var numeral = require('numeral');

    numeral.register('locale', 'g', {
      delimiters: {
        thousands: '.',
        decimal: ','
      },
      abbreviations: {
        thousand: '',
        million: '',
        billion: '',
        trillion: ''
      },
      ordinal: function (number) {
        return '';
      },
      currency: {
        symbol: ' '
      }
    });

    numeral.locale('g');
  }
  render() {
    var numeral = require('numeral');

    const myNumeral = numeral(10000.2325);
    const textNumeral = numeral('10.000,2325')

    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <p className="App-intro">
          {myNumeral.format('0,0.0000')}
          <br />
          {textNumeral.format('0,0.0000')}
        </p>
      </div>
    );
  }
}

export default App;
