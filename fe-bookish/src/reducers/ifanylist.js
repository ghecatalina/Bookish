import { IF_IN_ANY_LIST, UPDATE_IF_ANY } from "../constants/actionTypes";

const ifAnyListReducer = (ifAny = {}, action) => {
    switch (action.type) {
        case IF_IN_ANY_LIST:
            return action.payload;
        case UPDATE_IF_ANY:
            return action.payload;
        default:
            return ifAny;
    }
}

export default ifAnyListReducer;