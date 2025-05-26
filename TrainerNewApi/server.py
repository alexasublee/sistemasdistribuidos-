import grpc
from concurrent import futures
from pymongo import MongoClient
from services.trainer_service import TrainerService
import trainer_pb2_grpc

import os
MONGO_URI = os.getenv("MONGO_URI", "mongodb://localhost:27017")
DB_NAME = os.getenv("DB_NAME", "TrainerDB")
COLLECTION = os.getenv("TRAINERS_COLLECTION", "trainers")


client = MongoClient(MONGO_URI)
db = client[DB_NAME]
collection = db[COLLECTION]


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    from repositories.trainer_repository import TrainerRepository
    repository = TrainerRepository(collection)

    trainer_pb2_grpc.add_TrainerServiceServicer_to_server(
        TrainerService(repository), server
    )

    server.add_insecure_port('[::]:50051')
    print("Servidor gRPC escuchando en puerto 50051")
    server.start()
    server.wait_for_termination()

if __name__ == '__main__':
    serve()
