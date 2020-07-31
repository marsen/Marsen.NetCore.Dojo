import React from 'react';
import Square from './Square';
import Board from './Board';
import TicTacToe from './TicTacToe';

export default {
  component: TicTacToe,
  title: 'Game',
  decorators: [story => <div style={{ padding: '3rem' }}>{story()}</div>],
  excludeStories: /.*Data$/,
};

export const Default = () => <Square />;
export const TheBoard = () => <Board />;
export const Game = () => <TicTacToe />;