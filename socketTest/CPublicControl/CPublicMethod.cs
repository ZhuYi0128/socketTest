using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Diagnostics;
using System.Windows.Controls;

namespace socketTest.CPublicControl
{
    class CPublicMethod
    {
        
        /// <summary>
        /// 获取新的编码方法
        /// </summary>
        /// <param name="varLen">生成字符长度</param>
        /// <param name="varDealDT">要处理的数据表</param>
        /// <param name="varDealColumn">要处理的列</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public string makeNewID(string varLen, ref DataTable varDealDT, string varDealColumn, string defaultValue)
        {
            string strNewEmployeeID = "";

            var d = from treeItem in varDealDT.AsEnumerable()
                    select new { maxValue = Convert.ToInt32(treeItem[varDealColumn]) };

            if (d.Count() > 0)
            {
                strNewEmployeeID = String.Format("{0:D" + varLen + "}", d.Max(p => p.maxValue) + 1);
            }
            else
            {
                strNewEmployeeID = defaultValue;
            }
            return strNewEmployeeID;
        }

        public string makeTwoPartNewID(int varLen, ref DataTable varDealDT, string varDealColumn, int varFirstLen, string varFirstPart, int varSecondLen, string varLinkBreak, string defaultValue)
        {
            string strNewID = "";

            var d = from treeItem in varDealDT.AsEnumerable()
                    where treeItem.Field<string>(varDealColumn).Trim().Substring(0, varFirstLen) == varFirstPart.Trim()
                    select new { maxValue = Convert.ToInt32(treeItem[varDealColumn].ToString().Substring(varLen - varFirstLen - varSecondLen + varFirstLen, varSecondLen)) };


            if (d.Count() > 0)
            {
                strNewID = varFirstPart.ToString() + varLinkBreak + String.Format("{0:D" + varSecondLen.ToString() + "}", d.Max(p => p.maxValue) + 1);
            }
            else
            {
                strNewID = varFirstPart.ToString() + varLinkBreak + defaultValue;
            }
            return strNewID;
        }

        public void clearDataTableExistInfo(ref DataTable varDealDT, int varDataTableClearSign)
        {
            if (varDealDT != null)
            {
                if (varDealDT.Columns != null)
                {
                    if (varDealDT.Columns.Count > 0)
                    {
                        if (varDealDT.Rows != null)
                        {
                            if (varDealDT.Rows.Count > 0)
                            {
                                if (varDataTableClearSign > 0)
                                {
                                    varDealDT.Rows.Clear();
                                    varDealDT.AcceptChanges();
                                }
                            }
                        }

                        if (varDataTableClearSign > 1)
                        {
                            varDealDT.Columns.Clear();
                            varDealDT.AcceptChanges();
                        }
                    }
                }
            }
        }

        public void fullCombBox(ref System.Windows.Controls.ComboBox cbo, ref DataTable varDT, string varDisplayPath, string varValuePath)
        {
            cbo.ItemsSource = null;

            if (null != varDT.Rows)
            {
                if (varDT.Rows.Count > 0)
                {
                    cbo.ItemsSource = varDT.DefaultView;
                    cbo.DisplayMemberPath = varDT.Columns[varDisplayPath].ToString();
                    cbo.SelectedValuePath = varDT.Columns[varValuePath].ToString();
                }
            }
        }

        public void fullCombBox2(ref System.Windows.Controls.ComboBox cbo, ref DataTable varDT, string varDisplayPath, string varValuePath)
        {
            if (null != cbo.Items)
            {
                if (cbo.Items.Count > 0)
                {
                    cbo.Items.Clear();
                }
            }

            if (null != varDT.Rows)
            {
                if (varDT.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow dr in varDT.Rows)
                    {
                        ComboBoxItem cBoxItem = new ComboBoxItem();

                        cBoxItem.Content = dr[varDisplayPath].ToString();
                        cBoxItem.Tag = dr[varValuePath].ToString();

                        cbo.Items.Add(cBoxItem);

                    }
                }
            }
        }


        //public void RecordLocalLogMessage(ref ListView varListView,
        //                                    string strUserID,
        //                                    string strUserName,
        //                                    string strExecOperation,
        //                                    string strExecResult,
        //                                    string strDescription,
        //                                    string varFilePathInfo,
        //                                    int varUseFileSign)             
        //{
        //    string ErrorStr="";

        //    try
        //    {
        //        string stLocalLogIDMaxValue = "";

        //        Common.CDataLocalLogInfo.GLocalLogFilePathInfo = varFilePathInfo;

        //        if (Common.CDataLocalLogInfo.getLocalLogIDMaxValueInfo(CCommon.Key_T_S_LocalLog_LocalLog_ID_Nvar, 0, ref stLocalLogIDMaxValue,
        //                                                               varUseFileSign, ref ErrorStr))
        //        {
        //            Entity.EntityLocalLogInfo varLocalLogInfo = new Entity.EntityLocalLogInfo();
        //            varLocalLogInfo.LocalLog_ID = stLocalLogIDMaxValue;
        //            varLocalLogInfo.LocalLog_Time = DateTime.Now;
        //            varLocalLogInfo.LocalLog_UserID = strUserID.Trim();
        //            varLocalLogInfo.LocalLog_UserName = strUserName.Trim();
        //            varLocalLogInfo.LocalLog_ExecOperation = strExecOperation.Trim();
        //            varLocalLogInfo.LocalLog_ExecResult = strExecResult.Trim();
        //            varLocalLogInfo.LocalLog_Description = strDescription.Trim();

        //            if (Common.CDataLocalLogInfo.insertLocalLogRecord(ref varLocalLogInfo, varUseFileSign, ref ErrorStr))
        //            {
        //                GlobalLogInfo.GlobalProjectLocalLogInfos.Add(varLocalLogInfo);

        //                int iScrollIndex = -1;

        //                if (varListView.Items != null)
        //                {
        //                    if (varListView.Items.Count > 0)
        //                    {
        //                        iScrollIndex = varListView.Items.Count - 1;
        //                        varListView.ScrollIntoView(varListView.Items[iScrollIndex]);
        //                        varListView.UpdateLayout();
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ErrorStr="获取最大日志编号错误！";
        //        }

        //        if (ErrorStr.Trim() != String.Empty)
        //        {
        //            throw new Exception(ErrorStr);
        //        }                
        //    }
        //    catch (Exception err)
        //    {
        //        //记录到系统日志中
        //        ToLog(err.Message, "防火墙配置管理程序操作错误记录");
        //    }
        //}

        //public void RecordErrMessage(string strUserID, string strCommand, string strRemark, string strTableName, string strErrMessage)
        //{
        //    try
        //    {
        //        Entity.EntityErrInfo varErrInfo = new Entity.EntityErrInfo();

        //        varErrInfo.ExecErr_Time = DateTime.Now;
        //        varErrInfo.ExecErr_UserID = strUserID.Trim();
        //        varErrInfo.ExecErr_Command = strCommand.Trim();
        //        varErrInfo.ExecErr_Remark = strRemark.Trim();
        //        varErrInfo.ExecErr_TableName = strTableName.Trim();
        //        varErrInfo.ExecErr_Explain = strErrMessage.Substring(0, ((strErrMessage.Length > 200) ? 200 : strErrMessage.Length));

        //        CData.CErrControl.insertErrRecord(varErrInfo);
        //    }
        //    catch (Exception err)
        //    {
        //        //记录到系统日志中
        //        ToLog(err.Message, "防火墙配置管理程序操作错误记录");
        //    }
        //}

        //public void RecordLogMessage(string strUserID, string strCommand, string strRemark,string strTableName )
        //{
        //    try
        //    {
        //        Entity.EntityControlLogInfo varControlLogInfo = new Entity.EntityControlLogInfo();

        //        varControlLogInfo.ContolLog_Time = DateTime.Now;
        //        varControlLogInfo.ContolLog_UserID = strUserID.Trim();
        //        varControlLogInfo.ContolLog_Command = strCommand.Trim();
        //        varControlLogInfo.ContolLog_Remark = strRemark.Trim();
        //        varControlLogInfo.ContolLog_TableName = strTableName.Trim();

        //        CData.CLogControl.insertLogRecord(varControlLogInfo);
        //    }
        //    catch (Exception err)
        //    {
        //        //记录到系统日志中
        //        ToLog(err.Message, "防火墙配置管理程序操作错误记录");
        //    }
        //}

        public void ToLog(string ExceptionString, string LogSource)
        {
            if (!EventLog.SourceExists(LogSource))
            {
                EventSourceCreationData EventSourceCreationData = new EventSourceCreationData("", "");//(LogName,MachineName)空代表应用程序日志和本机
                EventSourceCreationData.Source = LogSource;
                EventLog.CreateEventSource(EventSourceCreationData);
            }

            EventLog myLog = new EventLog();
            myLog.Source = LogSource;

            myLog.ModifyOverflowPolicy(OverflowAction.OverwriteOlder, 2);

            try
            {
                myLog.WriteEntry(ExceptionString);
            }
            catch
            {
                myLog.Clear();
                try
                {
                    myLog.WriteEntry(ExceptionString);
                }
                catch {}

            }           
        }

        public void ReConfigDataTableByDecryptSingleFieldInfo(ref DataTable varDT, string varFieldName)
        {
            int itColumnCount = 0;
            int itColumnExistSign = -1;
            string stFieldValue = "";
            string stDecryptFieldValue ="";

            try
            {
                if (varDT != null)
                {
                    if (varDT.Columns != null)
                    {
                        if (varDT.Columns.Count > 0)
                        {
                            itColumnCount = varDT.Columns.Count;

                            for (int itDRF = 0; itDRF < itColumnCount; itDRF++)
                            {
                                if (varDT.Columns[itDRF].ColumnName.Trim() == varFieldName.Trim())
                                {
                                    itColumnExistSign = itDRF;
                                }
                            }

                            if (itColumnExistSign > -1)
                            {
                                if (varDT.Rows != null)
                                {
                                    if (varDT.Rows.Count > 0)
                                    {
                                        foreach (DataRow dr in varDT.Rows)
                                        {
                                            stFieldValue = "";
                                            stDecryptFieldValue = "";

                                            if (dr[itColumnExistSign] != null)
                                            {
                                                stFieldValue = dr[itColumnExistSign].ToString();

                                                if (stFieldValue.Trim() != String.Empty)
                                                {
                                                    stDecryptFieldValue = Des.DesDecrypt(stFieldValue.Trim(), "/']zse0-");

                                                    dr[itColumnExistSign] = stDecryptFieldValue;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        public void EncryptionSingleFieldStrInfo(string varFieldValue,ref string varEncryptionFieldValue)
        {
            string stEncryptionFieldValue = "";

            try
            {
                if (varFieldValue.Trim() != String.Empty)
                {
                    stEncryptionFieldValue = Des.DesEncrypt(varFieldValue.Trim(), "/']zse0-");
                }

                if (stEncryptionFieldValue != String.Empty)
                {
                    varEncryptionFieldValue = stEncryptionFieldValue;
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        public void DecryptionSingleFieldStrInfo(string varFieldValue, ref string varDecryptionFieldValue)
        {
            string stDecryptionFieldValue = "";

            try
            {
                if (varFieldValue.Trim() != String.Empty)
                {
                    stDecryptionFieldValue = Des.DesDecrypt(varFieldValue.Trim(), "/']zse0-");
                }

                if (stDecryptionFieldValue != String.Empty)
                {
                    varDecryptionFieldValue = stDecryptionFieldValue;
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
    
    }
}
