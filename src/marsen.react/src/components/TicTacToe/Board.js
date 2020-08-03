import React from 'react';
import Square from './Square';

export default function Board(props) {
    const squareSize = 3
    let squareList = [];

    function renderSquare(i) {
        return <Square 
                value={props.squares[i]} 
                onClick={() => props.onClick(i)}
            />;
    };

    for (let i = 0; i < squareSize; i++) {
        squareList.push(<div key={i} className="board-row">{renderSquare(i*squareSize)}{renderSquare(i*squareSize+1)}{renderSquare(i*squareSize+2)}</div>)
    }
    
    return (<div>{squareList}</div>);
    
}

