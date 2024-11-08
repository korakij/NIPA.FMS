using MNG.Models;
using MNG.Services.Core;
using MNG.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNG.Services
{
    public class ProductService : ServiceBase<Product>
    {
        public ProductService(AppDb db) : base(db)
        {

        }

        public async Task<List<Product>> FindWithoutImage() 
        {
            var newproducts = db.Products.Select(p => new { p.Code, p.CustomerPartNo, p.Name, p.MaterialCode, p.Weight, p.ActiveControlPlanId}).ToList();
            List<Product> products = new List<Product>();

            foreach (var prd in newproducts) 
            {
                products.Add(new Product() { Code = prd.Code, CustomerPartNo = prd.CustomerPartNo, Name = prd.Name, MaterialCode = prd.MaterialCode, Weight = prd.Weight, ActiveControlPlanId = prd.ActiveControlPlanId});
            }

            return products;
        }

    }
}
