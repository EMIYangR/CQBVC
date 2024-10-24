import StringUtils as su
print("数字转换为字符串为：", su.objToStr(66))
from StringUtils import objToStr as os
print("数字转换为字符串为：", os(77))

import task.numUtils as nu
numOper = nu.NumOperator()
print("数字32和数字66的和为：", numOper.add(32, 66))
print("数字2的10次方为", numOper.pow(2, 10))

from task import numUtils as nu2
numOper2 = nu2.NumOperator()
print("数字32和数字66的和为：", numOper2.add(32, 66))
print("数字2的10次方为", numOper2.pow(2, 10))
