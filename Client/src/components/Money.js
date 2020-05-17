import React from 'react';
import { CURRENCY } from '../constants/common';
import formatNumber from '../utils/formatting';

function Money({ value, valueClass }) {
    return <>
        <span className={valueClass}>{formatNumber(value)}</span> {CURRENCY}
    </>;
}

export default Money;