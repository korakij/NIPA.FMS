using MNG.Models.Productions;
using MNG.Services.Core;
using MNG.Services.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNG.Services
{
    public class FurnaceService : ServiceBase<Furnace>
    {
        public FurnaceService(AppDb db) : base(db)
        {

        }
    }
}
