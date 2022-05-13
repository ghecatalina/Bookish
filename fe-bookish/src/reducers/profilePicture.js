import { GET_PROFILE_PICTURE } from "../constants/actionTypes";

const profilePictureReducer = (profilePicture = {}, action) => {
    switch (action.type) {
        case GET_PROFILE_PICTURE:
            return action.payload;
        default:
            return profilePicture;
    }
}

export default profilePictureReducer;