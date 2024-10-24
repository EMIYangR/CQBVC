age = 0
deng = ""
while True:

    try:
        age = int(input("请输入年龄："))
    except ValueError:
        print("输入错误，请输入一个整数。")
        continue

    if age < 0:
        deng = "细胞"
    elif age < 10:
        deng = "幼"
    elif age < 20:
        deng = "小"
    elif age < 40:
        deng = "青"
    elif age < 60:
        deng = "中"
    elif age < 80:
        deng = "老"
    elif age < 120:
        deng = "老逼"
    else:
        print("一眼丁真")
        continue

    print("你好，%s登" % deng)
