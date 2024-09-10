#!/usr/bin/python3
# coding=utf-8
import cv2, os
import argparse
from generate_multi_plate import MultiPlateGenerator
from flask import Flask, request
import base64
import re

app = Flask(__name__)


@app.route("/")  # 路由：首页
def hello():
    return {'message': 'wellcome to chinese_license_plate_generator api server!'}


@app.route('/server.php', methods=['POST', 'GET'])  # 路由/whatever_by_key.php, 接收方法：get,post 都行
def plate_special():
    plate_number = request.values.get('cphm')
    bg_color = request.values.get('cpys')
    double = request.values.get('double')

    if (bg_color == '0'):
        bg_color = 'blue'


if (bg_color == '1'):
    bg_color = 'yellow'
if (bg_color == '4'):
    bg_color = 'green_car'
if (bg_color == '6'):
    bg_color = 'green_truck'

if (double == None):
    double = False
if (double == '0'):
    double = False
if (double == '1'):
    double = True
# 按正则表达式，判断, 纠正车牌号颜色
regex_0_1 = re.compile(r"[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼]{1}[A-Z]{1}[A-HJ-NP-Z0-9]{5}$");  # 普通汽车 蓝/黄
regex_4 = re.compile(r"[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼]{1}[A-Z]{1}[DF]{1}[A-HJ-NP-Z0-9]{1}[0-9]{4}$");  # 新能源 小型车 纯绿
regex_6 = re.compile(r"[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼]{1}[A-Z]{1}[0-9]{5}[DF]{1}$");  # 新能源 大型车 黄绿

if (regex_4.match(plate_number) != None):
    bg_color = 'green_car'

if (regex_6.match(plate_number) != None):
    bg_color = 'green_truck'

if (not (regex_0_1.match(plate_number) != None or regex_4.match(plate_number) != None or regex_6.match(
        plate_number) != None)):
    return '<img src="号码规则无效"></img>'

generator = MultiPlateGenerator('plate_model', 'font_model')
img = generator.generate_plate_special(plate_number, bg_color, double)
image_code = str(base64.b64encode(cv2.imencode('.jpg', img)[1]))[2:-1]
return '<img src="data:image/jpeg;base64,' + image_code + '"></img>'

if __name__ == "__main__":
    app.run(host='0.0.0.0', port=10086)