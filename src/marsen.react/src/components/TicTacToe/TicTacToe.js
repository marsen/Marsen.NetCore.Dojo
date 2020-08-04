import React from 'react';
import Board from './Board';

export default class TicTacToe extends React.Component {
    constructor(props){
        super(props);
        this.state = {
            history:[{
                squares: Array(9).fill(null),
                position:-1
            }],
            stepNumber:0,
            xIsNext: true,            
            isWin:false,
            historyAsc: true,
        };
    }

    handleClick(i) {
        const history = this.state.history.slice(0,this.state.stepNumber + 1);   
        const current = history[history.length - 1]
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
            history: history.concat([
                {
                    squares: squares,
                    position: '('+ parseInt(i / 3 + 1)+','+  parseInt(i % 3 + 1)+')'
                }
            ]),
            stepNumber: history.length,
            xIsNext: !this.state.xIsNext
        });
    }

    jumpTo(step){
        this.setState({
            stepNumber: this.selectedStep(step),
            xIsNext: (this.selectedStep(step) % 2) === 0,
        });
    }

    render() {
        const history = this.state.history ;                 
        const current = history[this.state.stepNumber];
              
        return (
            <div>
                <div className="game">
                <div className="game-board">
                    <Board 
                        onClick={(i)=>this.handleClick(i)} 
                        squares={current.squares} />
                </div>
                <div className="game-info">
                    <div className="status" >{this.status()} </div>
                    <button onClick={()=> this.sortMoves()}>SORT</button>                    
                    <ol>{this.moves()}</ol>
                </div>
                </div>
                <div>Mⓐⓡsen</div>
            </div>
        );
    }

    status() {
        const history = this.state.history ;                 
        const current = history[this.state.stepNumber];
        const winner  = calculateWinner(current.squares);
        let status;
        if (winner) {
            status = `Winner ${winner}`;
        }
        else {
            status = `Next player: ${this.nextPlayer()}`;
        }
        return status;
    }
    
    moves(){
        const history = this.state.history ;                                       
        const moves = (this.state.historyAsc ? [...history] : [...history].reverse())
                    .map((step,move)=>this.generateMovesList(step,move));
                    return moves;
    }

    generateMovesList(step,move) {        
            const desc = step.position !== -1 ?
            'Go to move #' + move + step.position :
            'Go to game start';         
            
            return (
                <li key={move}>
                    <button className={(move === this.selectedStep(this.state.stepNumber)) ? "type-bold" : ""} onClick={() => this.jumpTo(move)}>{desc}</button>
                </li>
            );
    }

    selectedStep(step) {
        return this.state.historyAsc ? step : this.state.history.length - step - 1;
    }

    sortMoves(){
       this.setState({
           historyAsc: !this.state.historyAsc,
       });
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