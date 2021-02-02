import React from 'react';
import { ArrowDropDown, ArrowDropUp } from '@material-ui/icons';
import { Input } from '@material-ui/core';
import { CSSProperties } from '@material-ui/core/styles/withStyles';

const style : CSSProperties =  { 
  textAlign: 'center',
  float: 'left'
};

export default function NumberSelector(props:any) {    
      return (        
          <div style={{width:24,float:"left"}}>
            <ArrowDropUp onClick={()=>{ props.add() }}/>            
            <Input id="prop.selectorId" value={props.Qty} inputProps={{min:0,style:style}} />
            <ArrowDropDown onClick={()=>{ props.minus() }} />
          </div>          
      );
}

//export default HelloWorld;
