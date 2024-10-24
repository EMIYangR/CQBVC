def printSet(set):
    for i in set:
        print(i)
    print()


interestsStr1 = input("请输入小明的个人喜好（多个喜好之间用，）：")
interestsStr2 = input("请输入小王的个人喜好（多个喜好之间用，）：")
interestsSet1 = set(interestsStr1.split("，"))
interestsSet2 = set(interestsStr2.split("，"))
interscetionSet = interestsSet1.intersection(interestsSet2)
print("两人的共同喜好为：")
printSet(interscetionSet)
unionSet = interestsSet1.union(interestsSet2)
print("两个人的所有喜好为：")
print(unionSet)
print("小明有而小王没有的喜好为：")
diffSet = interestsSet1.difference(interestsSet2)
printSet(diffSet)
