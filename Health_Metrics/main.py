from fastapi import FastAPI, HTTPException
from pydantic import BaseModel
from sqlalchemy import create_engine, Column, Integer, String, Float, DateTime
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker
from datetime import datetime

app = FastAPI()

DATABASE_URL = "postgresql://user:password@db/health_metrics"
engine = create_engine(DATABASE_URL)
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)
Base = declarative_base()

class Metric(Base):
    __tablename__ = "metrics"
    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(String, index=True)
    heart_rate = Column(Float)
    calories_burned = Column(Float)
    timestamp = Column(DateTime, default=datetime.utcnow)

Base.metadata.create_all(bind=engine)

class MetricRequest(BaseModel):
    user_id: str
    heart_rate: float
    calories: float

@app.get("/")
def read_root():
    return {"message": "Welcome to the Health Metrics API!"}

@app.post("/metrics")
def add_metric(metric: MetricRequest):
    db = SessionLocal()
    db_metric = Metric(
        user_id=metric.user_id,
        heart_rate=metric.heart_rate,
        calories=metric.calories
    )
    db.add(db_metric)
    db.commit()
    db.refresh(db_metric)
    db.close()
    return {"message": "Metric added successfully"}

@app.get("/metrics/{user_id}")
def get_metrics(user_id: str):
    db = SessionLocal()
    metrics = db.query(Metric).filter(Metric.user_id == user_id).all()
    db.close()
    if not metrics:
        raise HTTPException(status_code=404, detail="Metrics not found")
    return metrics

@app.get("/metrics/{user_id}/summary")
def get_summary(user_id: str):
    db = SessionLocal()
    metrics = db.query(Metric).filter(Metric.user_id == user_id).all()
    db.close()
    if not metrics:
        raise HTTPException(status_code=404, detail="Metrics not found")
    avg_heart_rate = sum(m.heart_rate for m in metrics) / len(metrics)
    total_calories = sum(m.calories for m in metrics)
    return {"average_heart_rate": avg_heart_rate, "total_calories": total_calories}
