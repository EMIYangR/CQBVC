# print("Hello World!")

# a = eval(input("请输入一个数a："))
# b = eval(input("请输入一个数b："))
# if a < b:
#     a, b = b, a
#     print("max=", a, "min=", b)

# 使用Python实现三个数的大小比较，输出最大值和最小值
# import numbers
#
# a: numbers = eval(input("请输入一个数a:"))
# b: numbers = eval(input("请输入一个数b:"))
# c: numbers = eval(input("请输入一个数c:"))
# if a > b and a > c:
#     if b > c:
#         b, c = c, b
# elif b > a and b > c:
#     a, b = b, a
#     if b > c:
#         b, c = c, b
# elif c > a and c > b:
#     a, c = c, a
# if b > c:
#         b, c = c, b
# print("max=", a, "min=", b)


# 1-2 比较三个数的大小并输出
# a = eval(input("请输入第一个数："))
# b = eval(input("请输入第二个数："))
# c = eval(input("请输入第三个数："))
# if a >= b and a >= c:
#     if b < c:
#         b, c = c, b
# elif b >= a and b >= c:
#     if a > c:
#         a, b = b, a
#     else:
#         a, b = b, a
#         b, c = c, b
# elif c >= a and c >= b:
#     if a < b:
#         a, c = c, a
#     else:
#         a, c = c, a
#         c, b = b, c
# print("max=", a, "min=", c)

a = 119
b = 120
print(a * 1024 * 1024 * 1024)
print(b * 1024 * 1024 * 1024)

c = (128849018880 - 128849014784)
print(c / 1024 / 1024 / 1024)
