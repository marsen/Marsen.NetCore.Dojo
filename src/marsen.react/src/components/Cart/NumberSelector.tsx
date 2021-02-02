import React from 'react';
import { ArrowDropDown, ArrowDropUp } from '@material-ui/icons';
import { Input } from '@material-ui/core';
import { CSSProperties } from '@material-ui/core/styles/withStyles';

const style : CSSProperties =  { 
  textAlign: 'center',
  float: 'left'
};

export default function NumberSelector(prop:any) {    
      return (        
          <div style={{width:24,float:"left"}}>
            <ArrowDropUp onClick={()=>{ prop.add() }}/>            
            <Input id="prop.selectorId" value="1" inputProps={{min:0,style:style}} />
            <ArrowDropDown onClick={()=>{ prop.minus() }} />
          </div>          
      );
}

//export default HelloWorld;
