import axios from 'axios'

export function loadHome() {
    return function (dispatch) {
        axios.get("/data/home.json")
            .then((response) => {
                dispatch({ type: "FETCH_HOME_FULFILLED", payload: response.data })
            })
            .catch((err) => {
                dispatch({ type: "FETCH_HOME_REJECTED", payload: err })
            })
    }
}