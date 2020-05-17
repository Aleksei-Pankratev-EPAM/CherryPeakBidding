import React from 'react';
import PropTypes from 'prop-types';
import NumberFormat from 'react-number-format';

const HorizontalInput = ({ name, type, value, handleBlur, handleValueChange, placeholder, addon, required, validationErrors }) => {

    const validated = validationErrors !== null;
    const valid = validated && validationErrors.length === 0;
    const isValidClass = validated && (valid ? 'is-valid' : 'is-invalid');
    const fieldClassName = `form-control ${isValidClass}`;
    const useTextArea = type === 'textarea';
    const useNumber = type === 'number';
    const useGeneralInput = !useNumber && !useTextArea;

    function getInput() {
        return <input
            className={fieldClassName}
            id={name}
            name={name}
            type={type}
            value={value}
            onBlur={handleBlur}
            onChange={(e) => handleValueChange(e.target.name, e.target.value)}
            placeholder={placeholder}
            required={required}
        />
    }

    function getNumberInput() {
        return (
            <NumberFormat
                thousandSeparator={true}
                value={value}
                name={name}
                onValueChange={(e) => handleValueChange(name, e.value)}
                onBlur={handleBlur}
                placeholder={placeholder}
                required={required}
                className={fieldClassName} />
        )
    }

    function getAddon() {
        return (
            <div className="input-group-append">
                <span id={name + '-addon'} className='input-group-text'>{addon}</span>
            </div>
        )
    }

    function getTextArea() {
        return (
            <textarea name={name} className={fieldClassName} rows="3" required={required}
                value={value} onBlur={handleBlur}
                onChange={(e) => handleValueChange(e.target.name, e.target.value)} />
        )
    }


    return (
        <div className='input-group mb-3'>
            {useTextArea && getTextArea()}
            {useNumber && getNumberInput()}
            {useGeneralInput && getInput()}
            {addon && getAddon()}
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
    handleBlur: PropTypes.func,
    handleValueChange: PropTypes.func,
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