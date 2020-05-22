import React from 'react';

function UserStatus({ value }) {
    let className = 'badge';

    switch (value) {
        case 'creator':
            className += ' badge-primary';
            break;
        case 'viewed':
            className += ' badge-secondary';
            break;
        case 'participated':
            className += ' badge-info';
            break;
        case 'leader':
            className += ' badge-warning';
            break;
        case 'winner':
            className += ' badge-success';
            break;
        default:
            return null;
    }

    return <span className={className}>{value}</span>
}

export default UserStatus;