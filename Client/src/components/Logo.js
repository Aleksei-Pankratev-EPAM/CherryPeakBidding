import React from 'react';
import { Link } from 'react-router-dom';

function Logo() {
    return (
        <div className="logo d-flex justify-content-center">
            <Link to="/">
                <img className="text-center" src="/logo.png" alt="Cherry Peak Bidding" width="180" height="170" />
            </Link>
        </div>
    );
}

export default Logo;