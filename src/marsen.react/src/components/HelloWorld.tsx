import React from 'react';


type HelloWorldProps = {
  name?: string
}

class HelloWorld extends React.Component<HelloWorldProps> {
    
  render() {
      return (
        <div>
          Hello { this.props.name ? this.props.name : "World"}
        </div>
      );
    }
  }

export default HelloWorld;
