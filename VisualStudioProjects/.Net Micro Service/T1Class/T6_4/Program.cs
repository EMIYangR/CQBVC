using System;
using System.Threading;
using StackExchange.Redis;

namespace T7_1
{
    class Product
    {
        public int PID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var redisDB = ConnectionMultiplexer.Connect("127.0.0.1:6379,abortConnect=false").GetDatabase(0);
            Product p = new Product()
            {
                ProductName = "100寸激光电视",
                ProductPrice = 6999,
                ProductStock = 100
            };

            // 销售数量
            redisDB.StringSet("saleNum", 0);
            int saleNum = Convert.ToInt32(redisDB.StringGet("saleNum"));

            // 创建事务
            var tran = redisDB.CreateTransaction();

            // 添加事务约束（监视字段） 加锁 乐观锁
            tran.AddCondition(Condition.SetLengthEqual("saleNum", saleNum));

            // 清空集合
            redisDB.SetRemove("customers", redisDB.SetMembers("customers"));

            int sum = 0;
            while (sum < p.ProductStock - 9)
            {
                Thread.Sleep(new Random().Next(100, 1000));
                // 更新销售数量
                saleNum = new Random().Next(1, 10);
                sum += saleNum;
                redisDB.StringSetAsync("saleNum", saleNum);

                // 保存用户信息
                string id = Guid.NewGuid().ToString();
                string customer = $"用户{id}";

                redisDB.SetAddAsync("customers", customer);
                string time = DateTime.Now.ToString("T");
                Console.WriteLine($"{time}{customer}喜提{saleNum}台{p.ProductName}");


                // 执行（提交）事务
                tran.Execute();
            }
            Console.WriteLine("电视机已售罄...");
            Console.WriteLine("购买成功的用户如下：");
            var set1 = redisDB.SetMembers("customers");
            foreach (var item in set1)
            {
                Console.WriteLine("\t" + item);
            }
        }
    }
}
