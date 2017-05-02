using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace socketTest.CData
{
    class CDataNetFirewallLogControl
    {
        private CPublicControl.CPublicMethod ACPublicMethod = new CPublicControl.CPublicMethod();
        private Common.CDataNetFirewallLogInfo ACDataNetFirewallLogInfo = new Common.CDataNetFirewallLogInfo();

        public bool getLastRecordFirewallLogTimeByFirewallID(ref string varLastRecordFirewallLogTime, string varFirewallID, string varCurrentFileSavePath, int varUseFileSign)
        {
            bool backSign = false;
            string ErrorStr = String.Empty;

            try
            {
                DataTable varDT = new DataTable();

                ACPublicMethod.clearDataTableExistInfo(ref varDT, 1);

                ACDataNetFirewallLogInfo.HandleFilePathInfo = varCurrentFileSavePath;

                if (ACDataNetFirewallLogInfo.GetLastRecordFirewallLogByFirewallID(ref varDT, varFirewallID, varUseFileSign, ref ErrorStr) == true)
                {
                    if (varDT != null)
                    {
                        if (varDT.Rows != null)
                        {
                            if (varDT.Rows.Count > 0)
                            {
                                for (int i = 0; i < varDT.Rows.Count; i++)
                                {
                                    if (varDT.Rows[i][CCommon.Key_T_S_FirewallLog_FirewallLog_Time_DateTime] != null)
                                    {
                                        if (varDT.Rows[i][CCommon.Key_T_S_FirewallLog_FirewallLog_Time_DateTime].ToString().Trim() != String.Empty)
                                        {
                                            varLastRecordFirewallLogTime = (DateTime.Parse(varDT.Rows[i][CCommon.Key_T_S_FirewallLog_FirewallLog_Time_DateTime].ToString())).ToString("yyyyMMddHHmmss");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                varLastRecordFirewallLogTime = "19900101000001";
                            }
                        }
                    }

                    backSign = true;
                }

                if (ErrorStr.Trim() != String.Empty)
                {
                    throw new Exception(ErrorStr);
                }
                else
                {
                    if (ErrorStr.Trim() == String.Empty && varDT != null)
                    {
                        if (varDT.Rows != null)
                        {
                            if (varDT.Rows.Count == 0)
                            {
                                varLastRecordFirewallLogTime = "19900101000001";
                                backSign = true;
                            }
                        }
                    }

                    return backSign;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        public bool GetColMaxValue(string varSelColumnName, int varSelectSign,
                            ref string varColMaxValue, string varCurrentFileSavePath, int varUseFileSign)
        {
            bool backSign = false;
            string ErrorStr = String.Empty;

            try
            {
                ACDataNetFirewallLogInfo.HandleFilePathInfo = varCurrentFileSavePath;

                if (ACDataNetFirewallLogInfo.getNetFirewallLogIDMaxValueInfo(varSelColumnName, varSelectSign,
                                                                       ref varColMaxValue,
                                                                       varUseFileSign, ref ErrorStr))
                {
                    return true;
                }

                if (ErrorStr.Trim() != String.Empty)
                {
                    throw new Exception(ErrorStr);
                }
                else
                {
                    return backSign;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        public bool AddFirewallLogInfo(ref Entity.EntityFirewallLogInfo varInfo, string varCurrentFileSavePath, int varUseFileSign)
        {
            bool backSign = false;
            string ErrorStr = String.Empty;

            try
            {
                ACDataNetFirewallLogInfo.HandleFilePathInfo = varCurrentFileSavePath;

                if (ACDataNetFirewallLogInfo.AddNetFirewallLogAllInfo(ref varInfo, varUseFileSign, ref ErrorStr))
                {
                    backSign = true;
                }

                if (ErrorStr.Trim() != String.Empty)
                {
                    throw new Exception(ErrorStr);
                }
                else
                {
                    return backSign;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
    

    }
}
