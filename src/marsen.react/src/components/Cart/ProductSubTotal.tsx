import React from 'react';
import SubTotal from './SubTotal';
import Product from './Product';
import { Box } from '@material-ui/core';
import { CSSProperties } from '@material-ui/core/styles/withStyles';
import NumberSelector from './NumberSelector';

const style : CSSProperties =  { 
  float:'left',  
};


export default function ProductSubTotal(prop:any) {    
      return (
          <Box style={style} >
              <img alt="mock" src="https://i.imgur.com/iVCU50y.jpg" style={style} width={80} />
              <Product />
              <NumberSelector />
              <SubTotal />
          </Box>
      );
}