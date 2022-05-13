import * as api from '../api/index';
import { GET_PROFILE_PICTURE } from "../constants/actionTypes";

export const get_profile_picture = (id) => async (dispatch) => {
    try {
        const { data } = await api.getProfilePicure(id);
        dispatch({ type: GET_PROFILE_PICTURE, payload: data });
    }catch (error){
        console.log(error);
    }
}