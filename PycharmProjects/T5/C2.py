import xml.sax
import json


class ProvinceHandler(xml.sax.ContentHandler):
    def __init__(self):
        self.provinceDict = {}
        self.province = None
        self.city = None
        self.CurrentData = ""

    def startElement(self, name, attrs):
        if name == 'province':
            self.province = attrs.get('name')
        elif name == 'city':
            self.city = ""

    def endElement(self, name):
        if name == 'province':
            self.province = None
        elif name == 'city':
            if self.province is not None:
                if self.province not in self.provinceDict:
                    self.provinceDict[self.province] = []
                self.provinceDict[self.province].append(self.city)
                self.city = None

    def characters(self, content):
        if self.city is not None:
            self.city += content
        elif self.province is not None:
            self.CurrentData += content


def parse_xml(xml_file):
    handler = ProvinceHandler()
    parser = xml.sax.make_parser()
    parser.setContentHandler(handler)
    parser.parse(xml_file)
    return handler.provinceDict


def convert_to_json(data):
    return json.dumps(data, ensure_ascii=False)


# 解析XML文件并转换为JSON字符串
xml_file = 'provinces.xml'  # 请替换为你的XML文件路径
provinces_data = parse_xml(xml_file)
json_string = convert_to_json(provinces_data)
print(json_string)
