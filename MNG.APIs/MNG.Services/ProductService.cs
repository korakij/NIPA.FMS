using MNG.Models;
using MNG.Services.Core;
using MNG.Services.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNG.Services
{
    public class ProductService : ServiceBase<Product>
    {
        public ProductService(AppDb db) : base(db)
        {

        }
    }
}
