import { combineReducers } from 'redux'

import home from './homeReducer'
import {localeReducer} from "react-multilingual";

export default combineReducers({
    home,
    locale: localeReducer("en", require("../locales/index").default)
})	    
