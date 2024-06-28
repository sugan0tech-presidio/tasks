def greet(name):
    return f"Hello, {name}!"

print(greet("Alice"))

def greet_with_default(name="World"):
    return f"Hello, {name}!"

print(greet_with_default())       
print(greet_with_default("Alice"))

def add(a, b):
    return a + b

print(add(5, 3))

