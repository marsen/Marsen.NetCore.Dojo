import React from 'react';
import Board from './Board';

export default class TicTacToe extends React.Component {
    render() {
      return (
        <div>
            <div className="game">
            <div className="game-board">
                <Board />
            </div>
            <div className="game-info">
                <div>{/* status */}</div>
                <ol>{/* TODO */}</ol>
            </div>
            </div>
            <div>Mⓐⓡsen</div>
        </div>
      );
    }
  }
