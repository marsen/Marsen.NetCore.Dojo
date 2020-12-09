import React from 'react';
import Counter from './Counter'

export default {
  component: Counter,
  title: 'Counter',
  decorators: [story => <div style={{ padding: '3rem' }}>{story()}</div>],
  // Our exports that end in "Data" are not stories.
  excludeStories: /.*Data$/,
};

export const Default = () => <Counter />;