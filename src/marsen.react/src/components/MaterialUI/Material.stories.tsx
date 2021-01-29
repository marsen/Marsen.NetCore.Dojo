import React from 'react';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import { ThemeProvider } from '@material-ui/core';
import App from './App';
import theme from './theme';

export default {
  component: Button,
  title: 'Material',
  decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],
  // Our exports that end in "Data" are not stories.
  excludeStories: /.*Data$/,
};

export const Default = () => <Button variant="contained" color="primary">你好，世界</Button>

export const Copyright = () =><ThemeProvider theme={theme}>
    {/* CssBaseline kickstart an elegant, consistent, and simple baseline to build upon. */}
    <CssBaseline />
    <App />
  </ThemeProvider>;
