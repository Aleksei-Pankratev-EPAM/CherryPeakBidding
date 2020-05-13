import React from 'react';

const FormErrorList = ({ errors = [] }) => {
    let className = errors.length ? 'alert alert-danger' : 'd-none';

    return (
        <div className={className}>
            {errors.map((err, i) => (
                <div key={i}>{err}</div>
            ))}
        </div>
    );
}

export default FormErrorList;