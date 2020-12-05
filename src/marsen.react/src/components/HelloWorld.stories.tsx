import React from 'react';
import HelloWorld from './HelloWorld'

export default {
  component: HelloWorld,
  title: 'HelloWord',
  decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],
  // Our exports that end in "Data" are not stories.
  excludeStories: /.*Data$/,
};

export const Default = () => <HelloWorld />;
export const HelloMark = () => <HelloWorld name="Mark" />;
export const HelloTaylor = () => <HelloWorld name="Taylor" />;