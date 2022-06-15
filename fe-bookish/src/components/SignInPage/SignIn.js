import { Grid, TextField, Button, Paper, Typography } from "@mui/material";
import React, {useState} from "react";
import library from '../../images/library.jfif';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from "react-redux";
import { signin } from "../../actions/auth";
import { useForm } from 'react-hook-form';
import { api } from "../../api";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";

const initialState = {email: '', password: ''};

const schema = yup.object().shape({
    email: yup.string().email().required(),
    password: yup.string().min(8).max(32).required(),
  });

const SignIn = () => {
    //const {user, dispatch} = useContext(AuthContext);
    const {register, handleSubmit, formState: {errors}, reset} = useForm({resolver: yupResolver(schema)});
    const navigate = useNavigate();
    const [formData, setFormData] = useState(initialState);
    const dispatch = useDispatch();
    const [err, setErr] = useState("");

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
        console.log(e.target.value);
        console.log(formData);
    }

    const sendSignInData = (data) => {
        const userInfo = {
            regularUserEmail: data.email,
            regularUserPassword: data.password,
        }
        //e.preventDefault();
        api.post('auth/login', userInfo)
        .then(response => {
            localStorage.setItem('tk', response?.data.tk);
            localStorage.setItem('id', response?.data.id);
            localStorage.setItem('role', response?.data.role);
            navigate('/books');
        })
        .catch(err => {
            console.log(err);
            setErr(err.response.data);
        })
        reset();
    }

    const goToSignUp = () => {
        navigate('/signup');
    }

    return (
            <Grid container style={{
                minWidth: "100%",
                height: "100vh",
              }}>
                <Grid item xs={0} sm={6} md={6} lg={6} xl={6}>
                    <img src={library} alt="" style={{backgroundSize: 'contain', backgroundRepeat: 'no-repeat', width:'100%', height: '100%'}}/>
                </Grid>

                <Grid item xs={12} sm={6} md={6} lg={6} xl={6} display="flex" justifyContent="center" alignItems="center" minHeight="100vh">
                    <Paper class="paper" style={{width: '350px'}}>
                        <Typography variant="subtitle1">Welcome back</Typography>
                        <Typography variant="h5">Login to your account</Typography>
                        <form onSubmit={handleSubmit(data => sendSignInData(data))}>
                            <TextField {...register("email", {required: "This field is required"})} type="text" label="Email" variant="standard" fullWidth style={{paddingTop: '10px', paddingBottom: '10px'}}/>
                            <Typography color='red' variant="body2">{errors.email?.message}</Typography>
                            <TextField {...register("password", {required: "This field is required", minLength: {value: 8, message: "Min length is 8"}})} type="password" label="Password" variant="standard" fullWidth style={{paddingTop: '10px', paddingBottom: '10px'}}/>
                            <Typography color='red' variant="body2">{errors.password?.message}</Typography>
                            <Typography color='red' variant="body2">{err}</Typography>
                            <Button variant="contained" style={{backgroundColor: "#E1C4AE"}} type="submit">Login</Button>
                        </form>
                        <Button variant="text" size="small" onClick={goToSignUp}>Don't have an account? Sign Up</Button>
                    </Paper>
                </Grid>
            </Grid>
    );
}

export default SignIn;