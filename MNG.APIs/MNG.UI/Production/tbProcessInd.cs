using System;
using System.Drawing;
using System.Windows.Forms;

namespace MNG.UI.Production
{
    public class TbProcessInd : TextBox
    {
        private bool _isCompleted;
        private bool _isPass;
        private string _code;

        private Timer timer1;
        private bool isOn;

        public void Enable() => timer1.Enabled = true;
        public void Disable() => timer1.Enabled = false;

        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                Display();
            }
        }

        public bool IsPass   {
            get { return _isPass; }
            set
            {
                _isPass = value;
                Display();
            }
        }

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                Display();
                
            }
        }

        public TbProcessInd()
        {
            isOn = false;
            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Start();
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        private void Display()
        {
            if (_code == null)
            {
                this.Text = "";
                BackColor = Color.FromName("White");
                ForeColor = Color.FromName("Black");
                timer1.Stop();
                return;
            }

            switch (_isCompleted)
            {
                case true:
                    timer1.Stop();
                    this.Text = "Completed";
                    if (_isPass)
                    {
                        BackColor = Color.FromName("GreenYellow");
                        ForeColor = Color.FromName("Black");
                    }
                    else
                    {
                        BackColor = Color.FromName("Red");
                        ForeColor = Color.FromName("White");
                    }
                    break;
                case false:
                    timer1.Start();
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_isCompleted == false)
            {
                this.Text = "Running";

                if (isOn)
                {
                    BackColor = Color.FromName("white");
                    ForeColor = Color.FromName("black");
                    isOn = false;
                }
                else
                {
                    BackColor = Color.FromName("GreenYellow");
                    ForeColor = Color.FromName("black");
                    isOn = true;
                }
            }
        }
    }
}
