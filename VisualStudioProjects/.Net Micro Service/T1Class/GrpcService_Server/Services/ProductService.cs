using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService_Product_Server;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcService_Server.Models;

namespace GrpcService_Server.Services
{
    public class ProductService : ProductManager.ProductManagerBase
    {
        FreshLiveDBContext _db;

        public ProductService(FreshLiveDBContext db)
        {
            _db = db;
        }
        public override Task<ProductReply> GetProductByID(ProductRequest request, ServerCallContext context)
        {
            int pid = request.Pid;
            var p = _db.Products.Find(pid);
            ProductReply productReply = new ProductReply();
            if (p != null)
            {
                GrpcService_Product_Server.Product product = new GrpcService_Product_Server.Product();
                product.ProductID = p.ProductId;
                product.ProductName = p.ProductName;
                product.ProductPic = p.ProductPic;
                product.ProductPrice = (double)p.ProductPrice;
                product.ProductDesc = p.ProductDesc;
                product.ClassID = p.ClassId;
                product.AddTime = p.AddTime.ToString();

                productReply.Product = product;
            }


            return Task.FromResult(productReply);
        }
        public override Task<AllProductsReply> GetProductAll(Empty request, ServerCallContext context)
        {
            var p = _db.Products.ToList();
            AllProductsReply allProductsReply = new AllProductsReply();
            if (p != null)
            {
                foreach (var item in p)
                {
                    GrpcService_Product_Server.Product product = new GrpcService_Product_Server.Product();
                    product.ProductID = item.ProductId;
                    product.ProductName = item.ProductName;
                    product.ProductPic = item.ProductPic;
                    product.ProductPrice = (double)item.ProductPrice;
                    product.ProductDesc = item.ProductDesc;
                    product.ClassID = item.ClassId;
                    product.AddTime = item.AddTime.ToString();

                    allProductsReply.Product.Add(product);
                }
            }
            return Task.FromResult(allProductsReply);
        }
    }
}
