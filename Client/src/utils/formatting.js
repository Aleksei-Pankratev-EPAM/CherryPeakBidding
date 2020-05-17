export default function formatNumber(value) {
    const formatter = new Intl.NumberFormat();
    return formatter.format(value);
}