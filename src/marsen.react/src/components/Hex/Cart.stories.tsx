import React from 'react';
import HexCart from './HexCart';
import PropDemo from "./Prop";
import ProductCard from "./ProductCard"
import data from "./data/food.json"
import ProductCarousel from './ProductCarousel';
import Product from './Product';

export default {
  component: HexCart,
  title: 'Hex Cart',
  decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],
  // Our exports that end in "Data" are not stories.
  excludeStories: /.*Data$/,
};



export const Default = () => <HexCart />
export const ThePropDemo = () => <PropDemo />
export const TheProductCard = () => <ProductCard name="Pizza" description="pizza 的樣子" price="250" cartItem setCartItem picture="https://images.unsplash.com/photo-1506354666786-959d6d497f1a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=60" />
export const TheProductCarousel = () => <ProductCarousel />
export const TheProduct = () => <Product cartItem setCartItem />

