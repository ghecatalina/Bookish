import { CircularProgress } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { api } from "../../api";
import NavBar from "../NavBar/NavBar";
import BookDetails from "./BookDetails";

const BookPage = () => {
    const {id} = useParams();
    const [rating, setRating] = useState(null);


    useEffect(() => {
        api.get(`/v1/Reviews/rating?id=${id}`)
        .then( (response) => {
            setRating(response.data)
        })
        .catch (function (error) {
            console.log(error);
        })
    }, []);

    return (
        <>
        <NavBar />
        {!rating ? <CircularProgress /> : <BookDetails id={id} rating={rating}/>}
        </>
    );
} 

export default BookPage;