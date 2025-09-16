# SnipShare MVP Starter

SnipShare is a minimal full-stack starter kit for sharing code snippets with gated full access for paying subscribers. The stack runs locally via Docker Compose and is ready for deployment through services such as Cloudflare Tunnel.

## Stack

- **Frontend**: Next.js 14 (TypeScript, App Router)
- **Backend**: FastAPI (Python)
- **Database**: PostgreSQL 15
- **Mail (development)**: Mailpit
- **Payments**: Stripe (test mode)
- **Orchestration**: Docker Compose

## Repository Structure

```
/snips
  ├─ docker-compose.yml
  ├─ docker-compose.override.yml
  ├─ .env
  ├─ .devcontainer/devcontainer.json
  ├─ api/
  │    ├─ Dockerfile
  │    ├─ requirements.txt
  │    └─ app/
  │         ├─ __init__.py
  │         ├─ main.py
  │         ├─ db.py
  │         ├─ models.py
  │         └─ schemas.py
  └─ web/
       ├─ Dockerfile
       ├─ package.json
       ├─ package-lock.json
       ├─ next.config.mjs
       └─ app/
            ├─ layout.tsx
            ├─ page.tsx
            ├─ submit/page.tsx
            └─ globals.css
```

## Running Locally

```bash
# Start all services (database, API, frontend, mailpit)
cd snips
docker compose up --build
```

- Frontend: http://localhost:3000
- API: http://localhost:8000/healthz
- Mailpit: http://localhost:8025

## FastAPI Highlights

- `POST /projects`: create a project with file validation (extension and size limits configured via environment variables).
- `GET /projects`: list projects with basic keyword and category filtering.
- `GET /projects/{id}`: fetch project details. By default, code content is truncated to the first 10 lines with a Pro upsell notice. Pass `?pro=true` to view full content (demo flow prior to implementing authentication and billing).

## Next.js Highlights

- Homepage lists projects with quick search and category toggles.
- `/submit` provides a bare-bones submission form that posts to the API.

## Dev Container Support

The repository ships with a VS Code Dev Container configuration (`.devcontainer/devcontainer.json`) that boots the entire stack with hot reload:

- FastAPI runs with `uvicorn --reload` and mounts the `api/app` directory.
- Next.js runs via `next dev` with the project directory mounted.
- Ports 3000, 8000, and 8025 are forwarded automatically.
- On container creation, Python and Node dependencies are installed inside the workspace.

## Next Steps

1. Implement a dedicated project detail page on the frontend that switches between locked and full views.
2. Add a reporting flow (`POST /reports`) and admin endpoints for moderation.
3. Introduce email-based authentication and role management.
4. Replace the `?pro=` demo flag with real subscription checks via Stripe integration.
5. Support project thumbnails and additional safeguards (NG word detection, stricter validation).

Refer to the project brief for an extended roadmap covering automation, testing, and operational tasks.
