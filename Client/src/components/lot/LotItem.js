import React from 'react';
import { Link } from 'react-router-dom';

const LotItem = ({ item }) => (
  <div className="col-md-4">
    <div className="card shadow-sm mb-3">
      <img src={item.urlToImage ?? 'no-image.png'} className="img-thumbnail mx-auto mt-3" width="200px" height="150px" />
      <div className="card-body">
        <h3 className="card-title"><Link to={`/lots/details/${item.id}`}>{item.title}</Link></h3>
        <p className="card-text">{item.description}</p>
        <div className="d-flex justify-content-between align-items-center">
          <div className="btn-group">
            <Link className="btn btn-sm btn-outline-secondary" to={`/lots/details/${item.id}`}>View</Link>
          </div>
          <small className="text-muted">{item.createdAt}</small>
        </div>
      </div>
    </div>
  </div>

);

export default LotItem;