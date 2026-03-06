import {
  Modal,
  Stack,
  Text,
  Button,
  Group,
  Badge,
  Divider,
  Anchor,
  Paper,
  Image,
  ScrollArea,
  Box,
} from '@mantine/core';
import type { Recipe } from '../hooks/useRecipe';

export interface Restaurant {
  id: number;
  name: string;
  address: string;
  cuisine: string;
  priceLevel: number;
  rating: number;
  googleMapsUrl: string;
}

interface Props {
  opened: boolean;
  recipe: Recipe | null;
  restaurant: Restaurant | null;
  restaurantLoading: boolean;
  lang: string;
  onCook: () => void;
  onEatOut: () => void;
  onKeepSwiping: () => void;
}

const t = (lang: string, sv: string, en: string) => lang === 'en' ? en : sv;

function priceLabel(level: number) {
  return '฿'.repeat(Math.max(1, Math.min(level, 4)));
}

function parseIngredients(raw: string): { name: string; amount: string }[] {
  try {
    const parsed = JSON.parse(raw);
    if (!Array.isArray(parsed)) return [];
    return parsed.map((item: Record<string, string>) => ({
      name: item.name ?? item.namn ?? '',
      amount: item.amount ?? item.mängd ?? '',
    }));
  } catch {
    return [];
  }
}

export default function MatchModal({
  opened,
  recipe,
  restaurant,
  restaurantLoading,
  lang,
  onCook,
  onEatOut,
  onKeepSwiping,
}: Props) {
  if (!recipe) return null;

  const ingredients = parseIngredients(recipe.ingredients);

  return (
    <Modal
      opened={opened}
      onClose={onKeepSwiping}
      title={
        <Text fw={700} size="lg">
          🎉 {t(lang, 'Det är en match!', "It's a match!")}
        </Text>
      }
      centered
      fullScreen
      radius={0}
      scrollAreaComponent={ScrollArea.Autosize}
      styles={{
        body: { padding: 0 },
        header: { padding: '16px 16px 0' },
      }}
    >
      <Stack gap={0}>
        {/* Recipe image */}
        {recipe.imageUrl && (
          <Image
            src={recipe.imageUrl}
            height={220}
            alt={recipe.name}
            style={{ objectFit: 'cover' }}
          />
        )}

        <Stack gap="md" p="md">
          {/* Persona name + dish name */}
          <Stack gap={2}>
            <Text fw={700} size="xl">{recipe.personaName}</Text>
            <Text size="sm" c="dimmed" tt="uppercase" fw={500} style={{ letterSpacing: '0.05em' }}>
              {recipe.name}
            </Text>
            <Group gap="xs" mt={4} wrap="wrap">
              <Badge color="orange" variant="light">{recipe.cuisine}</Badge>
              <Badge color="gray" variant="light">{recipe.cookingTime} min</Badge>
            </Group>
          </Stack>

          {/* Action buttons */}
          <Group grow>
            <Button
              size="lg"
              color="orange"
              radius="xl"
              onClick={onCook}
            >
              🍳 {t(lang, 'Laga hemma', 'Cook at home')}
            </Button>
            <Button
              size="lg"
              variant="outline"
              color="orange"
              radius="xl"
              onClick={onEatOut}
              loading={restaurantLoading}
              disabled={restaurantLoading}
            >
              🍽️ {t(lang, 'Äta ute', 'Eat out')}
            </Button>
          </Group>

          <Button
            variant="subtle"
            color="gray"
            size="sm"
            onClick={onKeepSwiping}
          >
            {t(lang, 'Fortsätt swipa', 'Keep swiping')}
          </Button>

          <Divider />

          {/* Ingredients */}
          <Stack gap="xs">
            <Text fw={600} size="md">{t(lang, 'Ingredienser', 'Ingredients')}</Text>
            {ingredients.map((ing, i) => (
              <Group key={i} justify="space-between">
                <Text size="sm">{ing.name}</Text>
                <Text size="sm" c="dimmed">{ing.amount}</Text>
              </Group>
            ))}
          </Stack>

          <Divider />

          {/* Instructions */}
          <Stack gap="xs">
            <Text fw={600} size="md">{t(lang, 'Tillagning', 'Instructions')}</Text>
            <Text size="sm" style={{ whiteSpace: 'pre-line' }}>{recipe.instructions}</Text>
          </Stack>

          {/* Restaurant card (shown after "Äta ute" is clicked and data loaded) */}
          {restaurant && (
            <>
              <Divider />
              <Stack gap="xs">
                <Text fw={600} size="md">🗺️ {t(lang, 'Restaurang i närheten', 'Restaurant nearby')}</Text>
                <Paper withBorder radius="md" p="md">
                  <Stack gap="xs">
                    <Text fw={700} size="md">{restaurant.name}</Text>
                    <Text size="sm" c="dimmed">{restaurant.address}</Text>
                    <Group gap="xs">
                      <Badge color="yellow" variant="light">⭐ {restaurant.rating}</Badge>
                      <Badge color="gray" variant="light">{priceLabel(restaurant.priceLevel)}</Badge>
                      <Badge color="orange" variant="light">{restaurant.cuisine}</Badge>
                    </Group>
                    <Anchor
                      href={restaurant.googleMapsUrl}
                      target="_blank"
                      rel="noopener noreferrer"
                      size="sm"
                    >
                      {t(lang, 'Öppna i Google Maps →', 'Open in Google Maps →')}
                    </Anchor>
                  </Stack>
                </Paper>
              </Stack>
            </>
          )}

          {/* Bottom spacing for mobile */}
          <Box h={32} />
        </Stack>
      </Stack>
    </Modal>
  );
}
