# name = input("输入：\n")
# print("输出：")
# print("|***********************|")
# print("|\t\t\t\t\t\t|")
# print("|\tWelcome to WHUT\t\t|")
# print("|\t\t\t\t\t\t|")
# print("|***********************|")
# print("欢迎您，%s同学！" % name)

# year = input()
# mouth = input()
# date = input()
# year = "2020"
# mouth = "09"
# date = "18"
#
# print("%s %s %s" % (year, mouth, date))
# print("%s-%s-%s" % (year, mouth, date))
# print("%s/%s/%s" % (year, mouth, date))
# print("%s,%s,%s" % (mouth, date, year))
# str = "{}年{}月{}日".format(year, mouth, date)
# print(str)
# print(year, "年", mouth, "月", date, "日")

# n = int(input("请输入n:"))
# for i in range(1, (n + 1)):
#     for j in range(i, (n + 1)):
#         print('*', end='')
#     print()

# for i in range(1, 5):
#     for j in range(0, 8):
#         print(j, end=' ')
#     print()

# count_divisible_by_3 = 0
# count_divisible_by_5 = 0
# while True:
#     num = int(input())
#     if num == -1:
#         break
#     if num % 3 == 0:
#         count_divisible_by_3 += 1
#     if num % 5 == 0:
#         count_divisible_by_5 += 1
#
# print("Divided by 3 is %d and divided by 5 is %d"%(count_divisible_by_3,count_divisible_by_5))

# def count_chars(s):
#     uppercase = 0
#     lowercase = 0
#     digits = 0
#     others = 0
#
#     for c in s:
#         if c.isupper():
#             uppercase += 1
#         elif c.islower():
#             lowercase += 1
#         elif c.isdigit():
#             digits += 1
#         else:
#             others += 1
#
#     return uppercase, lowercase, digits, others
#
#
# if __name__ == "__main__":
#     s = input("输入：")
#     uppercase, lowercase, digits, others = count_chars(s)
#     print(f"大写={uppercase},小写={lowercase},数字={digits},其他={others}")

# 输入数据
data = input().split()  # 输入一行数据，以空格分隔
x = int(input())  # 输入要查找的数据

# 在列表中查找x出现的索引编号
count = 0  # 统计x出现的次数
for i in range(len(data)):
    if data[i] == str(x):
        count += 1
        print("{} 出现的索引编号为 {}".format(x, i + 1))  # 输出索引编号，i+1是因为Python的索引从0开始

print("{} 共出现了 {} 次".format(x, count))