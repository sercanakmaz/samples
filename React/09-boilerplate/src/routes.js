import React from 'react'
import { Route } from 'react-router'

import ProductListPage from './pages/ProductListPage'
import HomePage from './pages/HomePage'

export default <div>
    <Route path="/" exact component={HomePage} />
    <Route path="/product" component={ProductListPage} />
</div>