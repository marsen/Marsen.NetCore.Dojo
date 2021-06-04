
import * as React from 'react';
import { experimentalStyled as styled } from '@material-ui/core/styles';
import { Box,Button,Container,Grid } from '@material-ui/core';
import FormLabel from '@material-ui/core/FormLabel';
import FormControl from '@material-ui/core/FormControl';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import RadioGroup from '@material-ui/core/RadioGroup';
import Radio from '@material-ui/core/Radio';
import Paper from '@material-ui/core/Paper';

export default {
    title: 'Material/Components/Layout',
    decorators: [(story: () => React.ReactNode) => <div style={{ padding: '3rem' }}>{story()}</div>],
    // Our exports that end in "Data" are not stories.
    excludeStories: /.*Data$/,
  };


export const Boxes = () => 
    <>
    Box with Button:
    <Box component="span" sx={{ p: 2, border: '1px dashed grey' }}>
      <Button>Save</Button>
    </Box>
    Box with sx:
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
  Small Container:
  <Container maxWidth="sm" sx={{ bgcolor: 'warning.main' }} >Container</Container>
  Fixed Container:
  <Container fixed sx={{ bgcolor: 'success.main' }}> fixed </Container>
</>;

const Item = styled(Paper)(({ theme }) => ({
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: 'center',
  color: theme.palette.text.secondary,
}));

let BasicGrid = () =>(<Grid container spacing={2}>
  <Grid item xs={8}>
    <Item sx={{bgcolor:'yellow'}} >xs=8</Item>
  </Grid>
  <Grid item xs={4}>
    <Item>xs=4</Item>
  </Grid>
  <Grid item xs={4}>
    <Item>xs=4</Item>
  </Grid>
  <Grid item xs={8}>
    <Item sx={{bgcolor:'yellow'}} >xs=8</Item>
  </Grid>
</Grid>);

let MultipleGrid = () => (<Grid container spacing={2}>
  <Grid item xs={6} md={8}>
    <Item sx={{bgcolor:'pink'}} >xs=6 md=8</Item>
  </Grid>
  <Grid item xs={6} md={4}>
    <Item>xs=6 md=4</Item>
  </Grid>
  <Grid item xs={6} md={4}>
    <Item>xs=6 md=4</Item>
  </Grid>
  <Grid item xs={6} md={8}>
    <Item sx={{bgcolor:'pink'}} >xs=6 md=8</Item>
  </Grid>
</Grid>);

let SpacingGrid = () => {
  const [spacing, setSpacing] = React.useState(2);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSpacing(Number((event.target as HTMLInputElement).value));
  };

 const jsx = `
  <Grid container spacing={${spacing}}>
`;
function getRandomColor() {
  var letters = '0123456789ABCDEF';
  var color = '#';
  for (var i = 0; i < 6; i++) {
    color += letters[Math.floor(Math.random() * 16)];
  }
  return color;
}

  return (
    <Grid sx={{ flexGrow: 1 }} container spacing={2}>
      <Grid item xs={12}>
        <Grid container justifyContent="center" spacing={spacing}>
          {[0, 1, 2].map((value) => {
            return (
            <Grid key={value} item>
              <Paper sx={{ height: 140, width: 100, bgcolor:getRandomColor }} />
            </Grid>
            )}
          )}
        </Grid>
      </Grid>
      <Grid item xs={12}>
        <Paper sx={{ p: 2 }}>
          <Grid container>
            <Grid item>
              <FormControl component="fieldset">
                <FormLabel component="legend">spacing</FormLabel>
                <RadioGroup
                  name="spacing"
                  aria-label="spacing"
                  value={spacing.toString()}
                  onChange={handleChange}
                  row
                >
                  {[0, 0.5, 1, 2, 3, 4, 8, 12].map((value) => (
                    <FormControlLabel
                      key={value}
                      value={value.toString()}
                      control={<Radio />}
                      label={value.toString()}
                    />
                  ))}
                </RadioGroup>
              </FormControl>
            </Grid>
          </Grid>
        </Paper>
        Code code={jsx}
      </Grid>
    </Grid>
  );
}

export const Grids = () =>
<>
Basic grid:
<BasicGrid />
Grid with multiple breakpoints:
<MultipleGrid />
Spacing grid:
<SpacingGrid />
</>;
