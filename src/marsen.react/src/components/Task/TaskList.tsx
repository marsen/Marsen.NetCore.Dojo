import React from 'react';
import Task from './Task';
import { connect } from 'react-redux';
import { archiveTask, pinTask } from '../../lib/redux';

type TaskListProps = {
  loading:boolean,
  tasks: any[],
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

PureTaskList.defaultProps = {
  loading: false,
};

export default connect(
  ({ tasks }) => ({
    tasks: tasks.filter((t: { state: string; }) => t.state === 'TASK_INBOX' || t.state === 'TASK_PINNED'),
  }),
  dispatch => ({
    onArchiveTask: (id: any) => dispatch(archiveTask(id)),
    onPinTask: (id: any) => dispatch(pinTask(id)),
  })
)(PureTaskList);