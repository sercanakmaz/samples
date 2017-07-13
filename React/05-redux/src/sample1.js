// import React from 'react';
// import ReactDOM from 'react-dom';
// import './index.css';
// import App from './App';
// import registerServiceWorker from './registerServiceWorker';

// ReactDOM.render(<App />, document.getElementById('app'));
// registerServiceWorker();

import { combineReducers, createStore } from 'redux';

const userReducer = function (state = {}, action) {
    switch (action.type) {
        case "CHANGE_NAME":
            state = { ...state, name: action.payload };
            break;
        case "CHANGE_AGE":
            state = { ...state, age: action.payload };
            break;
    }
    return state;
}

const tweetsReducer = function (state = {}, action) {
    
    return state;
}

const reducers = combineReducers({
    user: userReducer,
    tweets: tweetsReducer
})

const store = createStore(reducers);

// const reducer = function (state, action) {
//     if (action.type == 'INC') {
//         return state + action.payload;
//     }
//     else if (action.type == 'DEC') {
//         return state - state.action.payload;
//     }
//     return state;
// };


store.subscribe(() => {
    console.log('store changed', store.getState())
});

store.dispatch({ type: 'CHANGE_NAME', payload: "Will" })
store.dispatch({ type: 'CHANGE_AGE', payload: 35 })
store.dispatch({ type: 'CHANGE_AGE', payload: 36 })