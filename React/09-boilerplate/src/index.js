import React from 'react'
import { render } from 'react-dom'
import createHistory from 'history/createBrowserHistory';

// import { syncHistoryWithStore } from 'react-router-redux'
import Root from './containers/Root'
import store from './store'

const browserHistory = createHistory()
// const history = syncHistoryWithStore(browserHistory, store)

render(
  <Root store={store} history={browserHistory} />,
  document.getElementById('root')
)
