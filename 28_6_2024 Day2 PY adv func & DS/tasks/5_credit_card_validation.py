def luhn_check(card_number):
    card_number = card_number.replace(" ", "")
    n_digits = len(card_number)
    n_sum = 0
    alt = False

    for i in range(n_digits - 1, -1, -1):
        d = int(card_number[i])
        if alt:
            d *= 2
            if d > 9:
                d -= 9
        n_sum += d
        alt = not alt

    return n_sum % 10 == 0

card_number = input("Enter a credit card number: ")
if luhn_check(card_number):
    print("The credit card number is valid.")
else:
    print("The credit card number is invalid.")

