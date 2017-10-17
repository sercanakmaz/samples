import React, { Component } from 'react';
import Select from 'react-select';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      backspaceRemoves: true,
      multi: true,
      creatable: true
    };
  }
  onChange(value) {
    console.log('onChange', value);
    this.setState({
      value: value,
    });
  }
  switchToMulti() {
    this.setState({
      multi: true,
      value: [this.state.value],
    });
  }
  switchToSingle() {
    this.setState({
      multi: false,
      value: this.state.value ? this.state.value[0] : null
    });
  }
  getUsers(input) {
    // if (!input) {
    //   return Promise.resolve({ options: [] });
    // }

    // return fetch(`https://api.github.com/search/users?q=${input}`)
    //   .then((response) => response.json())
    //   .then((json) => {
    //     return { options: json.items };
    //   });
  }
  gotoUser(value, event) {
    window.open(value.html_url);
  }
  toggleBackspaceRemoves() {
    console.log('toggleBackspaceRemoves');
    this.setState({
      backspaceRemoves: !this.state.backspaceRemoves
    });
  }
  toggleCreatable() {
    console.log('toggleCreatable');

    this.setState({
      creatable: !this.state.creatable
    });
  }
  render() {
    return (
      <div className="section">
        <h3 className="section-heading">{this.props.label}</h3>
        <Select.Creatable multi={this.state.multi} value={this.state.value} onChange={this.onChange.bind(this)} onValueClick={this.gotoUser} valueKey="id" labelKey="login" backspaceRemoves={this.state.backspaceRemoves} />
        <div className="checkbox-list">
          <label className="checkbox">
            <input type="radio" className="checkbox-control" checked={this.state.multi} onChange={this.switchToMulti} />
            <span className="checkbox-label">Multiselect</span>
          </label>
          <label className="checkbox">
            <input type="radio" className="checkbox-control" checked={!this.state.multi} onChange={this.switchToSingle} />
            <span className="checkbox-label">Single Value</span>
          </label>
        </div>
        <div className="checkbox-list">
          <label className="checkbox">
            <input type="checkbox" className="checkbox-control" checked={this.state.creatable} onChange={this.toggleCreatable} />
            <span className="checkbox-label">Creatable?</span>
          </label>
          <label className="checkbox">
            <input type="checkbox" className="checkbox-control" checked={this.state.backspaceRemoves} onChange={this.toggleBackspaceRemoves} />
            <span className="checkbox-label">Backspace Removes?</span>
          </label>
        </div>
        <div className="hint">This example uses fetch.js for showing Async options with Promises</div>
      </div>
    );
  }
}

export default App;
