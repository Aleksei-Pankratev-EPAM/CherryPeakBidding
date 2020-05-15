import React from 'react';
import PropTypes from 'prop-types';

const HorizontalInput = ({ name, type, value, handleChange, placeholder, addon, required, validationErrors }) => {
    const valid = !validationErrors || validationErrors.length === 0;

    return (
        <div className='input-group mb-3'>
            <input
                className={`form-control ${valid ? 'is-valid' : 'is-invalid'}`}
                id={name}
                name={name}
                type={type}
                value={value}
                onChange={handleChange}
                placeholder={placeholder}
                required={required}
            />
            {addon &&
                (<div className="input-group-append">
                    <span id={name + '-addon'} className='input-group-text'>{addon}</span>
                </div>)
            }
            <div className="invalid-tooltip">
                {validationErrors}
            </div>
        </div>
    )
}

export default HorizontalInput;

HorizontalInput.propTypes = {
    name: PropTypes.string,
    type: PropTypes.string,
    value: PropTypes.string,
    handleChange: PropTypes.func,
    placeholder: PropTypes.oneOfType([PropTypes.string, PropTypes.number]),
    required: PropTypes.bool,
    validationErrors: PropTypes.arrayOf(PropTypes.string)
}

HorizontalInput.defaultValue = {
    type: 'text',
    value: '',
    placeholder: '',
    required: false,
    validationErrors: []
}