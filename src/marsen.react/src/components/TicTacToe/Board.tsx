import React from 'react';
import Square from './Square';


type BoardProps={ 
    winLine: number[],
    squares: (string|null)[], 
    onClick: (value: number) => void
}
export default function Board(props:BoardProps) {
    const squareSize = 3
    let squareList = [];

    function renderSquare(i:number) {
        return <Square 
                isWin={props.winLine && props.winLine.includes(i)}
                value={props.squares[i]} 
                onClick={() => props.onClick(i)}
            />;
    };

    for (let i = 0; i < squareSize; i++) {        
        let list = [];
        for (let j = 0; j < squareSize; j++) {
            list.push(<React.Fragment key={j}>{renderSquare(i*squareSize+j)}</React.Fragment>);
        }        
        squareList.push(<div key={i} className="board-row">{list}</div>)
    }
    
    return (<div>{squareList}</div>);    
}

