import React, { Component } from 'react';

// const Error = () => (
//   <div>
//     <h1>There are no news, check your sources!!!</h1>
//   </div>
// );

class Error extends Component {
  constructor(props) {
    super(props);
    this.state = {
      error: {
        sourse: props.error.sourse,
        message: props.error.message
      },
    };
  }
  render() {
    return (
      <div>
        <h1>Error!!!: {this.state.error.sourse}: {this.state.message}</h1>
      </div>
    );
  }
}

export default Error;
