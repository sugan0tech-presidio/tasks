import csv

employees = [
    ["Alice Johnson", "alice.johnson@example.com", "HR"],
    ["Bob Smith", "bob.smith@example.com", "Engineering"],
    ["Charlie Brown", "charlie.brown@example.com", "Marketing"],
    ["David Wilson", "david.wilson@example.com", "Sales"],
    ["Eva Turner", "eva.turner@example.com", "Finance"],
]

file_name = "employees.csv"

with open(file_name, "w", newline='') as file:
    writer = csv.writer(file)
    writer.writerow(["Name", "Email", "Department"])  # Header
    writer.writerows(employees)

print(f"{file_name} has been created with sample data.")

