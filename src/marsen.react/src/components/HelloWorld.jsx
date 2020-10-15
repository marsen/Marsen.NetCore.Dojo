import React from 'react';


class HelloWorld extends React.Component {
    render() {
      return (
        <div>
          Hello {this.props.name}
        </div>
      );
    }
  }

export default HelloWorld;