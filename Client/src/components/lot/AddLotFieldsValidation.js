import PropTypes from 'prop-types';

const MAX_TITLE_LENGTH = 50;
const MAX_DESCRIPTION_LENGTH = 1000;

const MIN_PRICE_STEP = 1.0;
const MAX_PRICE_STEP = 1_000_000.0;

const MIN_START_PRICE = 1.0;
const MAX_START_PRICE = 1_000_000_000.0;

const MIN_BIDDING_TIME = 0.25;
const MAX_BIDDING_TIME = 1*60*24*14;

export function getTitleValidationErrors(value) {
    let errors = [];
    if (!value) {
        errors.push(NotEmpty());
    }
    else if (value.length > MAX_TITLE_LENGTH) {
        errors.push(TooLong(MAX_TITLE_LENGTH));
    }
    return errors;
}
getTitleValidationErrors.propTypes = {
    value: PropTypes.string,
}

export function getDesctiptionValidationErrors(value) {
    let errors = [];

    if (value?.length > MAX_DESCRIPTION_LENGTH) {
        errors.push(TooLong(MAX_DESCRIPTION_LENGTH));
    }
    return errors;
}
getDesctiptionValidationErrors.propTypes = {
    value: PropTypes.string,
}

export function getStartPriceValidationErrors(value) {
    let errors = [];

    if (value < MIN_START_PRICE) {
        errors.push(LessThan(MIN_START_PRICE));
    }
    else if (value > MAX_START_PRICE) {
        errors.push(GreaterThan(MAX_START_PRICE));
    }

    return errors;
}
getStartPriceValidationErrors.propTypes = {
    value: PropTypes.number,
}

export function getPriceStepValidationErrors(value) {
    let errors = [];

    if (value < MIN_PRICE_STEP) {
        errors.push(LessThan(MIN_PRICE_STEP));
    }
    else if (value > MAX_PRICE_STEP) {
        errors.push(GreaterThan(MAX_PRICE_STEP));
    }

    return errors;
}
getPriceStepValidationErrors.propTypes = {
    value: PropTypes.number,
}

export function getBiddingTimeValidationErrors(value) {
    let errors = [];

    if (value < MIN_BIDDING_TIME) {
        errors.push(LessThan(MIN_BIDDING_TIME));
    }
    else if (value > MAX_BIDDING_TIME) {
        errors.push(GreaterThan(MAX_BIDDING_TIME));
    }

    return errors;
}
getBiddingTimeValidationErrors.propTypes = {
    value: PropTypes.number,
}

function NotEmpty() {
    return 'Поле должно быть заполнено.';
}

function TooLong(maxLength) {
    return `Поле должно быть не длиннее ${maxLength}.`;
}

function NaN() {
    return 'Значение должно быть числом.';
}

function LessThan(value) {
    return `Значение должно быть больше, чем ${value}.`;
}

function GreaterThan( value) {
    return `Значение должно быть меньше, чем ${value}.`;
}
