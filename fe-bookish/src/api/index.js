import axios from "axios";

export const api = axios.create({ baseURL: 'https://localhost:7198/api/' });

export const signIn = (formData) => api.post('auth/login', formData);
export const signUp = (formData) => api.post('auth/register', formData);

export const getCategories = () => api.get('v1/Category');

export const getBookById = (id) => api.get(`v1/Books/${id}`);
export const addBook = (formData) => api.post('v1/Books', formData);

export const addReview = (formData) => api.post('v1/Reviews', formData);
export const getReviews = () => api.get('v1/Reviews');
export const updateReview = (id, formData) => api.put(`v1/Reviews/${id}`, formData);
export const deleteReview = (id) => api.delete(`v1/Reviews/${id}`);

export const getIfInAnyList = (formData) => api.post('v1/BookLists/ifany', formData);
export const addToBookList = (formData) => api.post('v1/BookLists/addBook', formData);

export const getProfilePicure = (id) => api.get(`v1/Users/image/${id}`);