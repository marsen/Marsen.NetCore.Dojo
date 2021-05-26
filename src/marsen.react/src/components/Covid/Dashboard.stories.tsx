import React from 'react';
import Chart from './Chart'

export default {
  component: Chart,
  title: 'Covid-19 DashBoard',
  decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],
  // Our exports that end in "Data" are not stories.
  excludeStories: /.*Data$/,
};

export const Default = () => <Chart />;