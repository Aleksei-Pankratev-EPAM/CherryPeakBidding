import React from 'react';

import '../css/UserInfo.css';
import { CURRENCY } from './Currency';

function UserInfo({ userName, balance }) {
  return (
    <div className="user-info">
      <div className="user-name">{userName}</div>
      <div><span className="user-balance">{balance}</span> {CURRENCY}</div>
      <div><a className="btn btn-sm btn-outline-primary" href="/">Sign out</a></div>
    </div>
  );
}

export default UserInfo;