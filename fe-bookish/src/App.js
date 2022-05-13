import React from "react";
import LandingPage from "./components/LandingPage/LandingPage";
import SignIn from "./components/SignInPage/SignIn";
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import SignUp from "./components/SignUpPage/SignUp";
import AuthProvider from "./context/authContext/AuthProvider";
import AddBook from "./components/AddBookPage/AddBook";
import BooksProvider from "./context/booksContext/BooksProvider";
import BrowseBooks from "./components/BrowseBooksPage/BrowseBooks";
import CategoriesProvider from "./context/categoriesContext/CategoriesProvider";
import BookDetails from "./components/BookPage/BookDetails";
import ReviewsProvider from "./context/reviewsContext/ReviewsProvider";
import BookPage from "./components/BookPage/BookPage";
import BookListPage from "./components/BookListPage/BookListPage";
import NavBar from "./components/NavBar/NavBar";

const App = () => {
    const userId = localStorage.getItem('id');

    return (
        <AuthProvider>
            <BooksProvider>
                <CategoriesProvider>
                    <ReviewsProvider>
                    <BrowserRouter>
                        {!userId && <NavBar />}
                        <Routes>
                            <Route exact path="/" element={<LandingPage />} />
                            <Route exact path="/signin" element={<SignIn />} />
                            <Route exact path="/signup" element={<SignUp />} />
                            <Route exact path="/addbook" element={<AddBook />} />
                            <Route exact path="/books" element={<BrowseBooks />} />
                            <Route exact path="/books/:id" element={<BookPage />} />
                            <Route exact path="/mybooks" element={<BookListPage listType={"read"}/>} />
                        </Routes>
                    </BrowserRouter>
                    </ReviewsProvider>
                </CategoriesProvider>
            </BooksProvider>
        </AuthProvider>
    );
}

export default App;