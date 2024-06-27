import re

def is_valid_name(name):
    return bool(re.match("^[A-Za-z ]+$", name))

def is_valid_age(age):
    return age.isdigit() and 0 < int(age) < 120

def is_valid_dob(dob):
    return bool(re.match("^\d{2}/\d{12}/\d{4}$", dob))

def is_valid_phone(phone):
    return bool(re.match("^\d{10}$", phone))

name = input("Enter your name: ")
while not is_valid_name(name):
    name = input("Invalid name. Enter a valid name: ")

age = input("Enter your age: ")
while not is_valid_age(age):
    age = input("Invalid age. Enter a valid age: ")

dob = input("Enter your date of birth (DD/MM/YYYY): ")
while not is_valid_dob(dob):
    dob = input("Invalid date of birth. Enter a valid date of birth (DD/MM/YYYY): ")

phone = input("Enter your phone number: ")
while not is_valid_phone(phone):
    phone = input("Invalid phone number. Enter a valid phone number: ")

print(f"Details:\nName: {name}\nAge: {age}\nDate of Birth: {dob}\nPhone: {phone}")

