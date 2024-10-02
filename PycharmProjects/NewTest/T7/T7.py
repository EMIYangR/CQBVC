from flask import Flask

app = Flask(__name__)


@app.route('/')
def index():
    return '<h1 align="center">计网3班</h1>'


app.run()
