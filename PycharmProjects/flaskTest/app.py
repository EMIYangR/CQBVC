from flask import *

from DBHelper import DBHelper

app = Flask(__name__)


@app.route('/')
def hello_world():
    return '<a href="/hello">点击跳转主页</a><br><a href="/helloAll">All</a><br><a href="/hello/3">带参数传递</a>'


@app.route('/hello/<pid>')
def helloid(pid):
    return '获取到的参数为：%s' % pid


@app.route('/hello')
def hello():
    # return '<h1 align="center">计网3班</h1>'
    # return '<p>假装有数据</p>'
    # db = DBHelper()
    # with db.cursor() as cursor:
    #     sql = "select * from product where productid=1"
    #     p = db.queryAll(cursor, sql)
    return render_template("index.html")
    # return str.format('<h2>商品名称：{0} 商品价格：{1}</h2>', p[0]['productname'], p[0]['productprice'],p=p[0])


@app.route('/helloAll')
def hello_all():
    # db = DBHelper()
    # with db.cursor() as cursor:
    #     sql = "select * from product"
    #     p = db.queryAll(cursor, sql)
    return render_template("IndexAll.html")
    # return str.format('<h2>商品名称：{0} 商品价格：{1}</h2>', p[0]['productname'], p[0]['productprice'],p=p)


@app.route('/helloAllByName')
def find():
    pname = request.args.get("pname")
    sql = str.format("select * from product where productname like {0}", '%' + pname + '%')
    print(sql)
    db = DBHelper()
    with db.cursor() as cursor:
        sql = "select * from product"
        p = db.queryAll(cursor, sql)
    return render_template("IndexAll.html")



if __name__ == "__main__":
    app.run()
