import React from 'react';
import Board from './Board';

export default class TicTacToe extends React.Component {
    constructor(props){
        super(props);
        this.state = {
            history:[{
                squares: Array(9).fill(null)
            }],
            xIsNext: true,
            isWin:false,
        };
    }

    handleClick(i) {
        const current = this.state.history[this.state.history.length - 1]
        const winner  = calculateWinner(current.squares);
        if(winner){
            alert('game is over');
            return;
        }
        const squares = current.squares.slice();
        if(!!squares[i])
        {
            alert('error');   
            return;
        }else{
            squares[i] = this.nextPlayer();
        }
        this.setState({
            history: this.state.history.concat([{
                squares: squares,
            }]),
            xIsNext: !this.state.xIsNext
        });
    }

    render() {
        const current = this.state.history[this.state.history.length - 1];
        const winner  = calculateWinner(current.squares);
        let status;
        if(winner){
            status = `Winner ${winner}`;
        }else{
            status = `Next player: ${this.nextPlayer()}`;
        }

      return (
        <div>
            <div className="game">
            <div className="game-board">
                <Board 
                    onClick={(i)=>this.handleClick(i)} 
                    squares={current.squares} />
            </div>
            <div className="game-info">
                <div className="status" >{status}</div>
                <ol>{/* TODO */}</ol>
            </div>
            </div>
            <div>Mⓐⓡsen</div>
        </div>
      );
    }

    nextPlayer() {
        return this.state.xIsNext ? 'X' : 'O';
    }
  }

  function calculateWinner(squares) {
    const lines = [
        [0, 1, 2],
        [3, 4, 5],
        [6, 7, 8],
        [0, 3, 6],
        [1, 4, 7],
        [2, 5, 8],
        [0, 4, 8],
        [2, 4, 6],
    ];
    for (let i = 0; i < lines.length; i++) {
        const [a, b, c] = lines[i];
        if (squares[a] && squares[a] === squares[b] && squares[a] === squares[c]) {            
            return squares[a];
        }
    }
    return null;
}