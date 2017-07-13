import React from 'react';

export default class Todo extends React.Component{
   
    render(){
        const {text} = this.props;
        
        return (
          <li>
              {text}
          </li>
        );
    }
}
