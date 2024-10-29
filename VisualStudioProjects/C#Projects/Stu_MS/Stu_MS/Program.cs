using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stu_MS
{
    class Program
    {
        public static List<string> stu = new List<string>();
        public static string[] familyName1 = new string[] { "周", "吴", "郑", "王" };
        public static string[] lastName1 = new string[] { "一", "二", "三", "四", "五", "六" };
        public static string name;
        public static int id;
        static void Main(string[] args)
        {
            int familyName = familyName1.Length;
            int lastName = lastName1.Length;

            for (int i = 0; i < 20; i++)
            {
                int a = new Random().Next(familyName);
                int b = new Random().Next(lastName);
                name = familyName1[a] + lastName1[b];
                id = i + 1;
                string number = "202100" + (i + 1);
                int age = new Random().Next(17, 22);
                stu.Add(id + "\t" + name + "\t" + number + "\t" + age);
            }
            string input = "";
            while (input != "5")
            {
                Console.WriteLine("请选择：");
                Console.WriteLine("1、添加学生");
                Console.WriteLine("2、删除学生");
                Console.WriteLine("3、修改学生信息");
                Console.WriteLine("4、查询学生信息");
                Console.WriteLine("5、退出");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddStu();
                        break;
                    case "2":
                        DelStu();
                        break;
                    case "3":
                        ChangeStu();
                        break;
                    case "4":
                        SelectStu();
                        break;
                    case "5":
                        Console.WriteLine("感谢使用！");
                        break;
                    default:
                        Console.WriteLine("输入错误，请重新输入！");
                        break;
                }
            }
        }
        static void AddStu()
        {
            Console.WriteLine("请输入姓名：");
            string name = Console.ReadLine();
            Console.WriteLine("请输入学号：");
            string number = Console.ReadLine();
            Console.WriteLine("请输入年龄：");
            int age = int.Parse(Console.ReadLine());
            stu.Add((stu.Count + 1) + "\t" + name + "\t" + number + "\t" + age);
        }
        static void DelStu()
        {
            Console.WriteLine("请输入你要删除学生的id");
            int e = int.Parse(Console.ReadLine());
            Console.WriteLine(stu[e - 1]);
            stu.RemoveAt(e - 1);
            Console.WriteLine("删除成功");
        }
        static void ChangeStu()
        {
            Console.WriteLine("敬请期待！");
        }
        static void SelectStu()
        {
            Console.WriteLine("编号\t姓名\t学号\t年龄");
            foreach (var item in stu)
            {
                Console.WriteLine(item);
            }
        }
    }
}
