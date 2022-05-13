import { GET_CATEGORIES } from "../constants/actionTypes";

const categoriesReducer = (categories = [], action) => {
    switch (action.type) {
        case GET_CATEGORIES:
            return action.payload;

        default:
            return categories;
    }
}

export default categoriesReducer;