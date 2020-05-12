import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import LotItem from './LotItem';
import Error from '../Error';
import data from './lots.json'

class Lots extends Component {
  constructor(props) {
    super(props);

    const list = [];
    this.state = {
      lots: list,
      isError: false,
      error: null
    };
  }

  componentDidMount() {
    this.setState({
      lots: data
    });
  }

  renderItems() {
    if (!this.state?.isError ?? false) {
      return this.state.lots.map((item) => (
        <LotItem key={item.id} item={item} />
      ));
    } else {
      return <Error error={this.state.error} />
    }
  }
  render() {
    return (
      <div>
        <h1>Lots</h1>
        <Link className="btn btn-primary my-3" to="/lots/add">Add</Link>
        <div className="row">{this.renderItems()}</div>
      </div>
    );
  }
}

export default Lots;