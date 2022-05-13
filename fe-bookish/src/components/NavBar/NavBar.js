import { AppBar, Avatar, Grid, Box, Container, IconButton, Toolbar, Typography, InputBase } from "@mui/material";
import React, { useEffect, useState } from "react";
import logo from '../../images/logo.png';
//import avatar from '../../images/avatar.png';
import SearchIcon from '@mui/icons-material/Search';
import { styled, alpha } from '@mui/material/styles';
import { NavLink, useNavigate } from "react-router-dom";
import { api } from "../../api";
import { useDispatch, useSelector } from "react-redux";
import { get_profile_picture } from "../../actions/profilePicture";
import Dropdown from "./Dropdown";

const Search = styled('div')(({ theme }) => ({
    position: 'relative',
    borderRadius: theme.shape.borderRadius,
    backgroundColor: alpha(theme.palette.common.white, 0.25),
    '&:hover': {
      backgroundColor: alpha(theme.palette.common.white, 0.30),
    },
    marginRight: theme.spacing(2),
    marginLeft: 0,
    width: '100%',
    [theme.breakpoints.up('sm')]: {
      marginLeft: theme.spacing(3),
      width: 'auto',
    },
}));
  
const SearchIconWrapper = styled('div')(({ theme }) => ({
    padding: theme.spacing(0, 2),
    height: '100%',
    position: 'absolute',
    pointerEvents: 'none',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
    '&:hover': {
        cursor: 'pointer',
      },
}));
  
const StyledInputBase = styled(InputBase)(({ theme }) => ({
    color: 'inherit',
    '& .MuiInputBase-input': {
      padding: theme.spacing(1, 1, 1, 0),
      // vertical padding + font size from searchIcon
      paddingLeft: `calc(1em + ${theme.spacing(4)})`,
      transition: theme.transitions.create('width'),
      width: '100%',
      [theme.breakpoints.up('md')]: {
        width: '20ch',
      },
    },
}));

const userId = localStorage.getItem('id');

const NavBar = () => {
    const [search, setSearch] = useState({search: ''});
    const [dropdown, setDropDown] = useState(false);
    //const [avatar, setAvatar] = useState(null);
    const avatar = useSelector((state) => state.profilePicture);
    const dispatch = useDispatch();

    /*useEffect( () => {
        api.get(`v1/Users/image/${userId}`)
        .then(response => {
            setAvatar(response.data);
        })
        .catch(function (error) {
            console.log(error);
        })
    }, [])*/

    useEffect( () => {
        dispatch(get_profile_picture(userId));
    }, [dispatch]);

    const handleChange = (e) => {
        setSearch({ ...search, [e.target.name]: e.target.value });
        console.log(e.target.value);
    }
    
    const handleSearch = () => {
        console.log("In handleSearch");
        console.log(search);
    }

    return(
        <>
        <AppBar position="static" style={{background: '#AD9786'}}>
            <Container maxWidth="xl" >
                <Toolbar disableGutters>
                    <Grid container>
                        <Grid item xs={6}>
                        <NavLink to="/books" style={isActive => ({
    color: isActive ? "white" : "white", textDecoration: "none"
  })}>
                            <Box sx={{display: 'inline-flex'}}>
                            <IconButton size="large"
                            edge="start"
                            color="inherit"
                            aria-label="menu"
                            sx={{ mr: 2 }}
                            height={60}>
                                <img src={logo} alt="" height={50} />
                            </IconButton>
                            <Typography variant="h5" style={{marginLeft: '-25px', marginTop: '20px'}}>Bookish</Typography>
                            </Box>
                            </NavLink>
                        </Grid>
                    </Grid>
                                <Search>
                                <SearchIconWrapper>
                                <SearchIcon onClick={handleSearch}/>
                                </SearchIconWrapper>
                                <StyledInputBase
                                name="search"
                                placeholder="Search…"
                                inputProps={{ 'aria-label': 'search' }}
                                onChange={handleChange}
                                />
                            </Search>
                            {avatar && <Avatar alt="avatar" src={avatar.profilePicture} sx={{ width: 56, height: 56 }} onClick={() => setDropDown(!dropdown)}/> }
                            
                </Toolbar>
            </Container>
            {dropdown && <Dropdown />}
        </AppBar>
            </>
    );
}

export default NavBar;