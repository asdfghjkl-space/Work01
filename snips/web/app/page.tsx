'use client';
import { useEffect, useState } from 'react';

const API = process.env.NEXT_PUBLIC_API_BASE || 'http://localhost:8000';

type ProjectListItem = {
  id: number;
  title: string;
  description: string;
  category: string;
  license: string;
};

export default function Home() {
  const [q, setQ] = useState('');
  const [category, setCategory] = useState('');
  const [items, setItems] = useState<ProjectListItem[]>([]);

  const fetchList = async () => {
    const url = new URL(`${API}/projects`);
    if (q) url.searchParams.set('q', q);
    if (category) url.searchParams.set('category', category);
    const res = await fetch(url.toString());
    if (!res.ok) return;
    setItems(await res.json());
  };

  useEffect(() => {
    fetchList();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const toggleCategory = (name: string) => {
    setCategory((prev) => (prev === name ? '' : name));
  };

  return (
    <main style={{ maxWidth: 900, margin: '40px auto', padding: 16 }}>
      <h1>SnipShare</h1>
      <div style={{ display: 'flex', gap: 8, marginTop: 8 }}>
        <input
          value={q}
          onChange={(e) => setQ(e.target.value)}
          placeholder="検索キーワード"
          style={{ flex: 1, padding: 8 }}
        />
        <button onClick={fetchList}>Search</button>
      </div>
      <div style={{ marginTop: 8 }}>
        <label>
          <input
            type="checkbox"
            checked={category === 'Excel'}
            onChange={() => toggleCategory('Excel')}
          />{' '}
          Excel効率化
        </label>{' '}
        <label>
          <input
            type="checkbox"
            checked={category === 'Image'}
            onChange={() => toggleCategory('Image')}
          />{' '}
          画像処理
        </label>{' '}
        <label>
          <input
            type="checkbox"
            checked={category === 'Web'}
            onChange={() => toggleCategory('Web')}
          />{' '}
          Web/スクレイピング
        </label>
      </div>
      <ul style={{ marginTop: 16 }}>
        {items.map((it) => (
          <li
            key={it.id}
            style={{
              border: '1px solid #ddd',
              padding: 12,
              borderRadius: 8,
              marginBottom: 12
            }}
          >
            <a href={`/project/${it.id}`}>
              <b>{it.title}</b>
            </a>
            <div style={{ color: '#666' }}>{it.description}</div>
            <small>
              {it.category} • {it.license}
            </small>
          </li>
        ))}
      </ul>
      <a href="/submit">+ 投稿</a>
    </main>
  );
}
