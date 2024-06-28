def longest_unique_substtr(string):
    n = len(string)
    res = 0
    for i in range(n):
        visited = [0] * 256
        for j in range(i, n):
            if visited[ord(string[j])] == 1:
                break
            else:
                res = max(res, j - i + 1)
                visited[ord(string[j])] = 1
        visited[ord(string[i])] = 0
    return res

input_string = input("Enter a string: ")
length = longest_unique_substtr(input_string)
print(f"The length of the longest substring without repeating characters is {length}.")

