import { CircularProgress, Grid } from "@mui/material";
import React, { useContext, useEffect, useState } from "react";
import BooksContext from "../../context/booksContext/BooksContext";
import CategoriesContext from "../../context/categoriesContext/CategoriesContext";
import api from "../../services/api";
import NavBar from "../NavBar/NavBar";
import BookCard from "./BookCard/BookCard";
import BooksCarousel from "./BooksCarousel/BooksCarousel";

const BrowseBooks = () => {
    const [categoryList, setCategories] = useState([]);
    //const {categories, dispatch} = useContext(CategoriesContext);

    useEffect(() => {
        api.get('/v1/Category')
        .then((response) => {
            console.log(response.data);
            setCategories(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
    }, []);
    
    return(
        <>
        <NavBar />
        {!categoryList.length ? <CircularProgress /> :
            <div>
                <Grid container spacing={4} justifyContent="flex-start" style={{paddingLeft: '40px', paddingRight: '40px', paddingTop: '30px'}} >
                    {categoryList.map( (category) => {
                        return (
                            <BooksCarousel category={category} key={category.id}/>
                        )
                    })}
                </ Grid>
            </div>
        }
        </>
    );
}

export default BrowseBooks;