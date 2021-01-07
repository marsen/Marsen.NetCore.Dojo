// src/components/TaskList.stories.tsx

import React from 'react';
import { PureTaskList, TaskListProps } from './TaskList';
import { TaskItem, TaskState } from './Task';
import { Story } from '@storybook/react/types-6-0';

export default {
  component: PureTaskList,
  title: 'TaskList',
  decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],
  excludeStories: /.*Data$/,
};

const Template:Story<TaskListProps> = args => <PureTaskList {...args} />

var defaultItem:TaskItem = { 
  id:'1',
  title:'Test Task',
  state:TaskState.Inbox,
  updatedAt: new Date(2018, 0, 1, 9, 0)
};

export const Default = Template.bind({});
Default.args = { 
  tasks: [
    { ...defaultItem, id: '1', title: 'Task 1' },
    { ...defaultItem, id: '2', title: 'Task 2' },
    { ...defaultItem, id: '3', title: 'Task 3' },
    { ...defaultItem, id: '4', title: 'Task 4' },
    { ...defaultItem, id: '5', title: 'Task 5' },
    { ...defaultItem, id: '6', title: 'Task 6' },
  ],
};

export const WithPinnedTasks = Template.bind({});
WithPinnedTasks.args = {  
  tasks: [
    ...Default.args.tasks!.slice(0,5),
    { id: '6', title: 'Task 6 (pinned)', state: TaskState.Pinned },
  ],
};

export const Loading = Template.bind({});
Loading.args = {
  tasks: [],
  loading: true,
};

export const Empty = Template.bind({});
Empty.args = {  
  ...Loading.args,
  loading: false,
};