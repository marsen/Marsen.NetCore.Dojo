import React from 'react';
import { CSSProperties } from '@material-ui/core/styles/withStyles';

const style : CSSProperties =  { 
  width: '240px',
  float: 'left'
};

export default function Product(prop:any) {    
      return (
          <div style={style}>
            <span>Product Name </span>
            <details>
                <summary> Product Name</summary>
                Something small enough to escape casual notice.
            </details>
          </div>
      );
}