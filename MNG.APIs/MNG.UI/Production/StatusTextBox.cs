using System;
using System.Drawing;
using System.Windows.Forms;

namespace MNG.UI.Production
{
    public class StatusTextBox : TextBox
    {
        private string _onStatus;
        private Timer timer1;
        private bool isOn;

        public string ColorRunning { get; set; }
        public string ColorCompleted { get; set; }
        public bool IsCompleted { get; set; }

        public string OnStatus
        {
            get { return _onStatus; }
            set
            {
                _onStatus = value;

                switch (_onStatus)
                {
                    case "Completed":
                        timer1.Stop();
                        if (IsCompleted)
                        {
                            BackColor = Color.FromName("GreenYellow");
                            ForeColor = Color.FromName("black");
                        }
                        else
                        {
                            BackColor = Color.FromName("Yellow");
                            ForeColor = Color.FromName("black");
                        }
                        break;
                    case "Running":
                        timer1.Start();
                        BackColor = Color.FromName("GreenYellow");
                        ForeColor = Color.FromName("black");
                        break;
                    case "Holding":
                        timer1.Stop();
                        BackColor = Color.Orange;
                        ForeColor = Color.FromName("black");
                        break;
                }
            }
        }

        public StatusTextBox()
        {
            isOn = false;
            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_onStatus == "Running")
            {
                if (isOn)
                {
                    BackColor = Color.FromName("white");
                    ForeColor = Color.FromName("black");
                    isOn = false;
                }
                else
                {
                    BackColor = Color.FromName("YellowGreen");
                    ForeColor = Color.FromName("white");
                    isOn = true;
                }
                
            }
        }
    }
}
