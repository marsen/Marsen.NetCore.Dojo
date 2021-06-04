
import * as React from 'react';
import {Box,Button,Container} from '@material-ui/core';

export default {
    title: 'Material/Components/Layout',
    decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],
    // Our exports that end in "Data" are not stories.
    excludeStories: /.*Data$/,
  };


export const Boxes = () => 
    <>
    <Box component="span" sx={{ p: 2, border: '1px dashed grey' }}>
      <Button>Save</Button>
    </Box>
    <Box
      sx={{
        width: 250,
        height: 250,
        bgcolor: 'primary.dark',
        '&:hover': {
          backgroundColor: 'primary.main',
          opacity: [0.9, 0.8, 0.7],
        },
      }}
    />
    </>;

export const Containers = () => 
<>
  <Container maxWidth="sm" sx={{ bgcolor: 'warning.main' }} >Container</Container>
  <Container fixed sx={{ bgcolor: 'success.main' }}> fixed </Container>
</>;