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
    public class CustomerService : ServiceBase<Customer>
    {
        public CustomerService(AppDb db) : base(db)
        {

        }

        public async Task<List<Customer>> FindByCode(string code)
        {
            var pd = db.Customers.Where(p => p.CustomerCode.Contains(code) || p.CustomerCodeAc.Contains(code));

            return pd.ToList();
        }
    }
}
