def withDrawal(account):
    money = int(input("请输入取款的金额："))
    if account["balance"] < money:
        print("余额不足，取款失败！")
    else:
        account["balance"] = account["balance"] - money
        print("取款成功！")


def deposit(account):
    money = int(input("请输入存款的金额："))
    if account["balance"] < money:
        account["balance"] = account["balance"] + money
        print("存款成功！")


def queryBalance(account):
    print("您的余额为：", account["balance"])


print("欢迎使用本银行！")
print("服务种类：\n"
      "【1】查看余额 【2】取款 【3】存款")
isLoop = True
account = {"name": "Tom", "balance": 10000}
while isLoop:
    type = int(input("请输入服务种类："))
    if type == 1:
        queryBalance(account)
    elif type == 2:
        withDrawal(account)
    elif type == 3:
        deposit(account)
    else:
        print("请输入正确的服务种类！")
    tip = input("是否继续操作？(y/n)")
    if tip == "n":
        break
