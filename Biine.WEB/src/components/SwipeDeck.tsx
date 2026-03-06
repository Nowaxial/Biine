import { useEffect, useRef, useState } from 'react';
import TinderCard from 'react-tinder-card';
import { Center, Stack, Text, Loader, Button } from '@mantine/core';
import { useSession } from '../hooks/useSession';
import { useRecipe } from '../hooks/useRecipe';
import RecipeCard from './RecipeCard';
import MatchModal, { type Restaurant } from './MatchModal';

const API_URL = import.meta.env.PUBLIC_API_URL as string;

interface Props {
  lang: string;
}

export default function SwipeDeck({ lang }: Props) {
  const sessionId = useSession();
  const { state, fetchNext, fetchById } = useRecipe(sessionId, lang);
  const swipedRef = useRef(false);

  // Match modal state
  const [matchOpen, setMatchOpen] = useState(false);
  const [matchedRecipeSnapshot, setMatchedRecipeSnapshot] = useState<typeof state extends { status: 'recipe'; data: infer D } ? D : never | null>(null);
  const [restaurant, setRestaurant] = useState<Restaurant | null>(null);
  const [restaurantLoading, setRestaurantLoading] = useState(false);

  // Fetch first recipe once session ID is ready
  useEffect(() => {
    if (sessionId && state.status === 'idle') {
      fetchNext();
    }
  }, [sessionId]);

  // Re-fetch current card in new language when lang changes
  useEffect(() => {
    if (state.status === 'recipe') {
      fetchById(state.data.id);
    }
  }, [lang]);

  const handleSwipe = async (direction: string) => {
    if (swipedRef.current) return;
    if (state.status !== 'recipe') return;
    swipedRef.current = true;

    const action = direction === 'right' ? 'like' : 'dislike';
    const recipe = state.data;

    // POST interaction (fire-and-forget)
    fetch(`${API_URL}/api/interactions`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ sessionId, recipeId: recipe.id, action }),
    }).catch(() => {/* ignore */});

    if (direction === 'right') {
      // Show match modal with snapshot of the matched recipe
      setMatchedRecipeSnapshot(recipe as any);
      setRestaurant(null);
      setMatchOpen(true);
      // Don't fetch next yet — user will dismiss modal first
      swipedRef.current = false;
    } else {
      await fetchNext();
      swipedRef.current = false;
    }
  };

  const handleCook = async () => {
    if (!matchedRecipeSnapshot) return;
    // POST decision: cook
    fetch(`${API_URL}/api/decisions`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ sessionId, recipeId: matchedRecipeSnapshot.id, decision: 'cook' }),
    }).catch(() => {/* ignore */});
    // Close modal and fetch next
    setMatchOpen(false);
    setMatchedRecipeSnapshot(null);
    await fetchNext();
  };

  const handleEatOut = async () => {
    if (!matchedRecipeSnapshot) return;

    // POST decision: eat_out
    fetch(`${API_URL}/api/decisions`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ sessionId, recipeId: matchedRecipeSnapshot.id, decision: 'eat_out' }),
    }).catch(() => {/* ignore */});

    // Fetch a matching restaurant
    setRestaurantLoading(true);

    // Try to get user's location
    const getLocationParams = (): Promise<{ lat: number; lng: number } | null> => {
      return new Promise((resolve) => {
        if (!navigator.geolocation) {
          resolve(null);
          return;
        }
        navigator.geolocation.getCurrentPosition(
          (position) => {
            resolve({
              lat: position.coords.latitude,
              lng: position.coords.longitude,
            });
          },
          () => resolve(null), // Permission denied or error
          { timeout: 5000, maximumAge: 60000 }
        );
      });
    };

    try {
      // Get user's location
      const location = await getLocationParams();

      // Build URL with optional location params
      let url = `${API_URL}/api/restaurants/match?cuisine=${encodeURIComponent(matchedRecipeSnapshot.cuisine)}&lang=${lang}`;
      if (location) {
        url += `&lat=${location.lat}&lng=${location.lng}`;
      }

      const res = await fetch(url);
      if (res.ok) {
        const data: Restaurant = await res.json();
        setRestaurant(data);
      } else {
        // No restaurant for this cuisine — show a friendly fallback
        setRestaurant({
          id: 0,
          name: lang === 'en' ? 'No restaurant found' : 'Ingen restaurang hittad',
          address: lang === 'en' ? 'Search on Google Maps' : 'Sök på Google Maps',
          cuisine: matchedRecipeSnapshot.cuisine,
          priceLevel: 2,
          rating: 0,
          googleMapsUrl: `https://www.google.com/maps/search/${encodeURIComponent(matchedRecipeSnapshot.cuisine + ' restaurant Göteborg')}`,
        });
      }
    } catch {
      setRestaurant(null);
    } finally {
      setRestaurantLoading(false);
    }
  };

  const handleKeepSwiping = async () => {
    setMatchOpen(false);
    setMatchedRecipeSnapshot(null);
    setRestaurant(null);
    await fetchNext();
  };

  // ── Loading / empty / error states ──────────────────────────────────────

  if (state.status === 'idle' || state.status === 'loading') {
    return (
      <Center style={{ height: '100dvh' }}>
        <Loader color="orange" size="lg" />
      </Center>
    );
  }

  if (state.status === 'empty') {
    return (
      <Center style={{ height: '100dvh' }}>
        <Stack align="center" gap="md">
          <Text style={{ fontSize: 64 }}>🍽️</Text>
          <Text size="xl" fw={700} ta="center">
            {lang === 'en' ? "You've seen it all!" : 'Du har sett allt!'}
          </Text>
          <Text c="dimmed" ta="center">
            {lang === 'en' ? 'No more recipes right now.' : 'Inga fler recept just nu.'}
          </Text>
        </Stack>
      </Center>
    );
  }

  if (state.status === 'error') {
    return (
      <Center style={{ height: '100dvh' }}>
        <Stack align="center" gap="md">
          <Text size="xl" fw={700} c="red" ta="center">
            {lang === 'en' ? 'Something went wrong' : 'Något gick fel'}
          </Text>
          <Text c="dimmed" ta="center">{state.message}</Text>
          <Button color="orange" onClick={fetchNext}>
            {lang === 'en' ? 'Try again' : 'Försök igen'}
          </Button>
        </Stack>
      </Center>
    );
  }

  // state.status === 'recipe'
  return (
    <>
      <Center style={{ height: '100dvh', padding: '16px' }}>
        <div style={{ position: 'relative', width: '100%', maxWidth: 380, height: 520 }}>
          <TinderCard
            key={state.data.id}
            onSwipe={handleSwipe}
            preventSwipe={['up', 'down']}
            swipeRequirementType="position"
            swipeThreshold={80}
          >
            <RecipeCard recipe={state.data} />
          </TinderCard>
        </div>
      </Center>

      <MatchModal
        opened={matchOpen}
        recipe={matchedRecipeSnapshot}
        restaurant={restaurant}
        restaurantLoading={restaurantLoading}
        lang={lang}
        onCook={handleCook}
        onEatOut={handleEatOut}
        onKeepSwiping={handleKeepSwiping}
      />
    </>
  );
}
