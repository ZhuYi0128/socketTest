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
using System.Data;
using System.Configuration;
using FirewallNetTreeManager.Common;
using System.Threading;
using Microsoft.Win32;
using System.Net.Sockets;
using System.IO;
using Log4Net;


namespace socketTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

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
        private void getbtnPower()
        {
            try
            {
                if (tbtnPower.Trim() != String.Empty)
                {
                    char[] btnPower = tbtnPower.Trim().ToCharArray();

                    int btnCount = int.Parse(btnPower.GetLongLength(0).ToString());
                    int numbtn = 0;

                    if (btnPower[0].ToString().Trim() == "1" && numbtn < btnCount)
                    {
                        //btnSave.Visibility = Visibility.Visible;
                        ShowObjectIsHitTestVisible(1);
                    }
                    else
                    {
                        //btnSave.Visibility = Visibility.Hidden;
                        ShowObjectIsHitTestVisible(0);
                    }
                    numbtn += 1;

                    if (btnPower[1].ToString().Trim() == "1" && numbtn < btnCount)
                    {
                        //btnSave.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        //btnSave.Visibility = Visibility.Hidden;
                    }
                    numbtn += 1;
                }
            }
            catch
            { }

        }

        private void ShowObjectIsHitTestVisible(int varShowSign)
        {
            if (varShowSign == 1)
            {
                //txtNetFirewallID.IsHitTestVisible = true;
                txtNetFirewallName.IsHitTestVisible = true;
            }

            if (varShowSign == 0)
            {
                //txtNetFirewallID.IsHitTestVisible = false;
                txtNetFirewallName.IsHitTestVisible = false;
            }
        }

        #endregion

        private String _equipID;

        public String EquipID
        {
            get { return _equipID; }
            set { _equipID = value; }
        }

        private String _userID = "0000000001";

        public String UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private String _userName = "Admin";

        public String UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }




        private String _equipName;

        public String EquipName
        {
            get { return _equipName; }
            set { _equipName = value; }
        }

        public static int SERFlag = -1; //操作日志流量标志位
        //传递进来的实体类
        private NetEditEntity.EntityNetNodeInfo _etEditNetNodeInfo;
        public NetEditEntity.EntityNetNodeInfo ChooseEditNetNodeInfo
        {
            get
            {
                return _etEditNetNodeInfo;
            }

            set
            {
                _etEditNetNodeInfo = value;
            }
        }

        //private NetEditEntity.EntityNetFirewallInfo _eEditNetFirewallInfo;

        //实际程序下面代码要删掉
        private NetEditEntity.EntityNetFirewallInfo _eEditNetFirewallInfo = new NetEditEntity.EntityNetFirewallInfo();


        CPublicControl.CIntiDataTable ACIntiDataTable = new CPublicControl.CIntiDataTable();
        CPublicControl.CPublicMethod ACPublicMethod = new CPublicControl.CPublicMethod();
        CData.CDataNetFirewallLogControl ACDataNetFirewallLogControl = new CData.CDataNetFirewallLogControl();

        DataTable DTFirewallRunMode = new DataTable();
        DataTable DTFirewallConnectionState = new DataTable();


        public MainWindow()
        {
            InitializeComponent();
        }

        public void Initialize()
        {

            //加载传入信息
            fullSingleNetNodeInfo();


        }

        private void fullSingleNetNodeInfo()
        {
            if (!String.IsNullOrEmpty(EquipID))
            {
                //txtFirewallDeviceID.Text = EquipID;
                txtNetFirewallName.Text = EquipName;




                String strSql = @"SELECT * FROM V_EQUIP_SETTING WHERE EQUIP_ID = '" + EquipID + @"' ";
                DataSet dsTemp = new DataSet();

                try
                {
                    using (DBProvider proxy = new DBProvider())
                    {
                        String strDB = ConfigurationManager.AppSettings["SqlServer"];
                        String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                        proxy.CreateConnection(ref strDB, ref strConn);
                        proxy.SetSqlCmdText(ref strSql);
                        proxy.QueryData(ref dsTemp);

                    }

                    if (0 < dsTemp.Tables.Count)
                    {
                        foreach (DataRow item in dsTemp.Tables[0].Rows)
                        {
                            if (!(item["EQUIP_IP"] is DBNull))
                            {
                                txtMaskedIPAddress.setIPv4IP(Convert.ToString(item["EQUIP_IP"]).Trim());

                            }


                            if (!(item["EQUIP_USERNAME"] is DBNull))
                            {
                                txtUserName.Text = Convert.ToString(item["EQUIP_USERNAME"]).Trim();
                            }

                            if (!(item["EQUIP_PASSWORD"] is DBNull))
                            {
                                txtUserPassWord.Password = Convert.ToString(item["EQUIP_PASSWORD"]).Trim();
                            }
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //清除原有信息
            ClearAll();

            //if (_etEditNetNodeInfo.NetNode_Type_ID == "NetFirewall") ///????
            //{
            //    //_eEditNetFirewallInfo = (NetEditEntity.EntityNetFirewallInfo)_etEditNetNodeInfo; ///???
            //}


            ACIntiDataTable.IntiDTFirewallRunModeData(ref DTFirewallRunMode);

            ACPublicMethod.fullCombBox(ref cboCurrentRunMode, ref DTFirewallRunMode, CCommon.Key_T_S_Uppermonitor_ControlParameters_NetFirewallRunMode_Name_Nvar, CCommon.Key_T_S_Uppermonitor_ControlParameters_NetFirewallRunMode_ID_Nvar);

            ACIntiDataTable.IntiDTFirewallConnectionStateData(ref DTFirewallConnectionState);

            ACPublicMethod.fullCombBox(ref cboConnectionState, ref DTFirewallConnectionState, CCommon.Key_T_S_Uppermonitor_ControlParameters_ConnectionState_Name_Nvar, CCommon.Key_T_S_Uppermonitor_ControlParameters_ConnectionState_ID_Nvar);

        }

        private void cavInfo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ClearAll()
        {
            //txtNetFirewallID.Text = String.Empty;
            txtNetFirewallName.Text = String.Empty;

            txtFirewallDeviceID.Text = String.Empty;

            txtMaskedIPAddress.ipTextBox4.Text = String.Empty;
            txtMaskedIPAddress.ipTextBox3.Text = String.Empty;
            txtMaskedIPAddress.ipTextBox2.Text = String.Empty;
            txtMaskedIPAddress.ipTextBox1.Text = String.Empty;

            cboConnectionState.Text = String.Empty;
            if (cboConnectionState.Items != null)
            {
                if (cboConnectionState.Items.Count > 0)
                {
                    cboConnectionState.SelectedIndex = -1;
                }
            }

            cboCurrentRunMode.Text = String.Empty;
            if (cboCurrentRunMode.Items != null)
            {
                if (cboCurrentRunMode.Items.Count > 0)
                {
                    cboCurrentRunMode.SelectedIndex = -1;
                }
            }

            txtUserName.Text = string.Empty;
            txtUserPassWord.Password = string.Empty;
        }

        private int iComFileLen;
        private string sComFirewallDeviceID = "";
        private Byte byteComFirewallRunningMode;

        private void AddServer()
        {
            if (String.IsNullOrEmpty(txtMaskedIPAddress.getIPv4IP()))
            {
                return;
            }

            if (String.IsNullOrEmpty(EquipID))
            {
                return;
            }

            try
            {
                String strSql = @"SELECT COUNT(*) FROM T_A_SERVER WHERE SER_ID = '" + EquipID + @"' AND SER_IP = '" + txtMaskedIPAddress.getIPv4IP() + "' ";

                DataSet dsTemp = new DataSet();

                using (DBProvider proxy = new DBProvider())
                {
                    String strDB = ConfigurationManager.AppSettings["SqlServer"];
                    String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                    proxy.CreateConnection(ref strDB, ref strConn);
                    proxy.SetSqlCmdText(ref strSql);
                    proxy.QueryData(ref dsTemp);

                }

                if (0 < dsTemp.Tables.Count)
                {
                    if (0 < Convert.ToInt32(dsTemp.Tables[0].Rows[0][0]))
                    {
                        return;
                    }
                }

                String strSqlInsert = @"INSERT INTO T_A_SERVER(SER_ID,SER_IP) VALUES( '" + EquipID + @"', '" + txtMaskedIPAddress.getIPv4IP() + "') ";

                using (DBProvider proxy = new DBProvider())
                {
                    String strDB = ConfigurationManager.AppSettings["SqlServer"];
                    String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                    proxy.CreateConnection(ref strDB, ref strConn);
                    proxy.SetSqlCmdText(ref strSqlInsert);
                    proxy.ExecuteNotQuery();

                }

                SERFlag = -1;

                String strFlag = @" UPDATE T_A_SERVER SET SER_FLAG = -1";
                using (DBProvider proxy = new DBProvider())
                {
                    String strDB = ConfigurationManager.AppSettings["SqlServer"];
                    String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                    proxy.CreateConnection(ref strDB, ref strConn);
                    proxy.SetSqlCmdText(ref strFlag);
                    proxy.ExecuteNotQuery();

                }


            }
            catch (Exception e)
            {

                throw;
            }


        }

        private void JoinNewEditData()
        {
            String strSql = @"SELECT COUNT(*) FROM T_A_EQUIP_SETTING WHERE EQUIP_ID = '" + EquipID + @"' ";

            String strSqlInsert = @"INSERT INTO T_A_EQUIP_SETTING(EQUIP_ID,EQUIP_IP,EQUIP_MAC,EQUIP_USERNAME,EQUIP_PASSWORD,EQUIP_DES) VALUES (@EQUIP_ID,@EQUIP_IP,@EQUIP_MAC,@EQUIP_USERNAME,@EQUIP_PASSWORD,@EQUIP_DES)";
            String strSqlUpdate = @"UPDATE T_A_EQUIP_SETTING SET EQUIP_IP = @EQUIP_IP, EQUIP_MAC = @EQUIP_MAC, EQUIP_USERNAME = @EQUIP_USERNAME, EQUIP_PASSWORD = @EQUIP_PASSWORD, EQUIP_DES = @EQUIP_DES WHERE EQUIP_ID = @EQUIP_ID";
            DataSet dsTemp = new DataSet();

            bool bFlag = false;

            try
            {
                using (DBProvider proxy = new DBProvider())
                {
                    String strDB = ConfigurationManager.AppSettings["SqlServer"];
                    String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                    proxy.CreateConnection(ref strDB, ref strConn);
                    proxy.SetSqlCmdText(ref strSql);
                    proxy.QueryData(ref dsTemp);

                }

                if (0 < dsTemp.Tables.Count)
                {
                    if (0 < Convert.ToInt32(dsTemp.Tables[0].Rows[0][0]))
                    {
                        bFlag = true;
                    }
                }

                if (bFlag)
                {
                    using (DBProvider proxy = new DBProvider())
                    {
                        String strDB = ConfigurationManager.AppSettings["SqlServer"];
                        String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                        proxy.CreateConnection(ref strDB, ref strConn);
                        proxy.SetSqlCmdText(ref strSqlUpdate);

                        String strParam1 = @"@EQUIP_IP";
                        String strParam2 = @"@EQUIP_MAC";
                        String strParam3 = @"@EQUIP_USERNAME";
                        String strParam4 = @"@EQUIP_PASSWORD";
                        String strParam5 = @"@EQUIP_DES";
                        String strParam6 = @"@EQUIP_ID";

                        proxy.SetInParameter(ref strParam1, DbType.String, String.IsNullOrEmpty(txtMaskedIPAddress.getIPv4IP()) ? "" : txtMaskedIPAddress.getIPv4IP(), true);
                        proxy.SetInParameter(ref strParam2, DbType.String, "", false);
                        proxy.SetInParameter(ref strParam3, DbType.String, String.IsNullOrEmpty(txtUserName.Text.Trim()) ? "" : txtUserName.Text.Trim(), false);
                        proxy.SetInParameter(ref strParam4, DbType.String, String.IsNullOrEmpty(txtUserPassWord.Password) ? "" : txtUserPassWord.Password, false);
                        proxy.SetInParameter(ref strParam5, DbType.String, " ", false);
                        proxy.SetInParameter(ref strParam6, DbType.String, String.IsNullOrEmpty(EquipID) ? "" : EquipID, false);
                        proxy.ExecuteNotQuery();

                    }
                }
                else
                {
                    using (DBProvider proxy = new DBProvider())
                    {
                        String strDB = ConfigurationManager.AppSettings["SqlServer"];
                        String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                        proxy.CreateConnection(ref strDB, ref strConn);
                        proxy.SetSqlCmdText(ref strSqlInsert);

                        String strParam1 = @"@EQUIP_IP";
                        String strParam2 = @"@EQUIP_MAC";
                        String strParam3 = @"@EQUIP_USERNAME";
                        String strParam4 = @"@EQUIP_PASSWORD";
                        String strParam5 = @"@EQUIP_DES";
                        String strParam6 = @"@EQUIP_ID";

                        proxy.SetInParameter(ref strParam6, DbType.String, String.IsNullOrEmpty(EquipID) ? "" : EquipID, true);
                        proxy.SetInParameter(ref strParam1, DbType.String, String.IsNullOrEmpty(txtMaskedIPAddress.getIPv4IP()) ? "" : txtMaskedIPAddress.getIPv4IP(), false);
                        proxy.SetInParameter(ref strParam2, DbType.String, " ", false);
                        proxy.SetInParameter(ref strParam3, DbType.String, String.IsNullOrEmpty(txtUserName.Text.Trim()) ? "" : txtUserName.Text.Trim(), false);
                        proxy.SetInParameter(ref strParam4, DbType.String, String.IsNullOrEmpty(txtUserPassWord.Password) ? "" : txtUserPassWord.Password, false);
                        proxy.SetInParameter(ref strParam5, DbType.String, " ", false);


                        proxy.ExecuteNotQuery();

                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }



        }


        private void btnNetworkConnection_Click(object sender, RoutedEventArgs e)
        {
            //-------通信操作日志记录相关变量-------------------
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;
            string stExecState = "";
            string stExecOperationInfo = "";
            int iExecFlag = -1;
            //-------------------------------------------------


            string sComFirewallServiceIP = "";
            string sComUserName = "";
            string sComUserPwd = "";

            try
            {
                sComFirewallServiceIP = txtMaskedIPAddress.getIPv4IP().Trim();// Zy 获取输入IP 地址
                sComUserName = txtUserName.Text.Trim();// Zy 获取用户名输入
                sComUserPwd = txtUserPassWord.Password.Trim(); // Zy 获取用户密码输入

                _eEditNetFirewallInfo.ExecSocketCommunicate.SocketConnection_IP = sComFirewallServiceIP;
                _eEditNetFirewallInfo.ExecSocketCommunicate.SocketConnection_Port = GlobalInfo.GlobalFirewallServicePort;

                _eEditNetFirewallInfo.ExecSocketCommunicate.CreateConnect();

                if (_eEditNetFirewallInfo.ExecSocketCommunicate.socket_Con == 1)
                {
                    if (IsOrNotCommunicateRight(sComUserName, sComUserPwd, ref iExecFlag) == true)
                    {
                        if (iExecFlag == 1)
                        {
                            JoinLoginStateInfo(2);
                            StateFirewallCommState(0);
                            AddServer();
                            JoinNewEditData();
                            stDescription = "异常监测设备登录成功...";

                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "登录异常监测设备", "成功", "登录成功", ref strErr);

                            ShowErrorMsg(stDescription);
                        }

                        if (iExecFlag == 0)
                        {
                            JoinLoginStateInfo(0);
                            StateFirewallCommState(1);

                            _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                            _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                            stDescription = "未能登录异常监测设备...";
                            ShowErrorMsg(stDescription);

                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "登录异常监测设备", "失败", "登录失败", ref strErr);


                        }
                    }
                    else
                    {
                        stDescription = "下位机返回信息错误...";
                        ShowErrorMsg(stDescription);

                        String strErr = String.Empty;
                        CLog.InsertLocalLogRecord(UserID, UserName, "登录异常监测设备", "失败", "下位机返回信息错误", ref strErr);
                    }
                }
                else
                {
                    JoinLoginStateInfo(0);
                    StateFirewallCommState(1);

                    _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                    _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                    stDescription = "网络连接错误...";
                    ShowErrorMsg(stDescription);

                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "登录异常监测设备", "失败", "网络连接错误", ref strErr);

                }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);
                StateFirewallCommState(1);

                ShowErrorMsg(ex.Message.ToString());

                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ex.Message.ToString();
                #endregion
            }
            finally
            {

            }

        }

        public bool IsOrNotCommunicateRight(string name, string pwd, ref int varExecFlag)
        {
            //0x01：1字节  0x02：1字节   0x03：1字节    name 16字节   pwd 16字节
            byte[] bytelComByte = new byte[1 + 1 + 1 + 16 + 16];

            int iComIndex = 0;
            iComFileLen = 0;

            Byte bComOper1 = 0x01; // zy 登录发送协议 0x01 0x01 0x03
            Byte bComOper2 = 0x01;
            Byte bComOper3 = 0x03;

            Array.Copy(BitConverter.GetBytes(bComOper1), 0, bytelComByte, iComIndex, 1);
            iComIndex += 1;
            Array.Copy(BitConverter.GetBytes(bComOper2), 0, bytelComByte, iComIndex, 1);
            iComIndex += 1;
            Array.Copy(BitConverter.GetBytes(bComOper3), 0, bytelComByte, iComIndex, 1);
            iComIndex += 1;
            Encoding.ASCII.GetBytes(name, 0, name.Length, bytelComByte, iComIndex);
            iComIndex += 16;
            Encoding.ASCII.GetBytes(pwd, 0, pwd.Length, bytelComByte, iComIndex);
            iComIndex += 16;

            byte[] byteComReceiveBuffer = new byte[30];

            try
            {
                int iComSendCount = 0;

                iComSendCount = _eEditNetFirewallInfo.ExecSocketCommunicate.SendData(bytelComByte);

                if (iComSendCount > 0)
                {
                    int iComReceiveCount = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveData(byteComReceiveBuffer);
                    string Receive;
                    string R1;
                    Receive = System.Text.Encoding.Default.GetString(byteComReceiveBuffer);
                    //R1 = Encoding.ASCII.GetString(byteComReceiveBuffer).Trim('\0');
                    R1 = Encoding.ASCII.GetString(byteComReceiveBuffer, 0, iComReceiveCount).Trim('\0');
                    if ((iComReceiveCount > 0))
                    {
                        varExecFlag = _eEditNetFirewallInfo.ExecSocketCommunicate.CheckData(byteComReceiveBuffer, iComReceiveCount, "login");

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        private void JoinLoginStateInfo(int varSuccessSign)
        {
            if (varSuccessSign == 0)
            {
                _eEditNetFirewallInfo.ConnectionState = "00";  //已断开
                _eEditNetFirewallInfo.IsOrNotLogin = 0;        //已退出登录
            }

            if (varSuccessSign == 1)
            {
                _eEditNetFirewallInfo.ConnectionState = "01";  //已关闭
                _eEditNetFirewallInfo.IsOrNotLogin = 0;        //已退出登录
            }

            if (varSuccessSign == 2)
            {
                _eEditNetFirewallInfo.ConnectionState = "02";  //已连接
                _eEditNetFirewallInfo.IsOrNotLogin = 1;        //已登录
            }
        }


        // zy 没看懂
        private void StateFirewallCommState(int varRefreshSign)
        {
            if (varRefreshSign == 0)
            {
                sComFirewallDeviceID = _eEditNetFirewallInfo.ExecSocketCommunicate.FirewallDeviceID;
                _eEditNetFirewallInfo.NetFirewallDevice_ID = sComFirewallDeviceID;

                byteComFirewallRunningMode = _eEditNetFirewallInfo.ExecSocketCommunicate.RunningMode;
                _eEditNetFirewallInfo.NetFirewallRunMode = byteComFirewallRunningMode.ToString("D2");

                txtFirewallDeviceID.Text = _eEditNetFirewallInfo.NetFirewallDevice_ID;
                EquipID = _eEditNetFirewallInfo.NetFirewallDevice_ID;
                cboCurrentRunMode.Text = String.Empty;
                if (cboCurrentRunMode.Items != null)
                {
                    if (cboCurrentRunMode.Items.Count > 0)
                    {
                        cboCurrentRunMode.SelectedValue = _eEditNetFirewallInfo.NetFirewallRunMode;
                    }
                }
            }

            if (varRefreshSign == 0 || varRefreshSign == 1)
            {
                cboConnectionState.Text = String.Empty;
                if (cboConnectionState.Items != null)
                {
                    if (cboConnectionState.Items.Count > 0)
                    {
                        cboConnectionState.SelectedValue = _eEditNetFirewallInfo.ConnectionState;
                    }
                }
            }
        }

        private void butReceiveData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnConnectionCancel_Click(object sender, RoutedEventArgs e)
        {
            //-------通信操作日志记录相关变量-------------------
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;
            string stExecState = "";
            string stExecOperationInfo = "";
            int iExecFlag = -1;
            //-------------------------------------------------

            byte[] logoutReq = new byte[2];
            byte[] logoutRet = new byte[3];
            int itSendLength = 0;
            int itReceiveLength = 0;

            logoutReq[0] = 0x01;  // zy 注销发送协议
            logoutReq[1] = 0x02;

            try
            {
                if (_eEditNetFirewallInfo.ExecSocketCommunicate.SocketConnectionStatus() == false)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("网络处于未连接状态！");
                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "注销异常监测设备", "失败", "网络处于未连接状态", ref strErr);

                    return;
                }

                //是否是登录状态
                if (_eEditNetFirewallInfo.IsOrNotLogin == 0)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("用户未登录异常监测设备！");

                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "注销异常监测设备", "失败", "用户未登录异常监测设备", ref strErr);


                    return;
                }

                itSendLength = _eEditNetFirewallInfo.ExecSocketCommunicate.SendData(logoutReq);

                if (itSendLength > 0)
                {
                    itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveData(logoutRet);

                    if (itReceiveLength > 0)
                    {
                        iExecFlag = _eEditNetFirewallInfo.ExecSocketCommunicate.CheckData(logoutRet, itReceiveLength, "logout");

                        if (iExecFlag == 1)
                        {
                            _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                            _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                            JoinLoginStateInfo(0);
                            StateFirewallCommState(1);

                            stDescription = "异常监测设备登录已注销...";
                            ShowErrorMsg(stDescription);

                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "注销异常监测设备", "成功", "异常监测设备登录已注销", ref strErr);

                        }

                        if (iExecFlag == 0)
                        {
                            _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                            _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                            JoinLoginStateInfo(0);
                            StateFirewallCommState(1);

                            stDescription = "异常监测设备未登录...";
                            ShowErrorMsg(stDescription);

                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "注销异常监测设备", "失败", "异常监测设备未登录", ref strErr);

                        }
                    }
                    else
                    {
                        _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                        _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                        JoinLoginStateInfo(0);
                        StateFirewallCommState(1);

                        stDescription = "下位机返回信息错误...";
                        ShowErrorMsg(stDescription);

                        String strErr = String.Empty;
                        CLog.InsertLocalLogRecord(UserID, UserName, "注销异常监测设备", "失败", "下位机返回信息错误", ref strErr);

                    }
                }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);
                StateFirewallCommState(1);

                ShowErrorMsg(ex.Message.ToString());

                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ex.Message.ToString();
                #endregion
            }
            finally
            {

            }
        }




        private void ShowErrorMsg(string strMsg)
        {
            MessageBox.Show(strMsg, "提示信息", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.Cancel);
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cboConnectionState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtFirewallDeviceID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNetFirewallName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNetFirewallID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       

        private void btnRestoreDefaultSettings_Click(object sender, RoutedEventArgs e)
        {
            //-------通信操作日志记录相关变量-------------------
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;
            string stExecState = "";
            string stExecOperationInfo = "";
            int iExecFlag = -1;
            //-------------------------------------------------

            //string lang_FirewallServiceIP = "";

            byte[] restartReq = new byte[2];
            byte[] restartRet = new byte[3];

            int itSendLength = 0;
            int itReceiveLength = 0;

            restartReq[0] = 0x01; //  zy 恢复出厂设置发送协议
            restartReq[1] = 0x04;

            try
            {

                if (_eEditNetFirewallInfo.ExecSocketCommunicate.SocketConnectionStatus() == false)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("网络处于未连接状态！");

                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备恢复出厂设置", "失败", "网络处于未连接状态", ref strErr);

                    return;
                }

                //是否是登录状态
                if (_eEditNetFirewallInfo.IsOrNotLogin == 0)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("用户未登录异常监测设备！");
                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备恢复出厂设置", "失败", "用户未登录异常监测设备", ref strErr);


                    return;
                }

                //判断是否重启 
                if (MessageBox.Show("是否恢复异常监测设备默认值?", "提示信息", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
                {
                    itNotLogRecord = 1;
                    return;
                }

                itSendLength = _eEditNetFirewallInfo.ExecSocketCommunicate.SendData(restartReq);

                if (itSendLength > 0)
                {
                    itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveData(restartRet);

                    if (itReceiveLength > 0)
                    {
                        if (_eEditNetFirewallInfo.ExecSocketCommunicate.CheckData(restartRet, itReceiveLength, "recovery") == 1)
                        {
                            stDescription = "恢复异常监测设备出厂默认设置...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备恢复出厂设置", "成功", "恢复异常监测设备出厂默认设置", ref strErr);

                        }
                        else
                        {
                            stDescription = "异常监测设备未登录...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备恢复出厂设置", "失败", "异常监测设备未登录", ref strErr);

                        }

                        _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                        _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                        JoinLoginStateInfo(0);
                        StateFirewallCommState(1);
                    }
                    else
                    {
                        _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                        _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                        JoinLoginStateInfo(0);
                        StateFirewallCommState(1);

                        stDescription = "下位机返回信息错误...";
                        ShowErrorMsg(stDescription);

                        String strErr = String.Empty;
                        CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备恢复出厂设置", "失败", "下位机返回信息错误", ref strErr);

                    }
                }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);
                StateFirewallCommState(1);

                ShowErrorMsg(ex.Message);

                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ex.Message.ToString();
                #endregion
            }
            finally
            {

            }
        }

    



        public void ModifyNameAndPwd(string oldName, string oldPwd, string newName, string newPwd, ref int varExecFlag, ref string varDescription)
        {
            byte[] langByte = new byte[67];
            int langIndex = 3;
            int itLangSendLength = 0;
            int itLangReceiveLength = 0;

            langByte[0] = 0x01; // zy 修改用户名密码发送协议
            langByte[1] = 0x05;
            langByte[2] = 0x01;

            Encoding.ASCII.GetBytes(oldName, 0, oldName.Length, langByte, langIndex);
            langIndex += 16;
            Encoding.ASCII.GetBytes(oldPwd, 0, oldPwd.Length, langByte, langIndex);
            langIndex += 16;
            Encoding.ASCII.GetBytes(newName, 0, newName.Length, langByte, langIndex);
            langIndex += 16;
            Encoding.ASCII.GetBytes(newPwd, 0, newPwd.Length, langByte, langIndex);
            langIndex += 16;

            byte[] langReceiveBuffer = new byte[3];

            try
            {
                itLangSendLength = _eEditNetFirewallInfo.ExecSocketCommunicate.SendData(langByte);

                if (itLangSendLength > 0)
                {
                    itLangReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveData(langReceiveBuffer);

                    if (itLangReceiveLength > 0)
                    {
                        varExecFlag = _eEditNetFirewallInfo.ExecSocketCommunicate.CheckData(langReceiveBuffer, itLangReceiveLength, "modifyNameAndPwd");

                        if (varExecFlag == 1)
                        {
                            varDescription = "成功修改异常监测设备登录用户名和密码...";
                            ShowErrorMsg(varDescription);
                        }
                        else if (varExecFlag == 0)
                        {
                            varDescription = "已登录系统，但修改异常监测设备登录用户名和密码错误...";
                            ShowErrorMsg(varDescription);
                        }
                        else if (varExecFlag == 2)
                        {
                            _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                            _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                            JoinLoginStateInfo(0);

                            varDescription = "异常监测设备未登录...";
                            ShowErrorMsg(varDescription);
                        }
                        else if (varExecFlag == 3)
                        {
                            varDescription = "已登录系统，但异常监测设备登录用户名和密码错误...";
                            ShowErrorMsg(varDescription);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);

                throw new Exception(ex.Message.ToString());
            }
        }

        private void cboCurrentRunMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

      


        private bool IsOrNotReceiveLogRequest(ref int varExecFlag, ref string varDescription)
        {
            varExecFlag = -1;

            bool bBackSign = false;

            int langIndex = 0;

            byte[] receiveLogRequestReq = new byte[2];
            //byte[] receiveLogRequestReq = new byte[3 + 8 + 6];
            byte[] receiveLogRequestRet = new byte[3];

            int itSendLength = 0;
            int itReceiveLength = 0;

            receiveLogRequestReq[0] = 0x01;
            receiveLogRequestReq[1] = 0x11;
            //receiveLogRequestReq[2] = 0x03;

            langIndex = 3;

            //获取上一次记录的日志记录的最后一条记录的时间
            string stFirewallID = "";

            stFirewallID = _eEditNetFirewallInfo.NetFirewall_ID;

            string stBeforeLogTime = DateTime.Now.ToString("yyyyMMddHHmmss");


            try
            {
                if (getLastRecordFirewallLogTime(stFirewallID, ref stBeforeLogTime))
                {
                    //Encoding.ASCII.GetBytes(stBeforeLogTime, 0, stBeforeLogTime.Length, receiveLogRequestReq, langIndex);
                    //langIndex += 14;

                    itSendLength = _eEditNetFirewallInfo.ExecSocketCommunicate.SendData(receiveLogRequestReq);

                    if (itSendLength > 0)
                    {
                        itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveData(receiveLogRequestRet);

                        if (itReceiveLength > 0)
                        {
                            varExecFlag = _eEditNetFirewallInfo.ExecSocketCommunicate.CheckData(receiveLogRequestRet, itReceiveLength, "receiveLogRequest");

                            if (varExecFlag == 1)
                            {
                                varDescription = "已登录，开启接收日志...";
                                bBackSign = true;
                            }

                            if (varExecFlag == 0)
                            {
                                varDescription = "未登录，不能接收日志...";
                                ShowErrorMsg(varDescription);
                                bBackSign = true;
                            }
                        }
                        else
                        {
                            varDescription = "下位机返回信息错误...";
                            ShowErrorMsg(varDescription);
                            bBackSign = false;
                        }
                    }
                }
                else
                {
                    varDescription = "获取上位机中保存日志信息错误...";
                    ShowErrorMsg(varDescription);
                    bBackSign = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("上位机开启接收日志功能,为获取日志信息,向下位机发送请求错误:" + ex.Message.ToString());
            }

            return bBackSign;
        }

        //选择输入路径或是文件的标志
        private int _tUseFilePathKindSign = 0;
        public int ChooseUseFilePathKindSign
        {
            get { return _tUseFilePathKindSign; }
            set { _tUseFilePathKindSign = value; }
        }
        //选择程序路径
        private string _tFilePathInfo = "";
        public string ChooseHandleFilePathInfo
        {
            get { return _tFilePathInfo; }
            set { _tFilePathInfo = value; }
        }
        private bool getLastRecordFirewallLogTime(string varFirewallID, ref string varBeforeRecordLogTime)
        {
            bool bBackSign = false;

            if (ACDataNetFirewallLogControl.getLastRecordFirewallLogTimeByFirewallID(ref varBeforeRecordLogTime, varFirewallID, _tFilePathInfo, _tUseFilePathKindSign))
            {
                if (varBeforeRecordLogTime.Trim() != String.Empty)
                {
                    bBackSign = true;
                }
            }

            return bBackSign;
        }

        private string GSFirewallID = "";

        public Thread TExecUploadProject = null;







        public bool ReceiveLOGFlag = false; // 接收日志标志
        public bool ReceiveTrafficFlag = false; //接收流量标志

        private void btnGetFirewallLogInfo_Click(object sender, RoutedEventArgs e)
        {
            //-------通信操作日志记录相关变量-------------------
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;
            string stExecState = "";
            string stExecOperationInfo = "";
            int iExecFlag = -1;
            //-------------------------------------------------
            int ReceiveLOG = 0;
            try
            {
                if (!InspectionApproval2())
                {
                    itNotLogRecord = 1;
                    return;
                }

                if (IsOrNotReceiveLogRequest(ref iExecFlag, ref stDescription))
                {
                    if (iExecFlag == 1)
                    {
                        //_eEditNetFirewallInfo.ExecSocketCommunicate.LogSocketConnection_Port = GlobalInfo.GlobalFirewallLogServicePort;

                        //_eEditNetFirewallInfo.ExecSocketCommunicate.CreateLogConnect();

                        //if (_eEditNetFirewallInfo.ExecSocketCommunicate.socket_Con == 1)
                        //{
                            //  GCFirewallLogMessageDeal.SendLogControlCommandMessage(2, GSFirewallID);


                            ReceiveLOGFlag = true;

                            if (SERFlag == -1)
                            {
                                SERFlag = 0;
                            }
                            else if (SERFlag == 1)
                            {
                                SERFlag = 2;
                            }
                            else if (SERFlag == 0)
                            {
                                SERFlag = 0;
                            }
                            else if (SERFlag == 2)
                            {
                                SERFlag = 2;
                            }


                            String strSql = @" UPDATE T_A_SERVER SET SER_FLAG = " + SERFlag;
                            using (DBProvider proxy = new DBProvider())
                            {
                                String strDB = ConfigurationManager.AppSettings["SqlServer"];
                                String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                                proxy.CreateConnection(ref strDB, ref strConn);
                                proxy.SetSqlCmdText(ref strSql);//连接设置成全局的， 连接只连接一次 
                                proxy.ExecuteNotQuery();

                            }

                            stDescription = "开启接收异常监测设备日志...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "开启接收异常监测设备日志", "成功", "开启接收异常监测设备日志", ref strErr);


                            //调试用代码
                            //do
                            //{
                            //    ReceiveLog Rlog = new ReceiveLog();
                            //    Rlog.trUserID = tUserID;
                            //    Rlog.trUserName = tUserName;
                            //    Rlog.trbtnPower = tbtnPower;

                            //    NetEditEntity.EntityNetFirewallInfo etNetFirewallInfo = new NetEditEntity.EntityNetFirewallInfo();
                            //    etNetFirewallInfo.NetFirewall_ID = _eEditNetFirewallInfo.NetFirewall_ID;
                            //    etNetFirewallInfo.NetFirewall_Name = _eEditNetFirewallInfo.NetFirewall_Name;
                            //    etNetFirewallInfo.NetFirewallDevice_ID = _eEditNetFirewallInfo.NetFirewallDevice_ID;
                            //    etNetFirewallInfo.IPAddress = _eEditNetFirewallInfo.IPAddress;
                            //    etNetFirewallInfo.IPAddressSubnetMask = _eEditNetFirewallInfo.IPAddressSubnetMask;
                            //    etNetFirewallInfo.DefaultGateway = _eEditNetFirewallInfo.DefaultGateway;
                            //    etNetFirewallInfo.NetFirewall_DESC = _eEditNetFirewallInfo.NetFirewall_DESC;

                            //    etNetFirewallInfo.ConnectionState = _eEditNetFirewallInfo.ConnectionState;
                            //    etNetFirewallInfo.NetFirewallRunMode = _eEditNetFirewallInfo.NetFirewallRunMode;
                            //    etNetFirewallInfo.IsOrNotLogin = _eEditNetFirewallInfo.IsOrNotLogin;

                            //    etNetFirewallInfo.ExecSocketCommunicate = _eEditNetFirewallInfo.ExecSocketCommunicate;

                            //    Rlog.ChooseNetFirewallInfo = etNetFirewallInfo;
                            //    //Rlog.ChooseProjectID = _tProjectID;

                            //    Rlog.OpenSocketLogReceive();
                            //}
                            //while (ReceiveLOGFlag);


                            //ShowErrorMsg(stDescription);
                        //}
                    }

                    if (iExecFlag == 0)
                    {
                        _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                        _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                        JoinLoginStateInfo(0);
                        StateFirewallCommState(1);

                        stDescription = "开启接收异常监测设备日志错误...";
                        ShowErrorMsg(stDescription);

                        String strErr = String.Empty;
                        CLog.InsertLocalLogRecord(UserID, UserName, "开启接收异常监测设备日志", "失败", "开启接收异常监测设备日志错误", ref strErr);

                    }
                }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);
                StateFirewallCommState(1);

                ShowErrorMsg(ex.Message.ToString());

                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ex.Message.ToString();
                #endregion
            }
            finally
            {

            }
        }
        private bool InspectionApproval2()
        {
            //if (_etEditNetNodeInfo.ENetNodeNetFirewallInfo.ExecSocketCommunicate.socketCon == 0) // ????
            //{
            //    ShowErrorMsg("网络连接异常...");
            //    return false;
            //}

            if (_eEditNetFirewallInfo.ExecSocketCommunicate.SocketConnectionStatus() == false)
            {
                ShowErrorMsg("网络处于未连接状态！");
                return false;
            }

            //是否是登录状态
            if (_eEditNetFirewallInfo.IsOrNotLogin == 0)
            {
                ShowErrorMsg("用户未登录异常监测设备！");
                return false;
            }

            return true;
        }

        private void btnStopGetFirewallLog_Click(object sender, RoutedEventArgs e)
        {
            //-------通信操作日志记录相关变量-------------------
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;
            string stExecState = "";
            string stExecOperationInfo = "";
            //-------------------------------------------------


            try
            {
                if (!InspectionApproval2())
                {
                    itNotLogRecord = 1;
                    return;
                }

                //if (_eEditNetFirewallInfo.ExecSocketCommunicate.LogSocketConnectionStatus() == true)
                //{
                //_eEditNetFirewallInfo.ExecSocketCommunicate.CloseLogClientSocket();
                //_eEditNetFirewallInfo.ExecSocketCommunicate.DisLogConnect();

                //System.Threading.Thread.Sleep(200);

                if (SERFlag == 0)
                {
                    SERFlag = -1;
                }
                else if (SERFlag == 1)
                {
                    SERFlag = 1;
                }
                else if (SERFlag == 2)
                {
                    SERFlag = 1;
                }
                else if (SERFlag == -1)
                {
                    SERFlag = -1;
                }

                String strSql = @" UPDATE T_A_SERVER SET SER_FLAG = " + SERFlag;
                using (DBProvider proxy = new DBProvider())
                {
                    String strDB = ConfigurationManager.AppSettings["SqlServer"];
                    String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                    proxy.CreateConnection(ref strDB, ref strConn);
                    proxy.SetSqlCmdText(ref strSql);//连接设置成全局的， 连接只连接一次 
                    proxy.ExecuteNotQuery();

                }

                //ReceiveLOGFlag = false;

                //String strSql = @" UPDATE T_A_SYSTEMSTATUS SET ReceiveLOGFlag = 0";
                //using (DBProvider proxy = new DBProvider())
                //{
                //    String strDB = ConfigurationManager.AppSettings["SqlServer"];
                //    String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                //    proxy.CreateConnection(ref strDB, ref strConn);
                //    proxy.SetSqlCmdText(ref strSql);//连接设置成全局的， 连接只连接一次 
                //    proxy.ExecuteNotQuery();

                //}
                // GCFirewallLogMessageDeal.SendLogControlCommandMessage(1, GSFirewallID);

                stDescription = "关闭异常监测设备日志接收功能...";
                ShowErrorMsg(stDescription);

                String strErr = String.Empty;
                CLog.InsertLocalLogRecord(UserID, UserName, "关闭异常监测设备日志接收功能", "成功", "关闭异常监测设备日志接收功能", ref strErr);

                //}
                //else
                //{
                //    itNotLogRecord = 1;
                //    return;
                //}
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);
                StateFirewallCommState(1);

                ShowErrorMsg(ex.Message.ToString());

                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ex.Message.ToString();
                #endregion
            }
            finally
            {

            }

        }



        private void OpenSocketLogReceive()
        {

            string Time = "";
            string Type = "";
            string Info = "";
            string Level = "";
            string Src = "";
            string Dst = "";
            string Packet = "";
            string AlarmRC = "";
            if (OpenSingleSocketLogReceive(ref AlarmRC) == true)
            {

                string[] Alarm = AlarmRC.Split(new string[] { "<Time>", "</Time>", "<type>", "</type>", "<info>", "</info>", "<level>", "</level>", "<src>", "</src>", "<dst>", "</dst>", "<packet>", "</packet>" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string e in Alarm) ;

                Time = Alarm[1];
                Type = Alarm[3];
                Info = Alarm[5];
                Level = Alarm[7];
                Src = Alarm[9];
                Dst = Alarm[11];
                Packet = Alarm[13];

                Array.Clear(Alarm, 0, Alarm.Length);

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

        private bool OpenSingleSocketLogReceive(ref string AlarmReceive)
        {

            byte[] receiveLogData = new byte[500];
            int itReceiveLength = 0;
            string AlarmReceive1 = "";
            string ReceiveLogDataHead = "<alarm>";
            string ReceiveLogDataTail = "<alarm>";
            try
            {
                itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveLogData(receiveLogData);

                if ((itReceiveLength > 0))
                {

                    //AlarmReceive = System.Text.Encoding.Default.GetString(receiveLogData);
                    // R1 = Encoding.ASCII.GetString(byteComReceiveBuffer, 0, iComReceiveCount).Trim('\0');
                    AlarmReceive1 = Encoding.ASCII.GetString(receiveLogData, 0, itReceiveLength).Trim('\0');

                    if (AlarmReceive1.Contains(ReceiveLogDataHead))
                    {
                        if (AlarmReceive1.Contains(ReceiveLogDataTail))
                        {
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
                MessageBox.Show(ex.Message);
                return false;
            }

            // return true;
        }


        private bool IsOrNotReceiveTrafficRequest(ref int varExecFlag, ref string varDescription)
        {
            varExecFlag = -1;

            bool bBackSign = false;

            int langIndex = 0;

            byte[] receiveTrafficRequestReq = new byte[2];
            //byte[] receiveLogRequestReq = new byte[3 + 8 + 6];
            byte[] receiveTrafficRequestRet = new byte[3];

            int itSendLength = 0;
            int itReceiveLength = 0;

            receiveTrafficRequestReq[0] = 0x01;
            receiveTrafficRequestReq[1] = 0x12;
            //receiveLogRequestReq[2] = 0x03;

            langIndex = 3;

            //获取上一次记录的日志记录的最后一条记录的时间
            string stFirewallID = "";

            stFirewallID = _eEditNetFirewallInfo.NetFirewall_ID;

            string stBeforeLogTime = DateTime.Now.ToString("yyyyMMddHHmmss");


            try
            {
                if (getLastRecordFirewallLogTime(stFirewallID, ref stBeforeLogTime))
                {
                    //Encoding.ASCII.GetBytes(stBeforeLogTime, 0, stBeforeLogTime.Length, receiveLogRequestReq, langIndex);
                    //langIndex += 14;

                    itSendLength = _eEditNetFirewallInfo.ExecSocketCommunicate.SendData(receiveTrafficRequestReq);

                    if (itSendLength > 0)
                    {
                        itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveData(receiveTrafficRequestRet);

                        if (itReceiveLength > 0)
                        {
                            varExecFlag = _eEditNetFirewallInfo.ExecSocketCommunicate.CheckData(receiveTrafficRequestRet, itReceiveLength, "receiveTrafficRequest");

                            if (varExecFlag == 1)
                            {
                                varDescription = "已登录，开启接收流量数据...";
                                bBackSign = true;
                            }

                            if (varExecFlag == 0)
                            {
                                varDescription = "未登录，不能接收流量数据...";
                                ShowErrorMsg(varDescription);
                                bBackSign = true;
                            }
                        }
                        else
                        {
                            varDescription = "下位机返回信息错误...";
                            ShowErrorMsg(varDescription);
                            bBackSign = false;
                        }
                    }
                }
                else
                {
                    varDescription = "获取上位机中保存流量信息错误...";
                    ShowErrorMsg(varDescription);
                    bBackSign = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("上位机开启接收流量数据功能,为获取流量信息,向下位机发送请求错误:" + ex.Message.ToString());
            }

            return bBackSign;
        }

        private void btnGetFirewalTrafficInfo_Click(object sender, RoutedEventArgs e)
        {
            //-------通信操作日志记录相关变量-------------------
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;
            string stExecState = "";
            string stExecOperationInfo = "";
            int iExecFlag = -1;
            //-------------------------------------------------

            try
            {
                if (!InspectionApproval2())
                {
                    itNotLogRecord = 1;
                    return;
                }

                if (IsOrNotReceiveTrafficRequest(ref iExecFlag, ref stDescription))
                {
                    if (iExecFlag == 1)
                    {
                       // _eEditNetFirewallInfo.ExecSocketCommunicate.TrafficSocketConnection_Port = GlobalInfo.GlobalFirewallTrafficServicePort;

                       // _eEditNetFirewallInfo.ExecSocketCommunicate.CreateTrafficConnect();

                       // if (_eEditNetFirewallInfo.ExecSocketCommunicate.socket_Con == 1)
                       // {
                            // GCFirewallTrafficMessageDeal.SendTrafficControlCommandMessage(2, GSFirewallID);



                            if (SERFlag == -1)
                            {
                                SERFlag = 1;
                            }
                            else if (SERFlag == 0)
                            {
                                SERFlag = 2;
                            }
                            else if (SERFlag == 1)
                            {
                                SERFlag = 1;
                            }
                            else if (SERFlag == 2)
                            {
                                SERFlag = 2;
                            }

                            String strSql = @" UPDATE T_A_SERVER SET SER_FLAG = " + SERFlag;
                            using (DBProvider proxy = new DBProvider())
                            {
                                String strDB = ConfigurationManager.AppSettings["SqlServer"];
                                String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                                proxy.CreateConnection(ref strDB, ref strConn);
                                proxy.SetSqlCmdText(ref strSql);//连接设置成全局的， 连接只连接一次 
                                proxy.ExecuteNotQuery();

                            }

                            stDescription = "开启接收流量数据...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "开启接收流量数据", "成功", "开启接收流量数据", ref strErr);


                            ReceiveTrafficFlag = true;

                            //String strSql = @" UPDATE T_A_SYSTEMSTATUS SET ReceiveTrafficFlag = 1";
                            //using (DBProvider proxy = new DBProvider())
                            //{
                            //    String strDB = ConfigurationManager.AppSettings["SqlServer"];
                            //    String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                            //    proxy.CreateConnection(ref strDB, ref strConn);
                            //    proxy.SetSqlCmdText(ref strSql);//连接设置成全局的， 连接只连接一次 
                            //    proxy.ExecuteNotQuery();
                            //}

                            ////调试用代码
                            //do
                            //{
                            //    ReceiveTraffic RTraffic = new ReceiveTraffic();
                            //    RTraffic.trUserID = tUserID;
                            //    RTraffic.trUserName = tUserName;
                            //    RTraffic.trbtnPower = tbtnPower;
                            //    frm.ChooseUseFilePathKindSign = _tUseFilePathKindSign;
                            //    frm.ChooseHandleFilePathInfo = _tFilePathInfo;
                            //    frm.lvwTempLocalLog = lvwTempLocalLog;

                            //    NetEditEntity.EntityNetFirewallInfo etNetFirewallInfo = new NetEditEntity.EntityNetFirewallInfo();
                            //    etNetFirewallInfo.NetFirewall_ID = _eEditNetFirewallInfo.NetFirewall_ID;
                            //    etNetFirewallInfo.NetFirewall_Name = _eEditNetFirewallInfo.NetFirewall_Name;
                            //    etNetFirewallInfo.NetFirewallDevice_ID = _eEditNetFirewallInfo.NetFirewallDevice_ID;
                            //    etNetFirewallInfo.IPAddress = _eEditNetFirewallInfo.IPAddress;
                            //    etNetFirewallInfo.IPAddressSubnetMask = _eEditNetFirewallInfo.IPAddressSubnetMask;
                            //    etNetFirewallInfo.DefaultGateway = _eEditNetFirewallInfo.DefaultGateway;
                            //    etNetFirewallInfo.NetFirewall_DESC = _eEditNetFirewallInfo.NetFirewall_DESC;

                            //    etNetFirewallInfo.ConnectionState = _eEditNetFirewallInfo.ConnectionState;
                            //    etNetFirewallInfo.NetFirewallRunMode = _eEditNetFirewallInfo.NetFirewallRunMode;
                            //    etNetFirewallInfo.IsOrNotLogin = _eEditNetFirewallInfo.IsOrNotLogin;

                            //    etNetFirewallInfo.ExecSocketCommunicate = _eEditNetFirewallInfo.ExecSocketCommunicate;

                            //    RTraffic.ChooseNetFirewallInfo = etNetFirewallInfo;
                            //    Rlog.ChooseProjectID = _tProjectID;


                            //    RTraffic.OpenSocketTrafficReceive();
                            //}
                            //while (ReceiveTrafficFlag);


                            //ShowErrorMsg(stDescription);
                        //}
                    }

                    if (iExecFlag == 0)
                    {
                        _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                        _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                        JoinLoginStateInfo(0);
                        StateFirewallCommState(1);

                        stDescription = "开启接收流量数据错误...";
                        ShowErrorMsg(stDescription);
                        String strErr = String.Empty;
                        CLog.InsertLocalLogRecord(UserID, UserName, "开启接收流量数据", "失败", "开启接收流量数据错误", ref strErr);

                    }
                }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);
                StateFirewallCommState(1);

                ShowErrorMsg(ex.Message.ToString());

                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ex.Message.ToString();
                #endregion
            }
            finally
            {

            }

        }

        private void btnStopGetTrafficInfo_Click(object sender, RoutedEventArgs e)
        {
            //-------通信操作日志记录相关变量-------------------
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotTrafficRecord = 0;
            string stExecState = "";
            string stExecOperationInfo = "";
            //-------------------------------------------------


            try
            {
                if (!InspectionApproval2())
                {
                    itNotTrafficRecord = 1;
                    return;
                }

                //if (_eEditNetFirewallInfo.ExecSocketCommunicate.TrafficSocketConnectionStatus() == true) //
                //{
                // _eEditNetFirewallInfo.ExecSocketCommunicate.CloseTrafficClientSocket();
                // _eEditNetFirewallInfo.ExecSocketCommunicate.DisTrafficConnect();

                // System.Threading.Thread.Sleep(200);


                if (SERFlag == -1)
                {
                    SERFlag = -1;
                }
                else if (SERFlag == 0)
                {
                    SERFlag = 0;
                }
                else if (SERFlag == 1)
                {
                    SERFlag = -1;
                }
                else if (SERFlag == 2)
                {
                    SERFlag = 0;
                }

                String strSql = @" UPDATE T_A_SERVER SET SER_FLAG = " + SERFlag;
                using (DBProvider proxy = new DBProvider())
                {
                    String strDB = ConfigurationManager.AppSettings["SqlServer"];
                    String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                    proxy.CreateConnection(ref strDB, ref strConn);
                    proxy.SetSqlCmdText(ref strSql);//连接设置成全局的， 连接只连接一次 
                    proxy.ExecuteNotQuery();

                }

                //GCFirewallTrafficMessageDeal.SendTrafficControlCommandMessage(1, GSFirewallID);

                //ReceiveTrafficFlag = false;

                //String strSql = @" UPDATE T_A_SYSTEMSTATUS SET ReceiveTrafficFlag = 0";
                //using (DBProvider proxy = new DBProvider())
                //{
                //    String strDB = ConfigurationManager.AppSettings["SqlServer"];
                //    String strConn = ConfigurationManager.AppSettings["SqlConnection"];

                //    proxy.CreateConnection(ref strDB, ref strConn);
                //    proxy.SetSqlCmdText(ref strSql);//连接设置成全局的， 连接只连接一次 
                //    proxy.ExecuteNotQuery();
                //}

                stDescription = "关闭流量数据接收功能...";
                ShowErrorMsg(stDescription);
                String strErr = String.Empty;
                CLog.InsertLocalLogRecord(UserID, UserName, "关闭流量数据接收功能", "成功", "关闭流量数据接收功能", ref strErr);

                // }
                //else
                //{
                //  itNotTrafficRecord = 1;
                //  return;
                // }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);
                StateFirewallCommState(1);

                ShowErrorMsg(ex.Message.ToString());

                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ex.Message.ToString();
                #endregion
            }
            finally
            {

            }

        }

        private void OpenSocketTrafficReceive()
        {

            string TrafficName1 = "";
            string Address1 = "";
            decimal Inst_Traffic1;
            decimal Accum_Traffic1;
            decimal Avg_Size1;
            string Packets1 = "";
            string Last_Heard1 = "";

            string TrafficName2 = "";
            string Address2 = "";
            string Inst_Traffic2 = "";
            string Accum_Traffic2 = "";
            string Avg_Size2 = "";
            string Packets2 = "";
            string Last_Heard2 = "";

            string TrafficRC = "";
            if (OpenSingleSocketTrafficReceive(ref TrafficRC) == true)
            {

                string[] Traffic = TrafficRC.Split(new string[] { "<traffic name=\"", "\">", "<Address>", "</Address>", "<Inst_Traffic>", " bps</Inst_Traffic>", "<Accum_Traffic>", " Kbytes</Accum_Traffic>", "<Avg_Size>", " bytes</Avg_Size>", "<Packets>", "</Packets>", "<Last_Heard>", "</Last_Heard>" }, StringSplitOptions.RemoveEmptyEntries);
                //foreach (string a in Traffic) ;

                TrafficName1 = Traffic[1];
                Address1 = Traffic[3];
                Inst_Traffic1 = decimal.Parse(Traffic[5]);
                Accum_Traffic1 = decimal.Parse(Traffic[7]);
                Avg_Size1 = decimal.Parse(Traffic[9]);
                Packets1 = Traffic[11];
                Last_Heard1 = Traffic[13];

                //TrafficName2 = Traffic[15];
                //Address2 = Traffic[17];
                //Inst_Traffic2 = Traffic[19];
                //Accum_Traffic2 = Traffic[21];
                //Avg_Size2 = Traffic[23];
                //Packets2 = Traffic[25];
                //Last_Heard2 = Traffic[27];


                Array.Clear(Traffic, 0, Traffic.Length);


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

        private bool OpenSingleSocketTrafficReceive(ref string TrafficReceive)
        {

            byte[] receiveTrafficData = new byte[1000];
            int itReceiveLength = 0;
            string TrafficRC1 = "";
            string ReceiveDataHead = "<etherape>";
            string ReceiveDataTail = "</etherape>";
            try
            {
                itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveTrafficData(receiveTrafficData);

                if ((itReceiveLength > 0))
                {
                    //AlarmReceive = System.Text.Encoding.Default.GetString(receiveLogData);
                    // R1 = Encoding.ASCII.GetString(byteComReceiveBuffer, 0, iComReceiveCount).Trim('\0');
                    TrafficRC1 = Encoding.ASCII.GetString(receiveTrafficData, 0, itReceiveLength).Trim('\0');


                    if (TrafficRC1.Contains(ReceiveDataHead))
                    {
                        if (TrafficRC1.Contains(ReceiveDataTail))
                        {
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
                MessageBox.Show(ex.Message);
                return false;
            }

            // return true;
        }

        public static string RulePath = "";
        private void btnRuleChooseSet_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\Administrator\Desktop";
            ofd.Title = "请选择要发送的规则";
            ofd.Filter = "(*.ini)|*.ini";
            ofd.ShowDialog();
            RulePath = ofd.FileName;
        }

        private void btnRuleSet_Click(object sender, RoutedEventArgs e)
        {

            //-------通信操作日志记录相关变量-------------------
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;
            string stExecState = "";
            string stExecOperationInfo = "";
            int iExecFlag = -1;
            //-------------------------------------------------

            int RuleFileLength;

            try
            {
                using (FileStream fsRead = new FileStream(RulePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[1024 * 1024 * 5];
                    RuleFileLength = fsRead.Read(buffer, 0, buffer.Length);
                }

                SendRuleFile(RuleFileLength, ref iExecFlag, ref stDescription);
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);
                StateFirewallCommState(1);

                ShowErrorMsg(ex.Message);

                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ex.Message.ToString();
                #endregion
            }
            finally
            {
            }
        }

        private const int BufferSize = 4096;
        private void SendRuleFile(int varRuleFileLength, ref int varExecFlag, ref string varDescription)
        {
            byte[] SendRuleReq = new byte[7];
            byte[] SendRuleRet = new byte[3];

            byte[] file = new byte[BufferSize];
            int itSendLength = 0;
            int itReceiveLength = 0;

            SendRuleReq[0] = 0x01;
            SendRuleReq[1] = 0x10;
            SendRuleReq[2] = 0x04;
            Array.Copy(BitConverter.GetBytes(varRuleFileLength), 0, SendRuleReq, 3, 4);
            try
            {



                itSendLength = _eEditNetFirewallInfo.ExecSocketCommunicate.SendData(SendRuleReq);

                if (itSendLength > 0)
                {
                    itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveData(SendRuleRet);

                    if (itReceiveLength > 0)
                    {
                        varExecFlag = _eEditNetFirewallInfo.ExecSocketCommunicate.CheckData(SendRuleRet, itReceiveLength, "SendRuleRet");

                        if (varExecFlag == 1)
                        {
                            NetworkStream netStream = null;
                            netStream = _eEditNetFirewallInfo.ExecSocketCommunicate.GetNetworkStream();


                            FileStream fs1 = new FileStream(RulePath, FileMode.Open, FileAccess.Read);
                            int bytesRead1;
                            int totalBytes1 = 0;

                            do
                            {
                                bytesRead1 = fs1.Read(file, 0, file.Length);
                                netStream.Write(file, 0, bytesRead1);
                                totalBytes1 += bytesRead1;

                            } while (bytesRead1 > 0);

                            varDescription = "同步规则";
                            ShowErrorMsg(varDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备规则同步", "成功", "同步规则", ref strErr);

                        }
                        else if (varExecFlag == 0)
                        {
                            varDescription = "异常监测设备未登录...";
                            ShowErrorMsg(varDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备规则同步", "失败", "异常监测设备未登录", ref strErr);


                            _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                            _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                            JoinLoginStateInfo(0);
                        }


                    }
                    else
                    {
                        _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                        _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                        JoinLoginStateInfo(0);

                        varDescription = "下位机返回信息错误...";
                        ShowErrorMsg(varDescription);
                        String strErr = String.Empty;
                        CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备规则同步", "失败", "下位机返回信息错误", ref strErr);

                    }
                }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);

                throw new Exception(ex.Message.ToString());
            }

        }


        private string _tProjectID = "";
        public string ChooseProjectID
        {
            get { return _tProjectID; }
            set { _tProjectID = value; }
        }

      
              

        private void btnTrafficOn_Click(object sender, RoutedEventArgs e)
        {
            //-------通信操作日志记录相关变量-------------------
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;
            string stExecState = "";
            string stExecOperationInfo = "";
            int iExecFlag = -1;
            //-------------------------------------------------


            //---------------------------------------------------------
            byte[] TrafficOnReq = new byte[3];
            byte[] TrafficOnRet = new byte[3];


            int itSendLength = 0;
            int itReceiveLength = 0;

            TrafficOnReq[0] = 0x01;
            TrafficOnReq[1] = 0x21;
            TrafficOnReq[2] = 0x01;


            try
            {

                if (_eEditNetFirewallInfo.ExecSocketCommunicate.SocketConnectionStatus() == false)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("网络处于未连接状态！");
                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备启动流量", "失败", "网络处于未连接状态", ref strErr);

                    return;
                }

                //是否是登录状态
                if (_eEditNetFirewallInfo.IsOrNotLogin == 0)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("用户未登录异常监测设备！");
                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备启动流量", "失败", "用户未登录异常监测设备", ref strErr);

                    return;
                }

                itSendLength = _eEditNetFirewallInfo.ExecSocketCommunicate.SendData(TrafficOnReq);

                if (itSendLength > 0) // 暂无返回值
                {
                    itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveData(TrafficOnRet);// 暂无返回值

                    if (itReceiveLength > 0)// 暂无返回值
                    {
                        iExecFlag = _eEditNetFirewallInfo.ExecSocketCommunicate.CheckData(TrafficOnRet, itReceiveLength, "run");

                        if (iExecFlag == 1)
                        {
                            stDescription = "操作成功...";
                            ShowErrorMsg(stDescription);

                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备启动流量", "成功", "异常监测设备启动流量成功", ref strErr);

                        }
                        else if (iExecFlag == 0)
                        {
                            stDescription = "启动流量没成功...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备启动流量", "失败", "启动流量没成功", ref strErr);

                        }
                    }
                    else
                    {
                        _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                        _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                        JoinLoginStateInfo(0);
                        StateFirewallCommState(1);

                        stDescription = "下位机返回信息错误...";
                        ShowErrorMsg(stDescription);
                        String strErr = String.Empty;
                        CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备启动流量", "失败", "下位机返回信息错误", ref strErr);

                    }
                }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);
                StateFirewallCommState(1);

                ShowErrorMsg(ex.Message.ToString());

                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ex.Message.ToString();
                #endregion
            }
            finally
            {

            }
        }

        private void btnTrafficOff_Click(object sender, RoutedEventArgs e)
        {
            //-------通信操作日志记录相关变量-------------------
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;
            string stExecState = "";
            string stExecOperationInfo = "";
            int iExecFlag = -1;
            //-------------------------------------------------


            //---------------------------------------------------------
            byte[] TrafficOffReq = new byte[3];
            byte[] TrafficOffRet = new byte[3];


            int itSendLength = 0;
            int itReceiveLength = 0;

            TrafficOffReq[0] = 0x01;
            TrafficOffReq[1] = 0x21;
            TrafficOffReq[2] = 0x04;


            try
            {

                if (_eEditNetFirewallInfo.ExecSocketCommunicate.SocketConnectionStatus() == false)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("网络处于未连接状态！");
                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭流量", "失败", "网络处于未连接状态", ref strErr);

                    return;
                }

                //是否是登录状态
                if (_eEditNetFirewallInfo.IsOrNotLogin == 0)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("用户未登录异常监测设备！");
                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭流量", "失败", "用户未登录异常监测设备", ref strErr);

                    return;
                }

                itSendLength = _eEditNetFirewallInfo.ExecSocketCommunicate.SendData(TrafficOffReq);

                if (itSendLength > 0) // 暂无返回值
                {
                    itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveData(TrafficOffRet);// 暂无返回值

                    if (itReceiveLength > 0)// 暂无返回值
                    {
                        iExecFlag = _eEditNetFirewallInfo.ExecSocketCommunicate.CheckData(TrafficOffRet, itReceiveLength, "run");

                        if (iExecFlag == 1)
                        {
                            stDescription = "操作成功...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭流量", "成功", "异常监测设备关闭流量成功", ref strErr);

                        }
                                                else if (iExecFlag == 0)
                        {
                            stDescription = "关闭流量没成功...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭流量", "失败", "关闭流量没成功", ref strErr);

                        }
                    }
                    else
                    {
                        _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                        _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                        JoinLoginStateInfo(0);
                        StateFirewallCommState(1);

                        stDescription = "下位机返回信息错误...";
                        ShowErrorMsg(stDescription);
                        String strErr = String.Empty;
                        CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭流量", "失败", "下位机返回信息错误", ref strErr);

                    }
                }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);
                StateFirewallCommState(1);

                ShowErrorMsg(ex.Message.ToString());

                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ex.Message.ToString();
                #endregion
            }
            finally
            {

            }
        }

        private void btnLogOn_Click(object sender, RoutedEventArgs e)
        {
            //-------通信操作日志记录相关变量-------------------
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;
            string stExecState = "";
            string stExecOperationInfo = "";
            int iExecFlag = -1;
            //-------------------------------------------------


            //---------------------------------------------------------
            byte[] LogOnReq = new byte[3];
            byte[] LogOnRet = new byte[3];


            int itSendLength = 0;
            int itReceiveLength = 0;

            LogOnReq[0] = 0x01;
            LogOnReq[1] = 0x21;
            LogOnReq[2] = 0x02;


            try
            {

                if (_eEditNetFirewallInfo.ExecSocketCommunicate.SocketConnectionStatus() == false)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("网络处于未连接状态！");
                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备启动异常监测", "失败", "网络处于未连接状态", ref strErr);

                    return;
                }

                //是否是登录状态
                if (_eEditNetFirewallInfo.IsOrNotLogin == 0)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("用户未登录异常监测设备！");
                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备启动异常监测", "失败", "用户未登录异常监测设备", ref strErr);

                    return;
                }

                itSendLength = _eEditNetFirewallInfo.ExecSocketCommunicate.SendData(LogOnReq);

                if (itSendLength > 0) // 暂无返回值
                {
                    itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveData(LogOnRet);// 暂无返回值

                    if (itReceiveLength > 0)// 暂无返回值
                    {
                        iExecFlag = _eEditNetFirewallInfo.ExecSocketCommunicate.CheckData(LogOnRet, itReceiveLength, "run");

                        if (iExecFlag == 1)
                        {
                            stDescription = "操作成功...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备启动异常监测", "成功", "异常监测设备启动异常监测成功", ref strErr);

                        }
                        
                        else if (iExecFlag == 0)
                        {
                            stDescription = "启动异常没成功...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备启动异常监测", "失败", "启动异常没成功", ref strErr);

                        }
                    }
                    else
                    {
                        _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                        _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                        JoinLoginStateInfo(0);
                        StateFirewallCommState(1);

                        stDescription = "下位机返回信息错误...";
                        ShowErrorMsg(stDescription);
                        String strErr = String.Empty;
                        CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备启动异常监测", "失败", "下位机返回信息错误", ref strErr);

                    }
                }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);
                StateFirewallCommState(1);

                ShowErrorMsg(ex.Message.ToString());

                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ex.Message.ToString();
                #endregion
            }
            finally
            {

            }
        }

        private void btnLogOff_Click(object sender, RoutedEventArgs e)
        {
            //-------通信操作日志记录相关变量-------------------
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;
            string stExecState = "";
            string stExecOperationInfo = "";
            int iExecFlag = -1;
            //-------------------------------------------------


            //---------------------------------------------------------
            byte[] LogOffReq = new byte[3];
            byte[] LogOffRet = new byte[3];


            int itSendLength = 0;
            int itReceiveLength = 0;

            LogOffReq[0] = 0x01;
            LogOffReq[1] = 0x21;
            LogOffReq[2] = 0x05;


            try
            {

                if (_eEditNetFirewallInfo.ExecSocketCommunicate.SocketConnectionStatus() == false)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("网络处于未连接状态！");
                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭异常监测", "失败", "网络处于未连接状态", ref strErr);

                    return;
                }

                //是否是登录状态
                if (_eEditNetFirewallInfo.IsOrNotLogin == 0)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("用户未登录异常监测设备！");
                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭异常监测", "失败", "用户未登录异常监测设备", ref strErr);

                    return;
                }

                itSendLength = _eEditNetFirewallInfo.ExecSocketCommunicate.SendData(LogOffReq);

                if (itSendLength > 0) // 暂无返回值
                {
                    itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveData(LogOffRet);// 暂无返回值

                    if (itReceiveLength > 0)// 暂无返回值
                    {
                        iExecFlag = _eEditNetFirewallInfo.ExecSocketCommunicate.CheckData(LogOffRet, itReceiveLength, "run");

                        if (iExecFlag == 1)
                        {
                            stDescription = "操作成功...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭异常监测", "成功", "异常监测设备关闭异常监测成功", ref strErr);

                        }
                        
                        else if (iExecFlag == 0)
                        {
                            stDescription = "关闭异常没成功...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭异常监测", "失败", "关闭异常没成功", ref strErr);

                        }
                    }
                    else
                    {
                        _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                        _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                        JoinLoginStateInfo(0);
                        StateFirewallCommState(1);

                        stDescription = "下位机返回信息错误...";
                        ShowErrorMsg(stDescription);
                        String strErr = String.Empty;
                        CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭异常监测", "失败", "下位机返回信息错误", ref strErr);

                    }
                }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);
                StateFirewallCommState(1);

                ShowErrorMsg(ex.Message.ToString());

                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ex.Message.ToString();
                #endregion
            }
            finally
            {

            }
        }

        private void btnTestOn_Click(object sender, RoutedEventArgs e)
        {
            //-------通信操作日志记录相关变量-------------------
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;
            string stExecState = "";
            string stExecOperationInfo = "";
            int iExecFlag = -1;
            //-------------------------------------------------


            //---------------------------------------------------------
            byte[] TestOnReq = new byte[3];
            byte[] TestOnRet = new byte[3];


            int itSendLength = 0;
            int itReceiveLength = 0;

            TestOnReq[0] = 0x01;
            TestOnReq[1] = 0x21;
            TestOnReq[2] = 0x03;


            try
            {

                if (_eEditNetFirewallInfo.ExecSocketCommunicate.SocketConnectionStatus() == false)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("网络处于未连接状态！");
                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备开启训练模式", "失败", "网络处于未连接状态", ref strErr);

                    return;
                }

                //是否是登录状态
                if (_eEditNetFirewallInfo.IsOrNotLogin == 0)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("用户未登录异常监测设备！");
                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备开启训练模式", "失败", "用户未登录异常监测设备", ref strErr);

                    return;
                }

                itSendLength = _eEditNetFirewallInfo.ExecSocketCommunicate.SendData(TestOnReq);

                if (itSendLength > 0) // 暂无返回值
                {
                    itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveData(TestOnRet);// 暂无返回值

                    if (itReceiveLength > 0)// 暂无返回值
                    {
                        iExecFlag = _eEditNetFirewallInfo.ExecSocketCommunicate.CheckData(TestOnRet, itReceiveLength, "run");

                        if (iExecFlag == 1)
                        {
                            stDescription = "操作成功...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备开启训练模式", "成功", "异常监测设备开启训练模式成功", ref strErr);

                        }
                        
                        else if (iExecFlag == 0)
                        {
                            stDescription = "开启训练模式没成功...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备开启训练模式", "失败", "开启训练模式没成功", ref strErr);

                        }
                    }
                    else
                    {
                        _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                        _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                        JoinLoginStateInfo(0);
                        StateFirewallCommState(1);

                        stDescription = "下位机返回信息错误...";
                        ShowErrorMsg(stDescription);
                        String strErr = String.Empty;
                        CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备开启训练模式", "失败", "下位机返回信息错误", ref strErr);

                    }
                }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);
                StateFirewallCommState(1);

                ShowErrorMsg(ex.Message.ToString());

                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ex.Message.ToString();
                #endregion
            }
            finally
            {

            }
        }

        private void btnTestOff_Click(object sender, RoutedEventArgs e)
        {
            //-------通信操作日志记录相关变量-------------------
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;
            string stExecState = "";
            string stExecOperationInfo = "";
            int iExecFlag = -1;
            //-------------------------------------------------


            //---------------------------------------------------------
            byte[] TestOffReq = new byte[3];
            byte[] TestOffRet = new byte[3];


            int itSendLength = 0;
            int itReceiveLength = 0;

            TestOffReq[0] = 0x01;
            TestOffReq[1] = 0x21;
            TestOffReq[2] = 0x03;


            try
            {

                if (_eEditNetFirewallInfo.ExecSocketCommunicate.SocketConnectionStatus() == false)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("网络处于未连接状态！");
                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭训练模式", "失败", "网络处于未连接状态", ref strErr);

                    return;
                }

                //是否是登录状态
                if (_eEditNetFirewallInfo.IsOrNotLogin == 0)
                {
                    itNotLogRecord = 1;
                    ShowErrorMsg("用户未登录异常监测设备！");
                    String strErr = String.Empty;
                    CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭训练模式", "失败", "用户未登录异常监测设备", ref strErr);

                    return;
                }

                itSendLength = _eEditNetFirewallInfo.ExecSocketCommunicate.SendData(TestOffReq);

                if (itSendLength > 0) // 暂无返回值
                {
                    itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveData(TestOffRet);// 暂无返回值

                    if (itReceiveLength > 0)// 暂无返回值
                    {
                        iExecFlag = _eEditNetFirewallInfo.ExecSocketCommunicate.CheckData(TestOffRet, itReceiveLength, "run");

                        if (iExecFlag == 1)
                        {
                            stDescription = "操作成功...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭训练模式", "成功", "异常监测设备关闭训练模式成功", ref strErr);

                        }
                        
                        else if (iExecFlag == 0)
                        {
                            stDescription = "关闭训练模式没成功...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭训练模式", "失败", "关闭训练模式没成功", ref strErr);

                        }
                    }
                    else
                    {
                        _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                        _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                        JoinLoginStateInfo(0);
                        StateFirewallCommState(1);

                        stDescription = "下位机返回信息错误...";
                        ShowErrorMsg(stDescription);
                        String strErr = String.Empty;
                        CLog.InsertLocalLogRecord(UserID, UserName, "异常监测设备关闭训练模式", "失败", "下位机返回信息错误", ref strErr);

                    }
                }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);
                StateFirewallCommState(1);

                ShowErrorMsg(ex.Message.ToString());

                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ex.Message.ToString();
                #endregion
            }
            finally
            {

            }
        }









    }

}

