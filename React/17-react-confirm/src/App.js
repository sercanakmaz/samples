import React, { Component } from 'react';

import confirm from './confirm'

class App extends Component {
  onDeleteClick() {
    confirm('Are you sure')
    .then(
      (result) => {
        // `proceed` callback
        console.log('proceed called');
        console.log(result);
      },
      (result) => {
        // `cancel` callback
        console.log('cancel called');
        console.log(result)
      }
    )
  }
  render() {
    return (
      <div className="App">
        <button onClick={this.onDeleteClick.bind(this)} >
          Delete
        </button>
      </div>
    );
  }
}

export default App;
