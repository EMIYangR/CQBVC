using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace C4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入网页地址：");
            string inputUrl = Console.ReadLine();
            CallBackMethod(inputUrl);
            Console.ReadKey();
        }
        static Task<int> DownloadPage(string httpUrl)
        {
            return Task.Run<int>(async () =>
            {
                var client = new HttpClient();
                byte[] content = await client.GetByteArrayAsync(httpUrl);
                return content.Length;
            });
        }
        async static void CallBackMethod(string url)
        {
            var result = await DownloadPage(url);
            Console.WriteLine("总共从{0}下载了{1}B", url, result);
        }
    }
}
