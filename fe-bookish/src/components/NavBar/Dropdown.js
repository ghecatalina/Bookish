import { Button, ButtonGroup, Divider } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import "./Dropdown.css";

const Dropdown = () => {
    const navigate = useNavigate();

    const goToBooklist = (e) => {
            navigate('/mybooks');
    }

    const handleLogout = () => {
        localStorage.removeItem('tk');
        localStorage.removeItem('id');
        navigate('/');
    }

    return(
        <ButtonGroup orientation="vertical" className="submenu" variant="text" style={{background: '#AD9786', color:'white', borderColor: 'white'}}>
            <Button name="read" style={{color: 'white', border: 'white'}} onClick={goToBooklist}>My Books</Button>
            <Divider flexItem style={{background: 'white'}}/>
            <Button name="read" style={{color: 'white', border: 'white'}} >My Account</Button>
            <Divider flexItem style={{background: 'white'}}/>
            <Button style={{color: 'white', border: 'white'}} onClick={handleLogout}>Logout</Button>
        </ButtonGroup>
    );
}

export default Dropdown;