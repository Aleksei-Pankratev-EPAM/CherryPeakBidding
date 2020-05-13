import React from 'react';
import { Link } from 'react-router-dom';

import '../css/Logo.css';

function Logo() {
    return (
        <div className="logo d-flex justify-content-center">
            <Link to="/">
                <img className="text-center" alt="Cherry Peak Bidding" src="/logo.svg" />
            </Link>
        </div>
    );
}

export default Logo;