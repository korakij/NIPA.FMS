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
    public class ChemStdsController : ControllerBase
    {
        //    private readonly App app;

        //    public ChemStdsController(App app)
        //    {
        //        this.app = app;
        //    }

        //    [HttpGet]
        //    public IEnumerable<dto.ChemStd> GetAll()
        //    {

        //        var ChemStds = from x in app.ChemicalCompositions.Query(x => true)
        //                       select new dto.ChemStd
        //                       {
        //                           ID = x.ID,
        //                           Code = x.Code,
        //                           Desc = x.Desc,
        //                           CMaxF = x.CMaxF,
        //                           CMinF = x.CMinF,
        //                           SiMaxF = x.SiMaxF,
        //                           SiMinF = x.SiMinF,
        //                           MnMaxF = x.MnMaxF,
        //                           MnMinF = x.MnMinF,
        //                           MgMaxF = x.MgMaxF,
        //                           MgMinF = x.MgMinF,
        //                           SMaxF = x.SMaxF,
        //                           SMinF = x.SMinF,
        //                           AlMaxF = x.AlMaxF,
        //                           AlMinF = x.AlMinF,
        //                           CuMaxF = x.CuMaxF,
        //                           CuMinF = x.CuMinF,
        //                           SnMaxF = x.SnMaxF,
        //                           SnMinF = x.SnMinF,
        //                           CrMaxF = x.CrMaxF,
        //                           CrMinF = x.CrMinF,
        //                           PMaxF = x.PMaxF,
        //                           PMinF = x.PMinF,
        //                           MoMaxF = x.MoMaxF,
        //                           MoMinF = x.MoMinF,
        //                           NiMaxF = x.NiMaxF,
        //                           NiMinF = x.NiMinF,
        //                           VMaxF = x.VMaxF,
        //                           VMinF = x.VMinF,
        //                           TiMaxF = x.TiMaxF,
        //                           TiMinF = x.TiMinF,
        //                           TeMaxF = x.TeMaxF,
        //                           TeMinF = x.TeMinF,

        //                           CMaxL = x.CMaxL,
        //                           CMinL = x.CMinL,
        //                           SiMaxL = x.SiMaxL,
        //                           SiMinL = x.SiMinL,
        //                           MnMaxL = x.MnMaxL,
        //                           MnMinL = x.MnMinL,
        //                           MgMaxL = x.MgMaxL,
        //                           MgMinL = x.MgMinL,
        //                           SMaxL = x.SMaxL,
        //                           SMinL = x.SMinL,
        //                           AlMaxL = x.AlMaxL,
        //                           AlMinL = x.AlMinL,
        //                           CuMaxL = x.CuMaxL,
        //                           CuMinL = x.CuMinL,
        //                           SnMaxL = x.SnMaxL,
        //                           SnMinL = x.SnMinL,
        //                           CrMaxL = x.CrMaxL,
        //                           CrMinL = x.CrMinL,
        //                           PMaxL = x.PMaxL,
        //                           PMinL = x.PMinL,
        //                           MoMaxL = x.MoMaxL,
        //                           MoMinL = x.MoMinL,
        //                           NiMaxL = x.NiMaxL,
        //                           NiMinL = x.NiMinL,
        //                           VMaxL = x.VMaxL,
        //                           VMinL = x.VMinL,
        //                           TiMaxL = x.TiMaxL,
        //                           TiMinL = x.TiMinL,
        //                           TeMaxL = x.TeMaxL,
        //                           TeMinL = x.TeMinL,
        //                       };

        //        return ChemStds;
        //    }

        //    [HttpGet("csv")]
        //    public string GetAllCsv()
        //    {
        //        var sb = new StringBuilder();
        //        sb.AppendLine("Id,Code,Desc," +
        //            "CMaxF,CMinF,SiMaxF,SiMinF,MnMaxF,MnMinF,MgMaxF,MgMinF,SMaxF,SMinF,AlMaxF,AlMinF,CuMaxF,CuMinF," +
        //            "SnMaxF,SnMinF,CrMaxF,CrMinF,PMaxF,PMinF,MoMaxF,MoMinF,NiMaxF,NiMinF,VMaxF,VMinF,TiMaxF,TiMinF,TeMaxF,TeMinF," +
        //            "CMaxL,CMinL,SiMaxL,SiMinL,MnMaxL,MnMinL,MgMaxL,MgMinL,SMaxL,SMinL,AlMaxL,AlMinL,CuMaxL,CuMinL, " +
        //            "SnMaxL,SnMinL,CrMaxL,CrMinL,PMaxL,PMinL,MoMaxL,MoMinL,NiMaxL,NiMinL,VMaxL,VMinL,TiMaxL,TiMinL,TeMaxL,TeMinL,");

        //        var chemStds = from x in app.ChemStds.Query(x => true)
        //                       select new dto.ChemStd
        //                       {
        //                           ID = x.ID,
        //                           Code = x.Code,
        //                           Desc = x.Desc,
        //                           CMaxF = x.CMaxF,
        //                           CMinF = x.CMinF,
        //                           SiMaxF = x.SiMaxF,
        //                           SiMinF = x.SiMinF,
        //                           MnMaxF = x.MnMaxF,
        //                           MnMinF = x.MnMinF,
        //                           MgMaxF = x.MgMaxF,
        //                           MgMinF = x.MgMinF,
        //                           SMaxF = x.SMaxF,
        //                           SMinF = x.SMinF,
        //                           AlMaxF = x.AlMaxF,
        //                           AlMinF = x.AlMinF,
        //                           CuMaxF = x.CuMaxF,
        //                           CuMinF = x.CuMinF,
        //                           SnMaxF = x.SnMaxF,
        //                           SnMinF = x.SnMinF,
        //                           CrMaxF = x.CrMaxF,
        //                           CrMinF = x.CrMinF,
        //                           PMaxF = x.PMaxF,
        //                           PMinF = x.PMinF,
        //                           MoMaxF = x.MoMaxF,
        //                           MoMinF = x.MoMinF,
        //                           NiMaxF = x.NiMaxF,
        //                           NiMinF = x.NiMinF,
        //                           VMaxF = x.VMaxF,
        //                           VMinF = x.VMinF,
        //                           TiMaxF = x.TiMaxF,
        //                           TiMinF = x.TiMinF,
        //                           TeMaxF = x.TeMaxF,
        //                           TeMinF = x.TeMinF,

        //                           CMaxL = x.CMaxL,
        //                           CMinL = x.CMinL,
        //                           SiMaxL = x.SiMaxL,
        //                           SiMinL = x.SiMinL,
        //                           MnMaxL = x.MnMaxL,
        //                           MnMinL = x.MnMinL,
        //                           MgMaxL = x.MgMaxL,
        //                           MgMinL = x.MgMinL,
        //                           SMaxL = x.SMaxL,
        //                           SMinL = x.SMinL,
        //                           AlMaxL = x.AlMaxL,
        //                           AlMinL = x.AlMinL,
        //                           CuMaxL = x.CuMaxL,
        //                           CuMinL = x.CuMinL,
        //                           SnMaxL = x.SnMaxL,
        //                           SnMinL = x.SnMinL,
        //                           CrMaxL = x.CrMaxL,
        //                           CrMinL = x.CrMinL,
        //                           PMaxL = x.PMaxL,
        //                           PMinL = x.PMinL,
        //                           MoMaxL = x.MoMaxL,
        //                           MoMinL = x.MoMinL,
        //                           NiMaxL = x.NiMaxL,
        //                           NiMinL = x.NiMinL,
        //                           VMaxL = x.VMaxL,
        //                           VMinL = x.VMinL,
        //                           TiMaxL = x.TiMaxL,
        //                           TiMinL = x.TiMinL,
        //                           TeMaxL = x.TeMaxL,
        //                           TeMinL = x.TeMinL,
        //                       };

        //        foreach (var item in chemStds)
        //        {
        //            sb.AppendLine($"{item.ID},{item.Code},{item.Desc}," +
        //                $"{item.CMaxF},{item.CMinF},{item.SiMaxF},{item.SiMinF},{item.MnMaxF},{item.MnMinF},{item.MgMaxF},{item.MgMinF}," +
        //                $"{item.SMaxF},{item.SMinF},{item.AlMaxF},{item.AlMinF},{item.CuMaxF},{item.CuMinF},{item.SnMaxF},{item.SnMinF}," +
        //                $"{item.CrMaxF},{item.CrMinF},{item.PMaxF},{item.PMinF},{item.MoMaxF},{item.MoMinF},{item.NiMaxF},{item.NiMinF}," +
        //                $"{item.VMaxF},{item.VMinF},{item.TiMaxF},{item.TiMinF},{item.TeMaxF},{item.TeMinF}," +

        //                $"{item.CMaxL},{item.CMinL},{item.SiMaxL},{item.SiMinL},{item.MnMaxL},{item.MnMinL},{item.MgMaxL},{item.MgMinL}," +
        //                $"{item.SMaxL},{item.SMinL},{item.AlMaxL},{item.AlMinL},{item.CuMaxL},{item.CuMinL},{item.SnMaxL},{item.SnMinL}," +
        //                $"{item.CrMaxL},{item.CrMinL},{item.PMaxL},{item.PMinL},{item.MoMaxL},{item.MoMinL},{item.NiMaxL},{item.NiMinL}," +
        //                $"{item.VMaxL},{item.VMinL},{item.TiMaxL},{item.TiMinL},{item.TeMaxL},{item.TeMinL}");
        //        }

        //        return sb.ToString();
        //    }

        //    [HttpGet("{id}")]
        //    public Specification GetById(int id)
        //    {
        //        return app.ChemStds.Query(x => x.ID == id).SingleOrDefault();
        //    }

        //    [HttpPost]
        //    public IActionResult Post(dto.ChemStd item)
        //    {
        //        var c = new Specification
        //        {
        //        };

        //        app.ChemStds.Add(c);
        //        app.SaveChanges();

        //        return CreatedAtAction(nameof(GetById), new { id = c.ID });
        //    }
    }
}
