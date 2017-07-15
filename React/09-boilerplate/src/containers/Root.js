import React from 'react'
import PropTypes from 'prop-types'
import { Provider } from 'react-redux'
import { Router, Route } from 'react-router'
import routes from '../routes'
import App from './App'

class Root extends React.Component {

  render() {
    const { store, history } = this.props
    return (
      <Provider store={store}>
        <Router history={history} >
          <App children={routes} />
        </Router>
      </Provider>
    )
  }
}

export default Root
