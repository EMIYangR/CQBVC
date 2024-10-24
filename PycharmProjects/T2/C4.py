num = int(input("输入一个数字："))
# 将整数转换为字符串
str_num = str(num)
# 反转字符串
reversed_str_num = str_num[::-1]
# 判断反转后的字符串是否与原字符串相等
if str_num == reversed_str_num:
    print("%s是回文数" % num)
else:
    print("%s不是回文数" % num)
