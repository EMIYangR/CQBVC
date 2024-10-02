import os


def statFile(path, info):
    path += "\\"
    list1 = os.listdir(path)
    for item in list1:
        path1 = path + item
        if os.path.isdir(path1):
            info["fileNum"] += 1
            statFile(path1, info)
        else:
            info["dirNum"] += 1


info = {"fileNum": 0, "dirNum": 0}
path = "D:\\EMI"
statFile(path, info)
print("目录数量：", info["fileNum"], "，文件个数", info["dirNum"])
