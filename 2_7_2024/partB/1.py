from collections import Counter

no_of_shoes = int(input())
shoe_size_list = Counter(list(map(int,input().split())))

no_of_cust = int(input())
m_r=0
for i in range(no_of_cust):
    size_req , money = map(int, input().split())
    for k,v in Counter(shoe_size_list).items():
        if size_req== k:
            m_r+=money
            shoe_size_list[size_req]= shoe_size_list[size_req]-1
            if shoe_size_list[size_req]==0:
                del shoe_size_list[size_req]
                
print(m_r)

