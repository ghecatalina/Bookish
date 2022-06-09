import { Button, Divider, Grid, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { api } from "../../api";
import NavBar from "../NavBar/NavBar";
import BooksGrid from "./BooksGrid";

const userId = localStorage.getItem('id');

const BookListPage = ({listType}) => {
    const [listToShow, setListToShow] = useState({type: listType});
    const [books, setBooks] = useState(null);

    useEffect( () => {
        const bookListForm = {
            userId: userId,
            listType: listToShow.type
        }
        api.post('v1/BookLists/getList', bookListForm)
        .then(response => {
            setBooks(response.data);
        })
        .catch(function (error) {
            console.log(error);
        })
    }, [listToShow.type])

    const handleClick = (e) => {
        setListToShow({...listToShow, type: e.target.name});
        console.log(listType);
    }

    console.log(books);

    return (
        <>
        <NavBar />
        <Grid container columnSpacing={3} justifyContent="flex-start" style={{paddingLeft: '40px', paddingRight: '40px', paddingTop: '30px'}}>
            <Grid item xs={3}>
                <Grid container>
                    <Grid item xs = {12}>
                        <Typography variant="h6">My Books</Typography>
                    </Grid>
                    <Divider flexItem style={{width: 200}}/>
                    <Grid item xs = {12}>
                        <Button variant="text" name="read" onClick={handleClick} style={listToShow.type==="read" ? {color: 'black', fontWeight: 700} : {color: 'black'}}>Read</Button>
                    </Grid>
                    <Grid item xs = {12}>
                        <Button variant="text" name="currentlyreading" onClick={handleClick} style={listToShow.type==="currentlyreading" ? {color: 'black', fontWeight: 700} : {color: 'black'}}>Currently Reading</Button>
                    </Grid>
                    <Grid item xs = {12}>
                        <Button variant="text" name="wanttoread" onClick={handleClick} style={listToShow.type==="wanttoread" ? {color: 'black', fontWeight: 700} : {color: 'black'}}>Want To Read</Button>
                    </Grid>
                </Grid>
            </Grid>
            <Grid item xs={9}>
                {books !== null && <BooksGrid books={books}/>}
            </Grid>
        </Grid>
        </>
    );
}

export default BookListPage;