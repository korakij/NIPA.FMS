using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI
{
    public class FilterData
    {
        private string dataall;
        private string _kanbanNo;
        private string _partName;
        private List<string> _chem;

        public string Kanban_no { get { return _kanbanNo; } }
        public string Part_name { get { return _partName; } }
        public List<string> Chem { get { return _chem; } }


        public FilterData(string fileName)
        {
            dataall = "";
            _kanbanNo = "";
            _partName = "";
            _chem = new List<string>();

            try
            {
                StreamReader readStream = new StreamReader(fileName, Encoding.UTF8);

                dataall = readStream.ReadToEnd();
                readStream.Close();
                GetAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetAllData()
        {
            _partName = GetName();
            _kanbanNo = GetKanban();
            _chem = GetChem();
        }

        public string Datetime()
        {
            string now = "size=3>";
            string date = "";
            int s = 0;

            for (int i = 0; i < 4; i++)
            {
                int ind3 = dataall.IndexOf(now, s) + 7;
                int ind4 = dataall.IndexOf("</font>", ind3);
                date = dataall.Substring(ind3, ind4 - ind3);
                s = ind4;
            }

            DateTime Date = new DateTime();
            Date = Convert.ToDateTime(date);
            date = Date.ToString("dd/MM/yy HH:mm:ss");
            return date;
        }

        public string Date()
        {
            int indd = Datetime().IndexOf(" ", 0) + 1;
            string date = Convert.ToString(Datetime().Substring(0, indd)).Trim();

            return date;
        }

        public string Time()
        {
            int indt = Datetime().IndexOf(" ", 0) + 1;
            string time = Convert.ToString(Datetime().Substring(indt, Datetime().Length - indt)).Trim();

            return time;
        }

        private string GetName()
        {
            string Name = "";
            int ind1 = dataall.IndexOf("size=3><strong>") + 15;
            int ind2 = dataall.IndexOf("</strong>", ind1);
            Name = dataall.Substring(ind1, ind2 - ind1).Trim();

            return Name;
        }

        private string GetKanban()
        {
            string kanban = "";
            int s = 0;

            for (int i = 0; i < 2; i++)
            {
                int ind1 = dataall.IndexOf("size=3><strong>", s) + 15;
                int ind2 = dataall.IndexOf("</strong>", ind1);
                kanban = dataall.Substring(ind1, ind2 - ind1).Trim();
                s = ind2;
            }

            return kanban;
        }

        public string stand()
        {
            string stand = "";
            int s = 0;

            for (int i = 0; i < 3; i++)
            {
                int ind1 = dataall.IndexOf("size=3><strong>", s) + 15;
                int ind2 = dataall.IndexOf("</strong>", ind1);
                stand = dataall.Substring(ind1, ind2 - ind1);
                s = ind2;
            }

            return stand;
        }

        public List<string> GetChem()
        {
            List<string> value = new List<string>();

            int k = dataall.IndexOf("&Oslash;");
            int end = dataall.IndexOf("</html>");
            int l = 0;
            int m = 0;

            while (k != -1)
            {
                for (int i = 0; i < 8; i++)
                {
                    l = dataall.IndexOf("<font size=1>", k);
                    m = dataall.IndexOf("</font>", l);

                    if (l != -1 && m != -1)
                    {
                        string ss = dataall.Substring(l + 13, m - (l + 14)).Trim();
                        if (ss != "%" && ss != " ")
                        {
                            if (ss.StartsWith(";"))
                            {
                                //ss = ss.Substring(2);
                            }
                            if (ss.StartsWith("- "))
                            {
                                ss = "-" + ss.Substring(2);
                            }
                            if (ss.StartsWith("+ "))
                            {
                                ss = ss.Substring(2);
                            }
                            if (ss.StartsWith(";"))
                            {
                                ss = ss.Substring(1);
                            }
                            if (ss.StartsWith("&gt;"))
                            {
                                ss = ss.Substring(5, (ss.Length - 6)).Trim();
                            }
                            if (ss.StartsWith("&lt; ; ") || ss.StartsWith("&lt;"))
                            {
                                var org = ss;
                                var len = ss.Length;
                                ss = ss.Substring(6, (ss.Length - 7)).Trim();
                            }

                            value.Add(ss);
                        }
                    }
                    k = dataall.IndexOf("<font size=1>", m);
                }
                k = dataall.IndexOf("&Oslash;", m);
            }

            return value;
        }

        //public string In()
        //{
        //    string In = "F";

        //    if (Kanban_no == "" || Part_name == "")
        //    {
        //        In = "F";
        //    }
        //    else if (Kanban_no[0] == 'K' || Kanban_no[0] == 'F')
        //    {
        //        if (Kanban_no[0] == 'K')
        //        {
        //            In = "L";
        //        }
        //        else
        //        {
        //            In = "F";
        //        }
        //    }
        //    else if (Part_name[0] == 'K' || Part_name[0] == 'F')
        //    {
        //        if (Part_name[0] == 'K')
        //        {
        //            In = "L";
        //        }
        //        else
        //        {
        //            In = "F";
        //        }

        //        string buffer = "";
        //        buffer = Part_name;
        //        Part_name = Kanban_no;
        //        Kanban_no = buffer;
        //    }
        //    else
        //    {
        //        In = "F";
        //    }

        //    return In;
        //}

        public int Part_no()
        {
            int part_NO = 0;

            int inp = Kanban_no.Length - 1;
            string part_No = Kanban_no.Substring(inp - 1, 2);
            part_NO = Convert.ToInt32(part_No);

            return part_NO;
        }
    }
}
