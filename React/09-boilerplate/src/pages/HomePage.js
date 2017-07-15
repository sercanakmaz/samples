/* eslint-disable no-undef */

import React, { Component } from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { loadHome } from '../actions'

class HomePage extends Component {
  componentWillMount() {
    this.props.dispatch(loadHome());
  }

  render() {
    const { user } = this.props

    return (
      <div>
        {user.name}
      </div>
    )
  }
}

const mapStateToProps = (store, ownProps) => {
  const { user } = store.home.data

  return { user }
}

export default connect(mapStateToProps)(HomePage)
