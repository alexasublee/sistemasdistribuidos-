from enum import Enum
from datetime import datetime
from typing import List

class MedalType(Enum):
    UNKNOWN = 0
    GOLD = 1
    SILVER = 2
    BRONZE = 3

class Medal:
    def __init__(self, region: str, type: MedalType):
        self.region = region
        self.type = type

class Trainer:
    def __init__(self, id: str, name: str, age: int, birthdate: datetime, medals: List[Medal], created_at: datetime):
        self.id = id
        self.name = name
        self.age = age
        self.birthdate = birthdate
        self.medals = medals
        self.created_at = created_at
