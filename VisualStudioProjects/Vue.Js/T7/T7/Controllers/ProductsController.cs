using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using T7.Models;

namespace T7.Controllers
{
    public class ProductsController : ApiController
    {
        private FreshLiveDB db = new FreshLiveDB();

        // GET: api/Products
        public IQueryable<Product> GetProduct()
        {
            return db.Product;
        }

        /// <summary>
        /// 分页+模糊查
        /// </summary>
        /// <param name="pageIndex">页码数，1开始</param>
        /// <param name="pageSize">每页数量</param>
        /// <param name="productName">产品名称</param>
        /// <returns></returns>


        [Route("api/GetProductByPaging")]
        public IEnumerable<proc_ProductByPaging_Result> Get(int pageIndex, int pageSize, string productName)
        {
            if (productName==null)
            {
                return db.proc_ProductByPaging(pageIndex, pageSize, "").ToList();
            }
            else
            {
                return db.proc_ProductByPaging(pageIndex, pageSize, productName).ToList();
            }
           
        }

        /// <summary>
        /// 数据总条数
        /// </summary>
        /// <param name="name">产品名称</param>
        /// <returns></returns>
        [Route("api/GetCount")]
        public int Get(string name)
        {
            if (name == null)
            {
                return db.Product.Count();
            }
            else
            {
                return db.Product.Where(a => a.ProductName.Contains(name)).Count();
            }
            
        }

        ///// <summary>
        ///// 分页
        ///// </summary>
        ///// <param name="pageIndex">页码数，1开始</param>
        ///// <param name="pageSize">每页数量</param>
        ///// <returns></returns>

        //[Route("api/GetProductByPaging")]
        //public IEnumerable<proc_ProductByPaging_Result> Get(int pageIndex, int pageSize)
        //{
        //    return db.proc_ProductByPaging(pageIndex, pageSize,"").ToList();
        //}

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Product.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Product.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Product.Count(e => e.ProductID == id) > 0;
        }
    }
}