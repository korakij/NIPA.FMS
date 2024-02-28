using MNG.Models;
using MNG.Services.Core;
using MNG.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MNG.Services
{
  public class UserService : ServiceBase<User>
  {
    public UserService(AppDb db) : base(db)
    {
        
    }

    public User FindByName(string name)
    {
        var user = db.Users.Where(x => x.Name == name).FirstOrDefault();
        user.Password = string.Empty;

        return user;
    }
  }
}
