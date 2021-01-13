// src/App.js

import React from 'react';
import { Provider } from 'react-redux';
import store from './lib/jsRedux';
import InboxScreen from './components/jsTask/InboxScreen';
import './index.css';

function App() {
  return (
    <Provider store={store}>
      <InboxScreen />
    </Provider>
  );
}
export default App;
