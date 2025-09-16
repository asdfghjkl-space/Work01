import './globals.css';
import type { ReactNode } from 'react';

export const metadata = {
  title: 'SnipShare',
  description: 'Share code snippets with Pro-only full access'
};

export default function RootLayout({ children }: { children: ReactNode }) {
  return (
    <html lang="ja">
      <body>{children}</body>
    </html>
  );
}
