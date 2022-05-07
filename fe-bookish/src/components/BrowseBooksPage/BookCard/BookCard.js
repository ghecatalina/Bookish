import { Card, CardContent, CardMedia, Grid, Typography } from "@mui/material";
import React from "react";

const BookCard = ({book}) => {

    return(
        <Card elevation={3} sx={{ maxWidth: 140 }} style={{paddingTop: '10px', paddingLeft: '5px', paddingRight: '5px'}}>
            <div style={{height: '200', width: '100%'}}>
                <CardMedia component="img" src={book.coverImage} />
            </div>
            <CardContent>
                <Grid container spacing={1}>
                    <Grid item xs={12}>
                        <Typography variant="body2" fontWeight={600} fontSize={15}>{book.title}</Typography>
                    </Grid>
                    <Grid item xs={12}>
                        <Typography variant="body2" fontWeight={300} fontSize={12}>{book.author}</Typography>
                    </Grid>
                </Grid>
            </CardContent>
        </Card>
    );
}

export default BookCard;