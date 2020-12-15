import React from 'react';


type User = {
  name?: string
}

export default class HelloWorld extends React.Component<User> {    
  render() {
      return (
        <div>
          Hello { this.props.name ? this.props.name : "World"}
        </div>
      );
    }
  }

//export default HelloWorld;
