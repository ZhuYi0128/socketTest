using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace socketTest
{
    class CCommon
    {
        public static readonly string Key_XML_RootNode_Nvar = "rootNode";
        public static readonly string Key_XML_Path_BaseData_Nvar = "BaseDataXML";
        public static readonly string Key_XML_Path_ProjectManagerData_Nvar = "ProjectManagerDataXML";
        public static readonly string Key_XML_Path_SecondLevel_NetprotocolManagerData_Nvar = "NetprotocolDataXML";
        public static readonly string Key_XML_Path_SecondLevel_EquipManagerData_Nvar = "EquipDataXML";
        public static readonly string Key_XML_Path_SecondLevel_ModelManagerData_Nvar = "ModelDataXML";
        public static readonly string Key_XML_Path_SecondLevel_FirewallRuleManagerData_Nvar = "FirewallRuleDataXML";

        public static readonly string Key_XML_Path_SecondLevel_TempProjectZipFileData_Nvar = "TempProjectZipFileDataXML";
        public static readonly string Key_XML_Path_SecondLevel_TempFirewallRuleSendFileData_Nvar = "TempFirewallRuleSendFileDataXML";

        public static readonly string Key_XML_Path_ProjectApplicationData_Nvar = "ProjectApplicationData";

        public static readonly string Key_XML_Path_SecondLevel_LocalLogData_Nvar = "ProjectLog";

        public static readonly string Key_XML_LocalLog_FileName_Nvar = "LocalLog";
        public static readonly string Key_XML_AlarmLog_FileName_Nvar = "AlarmLog";
        public static readonly string Key_XML_MessageLog_FileName_Nvar = "MessageLog";

        public static readonly string Key_TXT_LOG_Path_BaseData_Nvar = "TxtLog";
        public static readonly string Key_TXT_LOG_FileName_Nvar = "Log";
        public static readonly int Key_TXT_LOG_FileMaxSize_Int = 1024000;

        public static readonly string Key_TXT_ERR_Path_BaseData_Nvar = "TxtErr";
        public static readonly string Key_TXT_ERR_FileName_Nvar = "Err";
        public static readonly int Key_TXT_ERR_FileMaxSize_Int = 1024000;

        public static readonly string Key_I_ColTypeName_String_Nvar = "string";
        public static readonly string Key_I_ColTypeName_Int_Nvar = "int";
        public static readonly string Key_I_ColTypeName_Double_Nvar = "double";
        public static readonly string Key_I_ColTypeName_Bool_Nvar = "bool";
        public static readonly string Key_I_ColTypeName_DateTime_Nvar = "DateTime";
        public static readonly string Key_I_ColTypeName_Image_Nvar = "image";

        public static readonly string Key_T_S_Selected_Bool = "Selected";


        //错误信息
        public static readonly string Key_I_Err_Command_loadData_Nvar = "加载数据错误";
        public static readonly string Key_I_Err_Command_Add_Nvar = "增加错误";
        public static readonly string Key_I_Err_Command_Del_Nvar = "删除错误";
        public static readonly string Key_I_Err_Command_Up_Nvar = "修改错误";
        public static readonly string Key_I_Err_Command_Sel_Nvar = "查询错误";
        public static readonly string Key_I_Err_Command_Print_Nvar = "打印错误";
        public static readonly string Key_I_Err_Command_Exec_Nvar = "执行错误";
        public static readonly string Key_I_Err_Command_Send_Nvar = "发送错误";
        public static readonly string Key_I_Err_Command_Receive_Nvar = "接收错误";

        //操作信息
        public static readonly string Key_I_ContolLog_Command_Add_Nvar = "增加操作";
        public static readonly string Key_I_ContolLog_Command_Del_Nvar = "删除操作";
        public static readonly string Key_I_ContolLog_Command_Up_Nvar = "修改操作";
        public static readonly string Key_I_ContolLog_Command_Sel_Nvar = "查询操作";
        public static readonly string Key_I_ContolLog_Command_Print_Nvar = "打印操作";
        public static readonly string Key_I_ContolLog_Command_Exec_Nvar = "执行操作";
        public static readonly string Key_I_ContolLog_Command_Send_Nvar = "发送操作";
        public static readonly string Key_I_ContolLog_Command_Receive_Nvar = "接收操作";


        //本地建立网络模型操作信息
        public static readonly string Key_I_LocalLog_ExecOperation_NewBuildProject_Nvar = "新建工程项目";
        public static readonly string Key_I_LocalLog_ExecOperation_SaveAsProject_Nvar = "另存工程项目";
        public static readonly string Key_I_LocalLog_ExecOperation_LoadProject_Nvar = "加载已保存的工程项目";
        public static readonly string Key_I_LocalLog_ExecOperation_CloseProject_Nvar = "关闭当前工程项目";

        public static readonly string Key_I_LocalLog_ExecOperation_NewBuildModel_Nvar = "新建网络模型";
        public static readonly string Key_I_LocalLog_ExecOperation_LoadModel_Nvar = "加载网络模型";
        public static readonly string Key_I_LocalLog_ExecOperation_SaveModel_Nvar = "保存网络模型";

        public static readonly string Key_I_LocalLog_ExecOperation_AddModelNode_Nvar = "增加网络模型中节点";
        public static readonly string Key_I_LocalLog_ExecOperation_DelModelNode_Nvar = "删除网络模型中节点";
        public static readonly string Key_I_LocalLog_ExecOperation_UpModelNodeInfo_Nvar = "更新网络模型中节点配置信息";
        public static readonly string Key_I_LocalLog_ExecOperation_JustModelNodeRelation_Nvar = "调整网络模型中节点间的关联关系";

        public static readonly string Key_I_LocalLog_ExecOperation_LoadNetEquipModelList_Nvar = "加载网络设备模型列表";
        public static readonly string Key_I_LocalLog_ExecOperation_AddNetEquipModel_Nvar = "增加网络设备模型列表中设备";
        public static readonly string Key_I_LocalLog_ExecOperation_DelNetEquipModel_Nvar = "删除网络设备模型列表中设备";
        public static readonly string Key_I_LocalLog_ExecOperation_UpNetEquipModelInfo_Nvar = "修改网络设备模型列表中设备信息";
        public static readonly string Key_I_LocalLog_ExecOperation_ImportNetEquipModelList_Nvar = "导入网络设备模型列表信息";
        public static readonly string Key_I_LocalLog_ExecOperation_ExportNetEquipMidelList_Nvar = "导出网络设备模型列表信息";

        public static readonly string Key_I_LocalLog_ExecOperation_LoadNetProtocolList_Nvar = "加载网络协议列表";
        public static readonly string Key_I_LocalLog_ExecOperation_AddNetProtocol_Nvar = "增加网络协议";
        public static readonly string Key_I_LocalLog_ExecOperation_DelNetProtocol_Nvar = "删除网络协议";
        public static readonly string Key_I_LocalLog_ExecOperation_UpNetProtocolInfo_Nvar = "修改网络协议信息";
        public static readonly string Key_I_LocalLog_ExecOperation_ImportNetProtocolList_Nvar = "导入网络协议列表信息";
        public static readonly string Key_I_LocalLog_ExecOperation_ExportNetProtocolList_Nvar = "导出网络协议列表信息";

        public static readonly string Key_I_LocalLog_ExecOperation_UpNetModelInWorkStationInfo_Nvar = "修改网络模型中工作站信息";
        public static readonly string Key_I_LocalLog_ExecOperation_UpNetModelInControlorInfo_Nvar = "修改网络模型中控制器信息";
        public static readonly string Key_I_LocalLog_ExecOperation_UpNetModelInNetInfo_Nvar = "修改网络模型中网络信息";
        public static readonly string Key_I_LocalLog_ExecOperation_UpNetModelInFirewallInfo_Nvar = "修改网络模型中防火期信息";
        public static readonly string Key_I_LocalLog_ExecOperation_UpNetModelInNetEquipInfo_Nvar = "修改网络模型中网络设备信息";

        public static readonly string Key_I_LocalLog_ExecOperation_LoadNetFirewallNormalRuleList_Nvar = "加载防火墙一般规则列表";
        public static readonly string Key_I_LocalLog_ExecOperation_AddNetFirewallNormalRule_Nvar = "增加防火墙一般规则";
        public static readonly string Key_I_LocalLog_ExecOperation_DelNetFirewallNormalRule_Nvar = "删除防火墙一般规则";
        public static readonly string Key_I_LocalLog_ExecOperation_UpNetFirewallNormalRuleInfo_Nvar = "修改防火墙一般规则信息";
        public static readonly string Key_I_LocalLog_ExecOperation_ImportNetFirewallNormalRuleList_Nvar = "导入防火墙一般规则列表信息";
        public static readonly string Key_I_LocalLog_ExecOperation_ExportNetFirewallNormalRuleList_Nvar = "导出防火墙一般规则列表信息";
        public static readonly string Key_I_LocalLog_ExecOperation_CommitNetFirewallNormalRuleList_Nvar = "提交防火墙一般规则列表信息";

        public static readonly string Key_I_LocalLog_ExecOperation_LoadNetFirewallIndustrialRuleList_Nvar = "加载防火墙工业规则列表";
        public static readonly string Key_I_LocalLog_ExecOperation_AddNetFirewallIndustrialRule_Nvar = "增加防火墙工业规则";
        public static readonly string Key_I_LocalLog_ExecOperation_DelNetFirewallIndustrialRule_Nvar = "删除防火墙工业规则";
        public static readonly string Key_I_LocalLog_ExecOperation_UpNetFirewallIndustrialRuleInfo_Nvar = "修改防火墙工业规则信息";
        public static readonly string Key_I_LocalLog_ExecOperation_ImportNetFirewallIndustrialRuleList_Nvar = "导入防火墙工业规则列表信息";
        public static readonly string Key_I_LocalLog_ExecOperation_ExportNetFirewallIndustrialRuleList_Nvar = "导出防火墙工业规则列表信息";
        public static readonly string Key_I_LocalLog_ExecOperation_CommitNetFirewallIndustrialRuleList_Nvar = "提交防火墙工业规则列表信息";

        public static readonly string Key_I_LocalLog_ExecOperation_LoadNetFirewallMACAddressBindingList_Nvar = "加载防火墙MAC地址绑定信息列表";
        public static readonly string Key_I_LocalLog_ExecOperation_SaveNetFirewallMACAddressBinding_Nvar = "保存防火墙MAC地址绑定信息列表";

        public static readonly string Key_I_LocalLog_ExecOperation_Exec_Nvar = "执行操作";
        public static readonly string Key_I_LocalLog_ExecOperation_SendCommand_Nvar = "向下位机发送指令";
        public static readonly string Key_I_LocalLog_ExecOperation_ReceiveCommand_Nvar = "接收下位机上传信息";
        //---------------------------------

        public static readonly string Key_I_LocalLog_ExecResult_Success_Nvar = "操作成功";
        public static readonly string Key_I_LocalLog_ExecResult_Failure_Nvar = "操作错误";


        public static readonly string Key_I_LocalLog_ExecSocketCommunicateOperation_Exec_Nvar = "与下位机通信";
        public static readonly string Key_I_LocalLog_ExecSocketCommunicateOperation_SendCommand_Nvar = "上位机主叫";
        public static readonly string Key_I_LocalLog_ExecSocketCommunicateOperation_ReceiveCommand_Nvar = "下位机发信息";

        public static readonly string Key_I_LocalLog_ExecSocketCommunicateResult_Success_Nvar = "与下位机通信正常";
        public static readonly string Key_I_LocalLog_ExecSocketCommunicateResult_Failure_Nvar = "与下位机通信错误";
        public static readonly string Key_I_LocalLog_ExecSocketCommunicateResult_OtherMessage_Nvar = "与下位机通信返回其他信息";
        public static readonly string Key_I_LocalLog_ExecSocketCommunicateResult_NotNormal_Nvar = "与下位机通信不正常";


        public static readonly string Key_Pro_ReturnOut_Int = "returnOut";

        
        public static readonly string Key_T_S_UserManager_TableName = "T_S_UserManager";

        public static readonly string Key_T_S_UserManager_User_ID_Nvar = "User_ID";
        public static readonly string Key_T_S_UserManager_User_Name_Nvar = "User_Name";
        public static readonly string Key_T_S_UserManager_User_Password_Nvar = "User_Password";

        public static readonly string Key_T_S_UserManager_XML_NodeName_Nvar = "User";

        //系统表--角色表
        public static readonly string Key_T_S_UserRole_TableName = "T_S_UserRole";

        public static readonly string Key_T_S_UserRole_Role_ID_Nvar = "Role_ID";
        public static readonly string Key_T_S_UserRole_Role_Name_Nvar = "Role_Name";

        public static readonly string Key_T_S_UserRole_XML_NodeName_Nvar = "Role";

        //系统表--操作日志记录表
        public static readonly string Key_T_S_ControlLogManager_TableName = "T_S_ControlLogManager";

        public static readonly string Key_T_S_ControlLogManager_ContolLog_ID_Int = "ContolLog_ID";
        public static readonly string Key_T_S_ControlLogManager_ContolLog_UserID_Nvar = "ContolLog_UserID";
        public static readonly string Key_T_S_ControlLogManager_ContolLog_UserIP_Nvar = "ContolLog_UserIP";
        public static readonly string Key_T_S_ControlLogManager_ContolLog_Time_DateTime = "ContolLog_Time";
        public static readonly string Key_T_S_ControlLogManager_ContolLog_TableName_Nvar = "ContolLog_TableName";
        public static readonly string Key_T_S_ControlLogManager_ContolLog_Command_Nvar = "ContolLog_Command";
        public static readonly string Key_T_S_ControlLogManager_ContolLog_Remark_Nvar = "ContolLog_Remark";

        //系统表--执行错误记录表
        public static readonly string Key_T_S_ExecErrManager_TableName = "T_S_ExecErrManager";

        public static readonly string Key_T_S_ExecErrManager_ExecErr_ID_Int = "ExecErr_ID";
        public static readonly string Key_T_S_ExecErrManager_ExecErr_UserID_Nvar = "ExecErr_UserID";
        public static readonly string Key_T_S_ExecErrManager_ExecErr_UserIP_Nvar = "ExecErr_UserIP";
        public static readonly string Key_T_S_ExecErrManager_ExecErr_Time_DateTime = "ExecErr_Time";
        public static readonly string Key_T_S_ExecErrManager_ExecErr_TableName_Nvar = "ExecErr_TableName";
        public static readonly string Key_T_S_ExecErrManager_ExecErr_Command_Nvar = "ExecErr_Command";
        public static readonly string Key_T_S_ExecErrManager_ExecErr_Explain_Nvar = "ExecErr_Explain";
        public static readonly string Key_T_S_ExecErrManager_ExecErr_Remark_Nvar = "ExecErr_Remark";
        public static readonly string Key_T_S_ExecErrManager_ExecErr_State_Bool = "ExecErr_State";
        public static readonly string Key_T_S_ExecErrManager_ExecErr_StateName_Nvar = "ExecErr_StateName";


        //针对具体设计内容
        //部门表      
        public static readonly string Key_T_A_DeptManager_TableName = "T_A_DeptManager";

        public static readonly string Key_T_A_DeptManager_Dept_ID_Nvar = "Dept_ID";
        public static readonly string Key_T_A_DeptManager_Dept_Name_Nvar = "Dept_Name";
        public static readonly string Key_T_A_DeptManager_Dept_Description_Nvar = "Dept_Description";

        public static readonly string Key_T_A_DeptManager_XML_NodeName_Nvar = "Dept";

        //员工表
        public static readonly string Key_T_A_EmployeeManager_TableName = "T_A_EmployeeManager";

        public static readonly string Key_T_A_EmployeeManager_Employee_ID_Nvar = "Employee_ID";
        public static readonly string Key_T_A_EmployeeManager_Employee_Name_Nvar = "Employee_Name";
        public static readonly string Key_T_A_EmployeeManager_Employee_Gender_Nvar = "Employee_Gender";
        public static readonly string Key_T_A_EmployeeManager_Employee_Gender_Show_Nvar = "Employee_Gender_Show";
        public static readonly string Key_T_A_EmployeeManager_Employee_Birthday_DateTime = "Employee_Birthday";

        public static readonly string Key_T_A_EmployeeManager_XML_NodeName_Nvar = "Employee";

        //职务表
        public static readonly string Key_T_A_PositionManager_TableName = "T_A_PositionManager";

        public static readonly string Key_T_A_PositionManager_Position_ID_Nvar = "Position_ID";
        public static readonly string Key_T_A_PositionManager_Position_Name_Nvar = "Position_Name";

        public static readonly string Key_T_A_PositionManager_XML_NodeName_Nvar = "Position";

        //工程项目记录管理
        public static readonly string Key_T_A_ProjectManager_TableName = "T_A_ProjectManager";

        public static readonly string Key_T_A_ProjectManager_Project_ID_Nvar = "Project_ID";
        public static readonly string Key_T_A_ProjectManager_Project_Name_Nvar = "Project_Name";
        public static readonly string Key_T_A_ProjectManager_Project_InitPath_Nvar = "Project_InitPath";
        public static readonly string Key_T_A_ProjectManager_Project_MakeDateTime_DateTime = "Project_MakeDateTime";
        public static readonly string Key_T_A_ProjectManager_Project_EditDateTime_DateTime = "Project_EditDateTime";

        public static readonly string Key_T_A_ProjectManager_XML_NodeName_Nvar = "Project";

        //创建的项目信息
        public static readonly string Key_T_A_ProjectManager_Project_CurrentPath_Nvar = "Project_CurrentPath";
        public static readonly string Key_T_A_ProjectManager_Project_EditMode_Int = "Project_EditMode";

        //设备类型表
        public static readonly string Key_T_A_EQP_TYPE_TableName = "T_A_EQP_TYPE";

        public static readonly string Key_T_A_EQP_TYPE_EQUIP_TYPE_ID_Nvar = "EQUIP_TYPE_ID";
        public static readonly string Key_T_A_EQP_TYPE_EQUIP_TYPE_DESC_Nvar = "EQUIP_TYPE_DESC";
        public static readonly string Key_T_A_EQP_TYPE_EQUIP_TYPE_PIC_Path_Nvar = "EQUIP_TYPE_PIC_Path";
        public static readonly string Key_T_A_EQP_TYPE_EQUIP_TYPE_PIC_ICO_Img = "EQUIP_TYPE_PIC_ICO";

        public static readonly string Key_T_A_EQP_TYPE_XML_NodeName_Nvar = "EQP_TYPE";

        //虚拟设备模型表
        public static readonly string Key_T_A_VIRTUAL_EQP_MODEL_TableName = "T_A_VIRTUAL_EQP_MODEL";
        public static readonly string Key_T_A_VIRTUAL_EQP_MODEL_EQUIP_MODEL_ID_Nvar = "VIRTUAL_EQUIP_MODEL_ID";
        public static readonly string Key_T_A_VIRTUAL_EQP_MODEL_EQUIP_MODEL_DESC_Nvar = "VIRTUAL_EQUIP_MODEL_DESC";

        public static readonly string Key_T_A_VIRTUAL_EQP_MODEL_XML_NodeName_Nvar = "VIRTUAL_EQP_MODEL";

        
        //上位机控制参数
        public static readonly string Key_T_S_Uppermonitor_ControlParameters_NetCommunicationPortCode_Int = "NetCommunicationPortCode";
        public static readonly string Key_T_S_Uppermonitor_ControlParameters_NetSourceCommunicationPortCode_Int = "NetSourceCommunicationPortCode";
        public static readonly string Key_T_S_Uppermonitor_ControlParameters_NetDestinationCommunicationPortCode_Int = "NetDestinationCommunicationPortCode";
        
        public static readonly string Key_T_S_Uppermonitor_ControlParameters_IPAddress_Nvar = "IPAddress";
        public static readonly string Key_T_S_Uppermonitor_ControlParameters_MACAddress_Nvar = "MACAddress";
        public static readonly string Key_T_S_Uppermonitor_ControlParameters_IPAddressSubnetMask_Nvar = "IPAddressSubnetMask";
        public static readonly string Key_T_S_Uppermonitor_ControlParameters_DefaultGateway_Nvar = "DefaultGateway";

        public static readonly string Key_T_S_Uppermonitor_ControlParameters_ConnectionState_ID_Nvar = "ConnectionState_ID";
        public static readonly string Key_T_S_Uppermonitor_ControlParameters_ConnectionState_Name_Nvar = "ConnectionState_Name";

        public static readonly string Key_T_S_Uppermonitor_ControlParameters_NetFirewallRunMode_ID_Nvar = "NetFirewallRunMode_ID";
        public static readonly string Key_T_S_Uppermonitor_ControlParameters_NetFirewallRunMode_Name_Nvar = "NetFirewallRunMode_Name";

        //协议类型管理表
        public static readonly string Key_T_A_NetProtocol_TableName = "T_A_NetProtocol";
        public static readonly string Key_T_A_NetProtocol_NetProtocol_ID_Nvar = "NetProtocol_ID";
        public static readonly string Key_T_A_NetProtocol_NetProtocol_Name_Nvar = "NetProtocol_Name";
        public static readonly string Key_T_A_NetProtocol_NetProtocol_Type_ID_Nvar = "NetProtocol_Type_ID";

        public static readonly string Key_T_A_NetProtocol_XML_NodeName_Nvar = "NetProtocol";

        //网络模型中的工作站信息
        public static readonly string Key_T_A_WorkStationInModel_TableName = "T_A_WorkStationInModel";
        public static readonly string Key_T_A_WorkStationInModel_WorkStation_ID_Nvar = "WorkStation_ID";
        public static readonly string Key_T_A_WorkStationInModel_WorkStation_Name_Nvar = "WorkStation_Name";
        public static readonly string Key_T_A_WorkStationInModel_WorkStation_DESC_Nvar = "WorkStation_DESC";

        public static readonly string Key_T_A_WorkStationInModel_XML_NodeName_Nvar = "WorkStationInModel";

        //网络模型中的网络控制设备信息
        public static readonly string Key_T_A_NetEquipControlerInModel_TableName = "T_A_NetEquipControlerInModel";
        public static readonly string Key_T_A_NetEquipControlerInModel_NetEquipControler_ID_Nvar = "NetEquipControler_ID";
        public static readonly string Key_T_A_NetEquipControlerInModel_NetEquipControler_Name_Nvar = "NetEquipControler_Name";
        public static readonly string Key_T_A_NetEquipControlerInModel_NetEquipControler_DESC_Nvar = "NetEquipControler_DESC";

        public static readonly string Key_T_A_NetEquipControlerInModel_XML_NodeName_Nvar = "NetEquipControlerInModel";

        //网络模型中的网络信息
        public static readonly string Key_T_A_NetInModel_TableName = "T_A_NetInModel";
        public static readonly string Key_T_A_NetInModel_Net_ID_Nvar = "Net_ID";
        public static readonly string Key_T_A_NetInModel_Net_Name_Nvar = "Net_Name";

        public static readonly string Key_T_A_NetInModel_XML_NodeName_Nvar = "NetInModel";


        //网络模型中的防火墙信息
        public static readonly string Key_T_A_NetFirewallInModel_TableName = "T_A_NetFirewallInModel";
        public static readonly string Key_T_A_NetFirewallInModel_NetFirewall_ID_Nvar = "NetFirewall_ID";
        public static readonly string Key_T_A_NetFirewallInModel_NetFirewall_Name_Nvar = "NetFirewall_Name";
        public static readonly string Key_T_A_NetFirewallInModel_NetFirewall_DESC_Nvar = "NetFirewall_DESC";
        public static readonly string Key_T_A_NetFirewallInModel_NetFirewallDevice_ID_Nvar = "NetFirewallDevice_ID";

        public static readonly string Key_T_A_NetFirewallInModel_XML_NodeName_Nvar = "NetFirewallInModel";


        //网络模型中的网络设备信息
        public static readonly string Key_T_A_NetEquipInModel_TableName = "T_A_NetEquipInModel";
        public static readonly string Key_T_A_NetEquipInModel_NetEquip_ID_Nvar = "NetEquip_ID";
        public static readonly string Key_T_A_NetEquipInModel_NetEquip_Name_Nvar = "NetEquip_Name";
        public static readonly string Key_T_A_NetEquipInModel_NetEquip_DESC_Nvar = "NetEquip_DESC";

        public static readonly string Key_T_A_NetEquipInModel_XML_NodeName_Nvar = "NetEquipInModel";

        //网络模型中节点记录信息
        public static readonly string Key_T_A_NetNodeRecordInModel_TableName = "T_A_NetNodeRecordInModel";
        public static readonly string Key_T_A_NetNodeRecordInModel_NetNode_ID_Nvar = "NetNode_ID";
        public static readonly string Key_T_A_NetNodeRecordInModel_NetNode_Name_Nvar = "NetNode_Name";
        public static readonly string Key_T_A_NetNodeRecordInModel_NetConnection_ID_Nvar = "NetConnection_ID";
        public static readonly string Key_T_A_NetNodeRecordInModel_Father_NetConnection_ID_Nvar = "Father_NetConnection_ID";
        public static readonly string Key_T_A_NetNodeRecordInModel_Father_NetNode_ID_Nvar = "Father_NetNode_ID";
        public static readonly string Key_T_A_NetNodeRecordInModel_NetNode_Level_Int = "NetNode_Level";

        public static readonly string Key_T_A_NetNodeRecordInModel_XML_NodeName_Nvar = "NetNodeRecordInModel";

        //本地日志记录表
        public static readonly string Key_T_S_LocalLog_TableName = "T_S_LocalLog";
        public static readonly string Key_T_S_LocalLog_LocalLog_ID_Nvar = "LocalLog_ID";
        public static readonly string Key_T_S_LocalLog_LocalLog_Time_DateTime = "LocalLog_Time";
        public static readonly string Key_T_S_LocalLog_LocalLog_UserID_Nvar = "LocalLog_UserID";
        public static readonly string Key_T_S_LocalLog_LocalLog_UserName_Nvar = "LocalLog_UserName";
        public static readonly string Key_T_S_LocalLog_LocalLog_ExecOperation_Nvar = "LocalLog_ExecOperation";
        public static readonly string Key_T_S_LocalLog_LocalLog_ExecResult_Nvar = "LocalLog_ExecResult";
        public static readonly string Key_T_S_LocalLog_LocalLog_Description_Nvar = "LocalLog_Description";

        public static readonly string Key_T_S_LocalLog_XML_NodeName_Nvar = "LocalLog";

        //防火墙日志
        public static readonly string Key_T_S_FirewallLog_TableName = "T_S_FirewallLog";
        public static readonly string Key_T_S_FirewallLog_FirewallLog_ID_Nvar = "FirewallLog_ID";
        public static readonly string Key_T_S_FirewallLog_FirewallLog_Time_DateTime = "FirewallLog_Time";
        public static readonly string Key_T_S_FirewallLog_Source_IPAddress_Nvar = "Source_IPAddress";
        public static readonly string Key_T_S_FirewallLog_Source_Port_Int = "Source_Port";
        public static readonly string Key_T_S_FirewallLog_Destination_IPAddress_Nvar = "Destination_IPAddress";
        public static readonly string Key_T_S_FirewallLog_Destination_Port_Int = "Destination_Port";
        public static readonly string Key_T_S_FirewallLog_FirewallRule_ID_Nvar = "FirewallRule_ID";
        //public static readonly string Key_T_S_FirewallLog_FirewallRuleType_ID_Nvar = "FirewallRuleType_ID";
        public static readonly string Key_T_S_FirewallLog_FirewallLogType_ID_Nvar = "FirewallLogType_ID";

        public static readonly string Key_T_S_FirewallLog_XML_NodeName_Nvar = "FirewallLog";

        //报警日志
        public static readonly string Key_T_S_AlarmLog_TableName = "T_S_AlarmLog";
        public static readonly string Key_T_S_AlarmLog_AlarmLog_ID_Nvar = "AlarmLog_ID";
        public static readonly string Key_T_S_AlarmLog_XML_NodeName_Nvar = "AlarmLog";      

        //消息日志
        public static readonly string Key_T_S_MessageLog_TableName = "T_S_MessageLog";
        public static readonly string Key_T_S_MessageLog_MessageLog_ID_Nvar = "MessageLog_ID";
    
        public static readonly string Key_T_S_MessageLog_XML_NodeName_Nvar = "MessageLog";

        //其他日志
        public static readonly string Key_T_S_OtherLog_TableName = "T_S_OtherLog";
        public static readonly string Key_T_S_OtherLog_OtherLog_ID_Nvar = "OtherLog_ID";
 
        public static readonly string Key_T_S_OtherLog_XML_NodeName_Nvar = "OtherLog";

        //网络防火墙规则类型信息
        public static readonly string Key_T_A_FirewallRuleType_FirewallRuleType_ID_Nvar = "FirewallRuleType_ID";

        //网络防火墙规则权限信息
        public static readonly string Key_T_A_FirewallNormalRule_FirewallRulePower_ID_Nvar = "FirewallRulePower_ID";
        public static readonly string Key_T_A_FirewallNormalRule_FirewallRulePower_Name_Nvar = "FirewallRulePower_Name";

        public static readonly string Key_T_A_FirewallNormalRule_FirewallRuleOrientation_ID_Nvar = "FirewallRuleOrientation_ID";
        public static readonly string Key_T_A_FirewallNormalRule_FirewallRuleOrientation_Name_Nvar = "FirewallRuleOrientation_Name";

        //网络防火墙一般规则
        public static readonly string Key_T_A_FirewallNormalRule_TableName = "T_A_FirewallNormalRule";
        public static readonly string Key_T_A_FirewallNormalRule_FirewallNormalRule_ID_Nvar = "FirewallNormalRule_ID";

       
        public static readonly string Key_T_A_FirewallNormalRule_Source_NetNode_ID_Nvar = "Source_NetNode_ID";
        public static readonly string Key_T_A_FirewallNormalRule_Source_IPAddress_Nvar = "Source_IPAddress";
        public static readonly string Key_T_A_FirewallNormalRule_Source_MACAddress_Nvar = "Source_MACAddress";
        public static readonly string Key_T_A_FirewallNormalRule_Source_Part_Int = "Source_Part";

        public static readonly string Key_T_A_FirewallNormalRule_Destination_NetNode_ID_Nvar = "Destination_NetNode_ID";        
        public static readonly string Key_T_A_FirewallNormalRule_Destination_IPAddress_Nvar = "Destination_IPAddress";
        public static readonly string Key_T_A_FirewallNormalRule_Destination_Part_Int = "Destination_Part";

        public static readonly string Key_T_A_FirewallNormalRule_XML_NodeName_Nvar = "FirewallNormalRule";

        public static readonly string Key_T_F_FirewallNormalRuleTempFile_FileName = "FirewallNormalRuleTempFile";


        //网络防火墙工业规则
        public static readonly string Key_T_A_FirewallIndustrialRule_TableName = "T_A_FirewallIndustrialRule";
        public static readonly string Key_T_A_FirewallIndustrialRule_FirewallIndustrialRule_ID_Nvar = "FirewallIndustrialRule_ID";

        public static readonly string Key_T_A_FirewallIndustrialRule_SafetyZone_NetNode_ID_Nvar = "SafetyZone_NetNode_ID";
        public static readonly string Key_T_A_FirewallIndustrialRule_SafetyZone_IPAddress_Nvar = "SafetyZone_IPAddress";

        public static readonly string Key_T_A_FirewallIndustrialRule_UnSafetyZone_NetNode_ID_Nvar = "UnSafetyZone_NetNode_ID";
        public static readonly string Key_T_A_FirewallIndustrialRule_UnSafetyZone_IPAddress_Nvar = "UnSafetyZone_IPAddress";
        public static readonly string Key_T_A_FirewallIndustrialRule_UnSafetyZone_MACAddress_Nvar = "UnSafetyZone_MACAddress";

        public static readonly string Key_T_A_FirewallIndustrialRule_IsOrNotIncludingDeepRule_Int = "IsOrNotIncludingDeepRule";

        public static readonly string Key_T_A_FirewallIndustrialRule_XML_NodeName_Nvar = "FirewallIndustrialRule";

        public static readonly string Key_T_F_FirewallIndustrialRuleTempFile_FileName = "FirewallIndustrialRuleTempFile";

        //网络防火墙工业规则深度规则
        public static readonly string Key_T_A_FirewallDeepRule_TableName = "T_A_FirewallDeepRule";
        public static readonly string Key_T_A_FirewallDeepRule_FirewallDeepRule_RecordCode_Nvar = "FirewallDeepRule_RecordCode";
        
        public static readonly string Key_T_A_FirewallDeepRuleTemplate_TableName = "T_A_FirewallDeepRuleTemplate";
        public static readonly string Key_T_A_FirewallDeepRule_FirewallDeepRule_ID_Nvar = "FirewallDeepRule_ID";
        public static readonly string Key_T_A_FirewallDeepRule_FirewallDeepRule_Name_Nvar = "FirewallDeepRule_Name";
        public static readonly string Key_T_A_FirewallDeepRule_FirewallDeepRule_IDAndName_Nvar = "FirewallDeepRule_IDAndName";

        public static readonly string Key_T_A_FirewallDeepRuleSonNodeTemplate_TableName = "T_A_FirewallDeepRuleSonNodeTemplate";
        public static readonly string Key_T_A_FirewallDeepRule_FirewallDeepRule_SonNode_ID_Nvar = "FirewallDeepRule_SonNode_ID";
        public static readonly string Key_T_A_FirewallDeepRule_FirewallDeepRule_SonNode_Name_Nvar = "FirewallDeepRule_SonNode_Name";
        public static readonly string Key_T_A_FirewallDeepRule_FirewallDeepRule_SonNode_Value_Nvar = "FirewallDeepRule_SonNode_Value";

        public static readonly string Key_T_A_FirewallDeepRuleRecord_XML_NodeName_Nvar = "FirewallDeepRuleRecord";
        public static readonly string Key_T_A_FirewallDeepRule_XML_NodeName_Nvar = "FirewallDeepRule";
        public static readonly string Key_T_A_FirewallDeepRuleSonNode_XML_NodeName_Nvar = "FirewallDeepRuleSonNode";

        

        //网络防火墙MAC地址绑定记录
        public static readonly string Key_T_A_FirewallMACAddressBinding_TableName = "T_A_FirewallMACAddressBinding";
        public static readonly string Key_T_A_FirewallMACAddressBinding_FirewallMACAddressBinding_RecordCode_Nvar = "FirewallMACAddressBinding_RecordCode";
        public static readonly string Key_T_A_FirewallMACAddressBinding_FirewallMACAddressBinding_IsOrNotBinding_Bool = "FirewallMACAddressBinding_IsOrNotBinding";
        public static readonly string Key_T_A_FirewallMACAddressBinding_FirewallMACAddressBinding_IsOrNotBinding_Show_Nvar = "FirewallMACAddressBinding_IsOrNotBinding_Show";

        public static readonly string Key_T_A_FirewallMACAddressBinding_XML_NodeName_Nvar = "FirewallMACAddressBinding";

        public static readonly string Key_T_F_ProjectTempFile_FileName = "ProjectTempFile";
    }
}
