import React from "react";
import LandingPage from "./components/LandingPage/LandingPage";
import SignIn from "./components/SignInPage/SignIn";
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import SignUp from "./components/SignUpPage/SignUp";
import AuthProvider from "./context/authContext/AuthProvider";
import AddBook from "./components/AddBookPage/AddBook";
import BooksProvider from "./context/booksContext/BooksProvider";
import BrowseBooks from "./components/BrowseBooksPage/BrowseBooks";

const App = () => {
    return (
        <AuthProvider>
            <BooksProvider>
                <BrowserRouter>
                    <Routes>
                        <Route exact path="/" element={<LandingPage />} />
                        <Route exact path="/signin" element={<SignIn />} />
                        <Route exact path="/signup" element={<SignUp />} />
                        <Route exact path="/addbook" element={<AddBook />} />
                        <Route exact path="/books" element={<BrowseBooks />} />
                    </Routes>
                </BrowserRouter>
            </BooksProvider>
        </AuthProvider>
    );
}

export default App;