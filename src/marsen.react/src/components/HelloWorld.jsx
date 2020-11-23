import React from 'react';


class HelloWorld extends React.Component {
    render() {
      return (
        <div>
          Hello { this.props.name ? this.props.name : "World"}
        </div>
      );
    }
  }

export default HelloWorld;