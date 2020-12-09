// src/components/Task.stories.tsx

import React from 'react';
import Task, { TaskProps } from './Task';
import { Story } from '@storybook/react/types-6-0';

export default {
  component: Task,
  title: 'Task',
};

const Template:Story<TaskProps> = args => <Task {...args} />;

export const Default = Template.bind({});
Default.args = {
  item: {
    id: '1',
    title: 'Test Task',
    state: 'TASK_INBOX',
    updatedAt: new Date(2018, 0, 1, 9, 0),
  },
};

export const Pinned = Template.bind({});
Pinned.args = {
  item: {
    ...Default.args.item,
    state: 'TASK_PINNED',
  },
};

export const Archived = Template.bind({});
Archived.args = {
  item: {
    ...Default.args.item,
    state: 'TASK_ARCHIVED',
  },
};