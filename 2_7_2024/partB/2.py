import math
import os
import random
import re
import sys

from collections import Counter
if __name__ == '__main__':
    s = sorted(input())
    cnt = Counter(s).most_common(3)
    for _ in cnt:
        result = ' '.join(str(item) for item in _)
        print(result)

