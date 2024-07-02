class Solution:
    def convert(self, s: str, numRows: int) -> str:
        ss = ""
        n = len(s)
        nRows = numRows-1
        step = 0
        if (n > 1) and (nRows >= 1):
            for i in range(0, numRows):
                j = i
                while j < n:
                    ss += s[j]
                    step = (nRows - (j%nRows))*2
                    j += step
        else:
            ss=s

        return ss
        
