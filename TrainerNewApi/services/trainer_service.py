import trainer_pb2
import trainer_pb2_grpc
from repositories.trainer_repository import TrainerRepository
from mappers.trainer_mapper import to_model_from_proto, to_proto_from_model

class TrainerService(trainer_pb2_grpc.TrainerServiceServicer):
    def __init__(self, repository: TrainerRepository):
        self.repository = repository

    def GetTrainer(self, request, context):
        trainer = self.repository.get_by_id(request.id)
        if not trainer:
            context.set_code(5)  # NOT_FOUND
            context.set_details("Trainer not found")
            return trainer_pb2.TrainerResponse()
        return to_proto_from_model(trainer)

    def CreateTrainer(self, request_iterator, context):
        trainers = []
        for request in request_iterator:
            trainer = to_model_from_proto(request)
            existing = self.repository.get_by_name(trainer.name)
            if not existing:
                created = self.repository.create(trainer)
                trainers.append(to_proto_from_model(created))
        return trainer_pb2.CreateTrainersResponse(
            succcess_count=len(trainers),
            trainers=trainers
        )

    def GetTrainersByName(self, request, context):
        if len(request.name) <= 1:
            context.set_code(grpc.StatusCode.INVALID_ARGUMENT)
            context.set_details("Name must be at least 2 characters long")
            return

        trainers = self.repository.get_by_name(request.name)

        for trainer in trainers:
            yield to_proto_from_model(trainer)