try:
    n = int(input("enter the number:"))
    val = 1/n
    if n == 2:
        raise Exception('nice la', 's', "iii")
except ZeroDivisionError as e:
    print(e)
except ValueError as e:
    print(e)
finally:
    print("what ever happens this will run")
