import * as actionTypes from './actionTypes';

const updateStateObject = (oldObject, updatedProprieties) => {
    return {
        ...oldObject,
        ...updatedProprieties
    };
};

const setCategoriesResponses = ( state, action ) => {
    console.log("quizResponses")
    console.log(action.payload)
    return updateStateObject( state, {
        categoriesResponses: action.payload
    } );
};


const CategoriesReducer = ( state, action ) => {
    switch ( action.type ) {
        case actionTypes.SET_CATEGORY_RESPONSES: return setCategoriesResponses(state, action);
        default:
            return state;
    }
};

export default CategoriesReducer;