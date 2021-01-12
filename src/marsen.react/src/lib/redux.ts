// src/lib/redux.js

// A simple redux store/actions/reducer implementation.
// A true app would be more complex and separated into different files.
import { createStore } from 'redux';
import { TaskItem, TaskState } from '../components/Task/Task';

// The actions are the "names" of the changes that can happen to the store
export const actions = {
  ARCHIVE_TASK: 'ARCHIVE_TASK',
  PIN_TASK: 'PIN_TASK',
};

// The action creators bundle actions with the data required to execute them
export const archiveTask = (id: string) => {
  console.log("archive task:"+id);
  return ({ type: TaskState.Archived, id })
};
export const pinTask = (id: string) => {
  console.log("pin task:"+id);
  return ({ type: TaskState.Pinned, id })
};

// All our reducers simply change the state of a single task.
function taskStateReducer(taskState: TaskState) {
  return (state: { tasks: TaskItem[]; }, action: { id: string; }) => {
    return {
      ...state,
      tasks: state.tasks.map(task =>
        task.id === action.id ? { ...task, state: taskState } : task
      ),
    };
  };
}

// The reducer describes how the contents of the store change for each action
export const reducer = (state: any, action: { id:string; type: TaskState; }) => {
  switch (action.type) {
    case TaskState.Archived:
    case TaskState.Pinned:
      return taskStateReducer(action.type)(state, action);
    default:
      return state;
  }
};

// The initial state of our store when the app loads.
// Usually you would fetch this from a server
const defaultTasks:Array<TaskItem> = [  
  { id: '1', title: 'Something', state: TaskState.Inbox },
  { id: '2', title: 'Something more', state: TaskState.Inbox },
  { id: '3', title: 'Something else', state: TaskState.Inbox },
  { id: '4', title: 'Something again', state: TaskState.Inbox },
];

// We export the constructed redux store
export default createStore(reducer, { tasks: defaultTasks });