import React from 'react';
import { createStore } from 'redux';
import { Provider } from 'react-redux';
import { combineForms } from 'react-redux-form';

import { connect } from 'react-redux';
import { Control, Form } from 'react-redux-form';

class MyForm extends React.Component {
  handleSubmit(detail) {
    // Do anything you want with the form value
    console.log(detail);
  }

  render() {
    return (
      <Form model="user.detail" onSubmit={(val) => this.handleSubmit(val)}>
        <label>Your name?</label>
        <Control.text model=".name" />
        <button>Submit!</button>
      </Form>
    );
  }
}

// No need to connect()!
const initialUser = { detail: { name: '' } };

const store = createStore(combineForms({
  user: initialUser,
}));

export default class App extends React.Component {
  render() {
    return (
      <Provider store={store}>
        <MyForm />
      </Provider>
    );
  }
}