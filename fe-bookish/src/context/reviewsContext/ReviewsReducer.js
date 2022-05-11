import * as actionTypes from './actionTypes';

const updateStateObject = (oldObject, updatedProprieties) => {
    return {
        ...oldObject,
        ...updatedProprieties
    };
};

const setReviewsResponses = ( state, action ) => {
    //console.log("quizResponses")
    console.log(action.payload)
    return updateStateObject( state, {
        reviewsResponses: action.payload
    } );
};


const ReviewsReducer = ( state, action ) => {
    switch ( action.type ) {
        case actionTypes.SET_REVIEW_RESPONSES: return setReviewsResponses(state, action);
        default:
            return state;
    }
};

export default ReviewsReducer;