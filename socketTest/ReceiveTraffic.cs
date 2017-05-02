using FirewallNetTreeManager.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace socketTest
{
    class ReceiveTraffic
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
        /// 解析server发来的流量数据，并存入数据库
        /// </summary>
        public void OpenSocketTrafficReceive()
        {

            // 定义string 分别对应截取到的字段和数据库的字段
            string TrafficName1 = "";
            string Address1 = "";

            string Inst_Traffic1REC = "";
            decimal Inst_Traffic1;
            string Inst_Traffic1Unit = "";

            string Accum_Traffic1REC = "";
            decimal Accum_Traffic1;
            string Accum_Traffic1Unit = "";

            string Avg_Size1REC = "";
            decimal Avg_Size1;
            string Avg_Size1Unit = "";

            string Packets1 = "";
            string Last_Heard1 = "";

            string TrafficName2 = "";
            string Address2 = "";

            string Inst_Traffic2REC = "";
            decimal Inst_Traffic2;
            string Inst_Traffic2Unit = "";

            string Accum_Traffic2REC = "";
            decimal Accum_Traffic2;
            string Accum_Traffic2Unit = "";

            string Avg_Size2REC = "";
            decimal Avg_Size2;
            string Avg_Size2Unit = "";

            string Packets2 = "";
            string Last_Heard2 = "";

            string TrafficRC = "";
            if (OpenSingleSocketTrafficReceive(ref TrafficRC) == true)
            {

                //将接收到的数据预处理之后 得到的字符串AlarmRC进行截取 存入Alarm数组中
                string[] Traffic = TrafficRC.Split(new string[] { "<traffic name=\"", "\">", "<Address>", "</Address>", "<Inst_Traffic>", " </Inst_Traffic>", "<Accum_Traffic>", "</Accum_Traffic>", "<Avg_Size>", "</Avg_Size>", "<Packets>", "</Packets>", "<Last_Heard>", "</Last_Heard>" }, StringSplitOptions.RemoveEmptyEntries);
                //foreach (string a in Traffic) ;

                //将截取到的数据分别存入定义的string中
                TrafficName1 = Traffic[1];
                Address1 = Traffic[3];

                Inst_Traffic1REC = Traffic[5];
                string[] Inst1 = Inst_Traffic1REC.Split(new char[] { ' ' });
                Inst_Traffic1 = decimal.Parse(Inst1[0]);
                Inst_Traffic1Unit = Inst1[1];

                Accum_Traffic1REC = Traffic[7];
                string[] Accum1 = Accum_Traffic1REC.Split(new char[] { ' ' });
                Accum_Traffic1 = decimal.Parse(Accum1[0]);
                Accum_Traffic1Unit = Accum1[1];

                Avg_Size1REC = Traffic[9];
                string[] Avg1 = Avg_Size1REC.Split(new char[] { ' ' });
                Avg_Size1 = decimal.Parse(Avg1[0]);
                Avg_Size1Unit = Avg1[1];
                
                Packets1 = Traffic[11];
                Last_Heard1 = Traffic[13];

                TrafficName2 = Traffic[15];
                Address2 = Traffic[17];

                Inst_Traffic2REC = Traffic[5];
                string[] Inst2 = Inst_Traffic2REC.Split(new char[] { ' ' });
                Inst_Traffic2 = decimal.Parse(Inst2[0]);
                Inst_Traffic2Unit = Inst2[1];

                Accum_Traffic2REC = Traffic[7];
                string[] Accum2 = Accum_Traffic2REC.Split(new char[] { ' ' });
                Accum_Traffic2 = decimal.Parse(Accum2[0]);
                Accum_Traffic2Unit = Accum2[1];

                Avg_Size2REC = Traffic[9];
                string[] Avg2 = Avg_Size2REC.Split(new char[] { ' ' });
                Avg_Size2 = decimal.Parse(Avg2[0]);
                Avg_Size2Unit = Avg2[1];

                Packets2 = Traffic[25];
                Last_Heard2 = Traffic[27];


                Array.Clear(Traffic, 0, Traffic.Length);


                // 将数据添加到数据库中
                //String strSql = @"INSERT INTO T_A_TRAFFIC (TRAFFIC_NAME,TRAFFIC_IP,INST_TRAFFIC,ACCUM_TRAFFIC,AVG_SIZE,TRAFFIC_PACKETS,LAST_HEARD) VALUES ('" + TrafficName1 + "','" + Address1 + "','" + Inst_Traffic1 + "','" + Accum_Traffic1 + "','" + Avg_Size1 + "','" + Packets1 + "','" + Last_Heard1 + "')";

                String strSql = @"INSERT INTO T_A_TRAFFIC (TRAFFIC_NAME,TRAFFIC_IP,TRAFFIC_PACKETS,LAST_HEARD) VALUES ('" + TrafficName1 + "','" + Address1 + "','" + Packets1 + "','" + Last_Heard1 + "')";

                //String strSq2 = @"INSERT INTO T_A_TRAFFIC (TRAFFIC_NAME,TRAFFIC_IP,INST_TRAFFIC,ACCUM_TRAFFIC,AVG_SIZE,TRAFFIC_PACKETS,LAST_HEARD) VALUES ('" + TrafficName2 + "','" + Address2 + "','" + Inst_Traffic2 + "','" + Accum_Traffic2 + "','" + Avg_Size2 + "','" + Packets2 + "','" + Last_Heard2 + "')";

                try
                {
                    using (DBProvider proxy = new DBProvider())
                    {
                        String strDB = ConfigurationManager.AppSettings["SqlServer"];
                        String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                        proxy.CreateConnection(ref strDB, ref strConn);
                        proxy.SetSqlCmdText(ref strSql);//连接设置成全局的， 连接只连接一次 
                        // proxy.SetSqlCmdText(ref strSq2);//连接设置成全局的， 连接只连接一次

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

        public bool OpenSingleSocketTrafficReceive(ref string TrafficReceive)
        {

            byte[] receiveTrafficData = new byte[1000]; // 定义接收到的数据数组
            int itReceiveLength = 0;
            string TrafficRC1 = "";
            string ReceiveDataHead = "<etherape>"; //定义特定字符串
            string ReceiveDataTail = "</etherape>"; //定义特定字符串
            try
            {
                // 获取接收到的Log数据长度  
                itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveTrafficData(receiveTrafficData);

                if ((itReceiveLength > 0))
                {

                    //将接收到的receiveLogData转变为字符串
                    TrafficRC1 = Encoding.ASCII.GetString(receiveTrafficData, 0, itReceiveLength).Trim('\0');


                    if (TrafficRC1.Contains(ReceiveDataHead)) // 判断字符串里有没有特定字符串
                    {
                        if (TrafficRC1.Contains(ReceiveDataTail)) // 判断字符串里有没有特定字符串
                        {
                            //截取字符串
                            string[] TrafficRC2 = TrafficRC1.Split(new string[] { "<etherape>", "</etherape>" }, StringSplitOptions.RemoveEmptyEntries);
                            TrafficReceive = TrafficRC2[1];

                            return true;
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
