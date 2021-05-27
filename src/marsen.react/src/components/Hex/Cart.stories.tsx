import React from 'react';
import HexCart from './HexCart';
import PropDemo from "./Prop";

export default {
  component: HexCart,
  title: 'Hex Cart',
  decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],
  // Our exports that end in "Data" are not stories.
  excludeStories: /.*Data$/,
};

export const Default = () => <HexCart />
export const ThePropDemo = () => <PropDemo />

