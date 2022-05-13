import { configureStore } from '@reduxjs/toolkit';
import authReducer from '../reducers/auth';
import booksReducer from '../reducers/books';
import categoriesReducer from '../reducers/categories';
import ifAnyListReducer from '../reducers/ifanylist';
import profilePictureReducer from '../reducers/profilePicture';
import reviewsReducer from '../reducers/reviews';

export const store = configureStore({
  reducer: {
      auth: authReducer,
      categories: categoriesReducer,
      books: booksReducer,
      reviews: reviewsReducer,
      ifAny: ifAnyListReducer,
      profilePicture: profilePictureReducer
  },
})