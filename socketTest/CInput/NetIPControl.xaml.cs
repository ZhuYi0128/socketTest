using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace socketTest.CInput
{
    /// <summary>
    /// NetIPControl.xaml 的交互逻辑
    /// </summary>
    public partial class NetIPControl : UserControl
    {
        public NetIPControl()
        {
            InitializeComponent();
            DataObject.AddPastingHandler(this, new DataObjectPastingEventHandler(IPTextBox_Paste));

            // 设置textBox次序
            ipTextBox1.setNeighbour(null, ipTextBox2);
            ipTextBox2.setNeighbour(ipTextBox1, ipTextBox3);
            ipTextBox3.setNeighbour(ipTextBox2, ipTextBox4);
            ipTextBox4.setNeighbour(ipTextBox3, null);
        }


        // 处理粘贴 类似ip的形式才能粘贴
        private void IPTextBox_Paste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string value = e.DataObject.GetData(typeof(string)).ToString();
                setIPv4IP(value);
            }

            e.CancelCommand();
        }

        public string getIPv4IP()
        {
            string strTempIP = "";

            if (ipTextBox1.Text.Trim() != String.Empty)
            {
                strTempIP = (int.Parse(ipTextBox1.Text.Trim())).ToString() + ".";
            }

            if (ipTextBox2.Text.Trim() != String.Empty)
            {
                strTempIP = strTempIP + (int.Parse(ipTextBox2.Text.Trim())).ToString() + ".";
            }

            if (ipTextBox3.Text.Trim() != String.Empty)
            {
                strTempIP = strTempIP + (int.Parse(ipTextBox3.Text.Trim())).ToString() + ".";
            }

            if (ipTextBox4.Text.Trim() != String.Empty)
            {
                strTempIP = strTempIP + (int.Parse(ipTextBox4.Text.Trim())).ToString();
            }

            return strTempIP;
        }

        // 设置ip
        public bool setIPv4IP(string strIP)
        {
            string[] ips = strIP.Split('.');
            if (ips.Length == 4)
            {
                int res;
                for (int i = 0; i < ips.Length; ++i)
                    if (!Int32.TryParse(ips[i], out res) || res > 255 || res < 0)
                    {
                        return false;
                    }
                ipTextBox1.Text = ips[0];
                ipTextBox2.Text = ips[1];
                ipTextBox3.Text = ips[2];
                ipTextBox4.Text = ips[3];
                return true;
            }
            return false;
        }
    }
}

