import React from 'react';

type SquareProps = {
  isWin?: boolean | undefined,
  value?: string | null ,
  onClick?:(event: React.MouseEvent<HTMLButtonElement,MouseEvent>)=>void | undefined
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