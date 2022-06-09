import { Button, ButtonGroup, Divider } from "@mui/material";
import React from "react";
import { useNavigate } from "react-router-dom";
import "./Dropdown.css";

const Dropdown = () => {
    const role = localStorage.getItem('role');
    const navigate = useNavigate();

    const goToBooklist = (e) => {
            navigate('/mybooks');
    }

    const goToMyAccount = () => {
        navigate('/myaccount');
    }

    const goToAddBook = () => {
        navigate('/addbook');
    }

    const handleLogout = () => {
        localStorage.clear();
        navigate('/');
    }

    return(
        <ButtonGroup orientation="vertical" className="submenu" variant="text" style={{background: '#AD9786', color:'white', borderColor: 'white'}}>
            {role === 'regular' ?
            <Button name="read" style={{color: 'white', border: 'white'}} onClick={goToBooklist}>My Books</Button> :
            <Button name="read" style={{color: 'white', border: 'white'}} onClick={goToAddBook}>Add Book</Button>
            }
            <Divider flexItem style={{background: 'white'}}/>
            <Button name="read" style={{color: 'white', border: 'white'}} onClick={goToMyAccount}>My Account</Button>
            <Divider flexItem style={{background: 'white'}}/>
            <Button style={{color: 'white', border: 'white'}} onClick={handleLogout}>Logout</Button>
        </ButtonGroup>
    );
}

export default Dropdown;