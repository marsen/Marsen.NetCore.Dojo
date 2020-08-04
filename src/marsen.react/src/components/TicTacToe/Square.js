import React from 'react';

export default function Square(props) {
      return (
        <button 
            className={props.isWin?'square win':'square'}
            onClick={props.onClick}>
                {props.value}
        </button>
      );
  }