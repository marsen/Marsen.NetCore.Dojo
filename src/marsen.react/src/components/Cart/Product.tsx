import React from 'react';

interface ProductProps {
    Name:string,
    Detail:string
}

export default function Product(props:ProductProps) { 
      return (
          <div style={{width:'240px',float:'left'}}>
            <span>{props.Name}</span>
            <details>
                <summary> More...</summary>
                {props.Detail}
            </details>
          </div>
      );
}