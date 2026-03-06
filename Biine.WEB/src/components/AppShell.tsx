import { MantineProvider, ActionIcon, Tooltip } from '@mantine/core';
import '@mantine/core/styles.css';
import OnboardingOverlay from './OnboardingOverlay';
import SwipeDeck from './SwipeDeck';
import { useLang } from '../hooks/useLang';

export default function AppShell() {
  const [lang, toggleLang] = useLang();

  return (
    <MantineProvider defaultColorScheme="light">
      {/* Language toggle — top-right corner, always visible */}
      <Tooltip label={lang === 'sv' ? 'Switch to English' : 'Byt till svenska'} position="bottom">
        <ActionIcon
          variant="subtle"
          color="gray"
          size="lg"
          radius="xl"
          onClick={toggleLang}
          style={{
            position: 'fixed',
            top: 12,
            right: 12,
            zIndex: 200,
            fontWeight: 700,
            fontSize: 14,
          }}
        >
          {lang === 'sv' ? 'EN' : 'SV'}
        </ActionIcon>
      </Tooltip>

      <OnboardingOverlay />
      <SwipeDeck lang={lang} />
    </MantineProvider>
  );
}
