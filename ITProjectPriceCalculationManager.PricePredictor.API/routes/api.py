from fastapi import APIRouter
from src.endpoints import predict

router = APIRouter()
router.include_router(predict.router)