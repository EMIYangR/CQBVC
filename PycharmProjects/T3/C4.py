import operator


def outputObjInfo(obj):
    print("对象的值为：", obj)
    print("对象的类型为：", type(obj))
    if type(obj) is list or \
            type(obj) is tuple or \
            type(obj) is dict or \
            type(obj) is str:
        print(obj, "的元素个数为：", len(obj))


def compare(obj1, obj2):
    if operator.eq(obj1, obj2):
        print(obj1, "等于", obj2)
    elif operator.lt(obj1, obj2):
        print(obj1, "小于", obj2)
    else:
        print(obj1, "大于", obj2)


outputObjInfo(12)
outputObjInfo([4, 6])
compare(8, 8)
