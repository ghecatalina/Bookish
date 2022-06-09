import { Button, ButtonGroup, Divider } from "@mui/material";
import React, { useEffect, useState } from "react";
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import { useDispatch, useSelector } from "react-redux";
import { get_if_any } from "../../../actions/ifAny";
import ReadButton from "./Buttons/ReadButton";
import CurrentlyReadingButton from "./Buttons/CurrentlyReadingButton";
import WantToReadButton from "./Buttons/WantToReadButton";

const ReadListButton = ({formData}) => {
    const [isExpanded, setIsExpended] = useState(false);
    const dispatch = useDispatch();
    const handleClickExpand = () => {
        setIsExpended(!isExpanded);
    }

    useEffect( () => {
        dispatch(get_if_any(formData));
    }, [dispatch]);

    const ifAny = useSelector((state) => state.ifAny);
    //setListForm({...listForm, fromListType: ifAny.listType});

    return(
        <ButtonGroup variant="text" style={{background: '#AD9786'}}>
            <ButtonGroup orientation="vertical">
                <ButtonGroup variant="text" style={{background: '#AD9786'}}>
                    {ifAny.listType === "none" && <Button variant="text" style={{color: 'white'}}>Add To a list</Button>}
                    {ifAny.listType === "read" && <ReadButton formData={formData} fromListType={ifAny.listType}/>}
                    {ifAny.listType === "currentlyreading" && <CurrentlyReadingButton formData={formData} fromListType={ifAny.listType}/>}
                    {ifAny.listType === "wanttoread" && <WantToReadButton formData={formData} fromListType={ifAny.listType}/>}
                    <Divider flexItem orientation="vertical"/>
                    <Button variant="text" onClick={handleClickExpand} style={{color: 'white'}}>
                        {!isExpanded ? <KeyboardArrowDownIcon /> : <KeyboardArrowUpIcon />}
                    </Button>
                </ButtonGroup>
                <>
                {isExpanded && 
                    <>
                    {ifAny.listType === "none" &&
                    <>
                    <Divider />
                    <WantToReadButton formData={formData} fromListType={ifAny.listType}/>
                    <Divider />
                    <ReadButton formData={formData} fromListType={ifAny.listType}/>
                    <Divider />
                    <CurrentlyReadingButton formData={formData} fromListType={ifAny.listType}/>
                    </>
                    }
                    {ifAny.listType === "read" &&
                    <>
                    <Divider />
                    <WantToReadButton formData={formData} fromListType={ifAny.listType}/>
                    <Divider />
                    <CurrentlyReadingButton formData={formData} fromListType={ifAny.listType}/>
                    </>
                    }
                    {ifAny.listType === "currentlyreading" &&
                    <>
                    <Divider />
                    <WantToReadButton formData={formData} fromListType={ifAny.listType}/>
                    <Divider />
                    <ReadButton formData={formData} fromListType={ifAny.listType}/>
                    </>
                    }
                    {ifAny.listType === "wanttoread" &&
                    <>
                    <Divider />
                    <ReadButton formData={formData} fromListType={ifAny.listType}/>
                    <Divider />
                    <CurrentlyReadingButton formData={formData} fromListType={ifAny.listType}/>
                    </>
                    }
                    </>
                }
                </>
            </ButtonGroup>
        </ButtonGroup>
        
    );
}

export default ReadListButton;