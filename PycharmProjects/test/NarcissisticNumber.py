for i in range(100, 1000):
    # 将整数转换为字符串，以便可以逐个字符地访问每个数字
    num_str = str(i)
    # 计算每个数字的n次幂之和
    sum = 0
    n = len(num_str)
    for j in num_str:
        sum += int(j) ** n
    # 如果这个数的n次幂之和等于它本身，则它是一个水仙花数
    if sum == i:
        print(i)

for i in range(1, 10):
    for j in range(1, i+1):
        print(f"{j}x{i}={i*j}\t", end="")
    print()

def is_leap_year(year):
    if year % 4 == 0:
        if year % 100 == 0:
            if year % 400 == 0:
                return True
            else:
                return False
        else:
            return True
    else:
        return False
print(is_leap_year(2020))  # 输出：True
print(is_leap_year(2021))  # 输出：False