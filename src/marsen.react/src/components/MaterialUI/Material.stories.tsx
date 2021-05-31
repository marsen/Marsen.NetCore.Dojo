import React from 'react';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import { ThemeProvider } from '@material-ui/core';
import App from './Copyright';
import theme from './theme';
import Album from './templates/album/Album';
//import Blog from './templates/blog/Blog';
import Checkout from './templates/checkout/Checkout';
import Dashboard from './templates/dashboard/Dashboard';
import Pricing from './templates/pricing/Pricing';
import SignIn from './templates/sign-in/SignIn';
import SignInSide from './templates/sign-in-side/SignInSide';
import SignUp from './templates/sign-up/SignUp';
import StickFooter from './templates/sticky-footer/StickyFooter';


export default {
  component: Button,
  title: 'Material',
  decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],
  // Our exports that end in "Data" are not stories.
  excludeStories: /.*Data$/,
};

export const Default = () => <Button variant="contained" color="primary">你好，世界</Button>;

export const Copyright = () =><ThemeProvider theme={theme}>
    {/* CssBaseline kickstart an elegant, consistent, and simple baseline to build upon. */}
    <CssBaseline />
    <App />
  </ThemeProvider>;


export const TheAlbum = () => <Album />;
//export const TheBlog = () => <Blog />;
export const TheCheckout = () => <Checkout />;
export const TheDashboard = () => <Dashboard />;
export const ThePricing = () => <Pricing />;
export const TheSingIn = () => <SignIn />;
export const TheSingInSide = () => <SignInSide />;
export const TheSignUp = () => <SignUp />;
export const TheStickFooter = () => <StickFooter />;