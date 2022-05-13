import { IF_IN_ANY_LIST, UPDATE_IF_ANY } from '../constants/actionTypes';
import * as api from '../api/index';

export const get_if_any = (formData) => async (dispatch) => {
    try {
        const { data } = await api.getIfInAnyList(formData);
        dispatch({ type: IF_IN_ANY_LIST, payload: data });
    }catch (error){
        console.log(error);
    }
}

export const add_to_booklist = (formData) => async (dispatch) => {
    try {
        const {data} = await api.addToBookList(formData);
        dispatch({type: UPDATE_IF_ANY, payload: data});
    }catch (error){
        console.log(error);
    }
}