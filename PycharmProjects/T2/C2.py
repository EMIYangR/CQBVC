salary=int(input("请输入税前工资年收入总额："))
insureFee=int(input("请输入五险一金费用："))
specialAdd=int(input("请输入专项附加扣除费用："))

taxesFee=salary-insureFee-specialAdd-5000

mTaxesFee=0
if taxesFee<3000:
    mTaxesFee= taxesFee * 0.03
elif taxesFee >=3000 and taxesFee < 12000:
    mTaxesFee= taxesFee * 0.1 - 210
elif taxesFee >=12000 and taxesFee < 25000:
    mTaxesFee= taxesFee * 0.1 - 1410
elif taxesFee >=25000 and taxesFee < 35000:
    mTaxesFee= taxesFee * 0.1 - 2660
elif taxesFee >=35000 and taxesFee < 55000:
    mTaxesFee= taxesFee * 0.1 - 4410
elif taxesFee >=55000 and taxesFee < 80000:
    mTaxesFee= taxesFee * 0.1 - 7160
else:
    mTaxesFee= taxesFee * 0.45 - 15160
print("您的个人所得税为：", mTaxesFee)