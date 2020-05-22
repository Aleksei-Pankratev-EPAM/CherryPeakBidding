export function pluralize(value, plural = '', singular = '') {
    const name = (value > 1 || value === 0) ? plural : singular;
    return `${value} ${name}`;
}