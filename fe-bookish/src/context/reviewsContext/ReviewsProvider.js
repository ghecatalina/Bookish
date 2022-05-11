import React, { useReducer } from 'react';

import ReviewsContext from './ReviewsContext';
import ReviewsReducer from './ReviewsReducer';

const ReviewsProvider = (props) => {
    const initialState = {
        reviewsResponses: {
            reviewId: 0,
            reviewResponses: []
        }
    };

    const [state, dispatch] = useReducer(ReviewsReducer, initialState);

    return(
        <ReviewsContext.Provider
            value={{
                reviewsResponses: state.reviewResponses,
                dispatch
            }}
            >
                {props.children}
            </ReviewsContext.Provider>
    );
};

export default ReviewsProvider;