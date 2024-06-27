def is_prime(num):
    if num < 2:
        return False
    for i in range(2, int(num**0.5) + 1):
        if num % i == 0:
            return False
    return True

numbers = [int(input(f"Enter number {i+1}: ")) for i in range(10)]
prime_numbers = [num for num in numbers if is_prime(num)]

if prime_numbers:
    average = sum(prime_numbers) / len(prime_numbers)
    print(f"Average of prime numbers: {average}")
else:
    print("No prime numbers in the list.")

