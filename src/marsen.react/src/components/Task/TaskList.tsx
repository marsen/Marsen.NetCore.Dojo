import React from 'react';
import Task, { TaskItem, TaskState } from './Task';
import { connect } from 'react-redux';
import { archiveTask, pinTask } from '../../lib/redux';

export type TaskListProps = {
  loading?:boolean,
  tasks: TaskItem[],
  onPinTask: (id:string)=>void,
  onArchiveTask:(id:string)=>void
}

export function PureTaskList(props:TaskListProps) {

  const LoadingRow = (
    <div className="loading-item">
      <span className="glow-checkbox" />
      <span className="glow-text">
        <span>Loading</span> <span>cool</span> <span>state</span>
      </span>
    </div>
  );

  if (props.loading) {    
    return (
      <div className="list-items">
        {LoadingRow}
        {LoadingRow}
        {LoadingRow}
        {LoadingRow}
        {LoadingRow}
        {LoadingRow}
      </div>
    );
  }
  
  if (props.tasks === undefined || props.tasks.length === 0) {
    return (
        <div className="list-items">
            <div className="wrapper-message">
                <span className="icon-check" />
                <div className="title-message">You have no tasks</div>
                <div className="subtitle-message">Sit back and relax</div>
            </div>
        </div>
    );
  }

  return (
    <div className="list-items">
      {props.tasks.map(item => (
        <Task key={item.id} item={item} onPinTask={props.onPinTask} onArchiveTask={props.onArchiveTask}/>
      ))}
    </div>
  );
}

export default connect(
  (props:TaskListProps) => ({
    tasks: props.tasks.filter((t: { state: TaskState; }) => t.state === TaskState.Inbox || t.state === TaskState.Pinned ),
  }),
  dispatch => ({
    onArchiveTask: (id: string) => dispatch(archiveTask(id)),
    onPinTask: (id: string) => dispatch(pinTask(id)),
  })
)(PureTaskList);