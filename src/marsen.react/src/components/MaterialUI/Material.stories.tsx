import React from 'react';
import Button from '@material-ui/core/Button';

export default {
  component: Button,
  title: 'Material',
  decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],
  // Our exports that end in "Data" are not stories.
  excludeStories: /.*Data$/,
};

export const Default = () => <Button variant="contained" color="primary">你好，世界</Button>