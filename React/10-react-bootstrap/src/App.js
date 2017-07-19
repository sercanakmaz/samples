import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Modal from 'react-bootstrap/lib/Modal';
import Button from 'react-bootstrap/lib/Button';

class App extends Component {
  componentWillMount() {
    this.setState({ show: true });
  }

  render() {
    let close = () => this.setState({ show: false });

    return (
      <div className="App">
        <div className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h2>Welcome to React</h2>
        </div>
        <p className="App-intro">
          To get started, edit <code>src/App.js</code> and save to reload.

        <Modal
            show={this.state.show}
            container={this}
            aria-labelledby="contained-modal-title"
          >
            <Modal.Header closeButton>
              <Modal.Title id="contained-modal-title">Contained Modal</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              Elit est explicabo ipsum eaque dolorem blanditiis doloribus sed id ipsam, beatae, rem fuga id earum? Inventore et facilis obcaecati.
          </Modal.Body>
            <Modal.Footer>
              <Button onClick={close}>Close</Button>
            </Modal.Footer>
          </Modal>
        </p>
      </div>
    );
  }
}

export default App;
