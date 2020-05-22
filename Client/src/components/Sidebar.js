import React from 'react';

import Logo from './Logo';
import Navigation from './Navigation';
import UserInfo from './UserInfo';

import '../css/Sidebar.css';

function Sidebar() {
    return (
        <div className="sidebar col-md-2">
            <Logo />
            <UserInfo userName="Admin" balance="200" />
            <Navigation />
        </div>
    );
}

export default Sidebar;