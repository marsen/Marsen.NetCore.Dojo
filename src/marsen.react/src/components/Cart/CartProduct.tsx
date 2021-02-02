import React from 'react';
import SubTotal from './SubTotal';
import Product from './Product';
import { Box } from '@material-ui/core';
import { CSSProperties } from '@material-ui/core/styles/withStyles';
import NumberSelector from './NumberSelector';

const style : CSSProperties =  { 
  float:'left',  
};


export interface CartProductProps {  
  subtotal:number,  
}

const temp = {
      "Id": "Product-cc59829e-d2d9-463f-b503-248f98934584",
      "Name": "Gutter Oil",
      "Detail": "the oil",
      "Picture": "yyy.jpg",
      "SubTotal": "14",
      "Qty": "2",
      "Price": "10"
    }

export default function CartProduct(props:CartProductProps) {    
      return (
          <Box style={style} >
              <img alt="mock" src="https://i.imgur.com/iVCU50y.jpg" style={style} width={80} />
              <Product />
              <NumberSelector />
              <SubTotal subtotal={props.subtotal}  symbol={'$$'} fontSize={20} />
          </Box>
      );
}