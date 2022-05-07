import React, { useReducer } from 'react';

import BooksContext from './BooksContext';
import BooksReducer from './BooksReducer';

const BooksProvider = (props) => {
    const initialState = {
        booksResponses: {
            bookId: 0,
            bookResponses: []
        }
    };

    const [state, dispatch] = useReducer(BooksReducer, initialState);

    return(
        <BooksContext.Provider
            value={{
                booksResponses: state.bookResponses,
                dispatch
            }}
            >
                {props.children}
            </BooksContext.Provider>
    );
};

export default BooksProvider;