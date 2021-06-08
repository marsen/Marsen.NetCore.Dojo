// src/components/Task.stories.tsx
import { Story } from '@storybook/react/types-6-0';
import React from 'react';
import Task, { TaskItem, TaskProps, TaskState } from './Task';


export default {  component: Task,
  title: 'Task',
};

const Template:Story<TaskProps> = args => <Task {...args} />;

var defaultItem:TaskItem = { 
  id:'1',
  title:'Test Task',
  state:TaskState.Inbox,
  updatedAt: new Date(2018, 0, 1, 9, 0),
};

export const Default = Template.bind({});
Default.args = { item: defaultItem, }

export const Pinned = Template.bind({});
var pinnedItem = Copy(defaultItem);
pinnedItem.state=TaskState.Pinned
Pinned.args = { item: pinnedItem };

export const Archived = Template.bind({});
var archivedItem = Copy(defaultItem);
archivedItem.state=TaskState.Archived;
Archived.args = {item: archivedItem};

function Copy(obj:any) {  
  return Object.assign({},obj);
}