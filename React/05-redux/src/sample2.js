// import React from 'react';
// import ReactDOM from 'react-dom';
// import './index.css';
// import App from './App';
// import registerServiceWorker from './registerServiceWorker';

// ReactDOM.render(<App />, document.getElementById('app'));
// registerServiceWorker();

import { applyMiddleware, createStore } from 'redux';

const reducer = function (initialState, action) {
    if (action.type == 'INC') {
        return initialState + 1;
    }
    else if (action.type == 'DEC') {
        return initialState - 1;
    }
    else if (action.type == 'E') {
        throw new Error("AAAA");
    }
    return initialState;
};

const logger = (store) => (next) => (action) => {
    console.log("action fired", action);
    next(action);
}
const error = (store) => (next) => (action) => {
    try {
        next(action);
    }
    catch (e) {
        console.log("AHHHH!", e);
    }
}

const midlleware = applyMiddleware(logger, error);

const store = createStore(reducer, 1, midlleware);

store.subscribe(() => {
    console.log('store changed', store.getState())
});

store.dispatch({ type: 'INC', payload: 1 })
store.dispatch({ type: 'INC', payload: 2 })
store.dispatch({ type: 'INC', payload: 22 })
store.dispatch({ type: 'INC', payload: 1 })
store.dispatch({ type: 'DEC', payload: 1000 })
store.dispatch({ type: 'E', payload: 1000 })

