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
using System.Windows.Shapes;
using System.Data;
using socketTest.Common;
using System.Configuration;
using Log4Net;

namespace socketTest
{
    /// <summary>
    /// FNetEquipManager.xaml 的交互逻辑
    /// </summary>
    public partial class FNetEquipManager : Window
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
                        btnSave.Visibility = Visibility.Visible;
                        ShowObjectIsHitTestVisible(1);
                    }
                    else
                    {
                        btnSave.Visibility = Visibility.Hidden;
                        ShowObjectIsHitTestVisible(0);
                    }
                    numbtn += 1;

                    if (btnPower[1].ToString().Trim() == "1" && numbtn < btnCount)
                    {
                        btnSave.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        btnSave.Visibility = Visibility.Hidden;
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
                txtNetEquipName.IsHitTestVisible = true;
                txtNetEquipTypeName.IsHitTestVisible = true;
                txtMaskedIPAddress.IsHitTestVisible = true;
                txtMaskedMACAddress.IsHitTestVisible = true;
                txtEquipDescInfo.IsHitTestVisible = true;
                btnGetMacAddress.IsHitTestVisible = true;
            }

            if (varShowSign == 0)
            {
                txtNetEquipName.IsHitTestVisible = false;
                txtNetEquipTypeName.IsHitTestVisible = false;
                txtMaskedIPAddress.IsHitTestVisible = false;
                txtMaskedMACAddress.IsHitTestVisible = false;
                txtEquipDescInfo.IsHitTestVisible = false;
                btnGetMacAddress.IsHitTestVisible = false;
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

        //传输数据的实体类
        CPublicControl.CIntiDataTable ACIntiDataTable = new CPublicControl.CIntiDataTable();
        CPublicControl.CPublicMethod ACPublicMethod = new CPublicControl.CPublicMethod();
        CData.CDataNetFirewallLogControl ACDataNetFirewallLogControl = new CData.CDataNetFirewallLogControl();

        private NetEditEntity.EntityNetFirewallInfo _eEditNetFirewallInfo;
        public NetEditEntity.EntityNetFirewallInfo ChooseNetFirewallInfo
        {
            get { return _eEditNetFirewallInfo; }
            set { _eEditNetFirewallInfo = value; }
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

        public ListView lvwTempLocalLog;

        public FNetEquipManager()
        {
            InitializeComponent();

            _eEditNetFirewallInfo = new NetEditEntity.EntityNetFirewallInfo();
        }

        public void Initialize()
        {
            //权限控制
            getbtnPower();

            //清除原有信息
            ClearAll();

            //加载传入信息
            fullSingleNetNodeInfo();

            txtNetEquipName.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void fullSingleNetNodeInfo()
        {
            if (!String.IsNullOrEmpty(EquipID))
            {
                txtNetEquipID.Text = EquipID;
                txtNetEquipName.Text = EquipName;




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

                            if (!(item["EQUIP_MAC"] is DBNull))
                            {
                                txtMaskedMACAddress.setMACAddress(Convert.ToString(item["EQUIP_MAC"]).Trim());
                            }

                            if (!(item["EQUIP_DES"] is DBNull))
                            {
                                txtEquipDescInfo.Text = Convert.ToString(item["EQUIP_DES"]).Trim();
                            }

                            if (!(item["EQUIP_TYPE_DESC"] is DBNull))
                            {
                                txtNetEquipTypeName.Text = Convert.ToString(item["EQUIP_TYPE_DESC"]).Trim();
                            }

                            if (!(item["EQUIP_USERNAME"] is DBNull))
                            {
                                textBox1.Text = Convert.ToString(item["EQUIP_USERNAME"]).Trim();
                            }

                            if (!(item["EQUIP_PASSWORD"] is DBNull))
                            {
                                pbPass.Password = Convert.ToString(item["EQUIP_PASSWORD"]).Trim();
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

        private void ClearAll()
        {
            txtNetEquipName.Text = String.Empty;
            txtNetEquipTypeName.Text = String.Empty;
            txtMaskedIPAddress.ipTextBox4.Text = String.Empty;
            txtMaskedIPAddress.ipTextBox3.Text = String.Empty;
            txtMaskedIPAddress.ipTextBox2.Text = String.Empty;
            txtMaskedIPAddress.ipTextBox1.Text = String.Empty;

            txtMaskedMACAddress.ipTextBox6.Text = String.Empty;
            txtMaskedMACAddress.ipTextBox5.Text = String.Empty;
            txtMaskedMACAddress.ipTextBox4.Text = String.Empty;
            txtMaskedMACAddress.ipTextBox3.Text = String.Empty;
            txtMaskedMACAddress.ipTextBox2.Text = String.Empty;
            txtMaskedMACAddress.ipTextBox1.Text = String.Empty;

            txtEquipDescInfo.Text = String.Empty;

            txtNetEquipID.Text = String.Empty;
        }

        //private void fullSingleNetNodeInfo()
        //{
        //    if (_eEditNetFirewallInfo != null)
        //    {
        //        if (_eEditNetFirewallInfo.ENetNodeEquipModelInfo != null)
        //        {
        //            if (_etEditNetNodeInfo.ENetNodeEquipModelInfo.EQUIP_TYPE_ID.ToString().Trim() != String.Empty)
        //            {
        //                if (_etEditNetNodeInfo.ENetNodeEquipModelInfo.EQUIP_TYPE_ID.ToString().Trim() == "001")
        //                {
        //                    if (_etEditNetNodeInfo.ENetNodeWorkstationInfo != null)
        //                    {
        //                        txtNetEquipID.Text = _etEditNetNodeInfo.ENetNodeWorkstationInfo.NetEquip_ID;
        //                        txtNetEquipName.Text = _etEditNetNodeInfo.ENetNodeWorkstationInfo.NetEquip_Name;
        //                        txtNetEquipTypeName.Text = _etEditNetNodeInfo.ENetNodeEquipModelInfo.VIRTUAL_EQUIP_MODEL_DESC; //????
        //                        txtEquipDescInfo.Text = _etEditNetNodeInfo.ENetNodeWorkstationInfo.NetEquip_DESC;

        //                        if (_etEditNetNodeInfo.ENetNodeWorkstationInfo.IPAddress.ToString().Trim() != String.Empty)
        //                        {
        //                            txtMaskedIPAddress.setIPv4IP(_etEditNetNodeInfo.ENetNodeWorkstationInfo.IPAddress.ToString().Trim());
        //                        }

        //                        if (_etEditNetNodeInfo.ENetNodeWorkstationInfo.MACAddress.ToString().Trim() != String.Empty)
        //                        {
        //                            txtMaskedMACAddress.setMACAddress(_etEditNetNodeInfo.ENetNodeWorkstationInfo.MACAddress.ToString().Trim());
        //                        }
        //                    }
        //                }

        //                if (_etEditNetNodeInfo.ENetNodeEquipModelInfo.EQUIP_TYPE_ID.ToString().Trim() == "002")
        //                {
        //                    if (_etEditNetNodeInfo.ENetNodeNetEquipInfo != null)
        //                    {
        //                        txtNetEquipID.Text = _etEditNetNodeInfo.ENetNodeNetEquipControlInfo.NetEquip_ID;
        //                        txtNetEquipName.Text = _etEditNetNodeInfo.ENetNodeNetEquipControlInfo.NetEquip_Name;
        //                        txtNetEquipTypeName.Text = _etEditNetNodeInfo.ENetNodeEquipModelInfo.VIRTUAL_EQUIP_MODEL_DESC; //????
        //                        txtEquipDescInfo.Text = _etEditNetNodeInfo.ENetNodeNetEquipControlInfo.NetEquip_DESC;

        //                        if (_etEditNetNodeInfo.ENetNodeNetEquipControlInfo.IPAddress.ToString().Trim() != String.Empty)
        //                        {
        //                            txtMaskedIPAddress.setIPv4IP(_etEditNetNodeInfo.ENetNodeNetEquipControlInfo.IPAddress.ToString().Trim());
        //                        }

        //                        if (_etEditNetNodeInfo.ENetNodeNetEquipControlInfo.MACAddress.ToString().Trim() != String.Empty)
        //                        {
        //                            txtMaskedMACAddress.setMACAddress(_etEditNetNodeInfo.ENetNodeNetEquipControlInfo.MACAddress.ToString().Trim());
        //                        }
        //                    }
        //                }

        //                if (_etEditNetNodeInfo.ENetNodeEquipModelInfo.EQUIP_TYPE_ID.ToString().Trim() == "005") //"001")
        //                {
        //                    if (_etEditNetNodeInfo.ENetNodeNetEquipInfo != null)
        //                    {
        //                        txtNetEquipID.Text = _etEditNetNodeInfo.ENetNodeNetEquipInfo.NetEquip_ID;
        //                        txtNetEquipName.Text = _etEditNetNodeInfo.ENetNodeNetEquipInfo.NetEquip_Name;
        //                        txtNetEquipTypeName.Text = _etEditNetNodeInfo.ENetNodeEquipModelInfo.VIRTUAL_EQUIP_MODEL_DESC; //????
        //                        txtEquipDescInfo.Text = _etEditNetNodeInfo.ENetNodeNetEquipInfo.NetEquip_DESC;

        //                        if (_etEditNetNodeInfo.ENetNodeNetEquipInfo.IPAddress.ToString().Trim() != String.Empty)
        //                        {
        //                            txtMaskedIPAddress.setIPv4IP(_etEditNetNodeInfo.ENetNodeNetEquipInfo.IPAddress.ToString().Trim());
        //                        }

        //                        if (_etEditNetNodeInfo.ENetNodeNetEquipInfo.MACAddress.ToString().Trim() != String.Empty)
        //                        {
        //                            txtMaskedMACAddress.setMACAddress(_etEditNetNodeInfo.ENetNodeNetEquipInfo.MACAddress.ToString().Trim());
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //private bool InspectionApproval(int varInspectionSign)
        //{
        //    if (varInspectionSign == 0 || varInspectionSign == 1)
        //    {
        //        //判断是否信息为空
        //        if (txtNetEquipName.Text.Trim() == String.Empty)
        //        {
        //            MessageBox.Show("设备名称不能为空！");
        //            txtNetEquipName.Focus();
        //            return false;
        //        }

        //        if (txtNetEquipTypeName.Text.Trim() == String.Empty)
        //        {
        //            MessageBox.Show("设备类型不能为空！");
        //            return false;
        //        }

        //        #region //IP地址输入检测
        //        if (txtMaskedIPAddress.getIPv4IP().Trim() == String.Empty)
        //        {
        //            MessageBox.Show("IP地址不能为空！");
        //            txtMaskedIPAddress.ipTextBox1.Focus();
        //            return false;
        //        }

        //        if (txtMaskedIPAddress.ipTextBox1.Text.Trim() == String.Empty)
        //        {
        //            MessageBox.Show("IP地址第1段不能为空！");
        //            txtMaskedIPAddress.ipTextBox1.Focus();
        //            return false;
        //        }

        //        if (txtMaskedIPAddress.ipTextBox2.Text.Trim() == String.Empty)
        //        {
        //            MessageBox.Show("IP地址第2段不能为空！");
        //            txtMaskedIPAddress.ipTextBox2.Focus();
        //            return false;
        //        }

        //        if (txtMaskedIPAddress.ipTextBox3.Text.Trim() == String.Empty)
        //        {
        //            MessageBox.Show("IP地址第3段不能为空！");
        //            txtMaskedIPAddress.ipTextBox3.Focus();
        //            return false;
        //        }

        //        if (txtMaskedIPAddress.ipTextBox4.Text.Trim() == String.Empty)
        //        {
        //            MessageBox.Show("IP地址第4段不能为空！");
        //            txtMaskedIPAddress.ipTextBox4.Focus();
        //            return false;
        //        }
        //        #endregion

        //        //string stIPAddress = "";
        //        //string stEquipID="";
        //        //string stEquipTypeID= "";                
        //        //string stIPAddressCheckInfo="";

        //        //stIPAddress = txtMaskedIPAddress.getIPv4IP().Trim();
        //        //stEquipID = txtNetEquipID.Text;
        //        //stEquipTypeID = GetEquipType(stEquipID);

        //        //GCNetEquipIPAddressCheckDeal.SendNetEquipIPAddressCheckCommandMessage(stIPAddress, stEquipID, stEquipTypeID, ref stIPAddressCheckInfo);

        //        //if (stIPAddressCheckInfo.Trim() !=String.Empty) 
        //        //{
        //        //    ShowErrorMsg("当前设备IP地址与 " + stIPAddressCheckInfo.Trim() + " 重复!");
        //        //    return false;
        //        //}
        //    }

        //    if (varInspectionSign == 0)
        //    {
        //        #region //MAC地址输入检测
        //        //if (txtMaskedMACAddress.getMACAddress().Trim() == String.Empty)
        //        //{
        //        //    ShowErrorMsg("MAC地址不能为空！");
        //        //    txtMaskedMACAddress.ipTextBox1.Focus();
        //        //    return false;
        //        //}

        //        //if (txtMaskedMACAddress.ipTextBox1.Text.Trim() == String.Empty)
        //        //{
        //        //    ShowErrorMsg("MAC地址第1段不能为空！");
        //        //    txtMaskedMACAddress.ipTextBox1.Focus();
        //        //    return false;
        //        //}
        //        //else
        //        //{
        //        //    if (txtMaskedMACAddress.ipTextBox1.Text.Trim().Length != 2)
        //        //    {
        //        //        ShowErrorMsg("MAC地址第1段长度不够！如果缺0，则补上0！");
        //        //        txtMaskedMACAddress.ipTextBox1.Focus();
        //        //        return false;
        //        //    }
        //        //}

        //        //if (txtMaskedMACAddress.ipTextBox2.Text.Trim() == String.Empty)
        //        //{
        //        //    ShowErrorMsg("MAC地址第2段不能为空！");
        //        //    txtMaskedMACAddress.ipTextBox2.Focus();
        //        //    return false;
        //        //}
        //        //else
        //        //{
        //        //    if (txtMaskedMACAddress.ipTextBox2.Text.Trim().Length != 2)
        //        //    {
        //        //        ShowErrorMsg("MAC地址第2段长度不够！如果缺0，则补上0！");
        //        //        txtMaskedMACAddress.ipTextBox2.Focus();
        //        //        return false;
        //        //    }
        //        //}

        //        //if (txtMaskedMACAddress.ipTextBox3.Text.Trim() == String.Empty)
        //        //{
        //        //    ShowErrorMsg("MAC地址第3段不能为空！");
        //        //    txtMaskedMACAddress.ipTextBox3.Focus();
        //        //    return false;
        //        //}
        //        //else
        //        //{
        //        //    if (txtMaskedMACAddress.ipTextBox3.Text.Trim().Length != 2)
        //        //    {
        //        //        ShowErrorMsg("MAC地址第2段长度不够！如果缺0，则补上0！");
        //        //        txtMaskedMACAddress.ipTextBox3.Focus();
        //        //        return false;
        //        //    }
        //        //}

        //        //if (txtMaskedMACAddress.ipTextBox4.Text.Trim() == String.Empty)
        //        //{
        //        //    ShowErrorMsg("MAC地址第4段不能为空！");
        //        //    txtMaskedMACAddress.ipTextBox4.Focus();
        //        //    return false;
        //        //}
        //        //else
        //        //{
        //        //    if (txtMaskedMACAddress.ipTextBox4.Text.Trim().Length != 2)
        //        //    {
        //        //        ShowErrorMsg("MAC地址第4段长度不够！如果缺0，则补上0！");
        //        //        txtMaskedMACAddress.ipTextBox4.Focus();
        //        //        return false;
        //        //    }
        //        //}

        //        //if (txtMaskedMACAddress.ipTextBox5.Text.Trim() == String.Empty)
        //        //{
        //        //    ShowErrorMsg("MAC地址第5段不能为空！");
        //        //    txtMaskedMACAddress.ipTextBox5.Focus();
        //        //    return false;
        //        //}
        //        //else
        //        //{
        //        //    if (txtMaskedMACAddress.ipTextBox5.Text.Trim().Length != 2)
        //        //    {
        //        //        ShowErrorMsg("MAC地址第5段长度不够！如果缺0，则补上0！");
        //        //        txtMaskedMACAddress.ipTextBox5.Focus();
        //        //        return false;
        //        //    }
        //        //}

        //        //if (txtMaskedMACAddress.ipTextBox6.Text.Trim() == String.Empty)
        //        //{
        //        //    ShowErrorMsg("MAC地址第6段不能为空！");
        //        //    txtMaskedMACAddress.ipTextBox6.Focus();
        //        //    return false;
        //        //}
        //        //else
        //        //{
        //        //    if (txtMaskedMACAddress.ipTextBox6.Text.Trim().Length != 2)
        //        //    {
        //        //        ShowErrorMsg("MAC地址第6段长度不够！如果缺0，则补上0！");
        //        //        txtMaskedMACAddress.ipTextBox6.Focus();
        //        //        return false;
        //        //    }
        //        //}


        //        //if (txtMaskedMACAddress.getMACAddress().Trim() != String.Empty)
        //        //{
        //        //    if (txtMaskedMACAddress.ipTextBox1.Text.Trim() == String.Empty)
        //        //    {
        //        //        ShowErrorMsg("MAC地址第1段不能为空！");
        //        //        txtMaskedMACAddress.ipTextBox1.Focus();
        //        //        return false;
        //        //    }
        //        //    else
        //        //    {
        //        //        if (txtMaskedMACAddress.ipTextBox1.Text.Trim().Length != 2)
        //        //        {
        //        //            ShowErrorMsg("MAC地址第1段长度不够！如果缺0，则补上0！");
        //        //            txtMaskedMACAddress.ipTextBox1.Focus();
        //        //            return false;
        //        //        }
        //        //    }

        //        //    if (txtMaskedMACAddress.ipTextBox2.Text.Trim() == String.Empty)
        //        //    {
        //        //        ShowErrorMsg("MAC地址第2段不能为空！");
        //        //        txtMaskedMACAddress.ipTextBox2.Focus();
        //        //        return false;
        //        //    }
        //        //    else
        //        //    {
        //        //        if (txtMaskedMACAddress.ipTextBox2.Text.Trim().Length != 2)
        //        //        {
        //        //            ShowErrorMsg("MAC地址第2段长度不够！如果缺0，则补上0！");
        //        //            txtMaskedMACAddress.ipTextBox2.Focus();
        //        //            return false;
        //        //        }
        //        //    }

        //        //    if (txtMaskedMACAddress.ipTextBox3.Text.Trim() == String.Empty)
        //        //    {
        //        //        ShowErrorMsg("MAC地址第3段不能为空！");
        //        //        txtMaskedMACAddress.ipTextBox3.Focus();
        //        //        return false;
        //        //    }
        //        //    else
        //        //    {
        //        //        if (txtMaskedMACAddress.ipTextBox3.Text.Trim().Length != 2)
        //        //        {
        //        //            ShowErrorMsg("MAC地址第2段长度不够！如果缺0，则补上0！");
        //        //            txtMaskedMACAddress.ipTextBox3.Focus();
        //        //            return false;
        //        //        }
        //        //    }

        //        //    if (txtMaskedMACAddress.ipTextBox4.Text.Trim() == String.Empty)
        //        //    {
        //        //        ShowErrorMsg("MAC地址第4段不能为空！");
        //        //        txtMaskedMACAddress.ipTextBox4.Focus();
        //        //        return false;
        //        //    }
        //        //    else
        //        //    {
        //        //        if (txtMaskedMACAddress.ipTextBox4.Text.Trim().Length != 2)
        //        //        {
        //        //            ShowErrorMsg("MAC地址第4段长度不够！如果缺0，则补上0！");
        //        //            txtMaskedMACAddress.ipTextBox4.Focus();
        //        //            return false;
        //        //        }
        //        //    }

        //        //    if (txtMaskedMACAddress.ipTextBox5.Text.Trim() == String.Empty)
        //        //    {
        //        //        ShowErrorMsg("MAC地址第5段不能为空！");
        //        //        txtMaskedMACAddress.ipTextBox5.Focus();
        //        //        return false;
        //        //    }
        //        //    else
        //        //    {
        //        //        if (txtMaskedMACAddress.ipTextBox5.Text.Trim().Length != 2)
        //        //        {
        //        //            ShowErrorMsg("MAC地址第5段长度不够！如果缺0，则补上0！");
        //        //            txtMaskedMACAddress.ipTextBox5.Focus();
        //        //            return false;
        //        //        }
        //        //    }

        //        //    if (txtMaskedMACAddress.ipTextBox6.Text.Trim() == String.Empty)
        //        //    {
        //        //        ShowErrorMsg("MAC地址第6段不能为空！");
        //        //        txtMaskedMACAddress.ipTextBox6.Focus();
        //        //        return false;
        //        //    }
        //        //    else
        //        //    {
        //        //        if (txtMaskedMACAddress.ipTextBox6.Text.Trim().Length != 2)
        //        //        {
        //        //            ShowErrorMsg("MAC地址第6段长度不够！如果缺0，则补上0！");
        //        //            txtMaskedMACAddress.ipTextBox6.Focus();
        //        //            return false;
        //        //        }
        //        //    }
        //        //}

        //        #endregion
        //    }

        //    return true;
        //}

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;

            try
            {
                //一种是直接保存到文件中
                //一种保存到当前模型中

                //输入信息合法性检测
                if (!InspectionApproval(0))
                {
                    itNotLogRecord = 1;
                    return;
                }

                if (MessageBox.Show("是否保存设备: " + txtNetEquipName.Text.Trim() + " 的信息记录？", "提示信息", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    itNotLogRecord = 1;
                    return;
                }

                JoinNewEditData();
            }
            catch (Exception ee)
            {
                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ee.Message.ToString();
                throw ee;
                #endregion
            }
            finally
            {
                #region 记录到本地操作日志中
                //string stExecState = "";

                //if (itNotLogRecord == 0)
                //{
                //    if (itErrorSign == 0)
                //    {
                //        stExecState = CCommon.Key_I_LocalLog_ExecResult_Success_Nvar;
                //    }
                //    else
                //    {
                //        stExecState = CCommon.Key_I_LocalLog_ExecResult_Failure_Nvar;
                //    }

                //    string stNodeTypeName = "";
                //    string stExecOperationInfo = "";

                //    getOperationInfByEquipTypeID(ref stNodeTypeName, ref stExecOperationInfo);

                //    if (stErrorStr == String.Empty)
                //    {
                //        stDescription = "修改" + stNodeTypeName + _etEditNetNodeInfo.NetNode_ID +
                //                        " " + _etEditNetNodeInfo.NetNode_Name;
                //    }
                //    else
                //    {
                //        stDescription = "修改" + stNodeTypeName + _etEditNetNodeInfo.NetNode_ID +
                //                        " " + _etEditNetNodeInfo.NetNode_Name +
                //                        " " + "错误信息：" + stErrorStr;
                //    }

                //    ACPublicMethod.RecordLocalLogMessage(ref lvwTempLocalLog, tUserID, tUserName,
                //                           stExecOperationInfo,
                //                           stExecState, stDescription,
                //                           _tFilePathInfo, _tUseFilePathKindSign);

                //}
                #endregion
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
                        proxy.SetInParameter(ref strParam2, DbType.String, String.IsNullOrEmpty(txtMaskedMACAddress.getMACAddress()) ? "" : txtMaskedMACAddress.getMACAddress(), false);
                        proxy.SetInParameter(ref strParam3, DbType.String, String.IsNullOrEmpty(textBox1.Text.Trim()) ? "" : textBox1.Text.Trim(), false);
                        proxy.SetInParameter(ref strParam4, DbType.String, String.IsNullOrEmpty(pbPass.Password) ? "" : pbPass.Password, false);
                        proxy.SetInParameter(ref strParam5, DbType.String, String.IsNullOrEmpty(txtEquipDescInfo.Text.Trim()) ? "" : txtEquipDescInfo.Text.Trim(), false);
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
                        proxy.SetInParameter(ref strParam2, DbType.String, String.IsNullOrEmpty(txtMaskedMACAddress.getMACAddress()) ? "" : txtMaskedMACAddress.getMACAddress(), false);
                        proxy.SetInParameter(ref strParam3, DbType.String, String.IsNullOrEmpty(textBox1.Text.Trim()) ? "" : textBox1.Text.Trim(), false);
                        proxy.SetInParameter(ref strParam4, DbType.String, String.IsNullOrEmpty(pbPass.Password) ? "" : pbPass.Password, false);
                        proxy.SetInParameter(ref strParam5, DbType.String, String.IsNullOrEmpty(txtEquipDescInfo.Text.Trim()) ? "" : txtEquipDescInfo.Text.Trim(), false);


                        proxy.ExecuteNotQuery();

                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }



        }

        private bool InspectionApproval(int varInspectionSign)
        {
            if (varInspectionSign == 0 || varInspectionSign == 1)
            {
                //判断是否信息为空
                if (txtNetEquipName.Text.Trim() == String.Empty)
                {
                    ShowErrorMsg("设备名称不能为空！");
                    txtNetEquipName.Focus();
                    return false;
                }

                if (txtNetEquipTypeName.Text.Trim() == String.Empty)
                {
                    ShowErrorMsg("设备类型不能为空！");
                    return false;
                }

                #region //IP地址输入检测
                if (txtMaskedIPAddress.getIPv4IP().Trim() == String.Empty)
                {
                    ShowErrorMsg("IP地址不能为空！");
                    txtMaskedIPAddress.ipTextBox1.Focus();
                    return false;
                }

                if (txtMaskedIPAddress.ipTextBox1.Text.Trim() == String.Empty)
                {
                    ShowErrorMsg("IP地址第1段不能为空！");
                    txtMaskedIPAddress.ipTextBox1.Focus();
                    return false;
                }

                if (txtMaskedIPAddress.ipTextBox2.Text.Trim() == String.Empty)
                {
                    ShowErrorMsg("IP地址第2段不能为空！");
                    txtMaskedIPAddress.ipTextBox2.Focus();
                    return false;
                }

                if (txtMaskedIPAddress.ipTextBox3.Text.Trim() == String.Empty)
                {
                    ShowErrorMsg("IP地址第3段不能为空！");
                    txtMaskedIPAddress.ipTextBox3.Focus();
                    return false;
                }

                if (txtMaskedIPAddress.ipTextBox4.Text.Trim() == String.Empty)
                {
                    ShowErrorMsg("IP地址第4段不能为空！");
                    txtMaskedIPAddress.ipTextBox4.Focus();
                    return false;
                }
                #endregion

                string stIPAddress = "";
                string stEquipID = "";
                string stEquipTypeID = "";
                string stIPAddressCheckInfo = "";

                stIPAddress = txtMaskedIPAddress.getIPv4IP().Trim();
                stEquipID = txtNetEquipID.Text;
                //stEquipTypeID = _etEditNetNodeInfo.ENetNodeEquipModelInfo.EQUIP_TYPE_ID.Trim();

               // GCNetEquipIPAddressCheckDeal.SendNetEquipIPAddressCheckCommandMessage(stIPAddress, stEquipID, stEquipTypeID, ref stIPAddressCheckInfo);

                if (stIPAddressCheckInfo.Trim() != String.Empty)
                {
                    ShowErrorMsg("当前设备IP地址与 " + stIPAddressCheckInfo.Trim() + " 重复!");
                    return false;
                }
            }

            if (varInspectionSign == 0)
            {
                #region //MAC地址输入检测
                if (txtMaskedMACAddress.getMACAddress().Trim() == String.Empty)
                {
                    ShowErrorMsg("MAC地址不能为空！");
                    txtMaskedMACAddress.ipTextBox1.Focus();
                    return false;
                }

                if (txtMaskedMACAddress.ipTextBox1.Text.Trim() == String.Empty)
                {
                    ShowErrorMsg("MAC地址第1段不能为空！");
                    txtMaskedMACAddress.ipTextBox1.Focus();
                    return false;
                }
                else
                {
                    if (txtMaskedMACAddress.ipTextBox1.Text.Trim().Length != 2)
                    {
                        ShowErrorMsg("MAC地址第1段长度不够！如果缺0，则补上0！");
                        txtMaskedMACAddress.ipTextBox1.Focus();
                        return false;
                    }
                }

                if (txtMaskedMACAddress.ipTextBox2.Text.Trim() == String.Empty)
                {
                    ShowErrorMsg("MAC地址第2段不能为空！");
                    txtMaskedMACAddress.ipTextBox2.Focus();
                    return false;
                }
                else
                {
                    if (txtMaskedMACAddress.ipTextBox2.Text.Trim().Length != 2)
                    {
                        ShowErrorMsg("MAC地址第2段长度不够！如果缺0，则补上0！");
                        txtMaskedMACAddress.ipTextBox2.Focus();
                        return false;
                    }
                }

                if (txtMaskedMACAddress.ipTextBox3.Text.Trim() == String.Empty)
                {
                    ShowErrorMsg("MAC地址第3段不能为空！");
                    txtMaskedMACAddress.ipTextBox3.Focus();
                    return false;
                }
                else
                {
                    if (txtMaskedMACAddress.ipTextBox3.Text.Trim().Length != 2)
                    {
                        ShowErrorMsg("MAC地址第2段长度不够！如果缺0，则补上0！");
                        txtMaskedMACAddress.ipTextBox3.Focus();
                        return false;
                    }
                }

                if (txtMaskedMACAddress.ipTextBox4.Text.Trim() == String.Empty)
                {
                    ShowErrorMsg("MAC地址第4段不能为空！");
                    txtMaskedMACAddress.ipTextBox4.Focus();
                    return false;
                }
                else
                {
                    if (txtMaskedMACAddress.ipTextBox4.Text.Trim().Length != 2)
                    {
                        ShowErrorMsg("MAC地址第4段长度不够！如果缺0，则补上0！");
                        txtMaskedMACAddress.ipTextBox4.Focus();
                        return false;
                    }
                }

                if (txtMaskedMACAddress.ipTextBox5.Text.Trim() == String.Empty)
                {
                    ShowErrorMsg("MAC地址第5段不能为空！");
                    txtMaskedMACAddress.ipTextBox5.Focus();
                    return false;
                }
                else
                {
                    if (txtMaskedMACAddress.ipTextBox5.Text.Trim().Length != 2)
                    {
                        ShowErrorMsg("MAC地址第5段长度不够！如果缺0，则补上0！");
                        txtMaskedMACAddress.ipTextBox5.Focus();
                        return false;
                    }
                }

                //if (txtMaskedMACAddress.ipTextBox6.Text.Trim() == String.Empty)
                //{
                //    ShowErrorMsg("MAC地址第6段不能为空！");
                //    txtMaskedMACAddress.ipTextBox6.Focus();
                //    return false;
                //}
                //else
                //{
                //    if (txtMaskedMACAddress.ipTextBox6.Text.Trim().Length != 2)
                //    {
                //        ShowErrorMsg("MAC地址第6段长度不够！如果缺0，则补上0！");
                //        txtMaskedMACAddress.ipTextBox6.Focus();
                //        return false;
                //    }
                //}


                if (txtMaskedMACAddress.getMACAddress().Trim() != String.Empty)
                {
                    if (txtMaskedMACAddress.ipTextBox1.Text.Trim() == String.Empty)
                    {
                        ShowErrorMsg("MAC地址第1段不能为空！");
                        txtMaskedMACAddress.ipTextBox1.Focus();
                        return false;
                    }
                    else
                    {
                        if (txtMaskedMACAddress.ipTextBox1.Text.Trim().Length != 2)
                        {
                            ShowErrorMsg("MAC地址第1段长度不够！如果缺0，则补上0！");
                            txtMaskedMACAddress.ipTextBox1.Focus();
                            return false;
                        }
                    }

                    if (txtMaskedMACAddress.ipTextBox2.Text.Trim() == String.Empty)
                    {
                        ShowErrorMsg("MAC地址第2段不能为空！");
                        txtMaskedMACAddress.ipTextBox2.Focus();
                        return false;
                    }
                    else
                    {
                        if (txtMaskedMACAddress.ipTextBox2.Text.Trim().Length != 2)
                        {
                            ShowErrorMsg("MAC地址第2段长度不够！如果缺0，则补上0！");
                            txtMaskedMACAddress.ipTextBox2.Focus();
                            return false;
                        }
                    }

                    if (txtMaskedMACAddress.ipTextBox3.Text.Trim() == String.Empty)
                    {
                        ShowErrorMsg("MAC地址第3段不能为空！");
                        txtMaskedMACAddress.ipTextBox3.Focus();
                        return false;
                    }
                    else
                    {
                        if (txtMaskedMACAddress.ipTextBox3.Text.Trim().Length != 2)
                        {
                            ShowErrorMsg("MAC地址第2段长度不够！如果缺0，则补上0！");
                            txtMaskedMACAddress.ipTextBox3.Focus();
                            return false;
                        }
                    }

                    if (txtMaskedMACAddress.ipTextBox4.Text.Trim() == String.Empty)
                    {
                        ShowErrorMsg("MAC地址第4段不能为空！");
                        txtMaskedMACAddress.ipTextBox4.Focus();
                        return false;
                    }
                    else
                    {
                        if (txtMaskedMACAddress.ipTextBox4.Text.Trim().Length != 2)
                        {
                            ShowErrorMsg("MAC地址第4段长度不够！如果缺0，则补上0！");
                            txtMaskedMACAddress.ipTextBox4.Focus();
                            return false;
                        }
                    }

                    if (txtMaskedMACAddress.ipTextBox5.Text.Trim() == String.Empty)
                    {
                        ShowErrorMsg("MAC地址第5段不能为空！");
                        txtMaskedMACAddress.ipTextBox5.Focus();
                        return false;
                    }
                    else
                    {
                        if (txtMaskedMACAddress.ipTextBox5.Text.Trim().Length != 2)
                        {
                            ShowErrorMsg("MAC地址第5段长度不够！如果缺0，则补上0！");
                            txtMaskedMACAddress.ipTextBox5.Focus();
                            return false;
                        }
                    }

                    if (txtMaskedMACAddress.ipTextBox6.Text.Trim() == String.Empty)
                    {
                        ShowErrorMsg("MAC地址第6段不能为空！");
                        txtMaskedMACAddress.ipTextBox6.Focus();
                        return false;
                    }
                    else
                    {
                        if (txtMaskedMACAddress.ipTextBox6.Text.Trim().Length != 2)
                        {
                            ShowErrorMsg("MAC地址第6段长度不够！如果缺0，则补上0！");
                            txtMaskedMACAddress.ipTextBox6.Focus();
                            return false;
                        }
                    }
                }

                #endregion
            }

            return true;
        }

        //private void getOperationInfByEquipTypeID(ref string varNodeEquipTypeName, ref string varExecOperationInfo)
        //{
        //    if (_etEditNetNodeInfo != null)
        //    {
        //        if (_etEditNetNodeInfo != null)
        //        {
        //            if (_etEditNetNodeInfo.ENetNodeEquipModelInfo != null)
        //            {
        //                switch (_etEditNetNodeInfo.ENetNodeEquipModelInfo.EQUIP_TYPE_ID)
        //                {
        //                    case "001":
        //                        varNodeEquipTypeName = "工作站";
        //                        varExecOperationInfo = CCommon.Key_I_LocalLog_ExecOperation_UpNetModelInWorkStationInfo_Nvar;
        //                        break;
        //                    case "002":
        //                        varNodeEquipTypeName = "控制器";
        //                        varExecOperationInfo = CCommon.Key_I_LocalLog_ExecOperation_UpNetModelInControlorInfo_Nvar;
        //                        break;
        //                    case "003":
        //                        varNodeEquipTypeName = "网络";
        //                        varExecOperationInfo = CCommon.Key_I_LocalLog_ExecOperation_UpNetModelInNetInfo_Nvar;
        //                        break;
        //                    case "004":
        //                        varNodeEquipTypeName = "防火墙";
        //                        varExecOperationInfo = CCommon.Key_I_LocalLog_ExecOperation_UpNetModelInFirewallInfo_Nvar;
        //                        break;
        //                    case "005":
        //                        varNodeEquipTypeName = "网络设备";
        //                        varExecOperationInfo = CCommon.Key_I_LocalLog_ExecOperation_UpNetModelInNetEquipInfo_Nvar;
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //}


        //private void JoinNewEditData()
        //{
        //    if (_etEditNetNodeInfo != null)
        //    {
        //        if (_etEditNetNodeInfo != null)
        //        {
        //            if (_etEditNetNodeInfo.ENetNodeEquipModelInfo != null)
        //            {
        //                if (_etEditNetNodeInfo.ENetNodeEquipModelInfo.EQUIP_TYPE_ID.ToString().Trim() != String.Empty)
        //                {
        //                    if (_etEditNetNodeInfo.ENetNodeEquipModelInfo.EQUIP_TYPE_ID.ToString().Trim() == "001")
        //                    {
        //                        _etEditNetNodeInfo.NetNode_Name = txtNetEquipName.Text;
        //                        _etEditNetNodeInfo.ENetNodeWorkstationInfo.NetEquip_Name = txtNetEquipName.Text;
        //                        _etEditNetNodeInfo.ENetNodeWorkstationInfo.IPAddress = txtMaskedIPAddress.getIPv4IP();
        //                        _etEditNetNodeInfo.ENetNodeWorkstationInfo.MACAddress = txtMaskedMACAddress.getMACAddress();
        //                        _etEditNetNodeInfo.ENetNodeWorkstationInfo.NetEquip_DESC = txtEquipDescInfo.Text;
        //                    }

        //                    if (_etEditNetNodeInfo.ENetNodeEquipModelInfo.EQUIP_TYPE_ID.ToString().Trim() == "002")
        //                    {
        //                        _etEditNetNodeInfo.NetNode_Name = txtNetEquipName.Text;
        //                        _etEditNetNodeInfo.ENetNodeNetEquipControlInfo.NetEquip_Name = txtNetEquipName.Text;
        //                        _etEditNetNodeInfo.ENetNodeNetEquipControlInfo.IPAddress = txtMaskedIPAddress.getIPv4IP();
        //                        _etEditNetNodeInfo.ENetNodeNetEquipControlInfo.MACAddress = txtMaskedMACAddress.getMACAddress();
        //                        _etEditNetNodeInfo.ENetNodeNetEquipControlInfo.NetEquip_DESC = txtEquipDescInfo.Text;
        //                    }


        //                    if (_etEditNetNodeInfo.ENetNodeEquipModelInfo.EQUIP_TYPE_ID.ToString().Trim() == "005") //001
        //                    {
        //                        _etEditNetNodeInfo.NetNode_Name = txtNetEquipName.Text;
        //                        _etEditNetNodeInfo.ENetNodeNetEquipInfo.NetEquip_Name = txtNetEquipName.Text;
        //                        _etEditNetNodeInfo.ENetNodeNetEquipInfo.IPAddress = txtMaskedIPAddress.getIPv4IP();
        //                        _etEditNetNodeInfo.ENetNodeNetEquipInfo.MACAddress = txtMaskedMACAddress.getMACAddress();
        //                        _etEditNetNodeInfo.ENetNodeNetEquipInfo.NetEquip_DESC = txtEquipDescInfo.Text;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        private void cavInfo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ShowErrorMsg(string strMsg)
        {
            MessageBox.Show(strMsg, "提示信息", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.Cancel);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;

            this.Close();
        }

        public  void btnGetMacAddress_Click(object sender, RoutedEventArgs e)
        {
            int itErrorSign = 0;
            string stErrorStr = "";
            string stDescription = "";
            int itNotLogRecord = 0;
            string stExecOperationInfo = "";
            string stExecState = "";
            int iExecFlag = -1;

            string stIPAddress = "";
            //int itExecGetMacAddressState = 0;
            string GetMACAddressValue = "";

            try
            {
                if (!InspectionApproval(1))
                {
                    itNotLogRecord = 1;
                    return;
                }

                stIPAddress =txtMaskedIPAddress.getIPv4IP();
                //itExecGetMacAddressState=0;
                //stGetMacAddress="";

                GetFirewallEquipMACAddress(stIPAddress, ref iExecFlag, ref stDescription, ref GetMACAddressValue);
                //GCNetEquipMACAddressDeal.SendEquipMACControlCommandMessage(stEquipIPAddress, ref iExecFlag, ref stGetMacAddress);

                
            }
            catch (Exception ee)
            {
                #region 记录错误
                itErrorSign = 1;
                stErrorStr = ee.Message.ToString();
                throw ee;
                #endregion
            }
            finally
            {
                
            }

        }

        public void GetFirewallEquipMACAddress(string varIPAddress, ref int varExecFlag, ref string varDescription, ref string varGetMACAddressValue)
        {
            byte[] GetFirewallEquipMACAddressReq = new byte[7];
            byte[] GetFirewallEquipMACAddressRet = new byte[9];

            int langIndex = 3;
            int itSendLength = 0;
            int itReceiveLength = 0;

            GetFirewallEquipMACAddressReq[0] = 0x01; // zy 获取MAC地址发送协议
            GetFirewallEquipMACAddressReq[1] = 0x08;
            GetFirewallEquipMACAddressReq[2] = 0x01;


            try
            {
                string[] sLFirewallNTPIP = varIPAddress.Trim().Split(new char[] { '.' });
                //int[] iLFirewallNTPIP = new int[4];

                for (int itIndex = 0; itIndex < 4; itIndex++)
                {
                    GetFirewallEquipMACAddressReq[langIndex + itIndex] = Convert.ToByte(sLFirewallNTPIP[itIndex]);
                }

                langIndex += 4;


                itSendLength = _eEditNetFirewallInfo.ExecSocketCommunicate.SendData(GetFirewallEquipMACAddressReq);

                if (itSendLength > 0)
                {
                    itReceiveLength = _eEditNetFirewallInfo.ExecSocketCommunicate.ReceiveData(GetFirewallEquipMACAddressRet);

                    if (itReceiveLength > 0)
                    {
                        varExecFlag = _eEditNetFirewallInfo.ExecSocketCommunicate.CheckData(GetFirewallEquipMACAddressRet, itReceiveLength, "GetFirewallEquipMACAddress");

                        if (varExecFlag == 1)
                        {

                            string stEquipMACPartOne = Convert.ToString(((int)GetFirewallEquipMACAddressRet[3]), 16);
                            string stEquipMACPartSecond = Convert.ToString(((int)GetFirewallEquipMACAddressRet[4]), 16);
                            string stEquipMACPartThird = Convert.ToString(((int)GetFirewallEquipMACAddressRet[5]), 16);
                            string stEquipMACPartFourth = Convert.ToString(((int)GetFirewallEquipMACAddressRet[6]), 16);
                            string stEquipMACPartFive = Convert.ToString(((int)GetFirewallEquipMACAddressRet[7]), 16);
                            string stEquipMACPartSix = Convert.ToString(((int)GetFirewallEquipMACAddressRet[8]), 16);


                            if (stEquipMACPartOne.Trim().Length == 1)
                            {
                                stEquipMACPartOne = "0" + stEquipMACPartOne.Trim();
                            }

                            if (stEquipMACPartSecond.Trim().Length == 1)
                            {
                                stEquipMACPartSecond = "0" + stEquipMACPartSecond.Trim();
                            }

                            if (stEquipMACPartThird.Trim().Length == 1)
                            {
                                stEquipMACPartThird = "0" + stEquipMACPartThird.Trim();
                            }

                            if (stEquipMACPartFourth.Trim().Length == 1)
                            {
                                stEquipMACPartFourth = "0" + stEquipMACPartFourth.Trim();
                            }

                            if (stEquipMACPartFive.Trim().Length == 1)
                            {
                                stEquipMACPartFive = "0" + stEquipMACPartFive.Trim();
                            }

                            if (stEquipMACPartSix.Trim().Length == 1)
                            {
                                stEquipMACPartSix = "0" + stEquipMACPartSix.Trim();
                            }

                            string stGetEquipMACAddress = "";
                            stGetEquipMACAddress = stEquipMACPartOne + stEquipMACPartSecond + stEquipMACPartThird + stEquipMACPartFourth + stEquipMACPartFive + stEquipMACPartSix;

                            varGetMACAddressValue = stGetEquipMACAddress;

                            txtMaskedMACAddress.setMACAddress(varGetMACAddressValue.Trim());

                            varDescription = "MAC地址已经获取！";
                            ShowErrorMsg(varDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "获取异常监测设备MAC地址", "成功", "地址已经获取", ref strErr);
                   
                        }
                        else if (varExecFlag == 0)
                        {
                            varDescription = "异常监测设备未登录...";
                            ShowErrorMsg(varDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "获取异常监测设备MAC地址", "失败", "异常监测设备未登录", ref strErr);
                   

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
                        CLog.InsertLocalLogRecord(UserID, UserName, "获取异常监测设备MAC地址", "失败", "下位机返回信息错误", ref strErr);
                   
                    }
                }
            }
            catch (Exception ex)
            {
                JoinLoginStateInfo(0);

                throw new Exception(ex.Message.ToString());
            }
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
                _eEditNetFirewallInfo.ConnectionState = "01";  //已静态
                _eEditNetFirewallInfo.IsOrNotLogin = 0;        //已退出登录
            }

            if (varSuccessSign == 2)
            {
                _eEditNetFirewallInfo.ConnectionState = "02";  //已连接
                _eEditNetFirewallInfo.IsOrNotLogin = 1;        //已登录
            }
        }

        private void btnCon_Click(object sender, RoutedEventArgs e)
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
                sComFirewallServiceIP = txtIPAddress.getIPv4IP().Trim();// Zy 获取输入IP 地址
                sComUserName = textBox1.Text.Trim();// Zy 获取用户名输入
                sComUserPwd = pbPass.Password.Trim(); // Zy 获取用户密码输入

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
                            //StateFirewallCommState(0);

                            stDescription = "异常监测设备登录成功...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "登录异常监测设备", "成功", "异常监测设备登录成功", ref strErr);
                   
                        }

                        if (iExecFlag == 0)
                        {
                            JoinLoginStateInfo(0);
                            //StateFirewallCommState(1);

                            _eEditNetFirewallInfo.ExecSocketCommunicate.CloseClientSocket();
                            _eEditNetFirewallInfo.ExecSocketCommunicate.DisConnect();

                            stDescription = "未能登录异常检测设备...";
                            ShowErrorMsg(stDescription);
                            String strErr = String.Empty;
                            CLog.InsertLocalLogRecord(UserID, UserName, "登录异常监测设备", "失败", "未能登录异常检测设备", ref strErr);
                   
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
                    //StateFirewallCommState(1);

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
                //StateFirewallCommState(1);

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
            //iComFileLen = 0;

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
        // zy 没看懂
       

    }
}
