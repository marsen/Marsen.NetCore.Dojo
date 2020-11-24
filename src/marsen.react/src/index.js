import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import HelloWorld from './components/HelloWorld';
import * as TaskList from './components/Task/TaskList';

ReactDOM.render(
  <React.StrictMode>
  <HelloWorld name="白金之星" />
  <br />
  <TaskList.PureTaskList />
  <br />
  <App />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
