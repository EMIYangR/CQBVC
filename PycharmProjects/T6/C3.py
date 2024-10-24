import pymysql


def connDB():
    conn = pymysql.conncect(host='127.0.0.1', port='3306', user='root', passwd='123456', db='mydb')
    curcor = conn.curcor()
    return (conn, curcor)


def execultSql(sql, params):
    DBconn = connDB()
    conn = DBconn[0]
    curcor = DBconn[1]
    try:
        num = curcor.execute(sql, params)
        conn.commit()
        return num
    except Exception as e:
        print(e)
        conn.rollback()
        return 0
    finally:
        curcor.colse()
        conn.colse()


def query(sql, params=None):
    DBconn = connDB()
    conn = DBconn[0]
    curcor = DBconn[1]
    try:
        num = curcor.execute(sql, params)
        results = curcor.fetchall()
        for row in results:
            print(row)
    except Exception as e:
        print(e)
    finally:
        curcor.colse()
        conn.colse()


while True:
    print("产品表的操作类型 【1】查询 【2】增加 【3】修改 【4】删除")
    type = input("请输入操作类型：")
    if type == '1':
        query('select * from product')
    elif type == '2':
        proInfo = input("请输入产品信息（输入格式为“产品名称，价格”）：")
        porItem = proInfo.split("，")
        execultSql("insert into product(productName,price) value (%s,%s)", (porItem[0], porItem[1]))
        print("产品保存成功！")
    elif type == '3':
        proInfo = input("请输入修改的产品信息（输入格式为“产品名称，价格”）：")
        porItem = proInfo.split("，")
        execultSql("update product set price=%s where productName=%s", (porItem[0], porItem[1]))
        print("产品修改成功！")
    elif type == '4':
        proInfo = input("请输入删除的产品编号（输入格式为“产品编号”）：")
        porItem = proInfo.split("，")
        execultSql("Delete from product where productID=%s", proInfo)
        print("产品删除成功！")

    exitInfo = input("是否继续？（y=继续，N=退出）")
    if exitInfo == "n":
        break

