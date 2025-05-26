FROM python:3.11-slim

WORKDIR /app


RUN pip install --no-cache-dir grpcio grpcio-tools protobuf pymongo


COPY . .


RUN python -m grpc_tools.protoc \
    -I. \
    --python_out=. \
    --grpc_python_out=. \
    trainer.proto

EXPOSE 50051

CMD ["python", "server.py"]
