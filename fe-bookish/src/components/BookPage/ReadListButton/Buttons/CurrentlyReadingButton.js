import { Button } from "@mui/material";
import React from "react";
import { useDispatch } from "react-redux";
import { add_to_booklist } from "../../../../actions/ifAny";

const CurrentlyReadingButton = ({formData, fromListType}) => {
    const dispatch = useDispatch();

    /*useEffect( () => {
        dispatch(get_if_any(formData));
    }, [dispatch]);*/

    const handleCurrReadingList =() => {
        const listForm = {
            userId: formData.userId,
            bookId: formData.bookId,
            fromListType: fromListType,
            toListType: "currentlyreading"
        };
        dispatch(add_to_booklist(listForm));
    }

    return (
        <Button variant="text" style={{color: 'white', border: 'white'}} onClick={handleCurrReadingList}>Currently Reading</Button>
    );
}

export default CurrentlyReadingButton;