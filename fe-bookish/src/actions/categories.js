import { GET_CATEGORIES } from "../constants/actionTypes";
import * as api from '../api/index';

export const get_categories = () => async (dispatch) => {
    try {
        const { data } = await api.getCategories();
        dispatch({ type: GET_CATEGORIES, payload: data });
    }catch (error){
        console.log(error);
    }
}