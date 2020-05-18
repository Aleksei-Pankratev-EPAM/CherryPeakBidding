import React from 'react';

import '../css/UserInfo.css';
import Money from './Money';

function UserInfo({ userName, balance }) {
  return (
    <div className="user-info">
      <div className="user-name">{userName}</div>
      <div><Money value={balance} valueClass='user-balance' /></div>
      <div><a className="btn btn-sm btn-outline-primary" href="/">Sign out</a></div>
    </div>
  );
}

export default UserInfo;