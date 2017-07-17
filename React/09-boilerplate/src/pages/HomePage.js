/* eslint-disable no-undef */

import React, { Component } from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { loadHome } from '../actions'
import {translatable} from "react-multilingual";

class HomePage extends Component {
  componentWillMount() {
    this.props.dispatch(loadHome());
  }

  render() {
    const { user } = this.props
    let { hello, changeLocale } = this.props;

    return (
      <div>
        {user.name}
        <br />
        <button onClick={() => changeLocale("en")}>en</button>
        <button onClick={() => changeLocale("fa")}>fa</button>
        <p>
          {hello}
        </p>
      </div>
    )
  }
}

const mapTranslationsToProps = ({ hello }) => ({ hello });

const mapStateToProps = (store, ownProps) => {
  const { user } = store.home.data

  return { user }
}

export default translatable(mapTranslationsToProps)(connect(mapStateToProps)(HomePage));
