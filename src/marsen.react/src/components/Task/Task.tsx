// src/components/Task.tsx
import React from 'react';

export enum TaskState{
  Inbox = 'TASK_INBOX',
  Pinned = 'TASK_PINNED',
  Archived = 'TASK_ARCHIVED'
}

export interface TaskProps {
  item:TaskItem,
  onArchiveTask: (id:string) => void,
  onPinTask: (id:string) => void
}

export class TaskItem{
  id: string = ''
  title: string = ''
  state: TaskState = TaskState.Inbox
  updatedAt?: Date
}

export default function Task(props:TaskProps) {
  return (
    <div className={`list-item ${props.item.state}`}>
      <label className="checkbox">
        <input
          type="checkbox"
          defaultChecked={props.item.state === TaskState.Archived}
          disabled={true}
          name="checked"
        />
        <span className="checkbox-custom" onClick={() => props.onArchiveTask(props.item.id)} />
      </label>
      <div className="title">
        <input type="text" value={props.item.title} readOnly={true} placeholder="Input title" />
      </div>

      <div className="actions" onClick={event => event.stopPropagation()}>
        {props.item.state !== TaskState.Archived && (
          // eslint-disable-next-line jsx-a11y/anchor-is-valid
          <a onClick={() => props.onPinTask(props.item.id)}>
            <span className={`icon-star`} />
          </a>
        )}
      </div>
    </div>
  );
}