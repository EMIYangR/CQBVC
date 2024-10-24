from flask import Flask

from DBHelper import DBHelper

app = Flask(__name__)
html = '<a href="/proInfo/1">xiaomi</a><br><a href="/proInfo/2">xiaomi</a><br><a href="/proInfo/3">xiaomi</a>'


@app.route('/')
def Index():
    return html


@app.route('/proInfo/[int:proid]')
def porInfo():
    db = DBHelper()
    with db.cursor() as cursor:
        res = db.queryAll(cursor, "select ProductName, price from Product where ProductID=1")
        return "商品名称：" + str(res[0]['ProductName']) + "商品价格：" + str(res[0]['price'])


if __name__ == "__main__":
    app.run(debug=True)
