import { CircularProgress, Grid } from "@mui/material";
import React, { useContext, useEffect, useState } from "react";
import BooksContext from "../../context/booksContext/BooksContext";
import api from "../../services/api";
import NavBar from "../NavBar/NavBar";
import BookCard from "./BookCard/BookCard";

const BrowseBooks = () => {
    const [bookList, setBookList] = useState([]);
    const {books, dispatch} = useContext(BooksContext);

    useEffect(() => {
        api.get('/v1/Books')
        .then((response) => {
            setBookList(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
    }, []);

    return(
        <>
        <NavBar />
        {!bookList.length ? <CircularProgress /> :
            <div>
                <Grid container spacing={4} justifyContent="flex-start" style={{paddingLeft: '40px', paddingRight: '40px', paddingTop: '30px'}} >
                    {bookList.map( (book) => {
                        return (
                            <Grid item key={book.id}>
                                <BookCard book={book}></BookCard>
                            </Grid>
                        )
                    })}
                </ Grid>
            </div>
        }
        </>
    );
}

export default BrowseBooks;