import { formatNumber } from '../formatting';

const MAX_TITLE_LENGTH = 50;
const MAX_DESCRIPTION_LENGTH = 1000;

const MIN_PRICE_STEP = 1.0;
const MAX_PRICE_STEP = 1_000_000.0;

const MIN_START_PRICE = 1.0;
const MAX_START_PRICE = 1_000_000_000.0;

const MIN_BIDDING_TIME_IN_MINUTES = 0.25;
const MAX_BIDDING_TIME_IN_MINUTES = 1 * 60 * 24 * 14;

export function getTitleValidationErrors(value) {
    let errors = [];
    if (!value) {
        errors.push(notEmpty());
    }
    else if (value.length > MAX_TITLE_LENGTH) {
        errors.push(tooLong(MAX_TITLE_LENGTH));
    }
    return errors;
}

export function getDesctiptionValidationErrors(value) {
    let errors = [];

    if (value?.length > MAX_DESCRIPTION_LENGTH) {
        errors.push(tooLong(MAX_DESCRIPTION_LENGTH));
    }
    return errors;
}

export function getStartPriceValidationErrors(value) {
    let errors = [];

    if (value < MIN_START_PRICE) {
        errors.push(lessThen(MIN_START_PRICE));
    }
    else if (value > MAX_START_PRICE) {
        errors.push(greaterThan(MAX_START_PRICE));
    }

    return errors;
}

export function getPriceStepValidationErrors(value) {
    let errors = [];

    if (value < MIN_PRICE_STEP) {
        errors.push(lessThen(MIN_PRICE_STEP));
    }
    else if (value > MAX_PRICE_STEP) {
        errors.push(greaterThan(MAX_PRICE_STEP));
    }

    return errors;
}

export function getBiddingTimeValidationErrors(value) {
    let errors = [];

    if (value < MIN_BIDDING_TIME_IN_MINUTES) {
        errors.push(lessThen(MIN_BIDDING_TIME_IN_MINUTES));
    }
    else if (value > MAX_BIDDING_TIME_IN_MINUTES) {
        errors.push(greaterThan(MAX_BIDDING_TIME_IN_MINUTES));
    }

    return errors;
}

function notEmpty() {
    return 'The field cannot be empty.';
}

function tooLong(maxLength) {
    return `The field length cannot be greater than ${formatNumber(maxLength)}.`;
}

function lessThen(value) {
    return `The field value cannot be less than ${formatNumber(value)}.`;
}

function greaterThan(value) {
    return `The field value cannot be greater than ${formatNumber(value)}.`;
}
