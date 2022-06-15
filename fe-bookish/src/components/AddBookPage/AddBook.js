import { Autocomplete, Button, Grid, Paper, TextField, Typography } from "@mui/material";
import { Box } from "@mui/system";
import React, { useEffect, useState } from "react";
import FileBase from 'react-file-base64';
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { api } from "../../api";
import NavBar from "../NavBar/NavBar";

const initialState = {
    title: '',
    author: '',
    description: '',
    coverImage: '',
    genre: ''};

const AddBook = () => {
    //const {book, dispatch} = useContext(BooksContext);
    const [formData, setFormData] = useState(initialState);
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const [genres, setGenres] = useState([]);

    useEffect(() => {
        api.get('v1/Category')
        .then(response => {
            setGenres(response.data);
        })
        .catch(err => {
            console.log(err);
        })
    }, [])

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    }

    const sendNewBook = () => {
        const bookInfo = {
            title: formData.title,
            author: formData.author,
            description: formData.description,
            coverImage: formData.coverImage,
            genre: formData.genre
        }
        //dispatch(add_book(bookInfo));
        api.post('/v1/Books', bookInfo)
          .then(function (response) {
            dispatch({type: 'SET_BOOK_RESPONSES', payload: response.data })
            navigate(`/books/${response.data.id}`);
          })
          .catch(function (error) {
            console.log(error);
          });
    }

    return(
        <>
        <NavBar />
        <Grid container
        spacing={0}
        direction="column"
        alignItems="center"
        justifyContent="center"
        style={{ minHeight: '100vh' }}>
            <Grid item xs={12}>
                <Paper style={{width: '400px', padding: '20px'}} elevation={5}>
                    <Grid container spacing={2} alignItems="center">
                        <Grid item xs={12} align="center">
                            <Typography variant="h5">Add a book</Typography>
                        </Grid>
                        <Grid item xs={12}>
                            <div>
                                <Typography variant="subtitle2">Choose book cover</Typography>
                                <FileBase type="file" multiple={false} onDone={({ base64 }) => setFormData({ ...formData, coverImage: base64 })} />
                            </div>
                        </Grid>
                        <Grid item xs={12}>
                            <TextField name="title" label="Title" fullWidth variant="standard" onChange={handleChange}/>
                        </Grid>
                        <Grid item xs={12}>
                            <TextField name="author" label="Author" fullWidth variant="standard" onChange={handleChange}/>
                        </Grid>
                        <Grid item xs={12}>
                        <Autocomplete
                        disablePortal
                        id="combo-box-demo"
                        options={genres}
                        fullWidth
                        getOptionLabel={(option) => option.categoryName}
                        // name="genre"
                        onChange={(event, newValue) => {setFormData({...formData, genre: newValue.categoryName})}}
                        renderOption={(props, option) => (
                            <Box component="li" sx={{ '& > img': { mr: 2, flexShrink: 0 } }} {...props}>
                                {option.categoryName}
                            </Box>
                        )} 
                        renderInput={(params) => 
                            <TextField
                            {...params}
                            label="Choose a genre"
                            inputProps={{
                                ...params.inputProps,
                                autoComplete: 'new-password', // disable autocomplete and autofill
                            }}
                            />
                        }
                        />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField name="description" multiline minRows={5} label="Description" fullWidth variant="standard" onChange={handleChange}/>
                        </Grid>
                        <Grid item xs={12} align="center">
                            <Button variant="contained" onClick={sendNewBook}>Submit</Button>
                        </Grid>
                    </Grid>
                </Paper>
            </Grid>
        </Grid>
        </>
    );
}

export default AddBook;