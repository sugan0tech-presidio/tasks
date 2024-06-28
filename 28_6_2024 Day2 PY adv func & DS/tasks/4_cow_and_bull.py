import random

def generate_secret_word():
    words = ["apple", "banana", "cherry", "dates", "elder", "figs", "grape", "honey"]
    return random.choice(words)

def get_cows_and_bulls(secret, guess):
    cows = sum(1 for s, g in zip(secret, guess) if s == g)
    bulls = len(set(secret) & set(guess)) - cows
    return cows, bulls

secret_word = generate_secret_word()
attempts = 0
max_attempts = 10

print("Welcome to the Cow and Bull game!")
print("Guess the secret word (4-6 letter fruit names).")

while attempts < max_attempts:
    guess = input("Enter your guess: ").lower()
    if guess == secret_word:
        print(f"Congratulations! You've guessed the word in {attempts + 1} attempts.")
        break
    cows, bulls = get_cows_and_bulls(secret_word, guess)
    print(f"Cows: {cows}, Bulls: {bulls}")
    attempts += 1

if attempts == max_attempts:
    print(f"Sorry, you've used all attempts. The secret word was: {secret_word}")

