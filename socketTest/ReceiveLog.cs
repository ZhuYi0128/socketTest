using FirewallNetTreeManager.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace socketTest
{
    class ReceiveLog
    {
        //private NetEditEntity.EntityNetFirewallInfo _eEditNetFirewallInfo = new NetEditEntity.EntityNetFirewallInfo();
        #region  定义属性，以供记录登陆者的信息，所有页面必须添加下面的定义。

        private string tUserID = "";
        public string trUserID
        {
            get { return tUserID; }
            set { tUserID = value; }
        }

        private string tUserName = "";
        public string trUserName
        {
            get { return tUserName; }
            set { tUserName = value; }
        }

        private string tbtnPower = "";
        public string trbtnPower
        {
            get { return tbtnPower; }
            set { tbtnPower = value; }
        }
       
           

        
        #endregion

        CPublicControl.CIntiDataTable ACIntiDataTable = new CPublicControl.CIntiDataTable();
        CPublicControl.CPublicMethod ACPublicMethod = new CPublicControl.CPublicMethod();
        CData.CDataNetFirewallLogControl ACDataNetFirewallLogControl = new CData.CDataNetFirewallLogControl();

        private NetEditEntity.EntityNetFirewallInfo _eEditNetFirewallInfo;
        public NetEditEntity.EntityNetFirewallInfo ChooseNetFirewallInfo
        {
            get { return _eEditNetFirewallInfo; }
            set { _eEditNetFirewallInfo = value; }
        }

        /// <summary>
        /// 解析server发送的Log数据，并存入数据库
        /// </summary>
        public void OpenSocketLogReceive()
        {
            // 定义string 分别对应截取到的字段和数据库的字段
            string Time = ""; 
            string Type = "";
            string Info = "";
            string Level = "";
            string Src = "";
            string Dst = "";
            string Packet = "";
            string AlarmRC = "";
            if (OpenSingleSocketLogReceive(ref AlarmRC) == true) // 判断调用函数 
            {


                //将接收到的数据预处理之后 得到的字符串AlarmRC进行截取 存入Alarm数组中
                string[] Alarm = AlarmRC.Split(new string[] { "<Time>", "</Time>", "<type>", "</type>", "<info>", "</info>", "<level>", "</level>", "<src>", "</src>", "<dst>", "</dst>", "<packet>", "</packet>" }, StringSplitOptions.RemoveEmptyEntries);
                //foreach (string e in Alarm) ;

                //将截取到的数据分别存入定义的string中
                Time = Alarm[1];
                Type = Alarm[3];
                Info = Alarm[5];
                Level = Alarm[7];
                Src = Alarm[9];
                Dst = Alarm[11];
                Packet = Alarm[13];

                Array.Clear(Alarm, 0, Alarm.Length);// 清空Alarm

                // 将数据添加到数据库中
                String strSql = @"INSERT INTO T_S_AlarmLog (AlarmLog_Time,AlarmLog_Type,AlarmLog_Info,AlarmLog_Level,AlarmLog_Src,AlarmLog_Dst,AlarmLog_Packet) VALUES ('" + Time + "','" + Type + "','" + Info + "','" + Level + "','" + Src + "','" + Dst + "','" + Packet + "')";

                try
                {
                    using (DBProvider proxy = new DBProvider())
                    {
                        String strDB = ConfigurationManager.AppSettings["SqlServer"];
                        String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                        proxy.CreateConnection(ref strDB, ref strConn);
                        proxy.SetSqlCmdText(ref strSql);//连接设置成全局的， 连接只连接一次 
                        proxy.ExecuteNotQuery();

                    }

                }
                catch (Exception e)
                {
                    //bRst = false;
                    throw;
                }
            }
        }

        public bool OpenSingleSocketLogReceive(ref string AlarmReceive)
        {

            byte[] receiveLogData = new byte[500]; // 定义接收到的数据数组
            int itReceiveLength = 0;
            string AlarmReceive1 = "";
            string ReceiveLogDataHead = "<alarm>"; //定义特定字符串
            string ReceiveLogDataTail = "<alarm>"; //定义特定字符串
            try
            {

                // 获取接收到的Log数据长度  
                itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveLogData(receiveLogData); 

                if ((itReceiveLength > 0))
                {

                    //将接收到的receiveLogData转变为字符串
                    AlarmReceive1 = Encoding.ASCII.GetString(receiveLogData, 0, itReceiveLength).Trim('\0');

                    if (AlarmReceive1.Contains(ReceiveLogDataHead)) // 判断字符串里有没有特定字符串
                    {
                        if (AlarmReceive1.Contains(ReceiveLogDataTail)) // 判断字符串里有没有特定字符串
                        {
                            //截取字符串
                            string[] TrafficRC2 = AlarmReceive1.Split(new string[] { "<alarm>", "</alarm>" }, StringSplitOptions.RemoveEmptyEntries);
                            AlarmReceive = TrafficRC2[1];
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return false;
            }

            // return true;
        }

    }
}
