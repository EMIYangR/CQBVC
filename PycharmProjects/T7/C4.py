from flask import Flask, render_template, request

from DBHelper import DBHelper

app = Flask(__name__)
db = DBHelper()


@app.route('/')
def Index():
    return render_template("login.html")


@app.route('/register')
def Index():
    return render_template("register.html")


@app.route('/resHandle', methods=["GET", "POST"])
def Index():
    if request.method == "POST":
        username = request.form.get("username")
        pwd = request.form.get("userpwd")
        with db.cursor() as cursor:
            sql = "insert into userInfo values(null, '%s','%s')" % (username, pwd)
            res = db.execute(cursor, sql)
            if res > 0:
                return render_template("resHandle.html")
    return '注册不成功!'


@app.route('/login', methods=["GET", "POST"])
def login():
    if request.method == "POST":
        username = request.form.get("username")
        pwd = request.form.get("userpwd")
        with db.cursor() as cursor:
            sql = "select * from userInfo where username = '%s' and userpwd = '%s'" % (username, pwd)
            res = db.queryAll(cursor, sql)
            if len(res) == 1:
                return render_template("loginHandle.html", username=username)
    return '注册不成功!'
