import React from 'react';
import PropTypes from 'prop-types';

const FieldRowContainer = ({ children, name, title, details, required }) => {
    return (
        <div>
            <div className="form-group row">
                <label htmlFor={name} className="col-sm-2 col-form-label">{title + (required ? '*': '')}</label>
                <div className="col-sm-8">
                    {children}
                    {details &&
                        (<small className="form-text text-muted">{details}</small>)}
                </div>
            </div>
        </div>
    )
}

export default FieldRowContainer;

FieldRowContainer.propTypes = {
    name: PropTypes.string,
    title: PropTypes.string,
    details: PropTypes.string,
}