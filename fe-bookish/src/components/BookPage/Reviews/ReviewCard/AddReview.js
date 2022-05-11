import { Button, Grid, Rating, TextField, Typography } from "@mui/material";
import React, { useContext, useEffect, useState } from "react";
import ReviewsContext from "../../../../context/reviewsContext/ReviewsContext";
import api from "../../../../services/api";

const userId = localStorage.getItem('id');

const AddReview = ({bookId}) => {
    const {review, dispatch} = useContext(ReviewsContext);
    const[reviewForm, setReview] = useState({ rating: 0, reviewDescription: ''});

    const handleAddReview = (e) => {
        e.preventDefault();
        //console.log(review);
        const reviewInfo = {
            userId: userId,
            bookId: Number(bookId),
            rating: reviewForm.rating,
            reviewDescription: reviewForm.reviewDescription
        };
        console.log("In handle Add Review =>"+reviewInfo);
        api.post('v1/Reviews', reviewInfo)
        .then((response) => {
            console.log(response.data);
            dispatch({type: 'SET_REVIEW_RESPONSES', payload: response.data })
        })
        .catch(function (error) {
            console.log(error);
        });
    }

    return (
        <Grid container spacing={2} style={{paddingRight: 30}}>
            <Grid item xs={12}>
                <Typography variant="h6">Add your review</Typography>
            </Grid>
            <Grid item xs={12}>
                <Rating  defaultValue={0}  onChange={(event, newValue) => {setReview({...reviewForm, rating: Number(newValue)}); }}/>
            </Grid>
            <Grid item xs={12}>
                <TextField variant="outlined" multiline rows={5} fullWidth onChange={(e) => {setReview({...reviewForm, reviewDescription: e.target.value}); }}/> 
            </Grid>
            <Grid item xs={12}>
                <Button variant="contained" style={{background: '#9F8069', color: 'white'}} onClick={handleAddReview}>Add Review</Button>
            </Grid>
        </Grid>
    );
}

export default AddReview;