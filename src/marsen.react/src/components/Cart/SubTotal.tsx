import { CSSProperties } from '@material-ui/core/styles/withStyles';
import React from 'react';

const style : CSSProperties =  { 
  float:'left'
};

export default function SubTotal(prop:any) {    
      return (
          <div style={style}>
            <span style={{fontSize:64}} >{prop.subtotal??10} </span>{prop.symbol??'$'}
          </div>
      );
}