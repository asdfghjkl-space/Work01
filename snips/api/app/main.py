import os
from fastapi import FastAPI, Depends, HTTPException, Query
from sqlmodel import select, Session
from .db import init_db, get_session
from .models import Project, CodeFile
from .schemas import ProjectCreate, ProjectOut

app = FastAPI(title="SnipShare API")

ALLOW_EXTS = set((os.getenv("ALLOW_EXTS") or ".py,.js,.ts,.cs,.ps1,.sh,.sql,.bat,.md,.txt").split(","))
MAX_FILE_SIZE = int(os.getenv("MAX_FILE_SIZE", "200000"))
MAX_PROJECT_SIZE = int(os.getenv("MAX_PROJECT_SIZE", "1000000"))


@app.on_event("startup")
def on_startup():
    init_db()


@app.get("/healthz")
def healthz():
    return {"ok": True}


@app.post("/projects", response_model=ProjectOut)
def create_project(payload: ProjectCreate, session: Session = Depends(get_session)):
    # サイズ＆拡張子チェック
    total = 0
    for f in payload.files:
        ext = os.path.splitext(f.filename)[1].lower()
        if ext not in ALLOW_EXTS:
            raise HTTPException(status_code=400, detail=f"Extension not allowed: {ext}")
        size = len(f.content.encode("utf-8"))
        if size > MAX_FILE_SIZE:
            raise HTTPException(status_code=400, detail=f"File too large: {f.filename}")
        total += size
    if total > MAX_PROJECT_SIZE:
        raise HTTPException(status_code=400, detail="Project too large")

    proj = Project(owner_id=1, title=payload.title, description=payload.description,
                   category=payload.category, license=payload.license)
    session.add(proj)
    session.commit()
    session.refresh(proj)

    for f in payload.files:
        cf = CodeFile(project_id=proj.id, filename=f.filename, language=f.language,
                      content=f.content, size_bytes=len(f.content.encode("utf-8")))
        session.add(cf)
    session.commit()

    return ProjectOut(id=proj.id, title=proj.title, description=proj.description,
                      category=proj.category, license=proj.license)


@app.get("/projects")
def list_projects(q: str | None = None, category: str | None = None,
                  language: str | None = None, session: Session = Depends(get_session)):
    stmt = select(Project)
    if q:
        like = f"%{q}%"
        stmt = stmt.where((Project.title.ilike(like)) | (Project.description.ilike(like)))
    if category:
        stmt = stmt.where(Project.category == category)
    # language は files 経由での厳密絞り込みは後日対応（MVPはクライアント側フィルタでもOK）
    rows = session.exec(stmt.order_by(Project.created_at.desc())).all()
    return [{
        "id": p.id,
        "title": p.title,
        "description": p.description,
        "category": p.category,
        "license": p.license
    } for p in rows]


@app.get("/projects/{pid}")
def get_project(pid: int, session: Session = Depends(get_session), pro: bool = Query(False)):
    proj = session.get(Project, pid)
    if not proj:
        raise HTTPException(status_code=404, detail="Not found")
    if not proj.is_public:
        raise HTTPException(status_code=404, detail="Not found")
    files = session.exec(select(CodeFile).where(CodeFile.project_id == pid)).all()

    def mask(content: str) -> str:
        lines = content.splitlines()
        head = "\n".join(lines[:10])
        return head + "\n/* ...locked. Upgrade to Pro to view full code... */\n"

    return {
        "project": {
            "id": proj.id,
            "title": proj.title,
            "description": proj.description,
            "category": proj.category,
            "license": proj.license
        },
        "files": [{
            "filename": f.filename,
            "language": f.language,
            "content": f.content if pro else mask(f.content)
        } for f in files]
    }
