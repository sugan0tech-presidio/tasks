from itertools import permutations

input_string = input("Enter a string: ")
perms = [''.join(p) for p in permutations(input_string)]
print(f"Permutations of the string are: {perms}")

