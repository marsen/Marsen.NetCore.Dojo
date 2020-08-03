import React from 'react';
import TicTacToe from './TicTacToe';

export default {
  component: TicTacToe,
  title: 'Game',
  decorators: [story => <div style={{ padding: '3rem' }}>{story()}</div>],
  excludeStories: /.*Data$/,
};


export const Default = () => <TicTacToe />;