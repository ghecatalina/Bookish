import React, { useReducer } from 'react';

import CategoriesContext from './CategoriesContext';
import CategoriesReducer from './CategoriesReducer';

const CategoriesProvider = (props) => {
    const initialState = {
        categoriesResponses: {
            categoryId: 0,
            categoryResponses: []
        }
    };

    const [state, dispatch] = useReducer(CategoriesReducer, initialState);

    return(
        <CategoriesContext.Provider
            value={{
                categoriesResponses: state.categoryResponses,
                dispatch
            }}
            >
                {props.children}
            </CategoriesContext.Provider>
    );
};

export default CategoriesProvider;