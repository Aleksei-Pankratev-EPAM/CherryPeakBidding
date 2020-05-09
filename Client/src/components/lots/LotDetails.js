import React, { Component } from 'react';

class LotDetails extends Component {
    constructor(props) {
      super(props);
      this.state = {
        lotId: props?.match?.params?.id
      };
      
    }
    render() {
      return (
        <div>
          <h1>Details lot here about lot {this.state.lotId}</h1>
        </div>
      );
    }
  }
  
  export default LotDetails;