import csv
import xlrd as xlrd
import xlwt as xlwt


class ExcelUtil:
    def read_excel(self, fileName):
        workbook = xlrd.open_workbook(fileName)
        sheet = workbook.sheet_by_index(0)
        data = []
        for i in range(0, sheet.nrows):
            data.append(sheet.row_values(i))
        return data

    def write_excel(self, fileName, data):
        style0 = xlwt.easyxf('font: name Times New Roman,color-index black,bold on', num_format_str='#,##0.00')
        wb = xlwt.Workbook()
        ws = wb.add_sheet('Sheet1')
        for i in range(0, data.__len__()):
            for j in range(i, data[i].__len__()):
                content = data[i][j]
                ws.write(i, j, content, style0)
        wb.save(fileName)


class CsvUtil:
    def read_csv(self, fileName):
        reader = csv.reader(open(fileName, 'r'))
        data = []
        for line in reader:
            data.append(line)
        return data

    def write_csv(self, fileName, data):
        csvfile = open(fileName, 'w')
        writer = csv.writer(csvfile)
        writer.writerows(data)
        csvfile.close()


csvUtil = CsvUtil()
excelUtil = ExcelUtil()

data = csvUtil.read_csv('product.csv')
excelUtil.write_excel('product.xlsx', data)

data = excelUtil.read_excel('employee.xlsx')
csvUtil.write_csv('employee.csv', data)
