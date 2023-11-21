using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;

namespace MNG.UI
{
    public class LightTower_ChemicalInLader
    {
        ModbusClient master; 
        public LightTower_ChemicalInLader()
        {
            master = new ModbusClient();
            master.Baudrate = 9600;
            master.SerialPort = "COM7";
            master.Parity = System.IO.Ports.Parity.None;
            master.StopBits = System.IO.Ports.StopBits.One;
            master.ConnectionTimeout = 5000;
            master.UnitIdentifier = 255;
            master.Disconnect();
            try
            {
                master.Connect();
            }
            catch 
            {
                MessageBox.Show("ไม่สามารถเชื่อมต่อกับไฟแสดงสถานะค่าเคมีได้ โปรดตรวจสอบอุปกรณ์ใหม่อีกครั้ง");
            }
        }

        public void ResultChem(bool _isComplete, bool _isPassed, string _kanbanCode)
        {
            if (master.Connected | true)
            {
                if (_isComplete)
                {
                    FontDialog fontDialog = new FontDialog();
                    
                    if (_isPassed)
                    {
                        master.WriteSingleCoil(0, true);
                        master.WriteSingleCoil(1, false);

                        DialogResult dr = MessageBox.Show($"Kanban : {_kanbanCode}\nค่าเคมีผ่าน", "ผลการตรวจสอบค่าเคมี", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            master.WriteSingleCoil(0, false);
                            master.WriteSingleCoil(1, false);
                        }
                    }
                    else
                    {
                        master.WriteSingleCoil(0, false);
                        master.WriteSingleCoil(1, true);

                        DialogResult dr = MessageBox.Show($"Kanban : {_kanbanCode}\nค่าเคมีไม่ผ่าน โปรดทบทวนการเทน้ำเหล็ก", "ผลการตรวจสอบค่าเคมี", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            master.WriteSingleCoil(0, false);
                            master.WriteSingleCoil(1, false);
                        }
                    }
                }
            }
        }
    }
}
