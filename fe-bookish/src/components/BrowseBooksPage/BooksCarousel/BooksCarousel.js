import { Grid, Typography } from "@mui/material";
import React from "react";
import BookCard from "../BookCard/BookCard";
import Carousel from 'react-elastic-carousel';
import './style.css';

const BooksCarousel = ({category}) => {
    return (
        <>
        <Typography variant="h5" style={{paddingTop: 10}}>{category.categoryName}</Typography>
        <Carousel itemsToShow={3} style={{marginBottom: 20}}>
            {category.books.map((book) => {
                        return (
                            <Grid item key={book.id}>
                                <BookCard book = {book}/>
                            </Grid>
                        )
                    })}
        </Carousel>
        </>
    );
}

export default BooksCarousel;