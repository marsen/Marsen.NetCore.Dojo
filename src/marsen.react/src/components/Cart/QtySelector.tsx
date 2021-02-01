import React from 'react';
import { ArrowDropDown, ArrowDropUp } from '@material-ui/icons';
import { Box, Input } from '@material-ui/core';

export default function QtySelector() {    
      return (        
          <Box width={24}>
            <ArrowDropUp/>
            <Input value="1" inputProps={{style:{textAlign:'center'}}} />
            <ArrowDropDown/>
          </Box>
      );
}

//export default HelloWorld;
