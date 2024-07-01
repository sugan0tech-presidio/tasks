from dataclasses import dataclass

@dataclass
class Employee:
    name: str
    dept: str
    age: int


sugan = Employee("sugan", "dept", 21)
print(sugan)
