FROM tiangolo/uvicorn-gunicorn-fastapi:python3.10

WORKDIR /app

COPY ITProjectPriceCalculationManager.PricePredictor.API/requirements requirements
RUN pip3 install --no-cache-dir --upgrade -r requirements

COPY ITProjectPriceCalculationManager.PricePredictor.API/ .

CMD ["uvicorn", "app.main:app", "--host", "0.0.0.0", "--port", "80"]