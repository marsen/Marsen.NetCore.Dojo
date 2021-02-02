import React from 'react';
import { CSSProperties } from '@material-ui/core/styles/withStyles';

interface ProductProps {
    Name:string,
    Detail:string
}

const style : CSSProperties =  { 
  width: '240px',
  float: 'left'
};

export default function Product(props:ProductProps) { 
      return (
          <div style={style}>
            <span>{props.Name}</span>
            <details>
                <summary> More...</summary>
                {props.Detail}
            </details>
          </div>
      );
}