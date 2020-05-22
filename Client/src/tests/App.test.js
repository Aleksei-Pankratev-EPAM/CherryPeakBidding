import React from 'react';
import { render } from '@testing-library/react';
import App from '../components/App';

test('renders sign out link', () => {
  const { getByText } = render(<App />);
  const linkElement = getByText(/Sign out/i);
  expect(linkElement).toBeInTheDocument();
});
