import { Card, Image, Text, Badge, Group, Stack } from '@mantine/core';
import type { Recipe } from '../hooks/useRecipe';

interface Props {
  recipe: Recipe;
}

const difficultyLabel: Record<string, string> = {
  easy: 'Lätt',
  medium: 'Medel',
  hard: 'Avancerat',
};

export default function RecipeCard({ recipe }: Props) {
  return (
    <Card
      shadow="lg"
      radius="xl"
      style={{
        width: '100%',
        maxWidth: 380,
        userSelect: 'none',
        overflow: 'hidden',
        position: 'absolute',
        top: 0,
        left: 0,
        right: 0,
        margin: '0 auto',
      }}
      p={0}
    >
      <Card.Section>
        <Image
          src={recipe.imageUrl}
          height={320}
          alt={recipe.name}
          style={{ objectFit: 'cover', pointerEvents: 'none' }}
        />
      </Card.Section>

      <Stack gap="xs" p="md">
        <Text fw={700} size="xl">{recipe.personaName}</Text>
        <Text size="xs" c="dimmed" tt="uppercase" fw={500} style={{ letterSpacing: '0.05em' }}>{recipe.name}</Text>
        <Text size="sm" c="dimmed" lineClamp={3}>{recipe.personaText}</Text>
        <Group gap="xs" wrap="wrap" mt="xs">
          <Badge color="orange" variant="light">{recipe.cuisine}</Badge>
          <Badge color="gray" variant="light">{recipe.cookingTime} min</Badge>
          <Badge color="gray" variant="light">
            {difficultyLabel[recipe.difficulty] ?? recipe.difficulty}
          </Badge>
          {recipe.tags.slice(0, 3).map(tag => (
            <Badge key={tag} color="gray" variant="outline">{tag}</Badge>
          ))}
        </Group>
      </Stack>
    </Card>
  );
}
