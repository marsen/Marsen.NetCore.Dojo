import React from 'react';
import Square from './Square';

export default class Board extends React.Component {
    constructor(props){
        super(props);
        this.state = {
            squares: Array(9).fill(null),
            xIsNext: true,
            isWin:false,
        };
    }

    renderSquare(i) {
        return <Square 
            value={this.state.squares[i]} 
            onClick={() => this.handleClick(i)}
            />;
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
            squares[i] = this.nextPlayer();            
        }
        this.setState({
            squares: squares,
            xIsNext: !this.state.xIsNext
        });
    }
    
    nextPlayer(){
        return this.state.xIsNext ? 'X' : 'O' ;
    }
    
    
    
    render() {
        const winner  = calculateWinner(this.state.squares);
        let status;
        if(winner){
            status = `winner ${winner}`;
        }else{
            status = `Next player: ${this.nextPlayer()}`;
        }

        return (
            <div>
                <div className="status">{status}</div>
                <div className="board-row">
                    {this.renderSquare(0)}{this.renderSquare(1)}{this.renderSquare(2)}
                </div>
                <div className="board-row">
                    {this.renderSquare(3)}{this.renderSquare(4)}{this.renderSquare(5)}
                </div>
                <div className="board-row">
                    {this.renderSquare(6)}{this.renderSquare(7)}{this.renderSquare(8)}
                </div>
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