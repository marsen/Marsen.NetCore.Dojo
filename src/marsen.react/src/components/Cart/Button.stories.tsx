import React from 'react';
import SubTotal, { SubTotalProps } from './SubTotal';
import NumberSelector from './NumberSelector';
//import Product from './Product';
import CartProduct from './CartProduct';
import Button from '@material-ui/core/Button';
import { Story } from '@storybook/react/types-6-0'


export default {
  component: Button,
  title: 'Cart',
  decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],  
  excludeStories: /.*Data$/,
};

export const Number_Selector = () => <NumberSelector />
//export const Cart_Product = () => <Product />
export const Cart_Product = () => <CartProduct />

const SubtotalTemplate:Story<SubTotalProps> = args => <SubTotal {...args} />;
export const Subtotal_Default = SubtotalTemplate.bind({});
Subtotal_Default.args = {};
export const Subtotal_EU = SubtotalTemplate.bind({});
Subtotal_EU.args = { fontSize:100, subtotal:20, symbol:'Э' };
export const Subtotal_NTD = SubtotalTemplate.bind({});
Subtotal_NTD.args = { fontSize:10, subtotal:99, symbol:'NTD' };
