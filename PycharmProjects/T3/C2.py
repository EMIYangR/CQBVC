s = input("请输入字符串：")
s1 = s
maxLen = 0
maxValue = ""
while len(s1) > 0:
    len1 = s1.count(s1[0])
    if len1 > maxLen:
        maxLen = len1
        maxValue = s1[0]
    s1 = s1.replace(s1[0], "")
print(maxValue, "出现的次数", maxLen)
print(s1)
sarr = s.split(maxValue)
for i in sarr:
    print(i, end=" ")gdfgsd
