def is_prime(num):
    if num < 2:
        return False
    for i in range(2, int(num**0.5) + 1):
        if num % i == 0:
            return False
    return True

def prime_numbers_up_to(n):
    primes = [num for num in range(2, n + 1) if is_prime(num)]
    return primes

max_num = int(input("Enter a number: "))
primes = prime_numbers_up_to(max_num)
print(f"Prime numbers up to {max_num}: {primes}")

