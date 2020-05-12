import React from 'react';
import { Link } from 'react-router-dom';

const LotItem = ({ item }) => (
  <div class="col-md-4">
    <div class="card shadow-sm mb-3">
      <img src={item.urlToImage ?? 'no-image.png'} className="img-thumbnail mx-auto mt-3" width="200px" height="150px" />
      <div class="card-body">
        <h3 class="card-title"><Link to={`/lots/details/${item.id}`}>{item.title}</Link></h3>
        <p class="card-text">{item.description}</p>
        <div class="d-flex justify-content-between align-items-center">
          <div class="btn-group">
            <Link className="btn btn-sm btn-outline-secondary" to={`/lots/details/${item.id}`}>View</Link>
          </div>
          <small class="text-muted">{item.createdAt}</small>
        </div>
      </div>
    </div>
  </div>

);

export default LotItem;