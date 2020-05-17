import React from 'react';
import { CURRENCY } from './Currency';
import FormattedNumber from './FormattedNumber';

function Money({ value, valueClass }) {
    return <>
        <span className={valueClass}><FormattedNumber value={value} /></span> {CURRENCY}
    </>;
}

export default Money;