import { Button } from "@mui/material";
import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import { add_to_booklist, get_if_any } from "../../../../actions/ifAny";
import { addToBookList } from "../../../../api";

const WantToReadButton = ({formData, fromListType}) => {
    const dispatch = useDispatch();

    /*useEffect( () => {
        dispatch(get_if_any(formData));
    }, [dispatch]);*/

    const handleWantToReadList =() => {
        const listForm = {
            userId: formData.userId,
            bookId: formData.bookId,
            fromListType: fromListType,
            toListType: "wanttoread"
        };
        dispatch(add_to_booklist(listForm));
    }

    return (
        <Button variant="text" style={{color: 'white', border: 'white'}} onClick={handleWantToReadList}>Want To Read</Button>
    );
}

export default WantToReadButton;