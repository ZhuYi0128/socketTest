using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace socketTest.Common
{
    class CDataLocalLogInfo
    {
        public static string GLocalLogFilePathInfo = "";

        public static bool getLocalLogIDMaxValueInfo(string varColName, int varFKSign, ref string varMaxValue,
                                         int varUseFileSign, ref string varErrorStr)
        {
            bool backSign = false;
            string stDefaultValue = "";

            XmlControl.CXDocumentControl ACXDocumentControl = new XmlControl.CXDocumentControl();

            string sRootNode = CCommon.Key_XML_RootNode_Nvar;
            string sNodeKeyName = CCommon.Key_T_S_LocalLog_XML_NodeName_Nvar;
            string sFilePathInfo = "";

            try
            {
                stDefaultValue = "0000000001";

                if (!GetXmlFilePathByUseFilePathKind(GLocalLogFilePathInfo, varUseFileSign, ref sFilePathInfo, ref varErrorStr))
                {
                    return backSign;
                }

                if (ACXDocumentControl.GetSingleFieldNewMaxValue(sFilePathInfo, sRootNode, sNodeKeyName,
                                  varColName, varFKSign, "10", 1, stDefaultValue,
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

        private static bool GetXmlFilePathByUseFilePathKind(string varJoinFilePathInfo, int varUseFilePathKindSign, ref string varGetFilePathInfo, ref string varErrorStr)
        {
            bool backSign = false;

            XmlControl.CXDocumentControl ACXDocumentControl = new XmlControl.CXDocumentControl();

            string sSaveSubFolderName1 = CCommon.Key_XML_Path_ProjectManagerData_Nvar + @"\" + CCommon.Key_XML_Path_SecondLevel_LocalLogData_Nvar;
            string sSaveSubFolderName2 = CCommon.Key_XML_Path_ProjectApplicationData_Nvar + @"\" + CCommon.Key_XML_Path_SecondLevel_LocalLogData_Nvar;


            try
            {
                //程序自构造文件路径和路径
                if (varUseFilePathKindSign == 0)
                {
                    if (ACXDocumentControl.getXmlFilePath(CCommon.Key_T_S_LocalLog_TableName, sSaveSubFolderName1, ref varGetFilePathInfo, ref varErrorStr))
                    {
                        backSign = true;
                    }
                }

                //外部输入文件路径，自己构造完整文件路径和文件名
                if (varUseFilePathKindSign == 1)
                {
                    if (ACXDocumentControl.getXmlFilePath2(CCommon.Key_T_S_LocalLog_TableName, sSaveSubFolderName2, varJoinFilePathInfo, ref varGetFilePathInfo, ref varErrorStr))
                    {
                        backSign = true;
                    }
                }

                //外部直接输入完整文件路径和文件名
                if (varUseFilePathKindSign == 2)
                {
                    backSign = true;
                }
                return backSign;
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        public static bool insertLocalLogRecord(ref Entity.EntityLocalLogInfo varEInfo, int varUseFileSign, ref string varErrorStr)
        {
            bool backSign = false;

            XmlControl.CXDocumentControl ACXDocumentControl = new XmlControl.CXDocumentControl();

            string sRootNode = CCommon.Key_XML_RootNode_Nvar;
            string sNodeKeyName = CCommon.Key_T_S_LocalLog_XML_NodeName_Nvar;
            string sFilePathInfo = "";

            try
            {
                if (!GetXmlFilePathByUseFilePathKind(GLocalLogFilePathInfo, varUseFileSign, ref sFilePathInfo, ref varErrorStr))
                {
                    return backSign;
                }

                string[] sLInformationName = new string[7];
                sLInformationName[0] = CCommon.Key_T_S_LocalLog_LocalLog_ID_Nvar;
                sLInformationName[1] = CCommon.Key_T_S_LocalLog_LocalLog_Time_DateTime;
                sLInformationName[2] = CCommon.Key_T_S_LocalLog_LocalLog_UserID_Nvar;
                sLInformationName[3] = CCommon.Key_T_S_LocalLog_LocalLog_UserName_Nvar;
                sLInformationName[4] = CCommon.Key_T_S_LocalLog_LocalLog_ExecOperation_Nvar;
                sLInformationName[5] = CCommon.Key_T_S_LocalLog_LocalLog_ExecResult_Nvar;
                sLInformationName[6] = CCommon.Key_T_S_LocalLog_LocalLog_Description_Nvar;

                string[] sLInformationValue = new string[7];
                sLInformationValue[0] = varEInfo.LocalLog_ID;
                sLInformationValue[1] = varEInfo.LocalLog_Time.ToString("yyyy-MM-dd HH:mm:ss"); ;
                sLInformationValue[2] = varEInfo.LocalLog_UserID;
                sLInformationValue[3] = varEInfo.LocalLog_UserName;
                sLInformationValue[4] = varEInfo.LocalLog_ExecOperation;
                sLInformationValue[5] = varEInfo.LocalLog_ExecResult;
                sLInformationValue[6] = varEInfo.LocalLog_Description;

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
