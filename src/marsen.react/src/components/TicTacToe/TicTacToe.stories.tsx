import React from 'react';

import Square from './Square';
import TicTacToe from './TicTacToe';
import '../../dist/tictactoe.css'

export default {
  component: TicTacToe,
  title: 'Game',
  decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],
  excludeStories: /.*Data$/,
};


export const Default = () => <TicTacToe />;
export const TheSquare = () => <Square />;
export const TheWinSquare = () => <Square isWin />;