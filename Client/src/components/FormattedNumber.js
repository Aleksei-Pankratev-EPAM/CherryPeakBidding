function FormattedNumber({ value }) {
    const formatter = new Intl.NumberFormat();
    return formatter.format(value);
}

export default FormattedNumber;