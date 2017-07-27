import React from 'react';
import PropTypes from 'prop-types';
import _ from 'lodash';
import { Responsive, WidthProvider } from 'react-grid-layout';
const ResponsiveReactGridLayout = WidthProvider(Responsive);

export default class App extends React.Component {
constructor(){
  super();
  this.state =   {
    layouts: { lg: [
        {
          "w": 6,
          "h": 2,
          "x": 0,
          "y": 0,
          "i": "0",
          "moved": false,
          "static": false
        },
        {
          "w": 6,
          "h": 2,
          "x": 6,
          "y": 0,
          "i": "1",
          "moved": false,
          "static": false
        },
        {
          "w": 6,
          "h": 3,
          "x": 2,
          "y": 2,
          "i": "2",
          "moved": false,
          "static": false
        }
      ] },
  };

}
  generateDOM() {
    return _.map(this.state.layouts.lg, function (l, i) {
      return (
        <div key={i} className={l.static ? 'static' : ''}>
          {l.static ?
            <span className="text" title="This item is static and cannot be removed or resized.">Static - {i}</span>
            : <span className="text">{i}</span>
          }
        </div>);
    });
  }

  onBreakpointChange = (breakpoint) => {
  };

  onLayoutChange = (layout, layouts) => {
  };

  onNewLayout = () => {
  };

  render() {
    return (
      <div>
        <button onClick={this.onNewLayout}>Generate New Layout</button>
        <ResponsiveReactGridLayout
          breakpoints={{lg: 1200}}
          layouts={this.state.layouts}
          onBreakpointChange={this.onBreakpointChange}
          onLayoutChange={this.onLayoutChange}>
          {this.generateDOM()}
        </ResponsiveReactGridLayout>
      </div>
    );
  }
}