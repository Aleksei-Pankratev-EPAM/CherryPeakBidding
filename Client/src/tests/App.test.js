import React from 'react';
import { render } from '@testing-library/react';
import App from '../components/App';

test('renders login link', () => {
  const { getByText } = render(<App />);
  const linkElement = getByText(/Login/i);
  expect(linkElement).toBeInTheDocument();
});
