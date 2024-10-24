import os


def copyFile(file, newFile):
    fileObject = open(file, "rb")
    newFileObject = open(newFile, "wb")
    str = fileObject.read()
    newFileObject.write(str)
    fileObject.close()
    newFileObject.close()


def createNewDir(newDir):
    os.makedirs(newDir)


def copyDir(dir, newDir):
    dir = dir + "\\"
    newDir = newDir + "\\"
    childDirList = os.listdir(dir)
    for childDir in childDirList:
        childPath = dir + childDir
        if os.path.isdir(childPath):
            createNewDir(newDir + childDir)
            copyDir(childPath, newDir + childDir)
        else:
            copyFile(childPath, newDir + childDir)


path = input("请输入目录：")
if not os.path.exists(path):
    print("错误！")
else:
    if os.path.isdir(path):
        copyDir(path, path + "_copy")
    else:
        copyFile(path, path + "_copy")
print("成功!")
