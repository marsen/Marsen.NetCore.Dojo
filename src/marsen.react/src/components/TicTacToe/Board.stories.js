import React from 'react';
import Board from './Board';

export default {
  component: Board,
  title: 'Game',
  decorators: [story => <div style={{ padding: '3rem' }}>{story()}</div>],
  excludeStories: /.*Data$/,
};


export const Default = () => <Board />;