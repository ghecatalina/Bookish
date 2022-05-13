import { GET_BOOK, ADD_BOOK } from "../constants/actionTypes";

const booksReducer = (books = [], action) => {
    switch (action.type) {
        case GET_BOOK:
            return action.payload;
        case ADD_BOOK:
            return [...books, action.payload];
        default:
            return books;
    }
}

export default booksReducer;