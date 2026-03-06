import { useState, useEffect } from 'react';
import { Modal, Stack, Text, Button, Group, Box, UnstyledButton } from '@mantine/core';

const STORAGE_KEY = 'biine_onboarding_done';

const slides = [
  {
    emoji: '🍽️',
    title: 'Välkommen till Biine',
    body: 'Swipa dig fram till din nästa måltid.',
  },
  {
    emoji: '🔥',
    title: 'Matcha med recept',
    body: 'Swipa höger på det som ser gott ut. Swipa vänster för att skippa.',
  },
  {
    emoji: '🗺️',
    title: 'Laga eller ät ute',
    body: 'När du matchar väljer du: laga hemma eller hitta en restaurang i Göteborg.',
  },
];

export default function OnboardingOverlay() {
  const [visible, setVisible] = useState(false);
  const [slide, setSlide] = useState(0);

  useEffect(() => {
    if (typeof window !== 'undefined') {
      const done = localStorage.getItem(STORAGE_KEY);
      if (done !== 'true') setVisible(true);
    }
  }, []);

  const handleDone = () => {
    localStorage.setItem(STORAGE_KEY, 'true');
    setVisible(false);
  };

  const handleNext = () => {
    if (slide < slides.length - 1) {
      setSlide(slide + 1);
    } else {
      handleDone();
    }
  };

  if (!visible) return null;

  const current = slides[slide];

  return (
    <Modal
      opened={visible}
      onClose={handleDone}
      withCloseButton={false}
      fullScreen
      padding="xl"
      styles={{
        body: {
          height: '100%',
          display: 'flex',
          flexDirection: 'column',
          justifyContent: 'center',
        },
      }}
    >
      <UnstyledButton
        onClick={handleDone}
        style={{ position: 'absolute', top: 16, right: 16 }}
      >
        <Text size="sm" c="dimmed">Hoppa över</Text>
      </UnstyledButton>

      <Stack align="center" gap="xl" style={{ flex: 1, justifyContent: 'center' }}>
        <Text style={{ fontSize: 64, lineHeight: 1 }}>{current.emoji}</Text>
        <Text size="xl" fw={700} ta="center">{current.title}</Text>
        <Text c="dimmed" ta="center" size="md">{current.body}</Text>

        <Group gap="xs" justify="center">
          {slides.map((_, i) => (
            <Box
              key={i}
              style={{
                width: 8,
                height: 8,
                borderRadius: '50%',
                backgroundColor: i === slide ? '#e8590c' : '#dee2e6',
              }}
            />
          ))}
        </Group>

        <Button color="orange" fullWidth size="lg" onClick={handleNext} mt="md">
          {slide < slides.length - 1 ? 'Nästa →' : 'Kom igång!'}
        </Button>
      </Stack>
    </Modal>
  );
}
