/* eslint-disable no-undef */

import React, { Component } from 'react'
// import PropTypes from 'prop-types'
import { connect } from 'react-redux'
// import { loadHome } from '../actions'

class ProductListPage extends Component {
  // static propTypes = {
  //   user: PropTypes.object
  // }

  componentWillMount() {
    // loadHome();
  }

  render() {
    // const { user } = this.props

    return (
      <div>
        ProductListPage
        {/*{user.name}*/}
      </div>
    )
  }
}

const mapStateToProps = (state, ownProps) => {
  // const { user } = state

  // return { user }

  return {}
}

export default connect(mapStateToProps)(ProductListPage)
