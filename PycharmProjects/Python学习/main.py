print("学习目录")
# print("1、Python概述")
# print("2、Python语言基础")
# print("3、序列数据")
# print("4、流程控制语句")
# print("5、字符串和正则表达式")
# print("6、函数与模块")
# print("7、文件")
# print("8、Python计算生态")
# print("9、面向对象程序设计")
# print("10、异常处理")
# print("11、数据库编程")
# print("12、GUI程序设计")
# print("13、图形绘制")

# Hello World！
print("Hello World!")

print("1、概述")
# 1、Python概述
# 1-1 输出"I Love Python！"
# print("I Love Python！")

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
# print("max=",a,"min=",c)

# 1-3 输出同心不同边长正方形的组合图形
# import turtle
#
# for i in range(5):
#     turtle.penup()
#     turtle.goto(0, -25 * (i + 1))
#     turtle.pendown()
#     length = 50 * (i + 1)
#     turtle.forward(length / 2)
#     turtle.left(90)
#     turtle.forward(length)
#     turtle.left(90)
#     turtle.forward(length)
#     turtle.left(90)
#     turtle.forward(length)
#     turtle.left(90)
#     turtle.forward(length / 2)

print("2、语言基础")
# 2、Python语言基础
# 2-1 换算华氏度为摄氏度
# Fah = eval(input("请输入一个华氏温度："))
# Cel = 5 / 9 * (Fah - 32)
# print("Fah=", Fah, "Cel=%.2f" % Cel)

# 2-2 计算e^pi并保留6位小数
# import math
# pi = 3.1415926
# print("exp(pi)=%.6f"%math.exp(pi))
#
# 2-3 判断闰年
# year = eval(input("请输入一个年份："))
# if year%400 == 0 or (year%4 == 0)and(year%10 != 0):
#     print(year,"是闰年！")
# else:
#     print(year,"不是闰年！")

# 2-4 输出实数的整数和小数部分
# shiShu = eval(input("请输入一个实数："))
# print(shiShu, "的整数部分是：", int(shiShu))
# print(shiShu, "的小数部分是：", shiShu - int(shiShu))

# 2-4-1 输出实数的整数和小数部分
# import math
# shiShu = eval(input("请输入一个实数："))
# zhenShu = math.modf(shiShu)
# print(shiShu, "的整数部分是：", int(zhenShu[1]))
# print(shiShu, "的小数部分是：", zhenShu[0])

# 2-5 已知铁的密度7.86g/cm3，求铁球的表面积和铁球的质量
# pi = 3.14155926
# r = eval(input("请输入铁球的半径（单位：cm）："))
# print("铁球的表面积是%.2f"%(4*pi*r**2),"cm²")
# print("铁球的质量是%.2f"%(4/3*pi**2*7.86),"g")

# 2-6 圆柱体表面积及体积
# pi = 3.14155926
# r = eval(input("请输入圆柱底面半径（单位：cm）："))
# h = eval(input("请输入圆柱高（单位：cm）："))
# print("圆柱的表面积是%.2f"%(2*pi*r**2+2*pi*r*h), "cm²")
# print("圆柱的体积是%.2f"%(pi*r**2*h), "cm³")

# 2-7 求一元二次方程的根
# import math
# a = float(input("请输入a的值："))
# b = float(input("请输入b的值："))
# c = float(input("请输入c的值："))
# d = b ** 2 - 2 * a * c
# if d >= 0:
#     x1 = ((-b + math.sqrt(d)) / (2 * a))
#     x2 = ((-b - math.sqrt(d)) / (2 * a))
#     print("x1=", x1, "x2=", x2)
# else:
#     print("此方程无实根！")

print("3、序列数据")
# 3、序列数据
# 3-1


# 3-2
# 3-3
# 3-4
# 3-5
# 3-6
# 3-7
# 3-8
# 3-9

print("4、流程控制语句")
# 4、流程控制语句
# 4-1 编程计算分段函数
# x = eval(input("请输入x："))
# if x <= -1:
#     print("y=", x**3+1)
# elif -1 <= x <= 1:
#     print("y=", x**2-5*x+2)
# elif x > 1:
#     print("y=", x**3-1)

# 4-2 绩效应发工资
# num = eval(input("请输入你的工号："))
# hour = eval(input("请输入你的工作时长："))
# money = 3000
# if hour < 88:
#     money = hour * 20
# elif 88 <= hour <= 176:
#     money += hour * 20
# elif hour > 176:
#     money += hour * 20 + (hour - 176) * 20 * 1.3
# print("本月应发工资为%.2f" % money)

# 4-3
# n = eval(input("请输入一个数字："))
# for i in range(n):
#     if i % 7 != 0 and i % 3 == 0:
#         print(i, end=" ")

# 4-4 银行利率
# liXi1 = 0.0195
# liXi2 = 0.04125
# bj = 10000
# for i in range(21):
#     bj += bj * liXi1
# print("方案1：20年后本息和为：%.2f" % bj)
# bj = 10000
# for i in range(4):
#     bj += bj * liXi2 * 5
# print("方案2：20年后本息和为：%.2f" % bj)

# 4-5 费马大定理
# def check_fermat(a, b, c, n):
#     flag = 0
#     for i in range(n + 1):
#         if a ** i + b ** i == c ** i:
#             flag = 1
#             break
#     print(i)
#     return flag


# a = eval(input("请输入正整数a:"))
# b = eval(input("请输入正整数b:"))
# c = eval(input("请输入正整数c（要求大于a和b）:"))
# n = eval(input("请输入指数上限n:"))
# if check_fermat(a, b, c, n):
#     print("Fermat is wrong!")
# else:
#     print("Fermat is right!")

# 4-6 3换1问题
# n = eval(input("请输入n:"))
# water = n
# while n >= 3:
#     water += n // 3
#     n = n // 3 + n % 3
# print("water=", water)

# 4-7


# 4-8
# 4-9

print("5、字符串和正则表达式")
# 5-1
# 5-2
# 5-3
# 5-4
# 5-5
# 5-6
# 5-7
# 5-8
# 5-9
