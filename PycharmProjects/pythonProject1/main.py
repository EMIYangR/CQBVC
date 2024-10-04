# # 定义一个函数，将摄氏度转换为华氏度
# def celsius_to_fahrenheit(celsius):
#     return celsius * 9 / 5 + 32
#
# # 定义一个函数，将华氏度转换为摄氏度
# def fahrenheit_to_celsius(fahrenheit):
#     return (fahrenheit - 32) * 5 / 9
#
# # 主程序
# if __name__ == '__main__':
#     # 提示用户输入摄氏度和华氏度，并将其转换为彼此
#     celsius = float(input("请输入摄氏度："))
#     fahrenheit = float(input("请输入华氏度："))
#     print(f"{celsius}摄氏度转换为华氏度为{celsius_to_fahrenheit(celsius)}")
#     print(f"{fahrenheit}华氏度转换为摄氏度为{fahrenheit_to_celsius(fahrenheit)}")

for i in range(1, 10):
    for j in range(1, i+1):
        print(f"{j}x{i}={i*j}", end='\t')
    print()