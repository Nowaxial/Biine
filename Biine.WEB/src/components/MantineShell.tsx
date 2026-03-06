import { MantineProvider } from '@mantine/core';
import '@mantine/core/styles.css';
import type { ReactNode } from 'react';

interface Props {
  children: ReactNode;
}

export default function MantineShell({ children }: Props) {
  return (
    <MantineProvider defaultColorScheme="light">
      {children}
    </MantineProvider>
  );
}
