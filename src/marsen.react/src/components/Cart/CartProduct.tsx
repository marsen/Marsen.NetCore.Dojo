import React from 'react';

export default function SubTotal(prop:any) {    
      return (
          <div>
            <span>{prop.subtotal??10} </span>{prop.symbol??'$'}
          </div>
      );
}