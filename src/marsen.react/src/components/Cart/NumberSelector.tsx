import React from 'react';
import { ArrowDropDown, ArrowDropUp } from '@material-ui/icons';
import { Box, Input } from '@material-ui/core';
import { CSSProperties } from '@material-ui/core/styles/withStyles';

const style : CSSProperties =  { 
  textAlign: 'center'
};

export default function NumberSelector(prop:any) {    
      return (        
          <Box width={24}>
            <ArrowDropUp onClick={()=>{ prop.add() }}/>            
            <Input id="prop.selectorId" value="1" inputProps={{min:0,style:style}} />
            <ArrowDropDown onClick={()=>{ prop.minus() }} />
          </Box>
      );
}

//export default HelloWorld;
