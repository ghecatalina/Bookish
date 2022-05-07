import * as actionTypes from './actionTypes';

const updateStateObject = (oldObject, updatedProprieties) => {
    return {
        ...oldObject,
        ...updatedProprieties
    };
};

const setBooksResponses = ( state, action ) => {
    console.log("quizResponses")
    console.log(action.payload)
    return updateStateObject( state, {
        booksResponses: action.payload
    } );
};


const BooksReducer = ( state, action ) => {
    switch ( action.type ) {
        case actionTypes.SET_BOOK_RESPONSES: return setBooksResponses(state, action);
        default:
            return state;
    }
};

export default BooksReducer;