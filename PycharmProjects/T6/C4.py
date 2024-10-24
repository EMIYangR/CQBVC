from utils.DBHelper import DBHelper

db = DBHelper()
with db.cursor() as curcor:
    while True:
        print("产品表的操作类型 【1】查询 【2】增加 【3】修改 【4】删除")
        type = input("请输入操作类型：")
        if type == '1':
            res = db.queryAll(curcor, 'select * from product')
            for item in res:
                print(item)
        elif type == '2':
            proInfo = input("请输入产品信息（输入格式为“产品名称，价格”）：")
            porItem = proInfo.split("，")
            sql = "insert into product(productName,price) value (%s,%s)"
            res = db.execute(curcor, sql, (porItem[0], porItem[1]))
            print("产品保存成功！")
        elif type == '3':
            proInfo = input("请输入修改的产品信息（输入格式为“产品名称，价格”）：")
            porItem = proInfo.split("，")
            sql = "update product set price=%s where productName=%s"

            res = db.execute(curcor, sql, (porItem[0], porItem[1]))
            print("产品修改成功！")
        elif type == '4':
            proInfo = input("请输入删除的产品编号（输入格式为“产品编号”）：")
            porItem = proInfo.split("，")
            sql = "Delete from product where productID=%s"
            res = db.execute(curcor, sql, porItem[0])
            print("产品删除成功！")

        exitInfo = input("是否继续？（y=继续，N=退出）")
        if exitInfo == "n":
            break
