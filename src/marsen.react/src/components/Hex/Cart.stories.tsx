import React from 'react';
import PropDemo from "./Prop";
import Product,{ProductCarousel, ProductCard} from './Product';
import App from './App';

export default {
  component: App,
  title: 'Hex Cart',
  decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],
  // Our exports that end in "Data" are not stories.
  excludeStories: /.*Data$/,
};



export const Default = () => <App />
export const ThePropDemo = () => <PropDemo />
export const TheProductCard = () => <ProductCard name="Pizza" description="pizza 的樣子" price="250" cartItem setCartItem picture="https://images.unsplash.com/photo-1506354666786-959d6d497f1a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=60" />
export const TheProductCarousel = () => <ProductCarousel />
export const TheProduct = () => <Product cartItem setCartItem />

