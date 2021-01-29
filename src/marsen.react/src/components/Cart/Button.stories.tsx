import React from 'react';
import Button from '@material-ui/core/Button';
//import { ArrowDropUp, ArrowDropDown } from '@material-ui/icons';
import QtySelector from './QtySelector'


export default {
  component: Button,
  title: 'Cart',
  decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],
  // Our exports that end in "Data" are not stories.
  excludeStories: /.*Data$/,
};

/*
export const CheckOut = () => <Button variant="contained" color="primary">Check Out</Button>
export const Back = () => <Button variant="contained">Back</Button>
export const Exit = () => <Button>✖</Button>
export const Up = () => <Button><ArrowDropUp  /></Button>
export const Down = () => <Button><ArrowDropDown /></Button>
*/
export const Qty = () => <QtySelector />
