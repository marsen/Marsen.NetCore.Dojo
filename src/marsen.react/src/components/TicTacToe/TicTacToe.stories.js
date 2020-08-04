import React from 'react';
import TicTacToe from './TicTacToe';
import Square from './Square';

export default {
  component: TicTacToe,
  title: 'Game',
  decorators: [story => <div style={{ padding: '3rem' }}>{story()}</div>],
  excludeStories: /.*Data$/,
};


export const Default = () => <TicTacToe />;
export const TheSquare =() => <Square win />;