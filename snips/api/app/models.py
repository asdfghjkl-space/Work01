from datetime import datetime
from typing import Optional
from sqlmodel import SQLModel, Field


class User(SQLModel, table=True):
    id: Optional[int] = Field(default=None, primary_key=True)
    email: str
    name: str
    role: str = "user"  # user/mod/admin
    created_at: datetime = Field(default_factory=datetime.utcnow)


class Subscription(SQLModel, table=True):
    id: Optional[int] = Field(default=None, primary_key=True)
    user_id: int
    status: str = "inactive"  # active/canceled/inactive
    current_period_end: Optional[datetime] = None


class Project(SQLModel, table=True):
    id: Optional[int] = Field(default=None, primary_key=True)
    owner_id: int
    title: str
    description: str
    category: str
    license: str
    is_public: bool = True
    created_at: datetime = Field(default_factory=datetime.utcnow)
    updated_at: datetime = Field(default_factory=datetime.utcnow)


class CodeFile(SQLModel, table=True):
    id: Optional[int] = Field(default=None, primary_key=True)
    project_id: int
    filename: str
    language: str
    content: str
    size_bytes: int
