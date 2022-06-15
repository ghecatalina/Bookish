import { CircularProgress, Grid } from "@mui/material";
import React from "react";
import { useSelector } from "react-redux";
import BooksCarousel from "./BooksCarousel/BooksCarousel";

const BrowseBooksCarousel = () => {
    const categoryList = useSelector((state) => state.categories);
    console.log(categoryList);

    return(
        <>
        {!categoryList.length ? <CircularProgress /> :
            <div>
                <Grid container spacing={4} justifyContent="flex-start" style={{paddingLeft: '40px', paddingRight: '40px', paddingTop: '30px'}} >
                    {categoryList.map( (category) => {

                        if (category.books.length !== 0) return (
                            <BooksCarousel category={category} key={category.id}/>
                        )
                    })}
                </ Grid>
            </div>
        }
        </>
    );
}

export default BrowseBooksCarousel;