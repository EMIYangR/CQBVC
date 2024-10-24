class Car:
    name = ""
    color = ""

    def run(self):
        print(self.name, "正在行驶")


class Truck(Car):
    def showCarInfo(self):
        print("车的名称为%s，车的颜色为%s" % (self.name, self.color))


truck = Truck()
truck.name = "北汽威旺"
truck.color = "蓝色"
truck.showCarInfo()
truck.run()
