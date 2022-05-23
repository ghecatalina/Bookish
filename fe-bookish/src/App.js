import React from "react";
import LandingPage from "./components/LandingPage/LandingPage";
import SignIn from "./components/SignInPage/SignIn";
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import SignUp from "./components/SignUpPage/SignUp";
import AddBook from "./components/AddBookPage/AddBook";
import BrowseBooks from "./components/BrowseBooksPage/BrowseBooks";
import BookPage from "./components/BookPage/BookPage";
import BookListPage from "./components/BookListPage/BookListPage";
import NavBar from "./components/NavBar/NavBar";
import MyAccountPage from "./components/MyAccountPage/MyAccountPage";

const App = () => {
    const userId = localStorage.getItem('id');

    return (
            <>
                    <BrowserRouter>
                        <Routes>
                            <Route exact path="/" element={<LandingPage />} />
                            <Route exact path="/signin" element={<SignIn />} />
                            <Route exact path="/signup" element={<SignUp />} />
                            <Route exact path="/addbook" element={<AddBook />} />
                            <Route exact path="/books" element={<BrowseBooks />} />
                            <Route exact path="/books/:id" element={<BookPage />} />
                            <Route exact path="/mybooks" element={<BookListPage listType={"read"}/>} />
                            <Route exact path="/myaccount" element={<MyAccountPage />} />
                        </Routes>
                    </BrowserRouter>
            </>
    );
}

export default App;