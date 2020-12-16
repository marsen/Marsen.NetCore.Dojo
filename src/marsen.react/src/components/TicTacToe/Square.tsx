import React from 'react';

type SquareProps = {
  isWin: boolean,
  value: string,
  onClick:(event: React.MouseEvent<HTMLButtonElement,MouseEvent>)=>void 
}

export default function Square(props: SquareProps) {
      return (
        <button 
            className={props.isWin?'square win':'square'}
            onClick={props.onClick}>
                {props.value}
        </button>
      );
  }