using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dto = MNG.APIs.Models;
using MNG.Models;
using MNG.Services;

namespace MNG.APIs.Controllers
{
  [Route("api/v0.1/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly App app;

    public UsersController(App app)
    {
      this.app = app;
    }

    [HttpGet]
    public IEnumerable<dto.User> GetAll()
    {

      var users = from x in app.Users.Query(x => true)
                  select new dto.User
                  {
                    Id = x.Id,
                    Name = x.Name,
                    BirthYear = x.BirthDate.Year
                  };

      return users;
    }


    [HttpGet("csv")]
    public string GetAllCsv()
    {
      var sb = new StringBuilder();
      sb.AppendLine("Id,Name,BirthYear");

      var users = from x in app.Users.Query(x => true)
                  select new dto.User
                  {
                    Id = x.Id,
                    Name = x.Name,
                    BirthYear = x.BirthDate.Year
                  };

      foreach (var item in users)
      {
        sb.AppendLine($"{item.Id},{item.Name},{item.BirthYear}");
      }

      return sb.ToString();
    }

    [HttpGet("{id}")]
    public User GetById(int id)
    {
      return app.Users.Query(x => x.Id == id).SingleOrDefault();
    }

    [HttpPost]
    public IActionResult Post(dto.User item)
    {
      var u = new User
      {
        Name = item.Name,
        BirthDate = new DateTime(item.BirthYear, 1, 1)
      };

      app.Users.Add(u);
      app.SaveChanges();

      return CreatedAtAction(nameof(GetById), new { id = u.Id });
    }

    //public string GetAll()
    //{
    //  var sb = new StringBuilder();
    //  var rnd = new Random();

    //  sb.AppendLine("Id,Name,BirthYear");


    //  for (int n = 1, max = rnd.Next(500); n <= max; n++)
    //  {
    //    var id = n;
    //    var name = "User " + n;
    //    var birthYear = 1960 + rnd.Next(50);

    //    sb.AppendLine($"{id},{name},{birthYear}");
    //  }

    //  return sb.ToString();
    //}
  }
}