FROM python:3.10

WORKDIR /app

COPY requirements requirements
RUN pip3 install -r requirements

COPY . .

CMD [ "python3", "main.py"]