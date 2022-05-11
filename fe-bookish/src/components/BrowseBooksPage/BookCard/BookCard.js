import { Paper, Typography } from "@mui/material";
import React from "react";
import { useNavigate } from "react-router-dom";
import useStyle from './styles';

const BookCard = ({book}) => {
    const classes = useStyle();
    const navigate = useNavigate();

    const handleClick = () => {
        navigate(`/books/${book.id}`);
    }

    return(
        <div style={{marginBottom: 20}} onClick={handleClick}>
        <Paper elevation={3} style={{padding: 5}}>
            <div style={{height: '250px', width: '150px'}}>
                <img src={book.coverImage} style={{height: '100%', width: '100%'}}/>
            </div>
            <div>
                <p>
                    <Typography component={'span'} variant="body2" style={{fontWeight: 550}}>{book.title}</Typography>
                </p>
                <p>
                    <Typography component={'span'} variant="body2">{book.author}</Typography>
                </p>
            </div>
        </Paper>
        </div>
    );
}

export default BookCard;