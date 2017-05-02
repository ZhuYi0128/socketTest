using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;


namespace socketTest.CPublicControl
{
    class CIntiDataTable
    {
        public void IntiDTDeptSample(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_DeptManager_Dept_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_DeptManager_Dept_Name_Nvar, typeof(string));
        }

        public void IntiDTDept(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_DeptManager_Dept_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_DeptManager_Dept_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_DeptManager_Dept_Description_Nvar, typeof(string));
        }

        public void IntiDTPosition(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_PositionManager_Position_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_PositionManager_Position_Name_Nvar, typeof(string));
        }

        public void IntiDTEmployee(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_EmployeeManager_Employee_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_EmployeeManager_Employee_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_EmployeeManager_Employee_Gender_Nvar, typeof(bool));
            DT.Columns.Add(CCommon.Key_T_A_EmployeeManager_Employee_Gender_Show_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_EmployeeManager_Employee_Birthday_DateTime, typeof(DateTime));
            DT.Columns.Add(CCommon.Key_T_A_DeptManager_Dept_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_DeptManager_Dept_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_PositionManager_Position_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_PositionManager_Position_Name_Nvar, typeof(string));
        }


        public void IntiDTUser(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_S_UserManager_User_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_UserManager_User_Name_Nvar, typeof(string));
        }

        public void IntiDTErrTableName(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_S_ExecErrManager_ExecErr_TableName_Nvar, typeof(string));
        }

        public void IntiDTUserInfo(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_EmployeeManager_Employee_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_EmployeeManager_Employee_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_UserManager_User_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_UserManager_User_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_DeptManager_Dept_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_DeptManager_Dept_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_UserManager_User_Password_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_UserRole_Role_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_UserRole_Role_Name_Nvar, typeof(string));
        }

        public void IntiDTUserInfo2(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_EmployeeManager_Employee_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_EmployeeManager_Employee_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_UserManager_User_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_UserManager_User_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_DeptManager_Dept_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_UserManager_User_Password_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_UserRole_Role_ID_Nvar, typeof(string));
        }

        public void IntiDTRole(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_S_UserRole_Role_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_UserRole_Role_Name_Nvar, typeof(string));
        }

        public void IntiDTProject(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_ProjectManager_Project_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_ProjectManager_Project_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_ProjectManager_Project_InitPath_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_UserManager_User_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_UserManager_User_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_ProjectManager_Project_MakeDateTime_DateTime, typeof(DateTime));
            DT.Columns.Add(CCommon.Key_T_A_ProjectManager_Project_EditDateTime_DateTime, typeof(DateTime));
        }

        public void IntiDTEquipTypeAllData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_EQP_TYPE_EQUIP_TYPE_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_EQP_TYPE_EQUIP_TYPE_DESC_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_EQP_TYPE_EQUIP_TYPE_PIC_Path_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_EQP_TYPE_EQUIP_TYPE_PIC_ICO_Img, typeof(byte[]));
        }

        public void IntiDTEquipModelAllData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_VIRTUAL_EQP_MODEL_EQUIP_MODEL_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_VIRTUAL_EQP_MODEL_EQUIP_MODEL_DESC_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_EQP_TYPE_EQUIP_TYPE_ID_Nvar, typeof(string));
        }

        public void IntiDTNetProtocolAllData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_NetProtocol_NetProtocol_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_NetProtocol_NetProtocol_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_Uppermonitor_ControlParameters_NetCommunicationPortCode_Int, typeof(int));
            DT.Columns.Add(CCommon.Key_T_A_NetProtocol_NetProtocol_Type_ID_Nvar, typeof(string));
        }

        public void IntiDTFirewallRuleCommonSetNetProtocolData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_NetProtocol_NetProtocol_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_NetProtocol_NetProtocol_Name_Nvar, typeof(string));

            string[] stsNetProtocolID = new string[4];
            stsNetProtocolID[0] = "01";
            stsNetProtocolID[1] = "02";
            stsNetProtocolID[2] = "03";
            stsNetProtocolID[3] = "00";

            string[] stsNetProtocolName = new string[4];

            stsNetProtocolName[0] = "TCP";
            stsNetProtocolName[1] = "UDP";
            stsNetProtocolName[2] = "ICMP";
            stsNetProtocolName[3] = "ALL";

            System.Data.DataRow dr;

            for (int i = 0; i < 4; i++)
            {
                dr = DT.NewRow();
                dr[CCommon.Key_T_A_NetProtocol_NetProtocol_ID_Nvar] = stsNetProtocolID[i];
                dr[CCommon.Key_T_A_NetProtocol_NetProtocol_Name_Nvar] = stsNetProtocolName[i];

                DT.Rows.Add(dr);
            }

            DT.AcceptChanges();
        }

        public void IntiDTFirewallRuleNetProtocolData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_NetProtocol_NetProtocol_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_NetProtocol_NetProtocol_Name_Nvar, typeof(string));

            string[] stsNetProtocolID = new string[4];
            stsNetProtocolID[0] = "01";
            stsNetProtocolID[1] = "02";
            stsNetProtocolID[2] = "03";
            stsNetProtocolID[3] = "00";

            string[] stsNetProtocolName = new string[4];

            stsNetProtocolName[0] = "TCP";
            stsNetProtocolName[1] = "UDP";
            stsNetProtocolName[2] = "ICMP";
            stsNetProtocolName[3] = "OTHER";

            System.Data.DataRow dr;

            for (int i = 0; i < 4; i++)
            {
                dr = DT.NewRow();
                dr[CCommon.Key_T_A_NetProtocol_NetProtocol_ID_Nvar] = stsNetProtocolID[i];
                dr[CCommon.Key_T_A_NetProtocol_NetProtocol_Name_Nvar] = stsNetProtocolName[i];

                DT.Rows.Add(dr);
            }

            DT.AcceptChanges();
        }

        public void IntiDTFirewallNetProtocolSLRData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_NetProtocol_NetProtocol_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_NetProtocol_NetProtocol_Name_Nvar, typeof(string));

            string[] stsNetProtocolID = new string[3];
            stsNetProtocolID[0] = "01";
            stsNetProtocolID[1] = "02";
            stsNetProtocolID[2] = "00";

            string[] stsNetProtocolName = new string[3];

            stsNetProtocolName[0] = "TCP";
            stsNetProtocolName[1] = "UDP";
            stsNetProtocolName[2] = "OTHER";

            System.Data.DataRow dr;

            for (int i = 0; i < 3; i++)
            {
                dr = DT.NewRow();
                dr[CCommon.Key_T_A_NetProtocol_NetProtocol_ID_Nvar] = stsNetProtocolID[i];
                dr[CCommon.Key_T_A_NetProtocol_NetProtocol_Name_Nvar] = stsNetProtocolName[i];

                DT.Rows.Add(dr);
            }

            DT.AcceptChanges();
        }

        public void IntiDTFirewallRulePowerData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_FirewallRulePower_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_FirewallRulePower_Name_Nvar, typeof(string));

            string[] stsPowerID = new string[4];
            stsPowerID[0] = "00";
            stsPowerID[1] = "01";
            stsPowerID[2] = "02";
            stsPowerID[3] = "03";

            string[] stsPowerName = new string[4];
            stsPowerName[0] = "允许";
            stsPowerName[1] = "允许且有日志";
            stsPowerName[2] = "禁止";
            stsPowerName[3] = "禁止且有日志";

            System.Data.DataRow dr;

            for (int i = 0; i < 4; i++)
            {
                dr = DT.NewRow();
                dr[CCommon.Key_T_A_FirewallNormalRule_FirewallRulePower_ID_Nvar] = stsPowerID[i];
                dr[CCommon.Key_T_A_FirewallNormalRule_FirewallRulePower_Name_Nvar] = stsPowerName[i];

                DT.Rows.Add(dr);
            }

            DT.AcceptChanges();
        }

        public void IntiDTFirewallRuleOrientationData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_FirewallRuleOrientation_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_FirewallRuleOrientation_Name_Nvar, typeof(string));

            string[] stsOrientationID = new string[2];
            stsOrientationID[0] = "00";
            stsOrientationID[1] = "01";

            string[] stsOrientationName = new string[2];
            stsOrientationName[0] = "-->";
            stsOrientationName[1] = "<--";

            System.Data.DataRow dr;

            for (int i = 0; i < 2; i++)
            {
                dr = DT.NewRow();
                dr[CCommon.Key_T_A_FirewallNormalRule_FirewallRuleOrientation_ID_Nvar] = stsOrientationID[i];
                dr[CCommon.Key_T_A_FirewallNormalRule_FirewallRuleOrientation_Name_Nvar] = stsOrientationName[i];

                DT.Rows.Add(dr);
            }

            DT.AcceptChanges();
        }

        public void IntiDTFirewallConnectionStateData(ref DataTable DT) // zy 连接状态
        {
            DT.Columns.Add(CCommon.Key_T_S_Uppermonitor_ControlParameters_ConnectionState_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_Uppermonitor_ControlParameters_ConnectionState_Name_Nvar, typeof(string));

            string[] stsConnectionStateID = new string[3];
            stsConnectionStateID[0] = "00";
            stsConnectionStateID[1] = "01";
            stsConnectionStateID[2] = "02";

            string[] stsConnectionStateName = new string[3];
            stsConnectionStateName[0] = "断开";
            stsConnectionStateName[1] = "静态";
            stsConnectionStateName[2] = "连接";

            System.Data.DataRow dr;

            for (int i = 0; i < 3; i++)
            {
                dr = DT.NewRow();
                dr[CCommon.Key_T_S_Uppermonitor_ControlParameters_ConnectionState_ID_Nvar] = stsConnectionStateID[i];
                dr[CCommon.Key_T_S_Uppermonitor_ControlParameters_ConnectionState_Name_Nvar] = stsConnectionStateName[i];

                DT.Rows.Add(dr);
            }

            DT.AcceptChanges();
        }

        public void IntiDTFirewallRunModeData(ref DataTable DT)  // zy 运行模式
        {
            DT.Columns.Add(CCommon.Key_T_S_Uppermonitor_ControlParameters_NetFirewallRunMode_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_Uppermonitor_ControlParameters_NetFirewallRunMode_Name_Nvar, typeof(string));

            string[] stsRunModeID = new string[5];
            stsRunModeID[0] = "01";
            stsRunModeID[1] = "02";
            stsRunModeID[2] = "03";
            stsRunModeID[3] = "04";
            stsRunModeID[4] = "05";

            string[] stsRunModeName = new string[5];
            stsRunModeName[0] = "未启动";
            stsRunModeName[1] = "启动流量监测";
            stsRunModeName[2] = "启动异常监测";
            stsRunModeName[3] = "启动流量和异常监测";
            stsRunModeName[4] = "启动训练模式";


            System.Data.DataRow dr;

            for (int i = 0; i < 5; i++)
            {
                dr = DT.NewRow();
                dr[CCommon.Key_T_S_Uppermonitor_ControlParameters_NetFirewallRunMode_ID_Nvar] = stsRunModeID[i];
                dr[CCommon.Key_T_S_Uppermonitor_ControlParameters_NetFirewallRunMode_Name_Nvar] = stsRunModeName[i];

                DT.Rows.Add(dr);
            }

            DT.AcceptChanges();
        }

        public void IntiDTFirewallSafetyZoneAllData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_NetNodeRecordInModel_NetNode_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_NetNodeRecordInModel_NetNode_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_Uppermonitor_ControlParameters_IPAddress_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_Uppermonitor_ControlParameters_MACAddress_Nvar, typeof(string));
        }

        public void IntiDTFirewallUnSafetyZoneAllData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_NetNodeRecordInModel_NetNode_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_NetNodeRecordInModel_NetNode_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_Uppermonitor_ControlParameters_IPAddress_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_Uppermonitor_ControlParameters_MACAddress_Nvar, typeof(string));
        }

        public void IntiDTFirewallNormalRuleAllData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_FirewallNormalRule_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_NetFirewallInModel_NetFirewall_ID_Nvar, typeof(string));

            DT.Columns.Add(CCommon.Key_T_A_NetProtocol_NetProtocol_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_NetProtocol_NetProtocol_Name_Nvar, typeof(string));

            DT.Columns.Add(CCommon.Key_T_A_FirewallMACAddressBinding_FirewallMACAddressBinding_IsOrNotBinding_Bool, typeof(bool));
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_Source_NetNode_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_Source_IPAddress_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_Uppermonitor_ControlParameters_NetSourceCommunicationPortCode_Int, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_Source_Part_Int, typeof(int));
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_Source_MACAddress_Nvar, typeof(string));

            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_FirewallRuleOrientation_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_FirewallRuleOrientation_Name_Nvar, typeof(string));

            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_Destination_IPAddress_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_Destination_NetNode_ID_Nvar, typeof(string));            
            DT.Columns.Add(CCommon.Key_T_S_Uppermonitor_ControlParameters_NetDestinationCommunicationPortCode_Int, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_Destination_Part_Int, typeof(int));

            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_FirewallRulePower_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_FirewallRulePower_Name_Nvar, typeof(string));
        }

        public void IntiDTFirewallIndustrialRuleInfoAllData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_FirewallIndustrialRule_FirewallIndustrialRule_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_NetFirewallInModel_NetFirewall_ID_Nvar, typeof(string));

            DT.Columns.Add(CCommon.Key_T_A_NetProtocol_NetProtocol_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_NetProtocol_NetProtocol_Name_Nvar, typeof(string));

            DT.Columns.Add(CCommon.Key_T_A_FirewallIndustrialRule_SafetyZone_NetNode_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallIndustrialRule_SafetyZone_IPAddress_Nvar, typeof(string));

            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_FirewallRuleOrientation_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_FirewallRuleOrientation_Name_Nvar, typeof(string));

            DT.Columns.Add(CCommon.Key_T_A_FirewallMACAddressBinding_FirewallMACAddressBinding_IsOrNotBinding_Bool, typeof(bool));
            DT.Columns.Add(CCommon.Key_T_A_FirewallMACAddressBinding_FirewallMACAddressBinding_IsOrNotBinding_Show_Nvar, typeof(string));
            
            DT.Columns.Add(CCommon.Key_T_A_FirewallIndustrialRule_UnSafetyZone_IPAddress_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallIndustrialRule_UnSafetyZone_NetNode_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallIndustrialRule_UnSafetyZone_MACAddress_Nvar, typeof(string));

            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_FirewallRulePower_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallNormalRule_FirewallRulePower_Name_Nvar, typeof(string));

            DT.Columns.Add(CCommon.Key_T_A_FirewallIndustrialRule_IsOrNotIncludingDeepRule_Int, typeof(int));

            
        }

        public void IntiDTDeepRuleTemplateData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_FirewallDeepRule_FirewallDeepRule_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallDeepRule_FirewallDeepRule_Name_Nvar, typeof(string));
        }

        public void IntiDTDeepRuleTemplateData2(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_FirewallDeepRule_FirewallDeepRule_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallDeepRule_FirewallDeepRule_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallDeepRule_FirewallDeepRule_IDAndName_Nvar, typeof(string));
        }

        public void IntiDTDeepRuleSonNodeTemplateData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_FirewallDeepRule_FirewallDeepRule_SonNode_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallDeepRule_FirewallDeepRule_SonNode_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallDeepRule_FirewallDeepRule_SonNode_Value_Nvar, typeof(string));
        }

        public void IntiDTNetFirewallMACAddressBindingInfoData(ref DataTable DT)
        {
            DT.Columns.Add(CCommon.Key_T_A_FirewallMACAddressBinding_FirewallMACAddressBinding_RecordCode_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_NetFirewallInModel_NetFirewall_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_FirewallRuleType_FirewallRuleType_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_NetNodeRecordInModel_NetNode_ID_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_A_NetNodeRecordInModel_NetNode_Name_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_Uppermonitor_ControlParameters_IPAddress_Nvar, typeof(string));
            DT.Columns.Add(CCommon.Key_T_S_Uppermonitor_ControlParameters_MACAddress_Nvar, typeof(string));
        }
        
    }
}
