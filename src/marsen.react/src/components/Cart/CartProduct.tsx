import * as React from 'react';
import Box from '@material-ui/core/Box'
import SubTotal from './SubTotal';
import Product from './Product';
import NumberSelector from './NumberSelector';

export interface CartProductProps {  
  price:number,  
  Qty:number,
  Name: string,
  Detail: string,
}

export default function CartProduct(props:CartProductProps) {    
      return (
          <Box sx={{float:'left'}}>
              <img alt="mock" src="https://i.imgur.com/iVCU50y.jpg" style={{float:'left'}} width={80} />
              <Product Name={props.Name} Detail={props.Detail} />
              <NumberSelector Qty={props.Qty} />
              <SubTotal subtotal={props.Qty*props.price} symbol={'$$'} fontSize={20} />
          </Box>
      );
}