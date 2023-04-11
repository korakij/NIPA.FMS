using SpectroReadtoDatabaseV4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectroReadToDatabaseV4
{
    public class ReadToDatabase
    {
        SpetroEntities1 db = new SpetroEntities1();

        FilterData filter = new FilterData();/////////////////////////////////////////////////////////////
        string date, time, kanban_no, part_name, In, standards;
        int part_no, id;
        List<string> values = new List<string>();

        public void ToDatabase()
        {
            //List<int> num;
            //var ps = from p in db.Chems select p.Id;
            //num = ps.ToList();
            //id = num[num.Count - 1] + 1;

            //filter.dataalls();

            //In = filter.In();
            //date = filter.Date();
            //time = filter.Time();
            //kanban_no = filter.Kanban_no; 
            //part_name = filter.Part_name;
            //standards = filter.stand();
            //part_no = filter.Part_no();
            //values = filter.value();

            //Chem sp = new Chem();

            //sp.Date = date;
            //sp.Time = time;
            //sp.Part_NO = part_no;
            //sp.Part_Name = part_name;
            //sp.Kanban_NO = kanban_no;
            //sp.Standards = standards;
            //sp.In = In;
            //sp.Id = id;
            //sp.C = values[0]; sp.Si = values[1]; sp.Mn = values[2]; sp.P = values[3]; sp.S = values[4]; sp.Cr = values[5]; sp.Mo = values[6]; sp.Ni = values[7];
            //sp.Al = values[8]; sp.Co = values[9]; sp.Cu = values[10]; sp.Nb = values[11]; sp.Ti = values[12]; sp.V = values[13]; sp.W = values[14]; sp.Pb = values[15];
            //sp.Sn = values[16]; sp.Mg = values[17]; sp.As = values[18]; sp.Zr = values[19]; sp.Bi = values[20]; sp.Ca = values[21]; sp.Ce = values[22]; sp.Sb = values[23];
            //sp.Te = values[24]; sp.B = values[25]; sp.Zn = values[26]; sp.La = values[27]; sp.Fe = values[28];

            //////////Transaction///////////////////////////
            //using (var tr = db.Database.BeginTransaction())
            //{
            //    db.Chems.Add(sp);
            //    db.SaveChanges();
            //    tr.Commit();
            //}
        }
    }
}
