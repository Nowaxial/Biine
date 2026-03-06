import { useState, useEffect } from 'react';

export type Lang = 'sv' | 'en';
const LANG_KEY = 'biine_lang';

export function useLang(): [Lang, () => void] {
  const [lang, setLang] = useState<Lang>('sv');

  useEffect(() => {
    const stored = localStorage.getItem(LANG_KEY) as Lang | null;
    if (stored === 'sv' || stored === 'en') setLang(stored);
  }, []);

  const toggle = () => {
    setLang(prev => {
      const next: Lang = prev === 'sv' ? 'en' : 'sv';
      localStorage.setItem(LANG_KEY, next);
      return next;
    });
  };

  return [lang, toggle];
}
