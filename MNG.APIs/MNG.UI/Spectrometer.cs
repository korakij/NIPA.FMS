using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNG.UI
{
    public class Spectrometer
    {
        private StreamReader sr;
        private List<List<string>> Info = new List<List<string>>();
        private int lastLine = 0;
        private string[] Element = { "C", "Si", "Mn", "Mg", "S", "Al", "Cu", "Sn", "Cr", "P", "Mo", "Ni", "V", "Ti", "Te" };
        private int[] Index = new int[15];

        public ChemicalComposition ChemResult { get; set; }
        public string TestNo { get; set; }

        public Spectrometer(string _path)
        {
            ChemResult = new ChemicalComposition();

            using (sr = new StreamReader(_path))
            {
                while (!sr.EndOfStream)
                {
                    List<string> data = new List<string>();
                    var line = sr.ReadLine();
                    var values = line.Split('\t');

                    if (lastLine == 0)
                        GetIndex(values);

                    for (int i = 0; i < values.Length; i++)
                    {
                        data.Add(values[i]);
                    }

                    Info.Add(data);
                    lastLine++;
                }
            }

            lastLine--;
            GetResult();
        }

        private int[] GetIndex(string[] _val)
        {
            int i = 0;
            foreach (var ele in Element)
            {
                int j = 0;
                foreach (var v in _val)
                {
                    if (ele == v.Trim())
                        Index[i] = j;
                    j++;
                }
                i++;
            }

            return Index;
        }

        private string CorrectString(string _str)
        {
            var st = _str.Trim();
            var len = st.Length;
            var dotPos = st.IndexOf('.');
            var num = len - dotPos;

            if (num > 4)
            {
                st = st.Substring(0, dotPos + 4);
            }

            return st;
        }

        private ChemicalComposition GetResult()
        {
            TestNo = Info[lastLine][5];

            ChemResult.C = Convert.ToDouble(CorrectString(Info[lastLine][Index[0]]));
            ChemResult.Si = Convert.ToDouble(CorrectString(Info[lastLine][Index[1]]));
            ChemResult.Mn = Convert.ToDouble(CorrectString(Info[lastLine][Index[2]]));
            ChemResult.Mg = Convert.ToDouble(CorrectString(Info[lastLine][Index[3]]));
            ChemResult.S = Convert.ToDouble(CorrectString(Info[lastLine][Index[4]]));
            ChemResult.Al = Convert.ToDouble(CorrectString(Info[lastLine][Index[5]]));
            ChemResult.Cu = Convert.ToDouble(CorrectString(Info[lastLine][Index[6]]));
            ChemResult.Sn = Convert.ToDouble(CorrectString(Info[lastLine][Index[7]]));
            ChemResult.Cr = Convert.ToDouble(CorrectString(Info[lastLine][Index[8]]));
            ChemResult.P = Convert.ToDouble(CorrectString(Info[lastLine][Index[9]]));
            ChemResult.Mo = Convert.ToDouble(CorrectString(Info[lastLine][Index[10]]));
            ChemResult.Ni = Convert.ToDouble(CorrectString(Info[lastLine][Index[11]]));
            ChemResult.V = Convert.ToDouble(CorrectString(Info[lastLine][Index[12]]));
            ChemResult.Ti = Convert.ToDouble(CorrectString(Info[lastLine][Index[13]]));
            ChemResult.Te = Convert.ToDouble(CorrectString(Info[lastLine][Index[14]]));

            return ChemResult;
        }
    }
}
