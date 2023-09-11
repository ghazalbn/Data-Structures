n = int(input("Enter n: "))
sum = int(n*(n + 1)/2)
for i in range(n - 1):
    sum -= int(input())
print(f"The unlisted number is {sum}.")