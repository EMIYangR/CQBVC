import pymysql


def getConn():
    conn = pymysql.conncect(host='127.0.0.1', port='3306', user='root', passwd='123456', db='mydb')
    return conn


def execultSql():
    conn = getConn()
    curcor = conn.curcor()
    createSql = 'create table product(productID int(11) not null auto_increment, productName varchar(60) not null,price int default 0,primary key (productID))'
    curcor.execult(createSql)
    curcor.execult("insert into product(productName,price) value ('mi6',2399)")
    curcor.execult("insert into product(productName,price) value ('meizu pro7',2999)")
    curcor.execult("insert into product(productName,price) value ('vivo x9s',2499)")
    conn.commit()
    curcor.execult("select * from product")
    results = curcor.fetchall()
    for rowItem in results:
        print("产品编号：%d, 产品名称：%s,价格：%d" % (rowItem[0], rowItem[1], rowItem[2]))
    curcor.close()
    conn.close()


if __name__ == "__main__":
    execultSql()
