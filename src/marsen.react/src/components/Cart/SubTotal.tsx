// src/components/Cart/SubTotal.tsx/
import React from 'react';
import { CSSProperties } from '@material-ui/core/styles/withStyles';

export interface SubTotalProps {
  fontSize?:number|undefined|null,
  subtotal?:number|undefined|null,
  symbol:string
}

const style : CSSProperties =  { 
  float:'left'
};

export default function SubTotal(props:SubTotalProps) {    
      return (
          <div style={style}>
            <span style={{fontSize:props.fontSize??64}} >{props.subtotal??10} </span>{props.symbol??'$'}
          </div>
      );
}