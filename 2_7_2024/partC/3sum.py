class Solution:
    def threeSumClosest(self, nums: list[int], target: int) -> int:
        nums.sort()
        answer = nums[0] + nums[1] + nums[2]
        
        for left in range(len(nums) - 2):
            middle = left + 1
            right = len(nums) - 1
            while middle < right:
                guess = nums[left] + nums[middle] + nums[right]
                if abs(guess - target) < abs(answer - target):
                    answer = guess
                if guess < target:
                    middle += 1
                elif guess > target:
                    right -= 1
                else:
                    return target
            
        return answer
