def is_leap(year):
    leap = False

    if (year/4) % 2 == 0:                
        leap = True
        if (year/100) % 2 == 0:           
            if (year/400) % 2 == 0:       
                leap = True
    return leap

