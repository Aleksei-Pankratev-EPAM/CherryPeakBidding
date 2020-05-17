import React from 'react';
import PropTypes from 'prop-types';

const HorizontalInput = ({ name, type, value, handleBlur, placeholder, addon, required, validationErrors }) => {

    const validated = validationErrors !== null;
    const valid = validated && validationErrors.length === 0;
    const isValidClass = validated && (valid ? 'is-valid' : 'is-invalid');
    const fieldClassName = `form-control ${isValidClass}`;
    const useTextArea = type === 'textarea';

    function getInput() {
        return <input
            className={fieldClassName}
            id={name}
            name={name}
            type={type}
            value={value}
            onBlur={handleBlur}
            placeholder={placeholder}
            required={required}
        />
    }

    function getTextArea() {
        return (
            <textarea name={name} className={fieldClassName} rows="3" required={required}
                value={value} onBlur={handleBlur} />
        )
    }


    return (
        <div className='input-group mb-3'>
            {useTextArea && getTextArea()}
            {!useTextArea && getInput()}
            {!useTextArea && addon && (
                <div className="input-group-append">
                    <span id={name + '-addon'} className='input-group-text'>{addon}</span>
                </div>
            )}
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
    handleBlur: PropTypes.func,
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