import { CircularProgress, Divider, Grid, Rating, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { useParams } from "react-router-dom";
import { get_book } from "../../actions/books";
import { get_if_any } from "../../actions/ifAny";
import api from "../../services/api";
import NavBar from "../NavBar/NavBar";
import ReadListButton from "./ReadListButton/ReadListButton";
import GeneralReviews from "./Reviews/ReviewCard/GeneralReviews";
import NoOfReviews from "./Reviews/ReviewCard/NoOfReviews";
import ReviewCard from "./Reviews/ReviewCard/ReviewCard";
import ReviewsGrid from "./Reviews/ReviewCard/ReviewsGrid";
import ReviewsPage from "./Reviews/ReviewsPage";

const userId = localStorage.getItem('id');

const BookDetails = ({id, rating}) => {
    const [book, setBook] = useState(null);
    const [noOfRatings, setNoOfRatings] = useState([]);
    const dispatch = useDispatch();
    //const [reviews, setReviews] = useState([]);
    const [ifAnyForm, setIfAnyForm] = useState({bookId: Number(id), userId: userId});
    useEffect( () => {
        dispatch(get_if_any(ifAnyForm));
    }, [dispatch]);

    useEffect(() => {
        api.get(`/v1/Reviews/ratings/${id}`)
        .then((response) => {
            setNoOfRatings(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
    }, []);

    useEffect(() => {
        api.get(`/v1/Books/${id}`)
        .then((response) => {
            console.log(response.data);
            setBook(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
    }, []);

    function getRating(){
        const sum = noOfRatings.reduce((total, currVal) => total = total + Number(currVal.noRating) * Number(currVal.rating), 0);
        const totalReviews = noOfRatings.reduce((total, currVal) => total = total + Number(currVal.noRating), 0);
        return sum / totalReviews;
    }

    return(
        <>
        {!book ? <CircularProgress /> :
            <>
            {noOfRatings && 
            <>
            <div style={{display: 'flex', justifyContent: 'center', marginTop: 30, marginLeft: 70, marginRight: 70,}}>
                <div style={{height:400, width: 250, marginRight: 50}}>
                    <img src={book.coverImage} alt="" style={{height: '100%',width: '230px', fill: 'cover'}}/>
                </div>
                <div style={{display: 'flex', flexDirection: 'column',}}>
                    <div style={{marginBottom: 20}}>
                        <Typography variant="h5">{book.title}</Typography>
                    </div>
                    <div style={{marginBottom: 20}}>
                        <Typography variant="h6">Author: {book.author}</Typography>
                    </div>
                    <div style={{marginBottom: 20}}>
                        <Rating precision={0.1} readOnly defaultValue={rating.rating} style={{color: '#C68A5D'}} />
                    </div>
                    <div style={{marginBottom: 20}}>
                        <ReadListButton formData={ifAnyForm}/>
                    </div>
                    <div>
                        <Typography variant="body2">{book.description}</Typography>
                    </div>
                </div>
            </div>
            <Divider variant="middle" flexItem style={{padding: 20}}/>
            <ReviewsPage noOfRatings={noOfRatings} bookId={id}/>
            </>
            }
            </>
        }
        </>
    );
}

export default BookDetails;