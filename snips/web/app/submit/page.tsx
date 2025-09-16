'use client';
import { useState } from 'react';

const API = process.env.NEXT_PUBLIC_API_BASE || 'http://localhost:8000';

export default function Submit() {
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');
  const [category, setCategory] = useState('Web');
  const [license, setLicense] = useState('MIT');
  const [filename, setFilename] = useState('hello.py');
  const [language, setLanguage] = useState('python');
  const [content, setContent] = useState('print("hello")');
  const [msg, setMsg] = useState('');

  const submit = async () => {
    const res = await fetch(`${API}/projects`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        title,
        description,
        category,
        license,
        files: [{ filename, language, content }]
      })
    });
    if (!res.ok) {
      setMsg('投稿失敗');
      return;
    }
    const data = await res.json();
    setMsg(`投稿成功: #${data.id}`);
  };

  return (
    <main style={{ maxWidth: 800, margin: '40px auto', padding: 16 }}>
      <h1>投稿</h1>
      <input
        placeholder="タイトル"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        style={{ width: '100%', padding: 8 }}
      />
      <textarea
        placeholder="説明文"
        value={description}
        onChange={(e) => setDescription(e.target.value)}
        style={{ width: '100%', padding: 8, marginTop: 8, height: 120 }}
      />
      <div style={{ display: 'flex', gap: 8, marginTop: 8 }}>
        <input
          placeholder="カテゴリ"
          value={category}
          onChange={(e) => setCategory(e.target.value)}
        />
        <input
          placeholder="ライセンス"
          value={license}
          onChange={(e) => setLicense(e.target.value)}
        />
      </div>
      <h3 style={{ marginTop: 16 }}>ファイル</h3>
      <div style={{ display: 'flex', gap: 8 }}>
        <input
          placeholder="ファイル名"
          value={filename}
          onChange={(e) => setFilename(e.target.value)}
        />
        <input
          placeholder="言語"
          value={language}
          onChange={(e) => setLanguage(e.target.value)}
        />
      </div>
      <textarea
        placeholder="コード本文"
        value={content}
        onChange={(e) => setContent(e.target.value)}
        style={{ width: '100%', padding: 8, marginTop: 8, height: 200 }}
      />
      <div style={{ marginTop: 12 }}>
        <button onClick={submit}>投稿する</button>
      </div>
      <div style={{ marginTop: 8 }}>{msg}</div>
    </main>
  );
}
