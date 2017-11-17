import React, { Component } from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table'

const products = [
  {
    id: 1,
    name: "Product 1",
    price: 513.42
  },
  {
    id: 2,
    name: "Product 2",
    price: 5413.42
  },
  {
    id: 3,
    name: "Product 3",
    price: 1513.42
  }
]

class ChildComponent extends Component {
  render() {
    const { row } = this.props;

    console.log("expanded: ", row.id)

    return (
      <div>
        expanded: {row.id}
      </div>
    );
  }
}

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      expandedRows: []
    }
  }

  isExpandableRow(row) {
    return true;
  }

  expandComponent(row) {
    if (!this.state.expandedRows.find(rowKey => row.id === rowKey)) {
      return null;
    }

    return (
      <ChildComponent row={row} />
    );
  }

  handleExpandClick(row) {
    const newExpandedRows = this.state.expandedRows;
    const rowExpandedIndex = newExpandedRows.findIndex(item => item === row.id);

    if (rowExpandedIndex >= 0) {
      newExpandedRows.splice(rowExpandedIndex, 1);
    }
    else {
      newExpandedRows.push(row.id)
    }

    this.bootstrapTable.handleExpandRow(newExpandedRows, row, rowExpandedIndex >= 0);
    this.setState({ expandedRows: newExpandedRows });
  }

  render() {
    return (
      <BootstrapTable ref={(element) => this.bootstrapTable = element}
        data={products}
        options={{
          expandRowBgColor: 'rgb(242, 255, 163)',
          expandBy: 'column'  // Currently, available value is row and column, default is row
        }}
        expandableRow={this.isExpandableRow}
        expandComponent={this.expandComponent.bind(this)}>
        <TableHeaderColumn dataField='id' isKey expandable={false}>Product ID</TableHeaderColumn>
        <TableHeaderColumn expandable={false} dataFormat={(cell, row) => <a onClick={this.handleExpandClick.bind(this, row)}>Expand</a>}></TableHeaderColumn>
        <TableHeaderColumn expandable={false} dataField='name'>Product Name</TableHeaderColumn>
        <TableHeaderColumn expandable={false} dataField='price'>Product Price</TableHeaderColumn>
      </BootstrapTable>
    );
  }
}

export default App;
