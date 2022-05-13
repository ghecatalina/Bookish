import * as actionType from '../constants/actionTypes';

const authReducer = (state = {authData: null}, action) => {
    switch (action.type){
        case actionType.AUTH:
            localStorage.setItem('tk', action?.data.tk);
            localStorage.setItem('id', action?.data.id);
            return {...state, authData: action.data, errors: null};

        case actionType.LOGOUT:
            localStorage.clear()
            return { ...state, authData: null, errors: null };

        default:
        return state;
    }
}

export default authReducer;