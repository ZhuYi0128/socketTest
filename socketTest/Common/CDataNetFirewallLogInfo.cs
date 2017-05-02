using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace socketTest.Common
{
    class CDataNetFirewallLogInfo
    {
        private XmlControl.CXDocumentControl ACXDocumentControl = new XmlControl.CXDocumentControl();

        private string sSaveSubFolderName1 = CCommon.Key_XML_Path_ProjectManagerData_Nvar + @"\" + CCommon.Key_XML_Path_SecondLevel_LocalLogData_Nvar;
        private string sSaveSubFolderName2 = CCommon.Key_XML_Path_ProjectApplicationData_Nvar + @"\" + CCommon.Key_XML_Path_SecondLevel_LocalLogData_Nvar;
        private string sRootNode = CCommon.Key_XML_RootNode_Nvar;
        private string sNodeKeyName = CCommon.Key_T_S_FirewallLog_XML_NodeName_Nvar;
        private string sFilePathInfo = "";

        private string _FilePathInfo = "";

        public string HandleFilePathInfo
        {
            get
            {
                return _FilePathInfo;
            }

            set
            {
                _FilePathInfo = value;
            }
        }


        public bool GetXmlFilePathByUseFilePathKind(string varJoinFilePathInfo, int varUseFilePathKindSign, ref string varGetFilePathInfo, ref string varErrorStr)
        {
            bool backSign = false;

            try
            {
                //程序自构造文件路径和路径
                if (varUseFilePathKindSign == 0)
                {
                    if (ACXDocumentControl.getXmlFilePath(CCommon.Key_T_S_FirewallLog_TableName, sSaveSubFolderName1, ref varGetFilePathInfo, ref varErrorStr))
                    {
                        backSign = true;
                    }
                }

                //外部输入文件路径，自己构造完整文件路径和文件名
                if (varUseFilePathKindSign == 1)
                {
                    if (ACXDocumentControl.getXmlFilePath2(CCommon.Key_T_S_FirewallLog_TableName, sSaveSubFolderName2, varJoinFilePathInfo, ref varGetFilePathInfo, ref varErrorStr))
                    {
                        backSign = true;
                    }
                }

                //外部直接输入完整文件路径和文件名
                if (varUseFilePathKindSign == 2)
                {
                    sFilePathInfo = varJoinFilePathInfo;
                    backSign = true;
                }
                return backSign;
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        public bool GetLastRecordFirewallLogByFirewallID(ref DataTable varDT, string varFirewallID, int varUseFileSign, ref string varErrorStr)
        {
            bool backSign = false;

            try
            {
                if (!GetXmlFilePathByUseFilePathKind(_FilePathInfo, varUseFileSign, ref sFilePathInfo, ref varErrorStr))
                {
                    return backSign;
                }

                string[] sLColName = new string[13];
                sLColName[0] = CCommon.Key_T_S_FirewallLog_FirewallLog_ID_Nvar;
                sLColName[1] = CCommon.Key_T_S_FirewallLog_FirewallLog_Time_DateTime;
                sLColName[2] = CCommon.Key_T_S_FirewallLog_Source_IPAddress_Nvar;
                sLColName[3] = CCommon.Key_T_S_FirewallLog_Source_Port_Int;
                sLColName[4] = CCommon.Key_T_S_FirewallLog_Destination_IPAddress_Nvar;
                sLColName[5] = CCommon.Key_T_S_FirewallLog_Destination_Port_Int;
                sLColName[6] = CCommon.Key_T_S_FirewallLog_FirewallRule_ID_Nvar;
                sLColName[7] = CCommon.Key_T_A_NetProtocol_NetProtocol_ID_Nvar;
                sLColName[8] = CCommon.Key_T_A_NetProtocol_NetProtocol_Name_Nvar;
                sLColName[9] = CCommon.Key_T_S_FirewallLog_FirewallLogType_ID_Nvar;
                sLColName[10] = CCommon.Key_T_A_NetFirewallInModel_NetFirewall_ID_Nvar;
                sLColName[11] = CCommon.Key_T_A_NetFirewallInModel_NetFirewall_Name_Nvar;
                sLColName[12] = CCommon.Key_T_S_Uppermonitor_ControlParameters_IPAddress_Nvar;

                string[] sLColTypeName = new string[13];
                sLColTypeName[0] = CCommon.Key_I_ColTypeName_String_Nvar;
                sLColTypeName[1] = CCommon.Key_I_ColTypeName_DateTime_Nvar;
                sLColTypeName[2] = CCommon.Key_I_ColTypeName_String_Nvar;
                sLColTypeName[3] = CCommon.Key_I_ColTypeName_Int_Nvar;
                sLColTypeName[4] = CCommon.Key_I_ColTypeName_String_Nvar;
                sLColTypeName[5] = CCommon.Key_I_ColTypeName_Int_Nvar;
                sLColTypeName[6] = CCommon.Key_I_ColTypeName_String_Nvar;
                sLColTypeName[7] = CCommon.Key_I_ColTypeName_String_Nvar;
                sLColTypeName[8] = CCommon.Key_I_ColTypeName_String_Nvar;
                sLColTypeName[9] = CCommon.Key_I_ColTypeName_String_Nvar;
                sLColTypeName[10] = CCommon.Key_I_ColTypeName_String_Nvar;
                sLColTypeName[11] = CCommon.Key_I_ColTypeName_String_Nvar;
                sLColTypeName[12] = CCommon.Key_I_ColTypeName_String_Nvar;

                string[,] sLFindALLNodeValueInfo = new string[0, 0];


                if (ACXDocumentControl.readNodeInfoLastNodeBySingleColCondition(sFilePathInfo, sRootNode, sNodeKeyName,
                                                          CCommon.Key_T_A_NetFirewallInModel_NetFirewall_ID_Nvar, varFirewallID, 1,
                                                          1, 0, 0, 1, 0,
                                                          sLColName, 0, ref sLFindALLNodeValueInfo, 0, ref varErrorStr))
                {
                    if (sLFindALLNodeValueInfo.GetLength(0) > 0)
                    {
                        if (ACXDocumentControl.convertArrayToDataTable(ref sLColName, ref sLColTypeName, ref sLFindALLNodeValueInfo, ref varDT, ref varErrorStr))
                        {
                            backSign = true;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }

            return backSign;
        }

        public bool getNetFirewallLogIDMaxValueInfo(string varGetMaxValueColName, int varFKSign,
                                        ref string varMaxValue,
                                        int varUseFileSign, ref string varErrorStr)
        {
            bool backSign = false;
            string stDefaultValue = "";


            try
            {
                stDefaultValue = "000000000000001";

                if (!GetXmlFilePathByUseFilePathKind(_FilePathInfo, varUseFileSign, ref sFilePathInfo, ref varErrorStr))
                {
                    return backSign;
                }

                if (ACXDocumentControl.GetSingleFieldNewMaxValue(sFilePathInfo, sRootNode, sNodeKeyName,
                                  varGetMaxValueColName, varFKSign, "15", 1, stDefaultValue,
                                  ref varMaxValue, 0, ref varErrorStr))
                {
                    backSign = true;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }

            return backSign;
        }

        public bool AddNetFirewallLogAllInfo(ref Entity.EntityFirewallLogInfo varEInfo, int varUseFileSign, ref string varErrorStr)
        {
            bool backSign = false;

            try
            {
                if (!GetXmlFilePathByUseFilePathKind(_FilePathInfo, varUseFileSign, ref sFilePathInfo, ref varErrorStr))
                {
                    return backSign;
                }

                string[] sLInformationName = new string[13];
                sLInformationName[0] = CCommon.Key_T_S_FirewallLog_FirewallLog_ID_Nvar;
                sLInformationName[1] = CCommon.Key_T_S_FirewallLog_FirewallLog_Time_DateTime;
                sLInformationName[2] = CCommon.Key_T_S_FirewallLog_Source_IPAddress_Nvar;
                sLInformationName[3] = CCommon.Key_T_S_FirewallLog_Source_Port_Int;
                sLInformationName[4] = CCommon.Key_T_S_FirewallLog_Destination_IPAddress_Nvar;
                sLInformationName[5] = CCommon.Key_T_S_FirewallLog_Destination_Port_Int;
                sLInformationName[6] = CCommon.Key_T_S_FirewallLog_FirewallRule_ID_Nvar;
                sLInformationName[7] = CCommon.Key_T_A_NetProtocol_NetProtocol_ID_Nvar;
                sLInformationName[8] = CCommon.Key_T_A_NetProtocol_NetProtocol_Name_Nvar;
                sLInformationName[9] = CCommon.Key_T_S_FirewallLog_FirewallLogType_ID_Nvar;
                sLInformationName[10] = CCommon.Key_T_A_NetFirewallInModel_NetFirewall_ID_Nvar;
                sLInformationName[11] = CCommon.Key_T_A_NetFirewallInModel_NetFirewall_Name_Nvar;
                sLInformationName[12] = CCommon.Key_T_S_Uppermonitor_ControlParameters_IPAddress_Nvar;

                string[] sLInformationValue = new string[13];
                sLInformationValue[0] = varEInfo.FirewallLog_ID;
                sLInformationValue[1] = varEInfo.FirewallLog_Time.ToString("yyyy-MM-dd HH:mm:ss");
                sLInformationValue[2] = varEInfo.Source_IPAddress;
                sLInformationValue[3] = varEInfo.Source_Port.ToString();
                sLInformationValue[4] = varEInfo.Destination_IPAddress;
                sLInformationValue[5] = varEInfo.Destination_Port.ToString();
                sLInformationValue[6] = varEInfo.FirewallRule_ID;
                sLInformationValue[7] = varEInfo.NetProtocol_ID;
                sLInformationValue[8] = varEInfo.NetProtocol_Name;
                sLInformationValue[9] = varEInfo.FirewallLogType_ID;
                sLInformationValue[10] = varEInfo.NetFirewall_ID;
                sLInformationValue[11] = varEInfo.NetFirewall_Name;
                sLInformationValue[12] = varEInfo.NetFirewall_IPAddress;

                if (ACXDocumentControl.addSonNodeSingleElementAllInfo(sFilePathInfo, sRootNode,
                                sNodeKeyName, "", sLInformationName, sLInformationValue, 0, 0, ref varErrorStr))
                {
                    backSign = true;
                }

            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }

            return backSign;
        }
    }
}
