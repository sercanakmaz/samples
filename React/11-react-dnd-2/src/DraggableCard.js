import React, { Component, PropTypes } from 'react';
import { findDOMNode } from 'react-dom';
import { DragSource } from 'react-dnd';
import { getEmptyImage } from 'react-dnd-html5-backend';

import Card from './Card';


function getStyles(isDragging) {
  return {
    display: isDragging ? 0.5 : 1
  };
}

const cardSource = {
  beginDrag(props, monitor, component) {
    // dispatch to redux store that drag is started
    const { item } = props;
    const { id, y } = item;
    const { clientWidth, clientHeight } = findDOMNode(component);

    return { id, y, item, clientWidth, clientHeight };
  },
  endDrag(props, monitor) {
    document.getElementById(props.item.id).style.display = 'block';
  },
  isDragging(props, monitor) {
    const isDragging = props.item && props.item.id === monitor.getItem().id;
    return isDragging;
  }
};

// options: 4rd param to DragSource https://gaearon.github.io/react-dnd/docs-drag-source.html
const OPTIONS = {
  arePropsEqual: function arePropsEqual(props, otherProps) {
    let isEqual = true;
    if (props.item.id === otherProps.item.id
    ) {
      isEqual = true;
    } else {
      isEqual = false;
    }
    return isEqual;
  }
};

function collectDragSource(connectDragSource, monitor) {
  return {
    connectDragSource: connectDragSource.dragSource(),
    connectDragPreview: connectDragSource.dragPreview(),
    isDragging: monitor.isDragging()
  };
}

class CardComponent extends Component {
  static propTypes = {
    item: PropTypes.object,
    connectDragSource: PropTypes.func.isRequired,
    connectDragPreview: PropTypes.func.isRequired,
    isDragging: PropTypes.bool.isRequired
  }

  componentDidMount() {
    // this.props.connectDragPreview(getEmptyImage(), {
    //   captureDraggingState: true
    // });
  }

  render() {
    const { isDragging, connectDragSource, item } = this.props;

    return connectDragSource(
      <div>
        <Card style={getStyles(isDragging)} item={item} />
      </div>
    );
  }
}

export default DragSource('card', cardSource, collectDragSource, OPTIONS)(CardComponent)
