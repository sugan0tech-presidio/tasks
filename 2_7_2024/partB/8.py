if __name__ == '__main__':
    n = int(input())
    for x in range(1, n+1):
        if x ==1:
            r = 1
        elif x < 10:
            r = (r*10)+x
        elif x > 9 and x<100:
            r = (r*100)+x
        elif x> 99:
            r = (r*1000)+x
    print(r)
