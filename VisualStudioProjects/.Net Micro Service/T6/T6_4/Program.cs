using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace T6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products= new List<Product>
            {
                new Product(){Id=1,Name="产品1",Price=9},
                new Product(){Id=2,Name="产品2",Price=8},
                new Product(){Id=3,Name="产品3",Price=7},
                new Product(){Id=4,Name="产品4",Price=6},
                new Product(){Id=5,Name="产品5",Price=5}
            };
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379,abortConnect=false");
            IDatabase redisDB = redis.GetDatabase(0);
            var tran = redisDB.CreateTransaction();
            tran.AddCondition(Condition.SetLengthEqual("prods", 0));
            Console.WriteLine("启动事务");
            foreach (var item in products)
            {
                tran.SetAddAsync("prods", JsonConvert.SerializeObject(item));
            }
            bool result = tran.Execute();
            Console.WriteLine("事务执行结果：" + result);
            var setResult = redisDB.SetScan("prods");
            foreach (var item in setResult)
            {
                Product prod = JsonConvert.DeserializeObject<Product>(item);
                Console.WriteLine("商品名称：{0}，价格：{1:C}",prod.Name,prod.Price);
            }
        }
    }
}
