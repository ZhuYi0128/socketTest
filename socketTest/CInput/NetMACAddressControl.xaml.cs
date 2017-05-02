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
    /// NetMACAddressControl.xaml 的交互逻辑
    /// </summary>
    public partial class NetMACAddressControl : UserControl
    {
        public NetMACAddressControl()
        {
            InitializeComponent();

            DataObject.AddPastingHandler(this, new DataObjectPastingEventHandler(IPTextBox_Paste));

            // 设置textBox次序
            ipTextBox1.setNeighbour(null, ipTextBox2);
            ipTextBox2.setNeighbour(ipTextBox1, ipTextBox3);
            ipTextBox3.setNeighbour(ipTextBox2, ipTextBox4);
            ipTextBox4.setNeighbour(ipTextBox3, ipTextBox5);
            ipTextBox5.setNeighbour(ipTextBox4, ipTextBox6);
            ipTextBox6.setNeighbour(ipTextBox5, null);
        }

        // 处理粘贴 类似MAC地址的形式才能粘贴
        private void IPTextBox_Paste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string value = e.DataObject.GetData(typeof(string)).ToString();
                setMACAddress(value);
            }

            e.CancelCommand();
        }

        public string getMACAddress()
        {
            return ipTextBox1.Text.ToUpper() + ipTextBox2.Text.ToUpper() + ipTextBox3.Text.ToUpper() + ipTextBox4.Text.ToUpper() + ipTextBox5.Text.ToUpper() + ipTextBox6.Text.ToUpper();
        }

        // 设置MAC地址
        public bool setMACAddress(string strMAC)
        {
            int itMACAddressLength = strMAC.Length;

            if (itMACAddressLength != 12)
            {
                return false;
            }

            string[] slMac = new string[6];

            for (int i = 0; i < 6; i++)
            {
                slMac[i] = strMAC.Substring(i * 2, 2);
            }


            int res;

            for (int i = 0; i < slMac.Length; i++)
            {
                if (!Int32.TryParse(slMac[i], System.Globalization.NumberStyles.HexNumber, null, out res))
                {
                    return false;
                }
                
                if( res > 255 || res < 0)
                {
                    return false;
                }
            }

            ipTextBox1.Text = slMac[0];
            ipTextBox2.Text = slMac[1];
            ipTextBox3.Text = slMac[2];
            ipTextBox4.Text = slMac[3];
            ipTextBox5.Text = slMac[4];
            ipTextBox6.Text = slMac[5];

            return true;
        }

    }
}
