# 自定义一个异常类，继承自基础的 Exception 类
class NumberFormatException(Exception):
    def __init__(self, arg):
        self.args = arg


try:
    string = input("请输入一个数字：")
    if not string.isdigit():
        raise NumberFormatException(string+" is invalid！")
    else:
        print("输入的数字是", string)
except NumberFormatException as e:
    print("".join(e.args))
    print("非法的数字格式！")
