import flask as Flask

from DBHelper import DBHelper

app = Flask(__name__)
app.config.from_pyfile('config.ini')


@app.route('/')
def Index():
    db = DBHelper()
    with db.cursor() as cursor:
        res = db.queryAll(cursor, "select account, balance from account where userID=1")
        return "账户名称：" + str(res[0]['account']) + "账户余额：" + str(res[0]['balance'])


if __name__ == "__main__":
    app.run()
