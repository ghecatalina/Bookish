import React from 'react';
import ReactDOM from 'react-dom';
import {createRoot} from 'react-dom/client';
import { Provider } from 'react-redux';
import { store } from './store/store';

import App from './App';

//const root = ReactDOM.createRoot(document.getElementById('root'));
const rootElement = document.getElementById('root');
const root = createRoot(rootElement);

root.render(
    <Provider store={store}>
        <App />
    </Provider>
);
