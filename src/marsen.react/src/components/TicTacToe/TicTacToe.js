import React from 'react';
import Board from './Board';

export default class TicTacToe extends React.Component {
    constructor(props){
        super(props);
        this.state = {
            squares: Array(9).fill(null),
            xIsNext: true,
            isWin:false,
        };
    }

    handleClick(i) {
        const winner  = calculateWinner(this.state.squares);
        if(winner){
            alert('game is over');
            return;
        }
        const squares = this.state.squares.slice();
        if(!!squares[i])
        {
            alert('error');   
            return;
        }else{
            squares[i] = this.state.xIsNext ? 'X' : 'O' ;
        }
        this.setState({
            squares: squares,
            xIsNext: !this.state.xIsNext
        });
    }

    render() {
      return (
        <div>
            <div className="game">
            <div className="game-board">
                <Board 
                    onClick={(i)=>this.handleClick(i)} 
                    squares={this.state.squares} />
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