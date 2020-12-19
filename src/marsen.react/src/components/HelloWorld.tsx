import React from 'react';


type User = {
  name?: string
}

export default function HelloWorld(args:User) {    
      return (
        <div>
          Hello { args.name ? args.name : "World"}
        </div>
      );
}

//export default HelloWorld;
