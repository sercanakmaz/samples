import { applyMiddleware, createStore } from 'redux';
import axios from 'axios';
import { createLogger } from 'redux-logger';
import thunk from 'redux-thunk';
import promise from 'redux-promise-middleware';

const initialState = {
    fetching: false,
    fetched: false,
    users: [],
    error: null
}

const reducer = function (state = initialState, action) {
    switch (action.type) {
        case "FETCH_USERS_PENDING": {
            return { ...state, fetching: true }
            break;
        }
        case "FETCH_USERS_FULFILLED": {
            return {
                ...state,
                fetching: false,
                fetched: true,
                users: action.payload
            }
            break;
        }
        case "FETCH_USERS_REJECTED": {
            return { ...state, fetching: false, error: action.payload }
            break;
        }
    }
    return state;
};

const midlleware = applyMiddleware(promise(), thunk, createLogger());

const store = createStore(reducer, midlleware);

store.dispatch({
    type: "FETCH_USERS",
    payload: axios.get("http://rest.learncode.academy/api/wstern/users")
})

// store.dispatch((dispatch) => {
//     dispatch({ type: "FETHC_USERS_START" });
//     axios.get("http://rest.learncode.academy/api/wstern/users")
//         .then((response) => {
//             dispatch({ type: "RECEIVE_USERS", payload: response.data });
//         })
//         .catch((err) => {
//             dispatch({ type: "FETHC_USERS_ERROR", payload: err });
//         });
// })