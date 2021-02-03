import React from 'react';
import SubTotal, { SubTotalProps } from './SubTotal';
import NumberSelector from './NumberSelector';
//import Product from './Product';
import CartProduct, { CartProductProps } from './CartProduct';
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

const CartProductTemplate:Story<CartProductProps> = args => <CartProduct {...args} />;
export const Cart_Product = CartProductTemplate.bind({});
Cart_Product.args = { Qty:3, price:7, Name:'It is Love', Detail:"Something you should know before buy it" }

const SubtotalTemplate:Story<SubTotalProps> = args => <SubTotal {...args} />;
export const Subtotal_Default = SubtotalTemplate.bind({});
Subtotal_Default.args = {};
export const Subtotal_EU = SubtotalTemplate.bind({});
Subtotal_EU.args = { fontSize:100, subtotal:20, symbol:'€' };
export const Subtotal_NTD = SubtotalTemplate.bind({});
Subtotal_NTD.args = { fontSize:10, subtotal:99, symbol:'NTD' };
