import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import Pagination from 'react-js-pagination';

import LotItem from './LotItem';
import data from './lots.json';
import regionData from './regions.json';

class Lots extends Component {
  constructor(props) {
    super(props);

    this.state = {
      lots: [],
      regions: [],
      chosenRegion: 'Moscow',
      showCompleted: true,
      totalItemCount: 50,
      itemsPerPage: 5,
      currentPage: 1
    };
  }

  componentDidMount() {
    this.setState({
      lots: data,
      regions: regionData,
      chosenRegion: 'Saratov'
    });
  }

  renderItems = () => {
    return this.state.lots.map((item) => (
      <LotItem key={item.id} item={item} />
    ));
  }

  renderConditionForm = () => {
    return (
      <form className="form-inline my-3">
        <div className="form-group mr-5">
          <label htmlFor="chosenRegion">Region</label>
          <select onChange={this.handleRegionChange} id="chosenRegion" className="form-control ml-1" value={this.state.chosenRegion}>
            {this.state.regions.map((r, i) => (
              <option key={i}>{r}</option>
            ))}
          </select>
        </div>

        <div className="form-group">
          <input onChange={this.handleShowCompletedChange} className="form-check-input" type="checkbox" id="showCompleted" defaultChecked={this.state.showCompleted} />
          <label className="form-check-label" htmlFor="showCompleted">Show completed</label>
        </div>
      </form>
    );
  }

  handlePageChange = (pageNumber) => {
    this.setState({ currentPage: pageNumber });
  }

  handleRegionChange = (e) => {
    this.setState({
      chosenRegion: e.target.value
    });
  }

  handleShowCompletedChange = () => {
    this.setState((prev) => {
      return {
        showCompleted: !prev.showCompleted
      };
    });
  }

  render() {
    return (
      <div>
        <h1>Lots</h1>
        <Link className="btn btn-primary mt-3" to="/lots/add">Add new</Link>
        {this.renderConditionForm()}
        <div className="row">{this.renderItems()}</div>

        <Pagination
          innerClass="pagination justify-content-center mt-3"
          itemClass="page-item"
          linkClass="page-link"
          activePage={this.state.currentPage}
          itemsCountPerPage={this.state.itemsPerPage}
          totalItemsCount={this.state.totalItemCount}
          pageRangeDisplayed={5}
          onChange={this.handlePageChange} />
      </div>
    );
  }
}

export default Lots;