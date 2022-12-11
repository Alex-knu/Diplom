from fastapi import APIRouter
from typing import Optional
from fastapi import Query

router = APIRouter(
    prefix="/predict",
    tags=["Predict"],
    responses={404: {"description": "Not found"}},
)

@router.post("/")
async def add_item(data):
    return 1