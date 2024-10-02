class Student:
    def __init__(self, id, name, sex, age):
        self.id = id
        self.name = name
        self.sex = sex
        self.age = age

    def printStudent(self):
        print(str.format("编号：%d，姓名：%s，性别：%s，年龄：%d" % (self.id, self.name, self.sex, self.age)))


stu1 = Student(1, "EMI", "男", 20)
stu1.printStudent()
