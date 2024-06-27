# input and output
var = str(input("Enter something:"))
print(var)

# dynamic types
var = 8
# adding types
tmp: int = 25
print(var)
print(tmp)
# tmp = "did", will throw LSp waring execution will be fine
# print(tmp)

if(tmp == 25):
    cummulative_val = 0
    for value in range(tmp):
        print(value, end=" ")
        cummulative_val += value
        print()

    print(f"total: {cummulative_val}")




fun test():
    
