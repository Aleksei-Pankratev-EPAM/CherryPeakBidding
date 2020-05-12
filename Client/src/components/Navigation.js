import React from 'react';
import { NavLink } from 'react-router-dom';

import '../css/Navigation.css';

function Navigation() {
    return (
        <ul className="navigation">
            <li><NavLink activeClassName="active-menu-item" to="/login">Login</NavLink></li>
            <li><NavLink activeClassName="active-menu-item" to="/register">Register</NavLink></li>
            <li><NavLink activeClassName="active-menu-item" to="/" exact>Home</NavLink></li>
            <li><NavLink activeClassName="active-menu-item" to="/lots">Lots</NavLink></li>
            <li><NavLink activeClassName="active-menu-item" to="/statistics">Statistics</NavLink></li>
        </ul>
    );
}

export default Navigation;