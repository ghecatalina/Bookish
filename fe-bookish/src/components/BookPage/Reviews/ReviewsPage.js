import { CircularProgress, Grid } from "@mui/material";
import React, { useEffect, useState } from "react";
import api from "../../../services/api";
import GeneralReviews from "./ReviewCard/GeneralReviews";
import ReviewCard from "./ReviewCard/ReviewCard";
import ReviewsGrid from "./ReviewCard/ReviewsGrid";

const userId = localStorage.getItem('id');

const ReviewsPage = ({noOfRatings, bookId}) => {
    const [reviews, setReviews] = useState([]);

    useEffect(() => {
        api.get(`/v1/Reviews/withoutCurrUser?bookId=${bookId}&userId=${userId}`)
        .then((response) => {
            console.log(response.data);
            setReviews(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
    }, []);

    return (<>
        {!reviews ? <CircularProgress /> :
        <Grid container justifyContent="center">
            <Grid item xs={6}>
                <GeneralReviews noOfRatings={noOfRatings} bookId={bookId} />
            </Grid>
            <Grid item xs={6}>
                <ReviewsGrid reviews={reviews} />
            </Grid>
        </Grid>
        }
        </>
    );
}

export default ReviewsPage;