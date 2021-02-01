import React from 'react';
import { ArrowDropDown, ArrowDropUp } from '@material-ui/icons';
import { Box, Input } from '@material-ui/core';

export default function NumberSelector(prop:any) {    
      return (        
          <Box width={24}>
            <ArrowDropUp onClick={()=>{ document.getElementById('mock_id').value++; }}/>            
            <Input id="mock_id" value="1" inputProps={{min:0,style:{textAlign:'center'}}} />
            <ArrowDropDown onClick={()=>{ document.getElementById('mock_id').value--;}} />
          </Box>
      );
}

//export default HelloWorld;
