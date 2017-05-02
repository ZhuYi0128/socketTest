using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace socketTest.SocketCommunicate
{
    public class comExecSocket
    {
        private TcpClient com_Socket_Client;
        private TcpClient com_TestSocket_Client;
        private TcpClient com_LogSocket_Client;
        private TcpClient com_TrafficSocket_Client;

        //private NetworkStream outStream;

        private int com_Port;//端口号
        private int com_Log_Port;
        private int com_Traffic_Port; 
        private string com_IP; //IP
        private int com_SendCount; //发送字符串长度
        private int com_LogSendCount;
        private int com_TrafficSendCount;
        private int com_ReceiveCount; //接受字符串长度
        private int com_LogReceiveCount;
        private int com_TrafficReceiveCount;

        private string com_ShowString = ""; //提示信息

        private byte[] com_ReceiveBuffer = new byte[1024]; //??? 接收缓冲区

        private int socket_State = -1; //socket 连接状态

        private Byte com_RunningMode;
        private string com_DeviceID = "";
        public string NetFirewall_ID;

        public int socket_Con  //用于判断连接是否正常的
        {
            get { return socket_State; }
        }

        public string SocketConnection_IP
        {
            get
            {
                return com_IP;
            }

            set
            {
                com_IP = value;
            }
        }

        public int SocketConnection_Port
        {
            get
            {
                return com_Port;
            }

            set
            {
                com_Port = value;
            }
        }

        public int LogSocketConnection_Port
        {
            get
            {
                return com_Log_Port;
            }

            set
            {
                com_Log_Port = value;
            }
        }
        public int TrafficSocketConnection_Port
        {
            get
            {
                return com_Traffic_Port;
            }

            set
            {
                com_Traffic_Port = value;
            }
        }
        
        public Byte RunningMode
        {
            get
            {
                return com_RunningMode;
            }
        }

        public string FirewallDeviceID
        {
            get
            {
                return com_DeviceID;
            }
        }

        public string socketMessage
        {
            get { return com_ShowString; }
        }


        public bool SocketConnectionStatus()
        {
            if (com_Socket_Client == null)
            {
                return false;
            }

            if (com_Socket_Client.Connected == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LogSocketConnectionStatus()
        {
            if (com_LogSocket_Client == null)
            {
                return false;
            }

            if (com_LogSocket_Client.Connected == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TrafficSocketConnectionStatus()
        {
            if (com_TrafficSocket_Client == null)
            {
                return false;
            }

            if (com_TrafficSocket_Client.Connected == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //构造函数
        public comExecSocket() 
        { 
            //string varIP = "202.199.75.251";
            //int VarPort = 8132;
            
            //this.com_IP = varIP;
            //this.com_Port = VarPort; 

            //com_Socket_Client = new TcpClient();
        }

        public NetworkStream GetNetworkStream()
        {
            if (com_Socket_Client == null)
            {
                return null;
            }

            return com_Socket_Client.GetStream();
        }

        //创建socket连接
        public void CreateConnect()
        {
            if (com_Socket_Client != null)
            {
                this.DisConnect();
            }

            try
            {
                this.com_Socket_Client = new TcpClient();
                IPEndPoint IPEP = new IPEndPoint(IPAddress.Parse(com_IP), com_Port);
              
                this.com_Socket_Client.ReceiveTimeout = 10 * 1000;
                this.com_Socket_Client.SendTimeout = 10 * 1000;
                this.com_Socket_Client.Client.Connect(IPEP);

                this.com_ShowString = "client connected successfully...";

                socket_State = 1;
            }
            catch (Exception ee)
            {
                this.com_ShowString = "Unexpected exception:" + ee.Message.ToString();
                socket_State = 0;
                throw ee;
            }
        }

        public void SetTempReceiveTimeout(int varTimeValue)
        {
            if (com_Socket_Client == null)
            {
                return;
            }

            try
            {
                com_Socket_Client.Client.ReceiveTimeout = varTimeValue;
            }
            catch (Exception ee)
            {
                this.com_ShowString = "Unexpected exception:" + ee.Message.ToString();
                socket_State = 0;
                throw ee;
            }            
        }

        
        
        /*
        * 连接测试函数
        */
        public void CreateTestConnect()
        {
            com_ShowString = "";

            if (com_TestSocket_Client != null)
            {
                this.DisTestConnect();
            }

            try
            {
                this.com_TestSocket_Client = new TcpClient(com_IP, com_Port);
                this.com_TestSocket_Client.ReceiveTimeout = 5000;
                this.com_TestSocket_Client.SendTimeout = 5000;

                this.com_ShowString = "Test client connected successfully...";
                
                socket_State = 1;
            }
            catch (Exception ex)
            {
                socket_State = 0;
            }
        }

        //创建log socket连接
        public void CreateLogConnect()
        {
            if (com_LogSocket_Client != null)
            {
                this.DisLogConnect(); 
            }

            try
            {
                this.com_LogSocket_Client = new TcpClient();
                IPEndPoint logIPEP = new IPEndPoint(IPAddress.Parse(com_IP), com_Log_Port);

                this.com_LogSocket_Client.SendTimeout = 10 * 1000;
                this.com_LogSocket_Client.Client.Connect(logIPEP);

                this.com_ShowString = "log client connected successfully...";

                socket_State = 1;
            }
            catch (Exception ee)
            {
                this.com_ShowString = "Unexpected log exception:" + ee.Message.ToString();
                socket_State = 0;
                throw ee;
            }
        }


        //创建traffic socket连接
        public void CreateTrafficConnect()
        {
            if (com_TrafficSocket_Client != null)
            {
                this.DisTrafficConnect();
            }

            try
            {
                this.com_TrafficSocket_Client = new TcpClient();
                IPEndPoint trafficIPEP = new IPEndPoint(IPAddress.Parse(com_IP), com_Traffic_Port);

                this.com_TrafficSocket_Client.SendTimeout = 10 * 1000;
                this.com_TrafficSocket_Client.Client.Connect(trafficIPEP);

                this.com_ShowString = "traffic client connected successfully...";

                socket_State = 1;
            }
            catch (Exception ee)
            {
                this.com_ShowString = "Unexpected traffic exception:" + ee.Message.ToString();
                socket_State = 0;
                throw ee;
            }
        }


        /*
       * 创建socket连接函数
       * 传递IP地址
       * 端口号默认为8132
       */
        public void CreateConnect(string varIP)
        {
            com_IP = varIP;
            CreateConnect();
        }

        public void DisConnect()
        {
            if (com_Socket_Client == null)
            {
                return ;
            }

            try
            {
                this.com_Socket_Client.Close();
                this.com_ShowString = "client disconnected successfully...";

                if (com_LogSocket_Client != null)
                {
                    this.com_LogSocket_Client.Close();
                }
            }
            catch (Exception ex)
            {
                this.com_ShowString = "client disconnected exception: " + ex.Message;
            }
            finally
            {
                this.com_Socket_Client = null;     //????? 
                
                if (com_LogSocket_Client != null)
                {
                    com_LogSocket_Client = null;
                }

                socket_State = -1;
            }
        }

        public void DisTestConnect()
        {
            if (com_TestSocket_Client == null)
            {
                return;
            }

            try
            {
                this.com_TestSocket_Client.Close();
                this.com_ShowString = "Test client disconnected successfully...";
            }
            catch (Exception ex)
            {
                this.com_ShowString = "test client disconnected error...";
            }
            finally
            {
                this.com_TestSocket_Client = null;
                socket_State = -1;
            }
        }

        public void DisLogConnect()
        {
            if (com_LogSocket_Client == null)
            {
                return;
            }

            try
            {
                this.com_LogSocket_Client.Close();
                this.com_ShowString = "log client disconnected successfully...";
            }
            catch (Exception ex)
            {
                this.com_ShowString = "log client disconnected exception: " + ex.Message;
            }
            finally
            {
                this.com_LogSocket_Client = null;  
                socket_State = -1;
            }
        }

        public void DisTrafficConnect()
        {
            if (com_TrafficSocket_Client == null)
            {
                return;
            }

            try
            {
                this.com_TrafficSocket_Client.Close();
                this.com_ShowString = "traffic client disconnected successfully...";
            }
            catch (Exception ex)
            {
                this.com_ShowString = "traffic client disconnected exception: " + ex.Message;
            }
            finally
            {
                this.com_TrafficSocket_Client = null;
                socket_State = -1;
            }
        }

        //关闭socket连接
        public void CloseClientSocket()
        {
            int itCloseSign = 0;

            com_ShowString = "";

            if (com_Socket_Client == null)
            {
                return;
            }

            try
            {
                itCloseSign = 0;
                this.com_Socket_Client.Client.Shutdown(SocketShutdown.Both);
                this.com_Socket_Client.Client.Close();
                this.com_ShowString = "client socket shutdown successfully...";

                if (com_LogSocket_Client != null)
                {
                    itCloseSign = 1;
                    this.com_LogSocket_Client.Client.Shutdown(SocketShutdown.Both);
                    this.com_LogSocket_Client.Client.Close();
                }

            }
            catch (Exception ex)
            {
                if (itCloseSign == 0)
                {
                    this.com_ShowString = "client socket shutdown fail..." + ex.Message;
                }

                if (itCloseSign == 1)
                {
                    this.com_ShowString = "log client socket shutdown fail..." + ex.Message;
                }
            }
            finally
            {
                com_Socket_Client = null;

                if (com_LogSocket_Client != null)
                {
                    com_LogSocket_Client = null;
                }

                socket_State = -1;
            }
        }

        //关闭 Log socket连接
        public void CloseLogClientSocket()
        {
            com_ShowString = "";

            if (com_LogSocket_Client == null)
            {
                return;
            }

            try
            {
                this.com_LogSocket_Client.Client.Shutdown(SocketShutdown.Both);
                this.com_LogSocket_Client.Client.Close();
                this.com_ShowString = "log client socket shutdown successfully...";
            }
            //catch (Exception ex)
            //{
            //    this.com_ShowString = "log client socket shutdown fail..." + ex.Message;
            //}
            finally
            {
                com_LogSocket_Client = null;
                socket_State = -1;
            }
        }

        //关闭 Traffic socket连接
        public void CloseTrafficClientSocket()
        {
            com_ShowString = "";

            if (com_TrafficSocket_Client == null)
            {
                return;
            }

            try
            {
                this.com_TrafficSocket_Client.Client.Shutdown(SocketShutdown.Both);
                this.com_TrafficSocket_Client.Client.Close();
                this.com_ShowString = "traffic client socket shutdown successfully...";
            }
            //catch (Exception ex)
            //{
            //    this.com_ShowString = "log client socket shutdown fail..." + ex.Message;
            //}
            finally
            {
                com_TrafficSocket_Client = null;
                socket_State = -1;
            }
        }

        /* sendBuff 发送的数据
         * 返回值 返回发送的字节数
         */
        public int SendData(Byte[] sendBuff)
        {
            com_ShowString = "";
            com_SendCount = 0;

            if (com_Socket_Client == null)
            {
                return 0;
            }

            try
            {
                if (com_Socket_Client.Connected == false)
                {
                    return 0;
                }

                com_SendCount = com_Socket_Client.Client.Send(sendBuff);
            }
            catch (Exception ex)
            {
                this.com_ShowString = "send Data fail..." + ex.Message;
                this.com_Socket_Client.Close();
                this.com_Socket_Client = null;
                this.socket_State = 0;
                return 0;
            }
            
            return com_SendCount;
        }

        /* receiveBuff 接受的数据
        * 返回值 返回接收的字节数
        */
        public int ReceiveData(Byte[] varReceiveBuff)
        {
            com_ReceiveCount = 0;
            com_ShowString = "";

            if (com_Socket_Client == null )
            {
                return 0;
            }

            try
            {
                if (com_Socket_Client.Connected == false)
                {
                    return 0;
                }   

                com_ReceiveCount = com_Socket_Client.Client.Receive(varReceiveBuff, 0, varReceiveBuff.Length, SocketFlags.None);
                 
                this.com_ShowString = "receive Data successfully...";
            }
            catch (Exception ex)
            {
                this.com_ShowString = "receive Data fail..." + ex.Message;

                com_Socket_Client.Close();
                com_Socket_Client = null;

                this.socket_State = 0;

                return 0;
            }
            
            return com_ReceiveCount;
        }

        /* sendBuff 发送的数据
        * 返回值 返回发送的字节数
        */
        public int SendLogData(Byte[] sendBuff)
        {
            com_ShowString = "";
            com_LogSendCount = 0;

            if (com_Socket_Client == null)
            {
                return 0;
            }

            if (com_LogSocket_Client == null)
            {
                return 0;
            }

            try
            {
                if (com_Socket_Client.Connected == false)
                {
                    return 0;
                }

                if (com_LogSocket_Client.Connected == false)
                {
                    return 0;
                }

                com_LogSendCount = com_LogSocket_Client.Client.Send(sendBuff);
            }
            catch (Exception ex)
            {
                this.com_ShowString = "send log data fail..." + ex.Message;
                this.com_LogSocket_Client.Close();
                this.com_LogSocket_Client = null;
                this.socket_State = 0;
                return 0;
            }

            return com_LogSendCount;
        }

        /* receiveBuff 接受的数据   log
        * 返回值 返回接收的字节数
        */
        public int ReceiveLogData(Byte[] varReceiveBuff)//, int varReceiveTimeoutSign)
        { 
            com_ShowString = "";
            com_LogReceiveCount = 0;

            if (com_Socket_Client == null)
            {
                return 0;
            }

            if (com_LogSocket_Client == null)
            {
                return 0;
            }

            try
            {
                if (com_Socket_Client.Connected == false)
                {
                    return 0;
                }

                if (com_LogSocket_Client.Connected == false)
                {
                    return 0;
                }

                //if (varReceiveTimeoutSign == 0)
                //{
                //    com_LogSocket_Client.Client.ReceiveTimeout = 10 * 1000;
                //}
                //else
                //{
                //    com_LogSocket_Client.Client.ReceiveTimeout = 0;
                //}

                com_LogReceiveCount = com_LogSocket_Client.Client.Receive(varReceiveBuff, 0, varReceiveBuff.Length, SocketFlags.None);

                this.com_ShowString = "receive log Data successfully...";
            }
            catch (Exception ex)
            {
                this.com_ShowString = "send log Data fail..." + ex.Message;

                if(com_LogSocket_Client != null)
                {
                    com_LogSocket_Client.Close();
                }

                com_LogSocket_Client = null;
                this.socket_State = 0;

                return 0;
            }

            return com_LogReceiveCount;
        }


        /* receiveBuff 接受的数据   traffic
        * 返回值 返回接收的字节数
        */
        public int ReceiveTrafficData(Byte[] varReceiveBuff)//, int varReceiveTimeoutSign)
        {
            com_ShowString = "";
            com_TrafficReceiveCount = 0;

            if (com_Socket_Client == null)
            {
                return 0;
            }

            if (com_TrafficSocket_Client == null)
            {
                return 0;
            }

            try
            {
                if (com_Socket_Client.Connected == false)
                {
                    return 0;
                }

                if (com_TrafficSocket_Client.Connected == false)
                {
                    return 0;
                }

                //if (varReceiveTimeoutSign == 0)
                //{
                //    com_TrafficSocket_Client.Client.ReceiveTimeout = 10 * 1000;
                //}
                //else
                //{
                //    com_TrafficSocket_Client.Client.ReceiveTimeout = 0;
                //}

                com_TrafficReceiveCount = com_TrafficSocket_Client.Client.Receive(varReceiveBuff, 0, varReceiveBuff.Length, SocketFlags.None);

                this.com_ShowString = "receive traffic Data successfully...";
            }
            catch (Exception ex)
            {
                this.com_ShowString = "send traffic Data fail..." + ex.Message;

                if (com_TrafficSocket_Client != null)
                {
                    com_TrafficSocket_Client.Close();
                }

                com_TrafficSocket_Client = null;
                this.socket_State = 0;

                return 0;
            }

            return com_TrafficReceiveCount;
        }



        public int CheckData(byte[] buff, int len, string flag)
        {
            int status = 0;

            switch (flag)
            {
                case "login":  //1
                    if (buff[0] == 0x02 && buff[1] == 0x01 && buff[2] == 0x02) status = 0;   //没登陆
                    else
                    { if (buff[0] == 0x01 && buff[1] == 0x01 && buff[2] == 0x01)
                        {
                            com_RunningMode = buff[3]; // zy 运行模式
                            com_DeviceID = Encoding.ASCII.GetString(buff, 4, len).Trim('\0'); // zy 装置ID ?????
                            //string b = string.Concat(buff);
                            //com_DeviceID = b.Substring(4,18);
                            status = 1;     //登录 
                        }
                    }
                    break;
                case "logout":  //2
                    if (buff[0] == 0x01 && buff[1] == 0x02 && buff[2] == 0x01) status = 1; //zy 已登录返回
                    else
                    {   if (buff[0] == 0x01 && buff[1] == 0x02 && buff[2] == 0x02) status = 0;  //zy 未登录返回
                    }
                    break;
                case "restart":  //3
                    if (buff[0] == 0x01 && buff[1] == 0x03 && buff[2] == 0x01)  status = 1; //zy 已登录返回
                    else
                    { if (buff[0] == 0x01 && buff[1] == 0x03 && buff[2] == 0x02) status = 0; //zy 未登录返回
                    }
                    break;
                case "recovery": //4
                    if (buff[0] == 0x01 && buff[1] == 0x04 && buff[2] == 0x01) status = 1;  // zy 已登录返回
                    else 
                    { if (buff[0] == 0x01 && buff[1] == 0x04 && buff[2] == 0x02)  status = 0;  // zy 未登录返回
                    }
                    break;
                case "modifyNameAndPwd": //5
                    if (buff[0] == 0x01 && buff[1] == 0x05 && buff[2] == 0x02) status = 1; // zy 已登录修改成功返回
                    else if (buff[0] == 0x01 && buff[1] == 0x05 && buff[2] == 0x03) status = 0; // zy 已登录修改错误返回
                    else if (buff[0] == 0x01 && buff[1] == 0x05 && buff[2] == 0x10) status = 2; // zy 未登录返回
                    else if (buff[0] == 0x01 && buff[1] == 0x05 && buff[2] == 0x04) status = 3; // zy 已登录但错误
                    break;
                case "time":  //6
                    if (buff[0] == 0x01 && buff[1] == 0x06 && buff[2] == 0x01) status = 1; // zy 时间设置成功
                    else if (buff[0] == 0x01 && buff[1] == 0x06 && buff[2] == 0x02) status = 0; // zy 未登录返回
                    else if (buff[0] == 0x01 && buff[1] == 0x06 && buff[2] == 0x04) status = 2; // zy 已登录未设置成功
                    break;
                case "modifyIP": //7
                     if (buff[0] == 0x01 && buff[1] == 0x07 && buff[2] == 0x01)
                    { status = 1; } // zy 已登录返回
                    else if (buff[0] == 0x01 && buff[1] == 0x07 && buff[2] == 0x02) status = 0; // zy 未登录返回
                    else if (buff[0] == 0x01 && buff[1] == 0x07 && buff[2] == 0x04) status = 2; // zy 修改出错返回
                    break;
                case "modifyNTPIP": //8
                    if (buff[0] == 0x04 && buff[1] == 0x11 && buff[2] == 0x01)
                    { status = 1; }
                    else if (buff[0] == 0x04 && buff[1] == 0x11 && buff[2] == 0x02) status = 0;
                    else if (buff[0] == 0x04 && buff[1] == 0x11 && buff[2] == 0x04) status = 2;
                    break;
                case "heart":  //9
                    if (buff[0] == 0x04 && buff[1] == 0x01 && buff[2] == 0x01) status = 1;
                    else if (buff[0] == 0x04 && buff[1] == 0x01 && buff[2] == 0x02) status = 0;
                    break;
                case "run":  //10
                    if (buff[0] == 0x01 && buff[1] == 0x21 && buff[2] == 0x01) status = 1;
                    else if (buff[0] == 0x01 && buff[1] == 0x21 && buff[2] == 0x02) status = 0;
                    break;
                case "selfLearning": //11
                    if (buff[0] == 0x20 && buff[1] == 0x31 && buff[2] == 0x01)
                    { status = 1; }
                    else if (buff[0] == 0x20 && buff[1] == 0x31 && buff[2] == 0x02) status = 0;
                    else if (buff[0] == 0x20 && buff[1] == 0x31 && buff[2] == 0x04) status = 2;
                    break; 
                case "managerControl": //12
                    if (buff[0] == 0x20 && buff[1] == 0x51 && buff[2] == 0x01)
                    { status = 1; }
                    else if (buff[0] == 0x20 && buff[1] == 0x51 && buff[2] == 0x02) status = 0;
                    else if (buff[0] == 0x20 && buff[1] == 0x51 && buff[2] == 0x04) status = 2;
                    break;
                case "directArrival":  //13
                    if (buff[0] == 0x20 && buff[1] == 0x41 && buff[2] == 0x01)
                    { status = 1; }
                    else if (buff[0] == 0x20 && buff[1] == 0x41 && buff[2] == 0x02) status = 0;
                    else if (buff[0] == 0x20 && buff[1] == 0x41 && buff[2] == 0x04) status = 2;
                    break;
                case "receiveLogRequest": //14
                    if (buff[0] == 0x01 && buff[1] == 0x11 && buff[2] == 0x01) status = 1;  // zy 获取日志 已登录返回
                    else if (buff[0] == 0x01 && buff[1] == 0x11 && buff[2] == 0x02) status = 0; // zy 获取日志 未登录返回
                    break;

                case "receiveTrafficRequest": //14
                    if (buff[0] == 0x01 && buff[1] == 0x12 && buff[2] == 0x01) status = 1;  // zy 获取流量 已登录返回
                    else if (buff[0] == 0x01 && buff[1] == 0x12 && buff[2] == 0x02) status = 0; // zy 获取流量 未登录返回
                    break;
                case "SendRuleRet":  //15
                    if (buff[0] == 0x01 && buff[1] == 0x10 && buff[2] == 0x01) status = 1;
                    else if (buff[0] == 0x01 && buff[1] == 0x10 && buff[2] == 0x02) status = 0;
                    break;
                case "industrialRuleRet":  //16
                    if (buff[0] == 0x08 && buff[1] == 0x01 && buff[2] == 0x03) status = 1;
                    else if (buff[0] == 0x08 && buff[1] == 0x01 && buff[2] == 0x04) status = 0;
                    break;
                case "normalRuleRet":      //17
                    if (buff[0] == 0x08 && buff[1] == 0x01 && buff[2] == 0x05) status = 1;
                    else if (buff[0] == 0x08 && buff[1] == 0x01 && buff[2] == 0x06) status = 0;
                    break;
                case "synchronizeRuleRet":   //18
                    if (buff[0] == 0x08 && buff[1] == 0x01 && buff[2] == 0x07) status = 1;
                    else if (buff[0] == 0x08 && buff[1] == 0x01 && buff[2] == 0x08) status = 0;
                    else if (buff[0] == 0x08 && buff[1] == 0x01 && buff[2] == 0x09) status = 2;
                    else if (buff[0] == 0x08 && buff[1] == 0x01 && buff[2] == 0x0A) status = 3;
                    break;
                case "GetFirewallEquipMACAddress": //19  获取MAC地址
                    if (buff[0] == 0x01 && buff[1] == 0x08 && buff[2] == 0x01) status = 1;
                    else if (buff[0] == 0x01 && buff[1] == 0x08 && buff[2] == 0x02) status = 0;
                    break;
                case "receiveSelfLearningRuleRequest": //21
                    if (buff[0] == 0x20 && buff[1] == 0x61 && buff[2] == 0x01) status = 1;
                    else if (buff[0] == 0x20 && buff[1] == 0x61 && buff[2] == 0x02) status = 0;
                    break;
                default: break;

            }
            return status;
        }


    }
}
