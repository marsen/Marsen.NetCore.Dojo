// src/components/Task.js

import React from 'react';


function Task(props:Props) {
  return (
    <div className={`list-item ${props.task.state}`}>
      <label className="checkbox">
        <input
          type="checkbox"
          defaultChecked={props.task.state === 'TASK_ARCHIVED'}
          disabled={true}
          name="checked"
        />
        <span className="checkbox-custom" onClick={() => props.onArchiveTask(props.task.id)} />
      </label>
      <div className="title">
        <input type="text" value={props.task.title} readOnly={true} placeholder="Input title" />
      </div>

      <div className="actions" onClick={event => event.stopPropagation()}>
        {props.task.state !== 'TASK_ARCHIVED' && (
          // eslint-disable-next-line jsx-a11y/anchor-is-valid
          <a onClick={() => props.onPinTask(props.task.id)}>
            <span className={`icon-star`} />
          </a>
        )}
      </div>
    </div>
  );
}

interface Props {
  task:{
    id: string,
    title: string,
    state: string
  },
  onArchiveTask: (id:string)=>void,
  onPinTask: (id:string)=>void
}

enum TaskState {
  Archived = "TASK_ARCHIVED"
}

export default Task;