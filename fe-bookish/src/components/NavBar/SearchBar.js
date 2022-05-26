import { Autocomplete, Box, createFilterOptions, TextField } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { api } from "../../api";

const SearchBar = () => {
    const [books, setBooks] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        api.get('v1/Books')
        .then(response => {
            setBooks(response.data);
        })
        .catch(err => {
            console.log(err);
        })
    }, [])

    const filterOptions = createFilterOptions({
        matchFrom: 'any',
        stringify: (option) => option.title + option.author,
      });

    return(
        <Autocomplete
        freeSolo
        id="free-solo-2-demo"
        disableClearable
        options={books}
        getOptionLabel={(option) => `${option.title} by ${option.author}`}
        filterOptions={filterOptions}
        onChange={(event, newValue) => {navigate(`/books/${newValue.id}`); window.location.reload()}}
        renderOption={(props, option) => (
            <Box component="li" sx={{ '& > img': { mr: 2, flexShrink: 0 } }} {...props}>
              <img
                loading="lazy"
                width="20"
                src={option.coverImage}
                alt=""
              />
              {option.title} by {option.author} 
            </Box>
          )}

        renderInput={(params) => (
          <TextField
            variant="standard"
            style={{radius: '15px', width: '350px', border: 'none'}}
            {...params}
            label="Search your book"
            InputProps={{
              ...params.InputProps,
              type: 'search',
            }}
          />
        )}
      />
    );
}

export default SearchBar;