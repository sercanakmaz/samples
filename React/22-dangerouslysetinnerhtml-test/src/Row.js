import React, { Component } from 'react';

class Row extends Component {
  render() {
    return (
      <div dangerouslySetInnerHTML={{__html: this.props.data.value}}>
      </div>
    );
  }
}

export default Row;
