if __name__ == '__main__':
    n = int(input())
    arr = list(map(int, input().split()))
    print(max([a for a in arr if a < max(arr)]))
