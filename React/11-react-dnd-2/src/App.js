import React, { Component } from 'react';
import { DragDropContext } from 'react-dnd';
import HTML5Backend from 'react-dnd-html5-backend';
import Cards from './Cards';
import './App.css';

const style = {
  width: 400,
};

class App extends Component {
  constructor(props) {
    super(props);
    this.moveCard = this.moveCard.bind(this);
    this.state = {
      cards1: [{
        id: 1,
        text: 'Write a cool JS library',
      }, {
        id: 2,
        text: 'Make it generic enough',
      }, {
        id: 3,
        text: 'Write README',
      }, {
        id: 4,
        text: 'Create some examples',
      }, {
        id: 5,
        text: 'Spam in Twitter and IRC to promote it (note that this element is taller than the others)Spam in Twitter and IRC to promote it (note that this element is taller than the others)Spam in Twitter and IRC to promote it (note that this element is taller than the others)Spam in Twitter and IRC to promote it (note that this element is taller than the others) ',
      }, {
        id: 6,
        text: '???',
      }, {
        id: 7,
        text: 'PROFIT',
      }],
      cards2: [{
        id: 1,
        text: 'Write a cool JS library',
      }, {
        id: 2,
        text: 'Make it generic enough',
      }, {
        id: 3,
        text: 'Write README',
      }, {
        id: 4,
        text: 'Create some examples',
      }, {
        id: 5,
        text: 'Spam in Twitter and IRC to promote it (note that this element is taller than the others)',
      }, {
        id: 6,
        text: '???',
      }, {
        id: 7,
        text: 'PROFIT',
      }]
    };

    for (var index = 0; index < this.state.cards1.length; index++) {
      var element = this.state.cards1[index];
      element["y"] = index;
    }
  }

  moveCard(dragIndex, hoverIndex) {
    const newState = { ...this.state };

    // const dragIndex = newState.cards.findIndex((item) => item.id == dragProps.id);
    // const hoverIndex = newState.cards.findIndex((item) => item.id == hoverProps.id);
    const dragCard = newState.cards1[dragIndex];

    newState.cards1.splice(dragIndex, 1);
    newState.cards1.splice(hoverIndex, 0, dragCard);

    for (var index = 0; index < newState.cards1.length; index++) {
      var element = newState.cards1[index];
      element.y = index;
    }

    this.setState(newState);
  }

  render() {
    const { cards1, cards2 } = this.state;

    return (
      <div style={style}>
        <Cards
          cards={cards1}
          moveCard={this.moveCard}
        />
      </div>
    );
  }
}

export default DragDropContext(HTML5Backend)(App)
