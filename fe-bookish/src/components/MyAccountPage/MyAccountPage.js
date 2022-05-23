import { Avatar, Button, CircularProgress, Divider, Grid, TextField, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { api } from "../../api";
import NavBar from "../NavBar/NavBar";
import FileBase from 'react-file-base64';

const userId = localStorage.getItem('id');

const MyAccountPage = () => {
    const [user, setUser] = useState({name: '', email: '', profilePicture: '', password: '', confirmPassword: ''});
    const [isEditable, setIsEditable] = useState(false);
    const [err, setErr] = useState('');
    const [photoPassword, SetPhotoPassword] = useState ({});
    //const [passwords, setPasswords] = useState({password: '', confirmPassword: ''});

    useEffect( () => {
        api.get(`v1/Users/info/${userId}`)
        .then(response => {
            setUser(prev => ({...prev, name: response.data.name}));
            setUser(prev => ({...prev, email: response.data.email}));
            setUser(prev => ({...prev, profilePicture: response.data.profilePicture}));
            /*setUser({name: response.data.name});
            setUser({email: response.data.email});
            setUser({profilePicture: response.data.profilePicture});*/
            //setUser(response.data);
            console.log(user);
        })
        .catch( function (error){
            console.log(error);
            setErr(error);
        });
    }, []); 

    const handleUpdateProfile = () => {
        console.log(user);
        const updateUser = {
            id: userId,
            name: user.name,
            profilePicture: user.profilePicture,
            password: user.password
        }

        api.put('/auth/update', updateUser)
        .then(response => {
            console.log(response.data);
            window.location.reload();
        })
        .catch(err => {
            console.log(err);
        })

    };

    return(
        <>
        <NavBar />
        {user.name !== '' && <Grid container spacing={3} justifyContent="flex-start" style={{paddingLeft: '40px', paddingRight: '40px', paddingTop: '30px', paddingBottom: '30px'}}>
            <Grid item xs={12}>
                <Typography variant="h6">My Account</Typography>
                <Divider flexItem />
            </Grid>
            <Grid item xs={6}>
                <Grid container spacing={3} alignItems="center" justifyContent="center" >
                    <Grid item xs={12}>
                        <Typography variant="body2">Name</Typography>
                        <TextField value={user.name} onChange={(e) => {setUser({...user, name: e.target.value});}}/>
                    </Grid>
                    <Grid item xs={12}>
                        <Typography variant="body2">Email</Typography>
                        <TextField disabled value={user.email} onChange={(e) => {setUser({...user, name: e.target.value});}}/>
                    </Grid>
                    <Grid item xs={12}>
                        <Typography variant="body2">Password</Typography>
                        <TextField name="password" type="password" onChange={(e) => setUser({...user, password: e.target.value})}/>
                    </Grid>
                    <Grid item xs={12}>
                        <Typography name="confirmPassword" variant="body2">Confirm Password</Typography>
                        <TextField name="confirmPassword" type="password" onChange={(e) => setUser({...user, confirmPassword: e.target.value})}/>
                    </Grid>
                    <Grid item xs={12}>
                        <Typography variant="body2" style={{color: 'red'}}>{err}</Typography>
                    </Grid>
                </Grid>
            </Grid>
            <Grid item xs={6}>
                <Grid container spacing={3} justifyContent="center" style={{paddingLeft: '40px', paddingRight: '40px', paddingTop: '30px'}}>
                    <Grid item xs={12}>
                        <Avatar src={user.profilePicture} style={{width: 200, height: 200}}/>
                    </Grid>
                    <Grid item xs={12}>
                            <div>
                                <Typography variant="subtitle2">Choose a photo</Typography>
                                <FileBase type="image" multiple={false} onDone={({ base64 }) => setUser({ ...user, profilePicture: base64 })} />
                            </div>
                        </Grid>
                </Grid>
            </Grid>
            <Grid container item xs={12} alignItems="center" justifyContent="center">
                <Button variant="contained" style={{background: '#9F8069', color: 'white'}} onClick={handleUpdateProfile}>Update Profile</Button>
            </Grid>
        </Grid>
        }
        </>
    );
}

export default MyAccountPage;