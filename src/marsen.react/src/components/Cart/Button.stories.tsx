import React from 'react';
import Button from '@material-ui/core/Button';
import NumberSelector from './NumberSelector';
import SubTotal from './SubTotal';


export default {
  component: Button,
  title: 'Cart',
  decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],
  // Our exports that end in "Data" are not stories.
  excludeStories: /.*Data$/,
};

export const Number_Selector = () => <NumberSelector />
export const Sub_Total = () => <SubTotal />
