// src/components/InboxScreen.stories.js

import React from 'react';
import { Provider } from 'react-redux';
import { PureInboxScreen } from './InboxScreen';
import store from '../../lib/jsRedux';

// A super-simple mock of a redux store
/*
const store = {
  getState: () => {
    return {
      tasks: TaskListStories.Default.args.tasks,
    };
  },
  subscribe: () => 0,
  dispatch: action('dispatch'),
};
*/


export default {
  component: PureInboxScreen,
  decorators: [story => <Provider store={store}>{story()}</Provider>],
  title: 'InboxScreen',
};

const Template = args => <PureInboxScreen {...args} />;

export const Default = Template.bind({});

export const Error = Template.bind({});
Error.args = {
  error: 'Something',
};;