export default function reducer(state = {
    data: {
        user: {
            id: null,
            name: null,
            age: null,
        }
    },
    fetching: false,
    fetched: false,
    error: null
}, action) {
    switch (action.type) {
        case "FETCH_HOME": {
            return { ...state, fetching: true }
        }
        case "FETCH_HOME_REJECTED": {
            return { ...state, fetching: false, error: null }
        }
        case "FETCH_HOME_FULFILLED": {
            return {
                ...state,
                fetching: false,
                fetched: true,
                data: action.payload
            }
        }
    }

    return state;
}