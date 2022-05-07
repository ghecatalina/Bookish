import { AppBar, Avatar, Grid, Box, Container, IconButton, Toolbar, Typography, InputBase } from "@mui/material";
import React from "react";
import logo from '../../images/logo.png';
import avatar from '../../images/avatar.png';
import SearchIcon from '@mui/icons-material/Search';
import { styled, alpha } from '@mui/material/styles';

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

const NavBar = () => {

    return(
        <AppBar position="static" style={{background: '#AD9786'}}>
            <Container maxWidth="xl" >
                <Toolbar disableGutters>
                    <Grid container>
                        <Grid item xs={6}>
                            <Box sx={{display: 'inline-flex'}}>
                            <IconButton size="large"
                            edge="start"
                            color="inherit"
                            aria-label="menu"
                            sx={{ mr: 2 }}
                            height={60}>
                                <img src={logo} alt="" height={50}/>
                            </IconButton>
                            <Typography variant="h5" style={{marginLeft: '-25px', marginTop: '20px'}}>Bookish</Typography>
                            </Box>
                        </Grid>
                    </Grid>
                                <Search>
                                <SearchIconWrapper>
                                <SearchIcon />
                                </SearchIconWrapper>
                                <StyledInputBase
                                placeholder="Search…"
                                inputProps={{ 'aria-label': 'search' }}
                                />
                            </Search>
                            <Avatar alt="avatar" src={avatar} sx={{ width: 56, height: 56 }}/>
                </Toolbar>
            </Container>
        </AppBar>
    );
}

export default NavBar;