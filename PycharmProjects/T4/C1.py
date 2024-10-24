class Song:
    def __init__(self, name, singer, type):
        self.name = name
        self.singer = singer
        self.type = type

    def printStudent(self):
        print(str.format("歌名：%s\t歌手：%s\t歌曲类型：%s" % (self.name, self.singer, self.type)))

stu1=Song("青花瓷","周杰伦","流行歌曲")
stu1.printStudent()
stu2 = Song("十年", "陈奕迅", "流行歌曲")
stu2.printStudent()
