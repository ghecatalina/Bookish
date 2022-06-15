import { CircularProgress, Grid, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import NoOfReviews from "./NoOfReviews";
import api from '../../../../services/api';
import AddReview from "./AddReview";
import MyReview from "./MyReview";

const userId = localStorage.getItem('id');

const GeneralReviews = ({noOfRatings, bookId}) => {
    //const [noOfRatings, setNoOfRatings] = useState([]);
    const [review, setReview] = useState(null);
    //const allReviews = useSelector((state) => state.reviews);

    function getTotalOfReviews() {
        const sum = noOfRatings.reduce((total, currVal) => total = total + Number(currVal.noRating), 0);
        return sum;
    }

    /*useEffect( () => {
        dispatch(get_reviews());
    }, [dispatch]);

    if(!allReviews) return null;
    console.log("I am here");
    console.log(allReviews);

    const reviews = allReviews.filter( function(e) {
        return (e.userId === userId && Number(e.bookId) === Number(bookId));
    });

    console.log("My review");
    console.log(reviews);

    const review = reviews[0];*/

    useEffect(() => {
        api.get(`/v1/Reviews/userBook?bookId=${bookId}&userId=${userId}`)
        .then((response) => {
            console.log(response.data);
            setReview(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
    }, [bookId]);

    /*useEffect(() => {
        api.get(`/v1/Reviews/ratings/${bookId}`)
        .then((response) => {
            setNoOfRatings(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
    }, []);*/

    return (
        <Grid container direction="row" alignItems="center" justifyContent="center" spacing={4} style={{paddingLeft: '100px', paddingRight: '40px', paddingTop: '30px', paddingBottom: '30px'}}>
            <Grid item xs={12} >
                <Typography variant="h5">General Reviews</Typography>
            </Grid>
            {
                !noOfRatings ? <CircularProgress /> :
                <div>
                <Grid container justifyContent="center" spacing={4} style={{paddingLeft: '40px', paddingRight: '40px', paddingTop: '30px'}}>
                    {noOfRatings.map( (rating) => {
                        return (
                            <Grid item xs={12} key={rating.rating}>
                            <NoOfReviews no={rating.rating} value={rating.noRating} total={getTotalOfReviews()} />
                            </Grid>
                        )
                    })}
                </ Grid>
            </div>
            }
            <Grid item xs={12}>
                {
                    !review ? 
                    <AddReview bookId={bookId}/> :
                    <MyReview review={review} bookId={bookId}/>
                }
            </Grid>
        </Grid>
    );
}

export default GeneralReviews;