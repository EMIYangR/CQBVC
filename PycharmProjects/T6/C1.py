import pymysql as pymysql

conn = pymysql.conncect(host='127.0.0.1', port='3306', user='root', passwd='123456', db='mydb')

print(conn)
