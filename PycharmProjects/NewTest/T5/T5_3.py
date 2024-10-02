import csv
import xlwt
import xlrd

import xlwt  # 导入xlwt模块

import pyodbc

# 创建连接字符串
conn_str = (
    r'DRIVER={ODBC Driver 17 for SQL Server};'
    r'SERVER=.;'
    r'DATABASE=Meixin;'
    r'UID=sa;'
    r'PWD=123456'
)

cnxn = pyodbc.connect(conn_str)
print(cnxn)

cursor = cnxn.cursor()
cursor.execute('SELECT * FROM Admin')
# cursor.execute('''
#    CREATE TABLE Users (
#         ID int IDENTITY(1,1) PRIMARY KEY,
#         Username nvarchar(50) NOT NULL
#     )
# ''')


for row in cursor:
    print(row)

# 提交更改
cnxn.commit()
# 关闭连接
cnxn.close()

# import pymysql
# conn = pymysql.connect(host='127.0.0.1',port=3306,
#                        user='root', passwd='123456', db='moviedb', charset='utf8')
# cursor = conn.cursor()   #获取游标对象
# rows = cursor.execute("select * from user") #执行SQL语句
# print("查询到%d条用户记录数"%(rows))
# results = cursor.fetchall()  #获取所有的记录
# for rowItem in results:   #循环遍历每一行记录
#     print("用户编号：%d 用户名：%s 密码：%s"%(rowItem[0],rowItem[1],rowItem[2]))
# conn.commit()  #提交数据库连接，如果是增、删、改操作，则必须提交
# cursor.close() #关闭游标对象
# conn.close()   #关闭数据库连接

# import pymysql
#
# conn = pymysql.connect(host='127.0.0.1',port=3306,
#                        user='root', passwd='123456', db='moviedb', charset='utf8')
# cursor = conn.cursor()   #获取游标对象
# #定义创建user表的sql语句，使用三引号'''表示格式化字符串
# sql = '''CREATE TABLE user1 ( userid int(11) NOT NULL auto_increment,
#   username varchar(60) NOT NULL,
#   userpass varchar(60) default NULL,
#   PRIMARY KEY  (userid))'''
# rows = cursor.execute(sql) #执行SQL语句
# conn.commit()  #提交数据库连接，如果是增、删、改操作，则必须提交
# print("user表创建成功")
# cursor.close() #关闭游标对象
# conn.close()   #关闭数据库连接

# # 创建内容的样式对象，包括字体样式以及数字的格式
# style0 = xlwt.easyxf('font: name Times New Roman, color-index blue, bold on', num_format_str='#,##0.00')
# wb = xlwt.Workbook()
# ws = wb.add_sheet('Sheet1')  # 添加一个sheet
# # 需要将中文通过u""的形式转换为unicode编码
# data = [[u"编号", u"姓名", u"年龄", u"地址"],
#         [1, u"张小明", 34, u"上海"], [2, u"李建成", 31, u"北京"]]
# for i in range(0, data.__len__()):  # 循环遍历每一行
#     for j in range(0, data[i].__len__()):  # 循环遍历第i行的每一列
#         ws.write(i, j, data[i][j], style0)
# wb.save('b.xls')

# def read_excel():
#     workbook = xlrd.open_workbook('诗文绘画作品信息统计表.xlsx')  # 打开Excel文件读取数据
#     print(workbook.sheet_names())  # 获取所有sheet
#     # sheet2 = workbook.sheet_names()[0] #第一种方式，根据下标获取
#     sheet = workbook.sheet_by_index(0)  # 第二种方式，根据sheet索引获取sheet对象，索引从0开始
#     # sheet = workbook.sheet_by_name('Sheet1') #第三种方式,根据sheet名称获取sheet对象
#     print(sheet.name, sheet.nrows, sheet.ncols)  # sheet的名称、行数和列数
#     # 获取整行和整列的值（数组）
#     rows = sheet.row_values(2)  # 获取第三行内容
#     cols = sheet.col_values(2)  # 获取第三列内容
#     print(str(rows), '\n', cols)
#     # 获取单元格内容
#     print(sheet.cell(1, 0).value, end=" ")
#     print(sheet.cell_value(1, 0), end=" ")
#     print(sheet.row(1)[0].value, end=" ")
#     print(sheet.cell(1, 0).ctype)  # 获取单元格内容的数据类型
#
#
# if __name__ == '__main__':  # 类似于Java的main()函数,也可以直接调用read_excel()
#     read_excel()

# var = csv.reader(open('a.csv', 'r'))
# for line in var:
#     for item in line:
#         print(item, end=' ')
#     print()

# csv_file =open('a.csv', 'a+')
# writer = csv.writer(csv_file)
# writer.writerow(['张三', 20, '重庆市'])
# data = [('张三1', 20, '重庆市'), ('张三2', 20, '重庆市')]
# writer.writerows(data)
# csv_file.close()
