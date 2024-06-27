name = input("Enter your name: ")
gender = input("Enter your gender (M/F): ")

if gender.upper() == 'M':
    salutation = 'Mr.'
elif gender.upper() == 'F':
    salutation = 'Ms.'
else:
    salutation = ''

print(f"Hello, {salutation} {name}!")

