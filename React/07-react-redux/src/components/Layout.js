import React from 'react';
import { connect } from 'react-redux'

class Layout extends React.Component {
    render() {
        console.log(this.props)
        return null;
    }
}

export default connect((store)=>{
    return {
        user: store.user.user
    }
})(Layout)