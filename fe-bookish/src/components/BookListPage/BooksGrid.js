import { Grid } from "@mui/material";
import { Box } from "@mui/system";
import React from "react";
import BookCard from "../BrowseBooksPage/BookCard/BookCard";

const BooksGrid = ({books}) => {
    return (
        <Grid container spacing={3}>
            {books.map((book) => {
                return (
                    <Box>
                    <Grid item key={book.id} style={{margin: 20}}>
                        <BookCard book={book} />
                    </Grid>
                    </Box>
                )
            })}
        </Grid>
    );
}

export default BooksGrid;