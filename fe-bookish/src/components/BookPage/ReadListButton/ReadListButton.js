import { Button, ButtonGroup, Container, Divider, Grid, Typography } from "@mui/material";
import React, { useState } from "react";
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';

const ReadListButton = () => {
    const [isExpanded, setIsExpended] = useState(false);

    const handleClickExpand = () => {
        setIsExpended(!isExpanded);
    }

    return(
        <ButtonGroup variant="text" style={{background: '#AD9786'}}>
            <ButtonGroup orientation="vertical">
                <ButtonGroup variant="text" style={{background: '#AD9786'}}>
                    <Button variant="text" style={{color: 'white'}}>Want To Read</Button>
                    <Button variant="text" onClick={handleClickExpand} style={{color: 'white'}}>
                        {!isExpanded ? <KeyboardArrowDownIcon /> : <KeyboardArrowUpIcon />}
                    </Button>
                </ButtonGroup>
                {isExpanded && 
                    <>
                    <Divider />
                    <Button variant="text" style={{color: 'white'}}>Read</Button>
                    <Divider />
                    <Button variant="text" style={{color: 'white'}}>Currently Reading</Button>
                    </>
                }
            </ButtonGroup>
        </ButtonGroup>
    );
}

export default ReadListButton;