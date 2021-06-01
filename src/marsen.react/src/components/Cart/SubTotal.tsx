// src/components/Cart/SubTotal.tsx/
import React from 'react';

export interface SubTotalProps {
  fontSize?:number|undefined|null,
  subtotal?:number|undefined|null,
  symbol:string
}

export default function SubTotal(props:SubTotalProps) {    
      return (
          <div style={{float:'left'}}>
            <span style={{fontSize:props.fontSize??64}} >{props.subtotal??10} </span>{props.symbol??'$'}
          </div>
      );
}