from models.trainer import Trainer, Medal, MedalType
from google.protobuf.timestamp_pb2 import Timestamp
import trainer_pb2

def to_proto_from_model(trainer: Trainer):
    return trainer_pb2.TrainerResponse(
        id=trainer.id,
        name=trainer.name,
        age=trainer.age,
        birthdate=Timestamp(seconds=int(trainer.birthdate.timestamp())),
        created_at=Timestamp(seconds=int(trainer.created_at.timestamp())),
        medals=[
            trainer_pb2.Medals(region=m.region, type=trainer_pb2.MedalType.Value(m.type.name))
            for m in trainer.medals
        ]
    )

def to_model_from_proto(request: trainer_pb2.CreateTrainerRequest):
    medals = [Medal(m.region, MedalType(m.type)) for m in request.medals]
    return Trainer(
        id='',
        name=request.name,
        age=request.age,
        birthdate=request.birthdate.ToDatetime(),
        created_at=Timestamp().ToDatetime(),
        medals=medals
    )
