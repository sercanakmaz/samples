import React, { Component } from 'react';
import PropTypes from 'prop-types';

const defaultStyle = {
    border: '1px dashed gray',
    padding: '0.5rem 1rem',
    marginBottom: '.5rem',
    backgroundColor: 'white',
    cursor: 'move',
};

export default class Card extends Component {
    static propTypes = {
        item: PropTypes.any.isRequired
    };

    render() {
        const { style, item, isDragging } = this.props;

        return (
            <div id={style ? item.id : null} style={{ ...defaultStyle, ...style }}>
                {item.text}
            </div>
        );
    }
}