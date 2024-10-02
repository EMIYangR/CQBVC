import pymysql
import contextlib

class DBHelper():
    # 定义上下文管理器，连接后自动关闭连接
    @contextlib.contextmanager
    def cursor(self, host='127.0.0.1', port=3306, user='root',
               passwd='123456', db='moviedb', charset='utf8'):
        conn = pymysql.connect(host=host, port=port, user=user,
                               passwd=passwd, db=db, charset=charset)

        # 以字典的形式获取数据
        cursor = conn.cursor(cursor=pymysql.cursors.DictCursor)
        print("-------------------")
        try:
            yield cursor
            conn.commit()  # 操作成功提交事务
        except Exception as e:
            print(e)
            conn.rollback()  # 出现异常进行回滚操作
        finally:
            cursor.close()
            conn.close()
    # 查询，返回查询结果
    def queryAll(self, cursor, sql, params=None):  # 查询所有的记录
        cursor.execute(sql, params)
        return cursor.fetchall()

    # 增删改，返回受影响的行数
    def execute(self, cursor, sql, params=None):
        effectedNum = cursor.execute(sql, params)
        return effectedNum


if __name__ == "__main__":
    dbHelper = DBHelper()   # 封装使用
    with dbHelper.cursor() as cursor:
        results = dbHelper.queryAll(cursor, "select * from product")
        for item in results:
            print(item)
        sql="insert product values(0,'huawei mate60',6799)"
        dbHelper.execute(cursor,sql)