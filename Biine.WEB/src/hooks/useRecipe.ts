import { useState, useCallback } from 'react';

const API_URL = import.meta.env.PUBLIC_API_URL as string;

export interface Recipe {
  id: number;
  name: string;
  personaName: string;
  personaText: string;
  ingredients: string;
  instructions: string;
  cookingTime: number;
  difficulty: string;
  cuisine: string;
  tags: string[];
  imageUrl: string | null;
}

type State =
  | { status: 'idle' }
  | { status: 'loading' }
  | { status: 'recipe'; data: Recipe }
  | { status: 'empty' }
  | { status: 'error'; message: string };

export function useRecipe(sessionId: string, lang: string = 'sv') {
  const [state, setState] = useState<State>({ status: 'idle' });

  const fetchNext = useCallback(async () => {
    if (!sessionId) return;
    setState({ status: 'loading' });
    try {
      const res = await fetch(
        `${API_URL}/api/recipes/next?sessionId=${sessionId}&lang=${lang}`
      );
      if (res.status === 204) {
        setState({ status: 'empty' });
        return;
      }
      if (res.status === 429) {
        setState({ status: 'error', message: 'För många förfrågningar. Vänta lite.' });
        return;
      }
      if (!res.ok) {
        setState({ status: 'error', message: 'Kunde inte hämta recept.' });
        return;
      }
      const data: Recipe = await res.json();
      setState({ status: 'recipe', data });
    } catch {
      setState({ status: 'error', message: 'Nätverksfel. Kontrollera anslutningen.' });
    }
  }, [sessionId, lang]);

  const fetchById = useCallback(async (id: number) => {
    setState({ status: 'loading' });
    try {
      const res = await fetch(`${API_URL}/api/recipes/${id}?lang=${lang}`);
      if (!res.ok) {
        setState({ status: 'error', message: 'Kunde inte hämta recept.' });
        return;
      }
      const data: Recipe = await res.json();
      setState({ status: 'recipe', data });
    } catch {
      setState({ status: 'error', message: 'Nätverksfel. Kontrollera anslutningen.' });
    }
  }, [lang]);

  return { state, fetchNext, fetchById };
}
