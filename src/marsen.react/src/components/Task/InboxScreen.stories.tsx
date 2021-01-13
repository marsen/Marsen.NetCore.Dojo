 //src/components/InboxScreen.stories.js

import React from 'react';
import { Provider } from 'react-redux';
import { InboxScreenProps, PureInboxScreen } from './InboxScreen';
import { Story } from '@storybook/react/types-6-0';
import store from '../../lib/redux'

export default {
  component: PureInboxScreen,
  decorators: [(story: () => React.ReactNode) => <Provider store={store}>{story()}</Provider>],
  title: 'InboxScreen',
};

const Template:Story<InboxScreenProps> = args => <PureInboxScreen {...args} />;

export const Default = Template.bind({});

export const Error = Template.bind({});
Error.args = {
  error: 'Something',
};