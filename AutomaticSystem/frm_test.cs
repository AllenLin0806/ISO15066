using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomaticSystem
{
    public partial class frm_test : Form
    {
        public frm_test()
        {
            InitializeComponent();
        }

        List<string> vRtx = new List<string>();
        public void txtRead()
        {
            foreach (string fname in System.IO.Directory.GetFiles(@"D:\1SO15066 自動化系統"))
            {
                if (System.IO.Path.GetFileNameWithoutExtension(fname) == "Robot_Configuration_" + DateTime.Now.ToString("yyyyMMdd") && System.IO.Path.GetExtension(fname) == ".txt")
                {
                    string line;
                    vRtx.Clear();  //做完一次就清除

                    // 一次讀取一行
                    System.IO.StreamReader file = new System.IO.StreamReader(fname);
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains("Power_Name") || line.Contains("Power_FW") || line.Contains("J0_Name") || line.Contains("J0_FW") || 
                            line.Contains("IO_Name") || line.Contains("IO_FW") || line.Contains("Patriot_L0_Name") || line.Contains("Patriot_L0_FW"))
                        {
                            vRtx.Add(line.Trim().Substring(0, line.LastIndexOf(',')));
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int found;
            if (vRtx.Count == 8)
            {
                for (int i = 0; i < vRtx.Count; i++)
                {
                    found = vRtx[i].IndexOf(":") + 1;
                    switch (vRtx[i].Trim().Substring(found))
                    {
                        case "PowerManager/IOs":
                            found = vRtx[i + 1].IndexOf(":") + 1;
                            textBox1.Text += vRtx[i + 1].Substring(found) + "\r\n";
                            break;
                        case "AC Servo Driver":
                            found = vRtx[i + 1].IndexOf(":") + 1;
                            textBox1.Text += vRtx[i + 1].Substring(found) + "\r\n";
                            break;
                        case "Multi-IO Module":
                            found = vRtx[i + 1].IndexOf(":") + 1;
                            textBox1.Text += vRtx[i + 1].Substring(found) + "\r\n";
                            break;
                        case "Patriot L0":
                            found = vRtx[i + 1].IndexOf(":") + 1;
                            textBox1.Text += vRtx[i + 1].Substring(found) + "\r\n";
                            break;
                    }
                    i++;
                }
            }
        }

        private void frm_test_Load(object sender, EventArgs e)
        {
            txtRead();
        }
    }
}
