import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

import Row from './Row.js';

const rowCount = 40;
const replaceCount = 5;

class App extends Component {
  constructor(props) {
    super(props)

    this.state = {
      rows: []
    }
  }

  generateData(count) {
    var result = [];

    for (let i = 0; i < count; i++) {
      result.push({ value: 'Some <strong>' + Math.random() + '</strong> <i>value</i> <script type="text/javascript">window.location = "http://google.com"</script>' });
    }

    return result;
  }

  componentDidMount() {
    var self = this;

    self.setState({
      rows: this.generateData(rowCount)
    })

    setInterval(() => {
      var index = Math.floor(Math.random() * (rowCount - replaceCount));

      var newRows = this.state.rows.slice();
      newRows.splice(index, replaceCount, ...this.generateData(replaceCount));

      self.setState({
        rows: newRows
      })
    }, 3000);
  }

  render() {
    return (
      <div className="App">
        <h1>My dangerouslySetInnerHTML test</h1>
        {this.state.rows.map((item, index) => <Row key={index} data={item} />)}
      </div>
    );
  }
}

export default App;
