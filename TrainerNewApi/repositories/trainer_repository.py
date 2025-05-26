from models.trainer import Trainer, Medal, MedalType
from bson import ObjectId

class TrainerRepository:
    def __init__(self, collection):
        self.collection = collection

    def get_by_id(self, trainer_id: str):
        doc = self.collection.find_one({"_id": trainer_id})
        return self._doc_to_model(doc) if doc else None

    def get_by_name(self, name: str):
        docs = self.collection.find({"name": {"$regex": name, "$options": "i"}})
        return [self._doc_to_model(d) for d in docs]

    def create(self, trainer: Trainer):
        doc = self._model_to_doc(trainer)
        self.collection.insert_one(doc)
        return self._doc_to_model(doc)

    def _doc_to_model(self, doc):
        medals = [Medal(m['region'], MedalType(m['type'])) for m in doc.get('medals', [])]
        return Trainer(
            id=str(doc['_id']),
            name=doc['name'],
            age=doc['age'],
            birthdate=doc['birthdate'],
            medals=medals,
            created_at=doc['created_at']
        )

    def _model_to_doc(self, trainer):
        return {
            "_id": trainer.id or str(ObjectId()),
            "name": trainer.name,
            "age": trainer.age,
            "birthdate": trainer.birthdate,
            "created_at": trainer.created_at,
            "medals": [{"region": m.region, "type": m.type.value} for m in trainer.medals]
        }
