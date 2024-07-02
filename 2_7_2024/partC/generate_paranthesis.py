class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        result = set()
        if n == 1:
            return ["()"]
        for p in self.generateParenthesis(n - 1):
            for i,c in enumerate(p):
                if c == '(':
                    result.add(p[:i+1] + "()" + p[i+1:])
            result.add(p + "()")
        return list(result)    
        
