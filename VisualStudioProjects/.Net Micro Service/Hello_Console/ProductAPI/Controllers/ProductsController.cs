using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductAPI.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        FreshLiveDBContext _db;
        IDatabase _redisDB;
        public ProductsController(FreshLiveDBContext db, IDatabase redisDB)
        {
            _db = db;
            //_redisDB = redisDB;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            // 从Redis中获取数据，若为空，则从SQL Server中获取
            //var redisResult = _redisDB.StringGet("products");
            //List<Product> dbResult;
            //if (string.IsNullOrEmpty(redisResult))
            //{
            //    dbResult = _db.Products.ToList();
            //    _redisDB.StringSet("products", JsonConvert.SerializeObject(dbResult));
            //    return dbResult;
            //}
            
            //return JsonConvert.DeserializeObject<List<Product>>(redisResult);

            return _db.Products.ToList();
        }
        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
