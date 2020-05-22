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
        <h1>Details</h1>
        <h2>LotId: {this.state.lotId}</h2>
      </div>
    );
  }
}

export default LotDetails;