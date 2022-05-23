import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { get_categories } from "../../actions/categories";
import { get_profile_picture } from "../../actions/profilePicture";
import NavBar from "../NavBar/NavBar";
import BrowseBooksCarousel from "./BrowseBooksCarousels";

const userId = localStorage.getItem('id');

const BrowseBooks = () => {
    const [categoryList, setCategories] = useState([]);
    const dispatch = useDispatch();
    //const {categories, dispatch} = useContext(CategoriesContext);

    useEffect(() => {
        dispatch(get_categories())
        /*api.get('/v1/Category')
        .then((response) => {
            console.log(response.data);
            setCategories(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });*/
    }, [dispatch]);

    useEffect( () => {
        dispatch(get_profile_picture(userId));
    }, [dispatch]);
    
    return(
        <>
        <NavBar />
        <BrowseBooksCarousel />
        </>
    );
}

export default BrowseBooks;