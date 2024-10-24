ColorTuple = ("blue", "yellow", "red", "white", "black")
print("前三种颜色是：", ColorTuple[:3])
print("第四到第五种颜色是：", ColorTuple[4:5])
print("后三种颜色是：", ColorTuple[3:])

tuple = ("gray", "orange")
colorTuple = ColorTuple + tuple

print(colorTuple)

dict = {"中国": "北京", "美国": "华盛顿", "英国": "伦敦"}
print("中国的首都是：", dict["中国"])
dict["泰国"] = "曼谷"
dict["英国"] = "伦敦市"
print(dict)
del dict["美国"]
print(dict)
