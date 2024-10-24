import random


class UserManager:
    def __init__(self):
        self.users = {}

    def display_users(self):
        if not self.users:
            print("无用户！")
        else:
            for id, (username, password) in self.users.items():
                print(f"编号: {id}\t用户名: {username}\t密码: {password}")

    def add_user(self):
        id = int(random.uniform(0, 1000))
        username = input("请输入添加的用户名: ")
        password = input("请输入添加的密码: ")
        self.users[id] = (username, password)
        print("添加成功！")

    def update_user(self):
        id = int(input("请输入要修改的用户编号: "))
        username = input("请输入要修改的用户名: ")
        password = input("请输入要修改的用户密码: ")
        if id in self.users:
            self.users[id] = (username, password)
            print("修改成功！")
        else:
            print("该用户不存在！")

    def delete_user(self):
        id = int(input("请输入要删除的用户编号: "))
        if id in self.users:
            del self.users[id]
            print("删除成功！")
        else:
            print("该用户不存在！")

    def login(self):
        username = input("请输入登录的用户名: ")
        password = input("请输入登录的密码: ")
        for _, (u, p) in self.users.items():
            if u == username and p == password:
                print("登录成功！")
                return
        print("账号或密码错误！")

    def run(self):
        while True:
            operation = int(input("用户操作类型：【1】查询 【2】添加 【3】修改 【4】删除 【5】登录 \n请选择操作类型: "))
            if operation == 1:
                self.display_users()
            elif operation == 2:
                self.add_user()
            elif operation == 3:
                self.display_users()
                self.update_user()
            elif operation == 4:
                self.display_users()
                self.delete_user()
            elif operation == 5:
                self.login()
            else:
                print("输入的操作类型有误！")


users = UserManager()
users.run()
