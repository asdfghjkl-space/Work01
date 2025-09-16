from pydantic import BaseModel
from typing import List


class CodeFileIn(BaseModel):
    filename: str
    language: str
    content: str


class ProjectCreate(BaseModel):
    title: str
    description: str
    category: str
    license: str
    files: List[CodeFileIn]


class ProjectOut(BaseModel):
    id: int
    title: str
    description: str
    category: str
    license: str
