import { ADD_BOOK, GET_BOOK } from "../constants/actionTypes";
import * as api from '../api/index';

export const get_book = (id) => async (dispatch) => {
    try {
        const { data } = await api.getBookById(id);
        dispatch({ type: GET_BOOK, payload: data });
    }catch (error){
        console.log(error);
    }
}

export const add_book = (formData) => async (dispatch) => {
    try{
        const {data} = await api.addBook(formData);
        dispatch({type: ADD_BOOK, payload: data});
    }catch (error){
        console.log(error);
    }
}