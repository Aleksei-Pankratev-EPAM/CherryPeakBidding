import React, { Component } from 'react';
import { Link } from 'react-router-dom'

const LotItem = ({item}) => (
  <div className="col s4">
    <div className="card">
      <div className="card-image">
        <img src={item.urlToImage} alt={item.title}/>
        <span className="card-title">{item.description}</span>
      </div>
      <div className="card-content">
        <p>{item.title}</p>
      </div>
      <div className="card-action">
        <Link to={`/lot-details/${item.id}`}>Lot details</Link>
        {/* <a href={item.url} rel="noopener noreferrer" target="_blank">Full article</a> */}
      </div>
    </div>
  </div>
);

export default LotItem;
