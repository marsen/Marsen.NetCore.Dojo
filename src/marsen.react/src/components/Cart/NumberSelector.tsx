import React from 'react';
import { ArrowDropDown, ArrowDropUp } from '@material-ui/icons';
import { Box, Input } from '@material-ui/core';

export default function NumberSelector(props:any) {    
      return (        
          <Box style={{width:24,float:"left"}}>
            <ArrowDropUp onClick={()=>{ props.add() }}/>            
            <Input id="prop.selectorId" value={props.Qty??0} 
              inputProps={{min:0,style:{textAlign:'center',float:'left'}}} />
            <ArrowDropDown onClick={()=>{ props.minus() }} />
          </Box>          
      );
}

//export default HelloWorld;
