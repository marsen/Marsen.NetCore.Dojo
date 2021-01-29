import React from 'react';
import { ArrowDropDown, ArrowDropUp } from '@material-ui/icons';
import { Box, Button, Input } from '@material-ui/core';

export default function QtySelector() {    
      return (        
          <Box>              
            <Button><ArrowDropUp/></Button>
                <Input value="1" />
            <Button><ArrowDropDown/></Button>                    
          </Box>
      );
}

//export default HelloWorld;
