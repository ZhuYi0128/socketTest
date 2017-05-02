using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Data;

namespace socketTest.XmlControl
{
    class CXDocumentControl
    {
        
        private XElement XElementAlls;

        public CXDocumentControl()
        {
            XElementAlls = null;
        }

        /// <summary>
        /// 获取XML文件的路径
        /// </summary>
        /// <param name="varFileName">文件名称</param>
        /// <param name="varSaveSubFolderName">存储XML文件子文件夹名</param>
        /// <param name="varFilePathInfo">返回找到的路径</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>
        public bool getXmlFilePath(string varFileName, string varSaveSubFolderName, ref string varFilePathInfo,ref string varErrorStr)
        {
            string sFileName = "";
            string sFileExecFullPath = "";
            //int itLastIndex = 0;
            string sFileExecPath = "";
            string sTempFileName="";

            varFilePathInfo = "";

            try
            {
                if (varSaveSubFolderName.Trim() != String.Empty)
                {
                    if (varFileName.Trim() != String.Empty)
                    {
                        sFileName = varFileName + ".xml";

                        //注意执行路径的获取方式
                        //
                        //System.Windows.Forms.Application.StartupPath
                        sFileExecFullPath = System.Windows.Forms.Application.ExecutablePath;

                        if (FileNameAndPathSeparate(sFileExecFullPath, ref sFileExecPath, ref sTempFileName, ref varErrorStr))
                        {
                            if (sFileExecPath.Trim() != String.Empty)
                            {
                                varFilePathInfo = sFileExecPath + @"\" + varSaveSubFolderName + @"\" + sFileName;

                                return true;
                            }
                            else
                            {
                                varErrorStr = "未找到文件有效路径！";
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }

                        #region 替换代码
                        //if (sFileExecFullPath.Trim() != String.Empty)
                        //{
                        //    itLastIndex = sFileExecFullPath.LastIndexOf(@"\");

                        //    if (itLastIndex >= 0 && itLastIndex <= sFileExecFullPath.Trim().Length)
                        //    {
                        //        sFileExecPath = sFileExecFullPath.Substring(0, itLastIndex);

                        //        if (sFileExecPath.Trim() != String.Empty)
                        //        {
                        //            varFilePathInfo = sFileExecPath + @"\" + varSaveSubFolderName + @"\" + sFileName;

                        //            return true;
                        //        }
                        //        else
                        //        {
                        //            varErrorStr = "未找到文件有效路径！";
                        //            return false;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        varErrorStr = "未输入文件的路径不是有效格式！";
                        //        return false;
                        //    }
                        //}
                        //else
                        //{
                        //    varErrorStr = "未找到文件执行路径！";
                        //    return false;
                        //}
                        #endregion

                    }
                    else
                    {
                        varErrorStr = "未输入XML文件名称！";
                        return false;
                    }
                }
                else
                {
                    varErrorStr = "未输入保存XML文件的子目录！";
                    return false;
                }

            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        public bool getSetKindFilePath(string varFileName, string varExtension, string varSaveSubFolderName, ref string varFilePathInfo, ref string varErrorStr)
        {
            string sFileName = "";
            string sFileExecFullPath = "";
            //int itLastIndex = 0;
            string sFileExecPath = "";
            string sTempFileName = "";

            varFilePathInfo = "";

            try
            {
                if (varSaveSubFolderName.Trim() != String.Empty)
                {
                    if (varFileName.Trim() != String.Empty)
                    {
                        sFileName = varFileName + "." + varExtension;

                        //注意执行路径的获取方式
                        //
                        //System.Windows.Forms.Application.StartupPath
                        sFileExecFullPath = System.Windows.Forms.Application.ExecutablePath;

                        if (FileNameAndPathSeparate(sFileExecFullPath, ref sFileExecPath, ref sTempFileName, ref varErrorStr))
                        {
                            if (sFileExecPath.Trim() != String.Empty)
                            {
                                varFilePathInfo = sFileExecPath + @"\" + varSaveSubFolderName + @"\" + sFileName;

                                return true;
                            }
                            else
                            {
                                varErrorStr = "未找到文件有效路径！";
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
                        varErrorStr = "未输入文件名称！";
                        return false;
                    }
                }
                else
                {
                    varErrorStr = "未输入保存文件的子目录！";
                    return false;
                }

            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        //文件名和路径分离方法
        private bool FileNameAndPathSeparate(string varFullPath, ref string varFindPath, ref string varFileName, ref string varErrorStr)
        {
            int itLastIndex = 0;

            varFindPath = "";
            varFileName = "";

            if (varFullPath.Trim() != null)
            {
                itLastIndex = varFullPath.LastIndexOf(@"\");

                if (itLastIndex >= 0 && itLastIndex <= varFullPath.Trim().Length)
                {
                    varFindPath = varFullPath.Substring(0, itLastIndex);

                    if ((itLastIndex + 1)< varFullPath.Trim().Length)
                    {
                        varFileName = varFullPath.Substring(itLastIndex +1 , varFullPath.Trim().Length - itLastIndex -1);
                    }
                    return true;
                }
                else
                {
                    varErrorStr = "未输入文件的路径不是有效格式！";
                    return false;
                }
            }
            else
            {
                varErrorStr = "未输入文件的路径和文件名！";
                return false;
            }
        }

        public bool getXmlFilePath2(string varFileName, string varSaveSubFolderName, string varImportFilePathInfo, ref string varExportFilePathInfo, ref string varErrorStr)
        {
            string sFileName = "";
            string stImportFilePathInfo = "";
            string sFileExecPath = "";
            string sTempFileName = "";

            stImportFilePathInfo = varImportFilePathInfo.Trim();

            //ProjectApplicationData
            //ProjectManagerDataXML

            try
            {
                if (varSaveSubFolderName.Trim() != String.Empty)
                {
                    if (varFileName.Trim() != String.Empty)
                    {
                        sFileName = varFileName + ".xml";

                        //注意执行路径的获取方式

                        if (FileNameAndPathSeparate(stImportFilePathInfo, ref sFileExecPath, ref sTempFileName, ref varErrorStr))
                        {
                            if (sFileExecPath.Trim() != String.Empty)
                            {
                                varExportFilePathInfo = sFileExecPath + @"\" + varSaveSubFolderName + @"\" + sFileName;

                                return true;
                            }
                            else
                            {
                                varErrorStr = "未找到文件有效路径！";
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
                        varErrorStr = "未输入XML文件名称！";
                        return false;
                    }
                }
                else
                {
                    varErrorStr = "未输入保存XML文件的子目录！";
                    return false;
                }

            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        /// <summary>
        /// 加载XML文件
        /// </summary>
        /// <param name="varFilePath">完整路径名+XML文件名</param>
        /// <param name="varRootNode">根节点名称</param>
        /// <param name="varReLoadSign">文件重载标志</param>
        /// <param name="varXElementAlls">传递的XElement元素</param>
        public void LoadXmlFile(string varFilePath, string varRootNode,int varReLoadSign, ref XElement varXElementAlls)
        {
            try
            {
                string stFileDirectory="";
                string stFileName="";
                string sErrorStr="";

                //应该先检测一下路径是否存在
                if (FileNameAndPathSeparate(varFilePath, ref stFileDirectory, ref stFileName, ref sErrorStr))
                {
                    if (!System.IO.Directory.Exists(stFileDirectory))
                    {

                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(stFileDirectory);

                        dir.Create();
                    }
                }

                if (!System.IO.File.Exists(varFilePath))
                {
                    XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                                    new XComment("Created:" + DateTime.Now.ToString()),
                                    new XElement(varRootNode));

                    try
                    {
                        doc.Save(varFilePath);
                    }
                    catch (Exception ee)
                    {
                        throw ee;
                    }

                    varXElementAlls = XElement.Load(varFilePath);
                }
                else
                {
                    if (varXElementAlls == null)
                    {
                        varXElementAlls = XElement.Load(varFilePath);
                    }
                    else
                    {
                        if (varXElementAlls.Name == null)
                        {
                            varXElementAlls = XElement.Load(varFilePath);
                        }
                        else
                        {
                            if (varReLoadSign == 0)
                            {
                                varXElementAlls = XElement.Load(varFilePath);
                            }
                            else
                            {
                                if (varXElementAlls.Name.LocalName.Trim() != varRootNode.Trim())
                                {
                                    varXElementAlls = XElement.Load(varFilePath);
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

        /// <summary>
        /// 增加一级子节点名、值和多个属性。可以增加一条记录的主键
        /// </summary>
        /// <param name="varFilePath">完整路径名+XML文件名</param>
        /// <param name="varRootNode">根节点名称</param>
        /// <param name="nodeKeyName">一级子节点名</param>
        /// <param name="nodeKeyValueText">一级子节点的值</param>
        /// <param name="varSLKeyAttributeName">一级子节点的多个属性名数组</param>
        /// <param name="varSLKeyAttributeValue">一级子节点的多个属性值数组</param>
        /// <param name="varPKIndex">在输入数组中标记主键所在列的索引</param>
        /// <param name="varReLoadSign">文件重载标志</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>
        public bool addSonNodeKeyElement(string varFilePath, string varRootNode,
                        string nodeKeyName, string nodeKeyValueText,
                        string[] varSLKeyAttributeName, string[] varSLKeyAttributeValue, int varPKIndex, int varXmlFileReLoadSign,ref string varErrStr)
        {
            try
            {
                if (checkTwoArrayDataIntegrity(ref varSLKeyAttributeName, ref varSLKeyAttributeValue, ref varErrStr) == false)
                {
                    return false;
                }

                if (nodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

                LoadXmlFile(varFilePath, varRootNode, varXmlFileReLoadSign,ref XElementAlls);


                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (nodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

                if (varSLKeyAttributeName.GetLength(0) <(varPKIndex+1))
                {
                    varErrStr = "主键索引设置错误！";
                    return false;
                }

                if (XElementAlls.HasElements == false)
                {
                    XElement sonkey = new XElement(nodeKeyName);

                    for (int itAttIndex = 0; itAttIndex < varSLKeyAttributeName.GetLength(0); itAttIndex++)
                    {
                        sonkey.SetAttributeValue(varSLKeyAttributeName[itAttIndex], varSLKeyAttributeValue[itAttIndex]);
                    }

                    sonkey.SetValue(nodeKeyValueText);

                    XElementAlls.Add(sonkey);

                    XElementAlls.Save(varFilePath);

                    return true;
                }
                else
                {
                    IEnumerable<XElement> empRecord =
                        from emp in XElementAlls.Elements(nodeKeyName)
                        where (string)emp.Attribute(varSLKeyAttributeName[varPKIndex]) == varSLKeyAttributeValue[varPKIndex]
                        select emp;

                    if (empRecord != null)
                    {
                        if (empRecord.Count() == 0)
                        {
                            XElement sonkey = new XElement(nodeKeyName);

                            for (int itAttIndex = 0; itAttIndex < varSLKeyAttributeName.GetLength(0); itAttIndex++)
                            {
                                sonkey.SetAttributeValue(varSLKeyAttributeName[itAttIndex], varSLKeyAttributeValue[itAttIndex]);
                            }

                            sonkey.SetValue(nodeKeyValueText);

                            XElementAlls.Add(sonkey);

                            XElementAlls.Save(varFilePath);

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
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        /// <summary>
        /// 给一级子节点下面增加二级子节点。
        /// 通过一级子节点属性(主键)找到一级子节点。
        /// 可以与上一个方法一起使用增加一条记录。
        /// 上一个方法增加一个主键，然后使用这个方法增加其他列
        /// </summary>
        /// <param name="varFilePath">完整路径名+XML文件名</param>
        /// <param name="varRootNode">根节点名称<</param>
        /// <param name="varNodeKeyName">一级子节点名</param>
        /// <param name="varKeyAttributeName">一级子节点属性名</param>
        /// <param name="varKeyAttributeValue">一级子节点属性值</param>
        /// <param name="varSonNodeName">二级子节点名</param>
        /// <param name="varSonNodeValueText">二级子节点值</param>
        /// <param name="varSonNodeAttributeName">二级子节点属性名</param>
        /// <param name="varSonNodeAttributeValue">二级子节点属性值</param>
        /// <param name="varReLoadSign">文件重载标志</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>
        public bool addSonNodeSingleElement(string varFilePath, string varRootNode,
                        string varNodeKeyName, string varKeyAttributeName, string varKeyAttributeValue,
                        string varSonNodeName, string varSonNodeValueText, string varSonNodeAttributeName, string varSonNodeAttributeValue,int varXmlFileReLoadSign ,ref string varErrStr)
        {
            try
            {
                if (varNodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

                if (varKeyAttributeName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点属性名为空(主键名为空)！";
                    return false;
                }

                if (varSonNodeName.Trim() == String.Empty)
                {
                    varErrStr = "二级子节点名为空(列名为空)！";
                    return false;
                }

                LoadXmlFile(varFilePath, varRootNode, varXmlFileReLoadSign,ref XElementAlls);

                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (XElementAlls.HasElements == true)
                {
                    IEnumerable<XElement> empRecord =
                       from emp in XElementAlls.Elements(varNodeKeyName)
                       where (string)emp.Attribute(varKeyAttributeName) == varKeyAttributeValue
                       select emp;

                    if (empRecord == null)
                    {
                        return false;
                    }

                    if (empRecord.Count() > 0)
                    {
                        XElement empSelRecord =
                            (from emp in XElementAlls.Elements(varNodeKeyName)
                             where (string)emp.Attribute(varKeyAttributeName) == varKeyAttributeValue
                             select emp).ElementAt(0);

                        if (empSelRecord != null)
                        {
                            if (empSelRecord.HasElements == false)
                            {
                                XElement sonNode = new XElement(varSonNodeName);

                                if (varSonNodeAttributeName.Trim() != String.Empty && varSonNodeAttributeValue.Trim() != String.Empty)
                                {
                                    sonNode.SetAttributeValue(varSonNodeAttributeName, varSonNodeAttributeValue);
                                }

                                sonNode.SetValue(varSonNodeValueText);

                                empSelRecord.Add(sonNode);

                                XElementAlls.Save(varFilePath);

                                return true;
                            }
                            else
                            {
                                IEnumerable<XElement> empSelSonRecord =
                                   from emp2 in empSelRecord.Elements(varSonNodeName)
                                   select emp2;

                                if (empSelSonRecord != null)
                                {
                                    if (empSelSonRecord.Count() == 0)
                                    {
                                        XElement sonNode = new XElement(varSonNodeName);

                                        if (varSonNodeAttributeName.Trim() != String.Empty && varSonNodeAttributeValue.Trim() != String.Empty)
                                        {
                                            sonNode.SetAttributeValue(varSonNodeAttributeName, varSonNodeAttributeValue);
                                        }

                                        sonNode.SetValue(varSonNodeValueText);

                                        empSelRecord.Add(sonNode);

                                        XElementAlls.Save(varFilePath);

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
            catch (Exception ee)
            {
                throw ee;
            }

        }

        /// <summary>
        /// 一个次增加一条记录的全部信息
        /// </summary>
        /// <param name="varFilePath">完整路径名+XML文件名</param>
        /// <param name="varRootNode">根节点名称<</param>
        /// <param name="nodeKeyName">一级子节点名</param>
        /// <param name="nodeKeyValueText">一级子节点值</param>
        /// <param name="varSLInformationName">一条记录全部列信息，子节点名数组</param>
        /// <param name="varSLInformationValue">一条记录全部列值，子节点值数组</param>
        /// <param name="varPKIndex">在输入数组中标记主键所在列的索引</param>
        /// <param name="varReLoadSign">文件重载标志</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>
        public bool addSonNodeSingleElementAllInfo(string varFilePath, string varRootNode,
                        string nodeKeyName, string nodeKeyValueText,
                        string[] varSLInformationName, string[] varSLInformationValue, int varPKIndex,int varXmlFileReLoadSign,ref string varErrStr)
        {
            try
            {
                if (checkTwoArrayDataIntegrity(ref varSLInformationName, ref varSLInformationValue, ref varErrStr) == false)
                {
                    return false;
                }

                if (nodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

                LoadXmlFile(varFilePath, varRootNode, varXmlFileReLoadSign,ref XElementAlls);

                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (varSLInformationName.GetLength(0) < (varPKIndex + 1))
                {
                    varErrStr = "主键索引设置错误！";
                    return false;
                }


                if (XElementAlls.HasElements == false)
                {
                    XElement sonkey = new XElement(nodeKeyName);

                    sonkey.SetValue(nodeKeyValueText);

                    if (varSLInformationName.GetLength(0) > 1)
                    {
                        for (int itXEIndex = 0; itXEIndex < varSLInformationName.GetLength(0); itXEIndex++)
                        {
                            if (itXEIndex == varPKIndex)
                            {
                                sonkey.SetAttributeValue(varSLInformationName[itXEIndex], varSLInformationValue[itXEIndex]);
                            }
                            else
                            {
                                XElement sonSonCol = new XElement(varSLInformationName[itXEIndex]);
                                sonSonCol.SetValue(varSLInformationValue[itXEIndex]);
                                sonkey.Add(sonSonCol);
                            }
                        }
                    }

                    XElementAlls.Add(sonkey);

                    XElementAlls.Save(varFilePath);

                    return true;
                }
                else
                {
                    IEnumerable<XElement> empRecord =
                        from emp in XElementAlls.Elements(nodeKeyName)
                        where (string)emp.Attribute(varSLInformationName[varPKIndex]) == varSLInformationValue[varPKIndex]
                        select emp;

                    if (empRecord != null)
                    {
                        if (empRecord.Count() == 0)
                        {
                            XElement sonkey = new XElement(nodeKeyName);

                            sonkey.SetValue(nodeKeyValueText);

                            if (varSLInformationName.GetLength(0) > 1)
                            {
                                for (int itXEIndex = 0; itXEIndex < varSLInformationName.GetLength(0); itXEIndex++)
                                {
                                    if (itXEIndex == varPKIndex)
                                    {
                                        sonkey.SetAttributeValue(varSLInformationName[itXEIndex], varSLInformationValue[itXEIndex]);
                                    }
                                    else
                                    {
                                        XElement sonSonCol = new XElement(varSLInformationName[itXEIndex]);
                                        sonSonCol.SetValue(varSLInformationValue[itXEIndex]);
                                        sonkey.Add(sonSonCol);
                                    }
                                }
                            }

                            XElementAlls.Add(sonkey);

                            XElementAlls.Save(varFilePath);

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
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        /// <summary>
        /// 更新单个一级子节点下所有二级子节点信息，表示通过主键找到这个记录然后更新所有列的信息
        /// </summary>
        /// <param name="varFilePath">完整路径名+XML文件名</param>
        /// <param name="varRootNode">根节点名称</param>
        /// <param name="varNodeKeyName">一级子节点名</param>
        /// <param name="varKeyAttributeName">一级子节点属性名</param>
        /// <param name="varKeyAttributeValue">一级子节点属性值</param>
        /// <param name="varSLSonNodeName">二级子节点名</param>
        /// <param name="varSLSonNodeValueText">二级子节点值</param>
        /// <param name="varReLoadSign">文件重载标志</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>
        public bool updateSingleSonNodeALLElement(string varFilePath, string varRootNode,
                        string varNodeKeyName, string varKeyAttributeName, string varKeyAttributeValue,
                        string[] varSLSonNodeName, string[] varSLSonNodeValueText,int varXmlFileReLoadSign,ref string varErrStr)
        {
            try
            {
                if (checkTwoArrayDataIntegrity(ref varSLSonNodeName, ref varSLSonNodeValueText, ref varErrStr) == false)
                {
                    return false;
                }

                if (varNodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

                if (varKeyAttributeName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点属性名为空(主键名为空)！";
                    return false;
                }

                LoadXmlFile(varFilePath, varRootNode, varXmlFileReLoadSign,ref XElementAlls);

                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (XElementAlls.HasElements == true)
                {
                    IEnumerable<XElement> lEmpSelUpdateRecord =
                          from emp in XElementAlls.Elements(varNodeKeyName)
                           where (string)emp.Attribute(varKeyAttributeName) == varKeyAttributeValue
                           select emp;

                    if (lEmpSelUpdateRecord == null)
                    {
                        return false;
                    }

                    if (lEmpSelUpdateRecord.Count() == 0)
                    {
                        return false;
                    }

                    XElement tEmpSelUpdateRecord = lEmpSelUpdateRecord.ElementAt(0);

                    if (tEmpSelUpdateRecord != null)
                    {
                        if (tEmpSelUpdateRecord.HasElements == true)
                        {
                            for (int itSonElementIndex = 0; itSonElementIndex < varSLSonNodeName.GetLength(0); itSonElementIndex++)
                            {
                                XElement sonNode = new XElement(varSLSonNodeName[itSonElementIndex]);

                                sonNode.SetValue(varSLSonNodeValueText[itSonElementIndex]);

                                tEmpSelUpdateRecord.Element(varSLSonNodeName[itSonElementIndex]).ReplaceWith(sonNode);
                            }

                            XElementAlls.Save(varFilePath);

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
            catch (Exception ee)
            {
                throw ee;
            }
        }

        /// <summary>
        /// 删除一级子节点根据通过一级子节点属性(记录主键)
        /// </summary>
        /// <param name="varFilePath">完整路径名+XML文件名</param>
        /// <param name="varRootNode">根节点名称</param>
        /// <param name="varNodeKeyName">一级子节点名</param>
        /// <param name="varKeyAttributeName">一级子节点属性名</param>
        /// <param name="varKeyAttributeValue">一级子节点属性值</param>
        /// <param name="varReLoadSign">文件重载标志</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>
        public bool deleteSonNodeElementByKey(string varFilePath, string varRootNode,
                        string varNodeKeyName, string varKeyAttributeName, string varKeyAttributeValue,int varXmlFileReLoadSign, ref string varErrStr)
        {
            try
            {
                if (varNodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

                if (varKeyAttributeName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点属性名为空(主键名为空)！";
                    return false;
                }

                LoadXmlFile(varFilePath, varRootNode, varXmlFileReLoadSign, ref XElementAlls);

                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (XElementAlls.HasElements == true)
                {
                    

                    IEnumerable<XElement> lempDelRecord =
                          from emp in XElementAlls.Elements(varNodeKeyName)
                          where (string)emp.Attribute(varKeyAttributeName) == varKeyAttributeValue
                          select emp;

                    if (lempDelRecord != null)
                    {
                        if (lempDelRecord.Count() > 0)
                        {
                            foreach (XElement tXe in lempDelRecord)
                            {
                                tXe.Remove();
                            }

                            XElementAlls.Save(varFilePath);

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
            catch (Exception ee)
            {
                throw ee;
            }
        }

      
        public bool deleteSonNodeElementByCondition(string varFilePath, string varRootNode,
                        string varNodeKeyName,
                        string varColName, string varColValue, int varPKSign,int varLikeSign,
                        int varXmlFileReLoadSign, ref string varErrStr)
        {
            try
            {
                if (varNodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

                if (varColName.Trim() == String.Empty)
                {
                    varErrStr = "字段名为空！";
                    return false;
                }

                LoadXmlFile(varFilePath, varRootNode, varXmlFileReLoadSign, ref XElementAlls);

                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (XElementAlls.HasElements == true)
                {
                    //         IEnumerable<XElement> empSelDataRecords;

                    //if (varPKSign == 0)
                    //{
                    //    empSelDataRecords =
                    //        from emp in XElementAlls.Elements(varNodeKeyName)
                    //        where (string)emp.Attribute(varSColConditionName).Value == varSColConditionValue
                    //        select emp;
                    //}
                    //else
                    //{
                    //    empSelDataRecords =
                    //        from emp in XElementAlls.Elements(varNodeKeyName)
                    //        where (string)emp.Element(varSColConditionName).Value == varSColConditionValue
                    //        select emp;
                    //}

                    //if (empSelDataRecords != null)
                    //{
                    //    if (empSelDataRecords.Count() > 0)
                    //    {
                    IEnumerable<XElement> lempDelRecord;

                    if (varPKSign == 0)
                    {
                        if (varLikeSign == 1)
                        {
                            lempDelRecord = from emp in XElementAlls.Elements(varNodeKeyName)
                                            where (string)emp.Attribute(varColName).Value == varColValue
                                            select emp;
                        }
                        else
                        {
                            lempDelRecord = from emp in XElementAlls.Elements(varNodeKeyName)
                                            where ((string)emp.Attribute(varColName).Value).StartsWith(varColValue)
                                            select emp;
                        }
                    }
                    else
                    {
                        if (varLikeSign == 1)
                        {
                            lempDelRecord = from emp in XElementAlls.Elements(varNodeKeyName)
                                            where (string)emp.Element(varColName).Value == varColValue
                                            select emp;
                        }
                        else
                        {
                            lempDelRecord = from emp in XElementAlls.Elements(varNodeKeyName)
                                            where ((string)emp.Element(varColName).Value).StartsWith(varColValue)
                                            select emp;
                        }
                    }

                    if (lempDelRecord != null)
                    {
                        if (lempDelRecord.Count() > 0)
                        {
                            int itDelRecordCount = 0;
                            itDelRecordCount = lempDelRecord.Count();

                            for (int iDel = itDelRecordCount - 1; iDel > -1; iDel--)
                            {
                                XElement tXe =lempDelRecord.ElementAt(iDel);
                                tXe.Remove();
                            }

                            //foreach (XElement tXe in lempDelRecord)
                            //{
                            //    tXe.Remove();
                            //}
                            
                            XElementAlls.Save(varFilePath);

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
            catch (Exception ee)
            {
                throw ee;
            }
        }

        public bool deleteSonNodeElementByDualCondition(string varFilePath, string varRootNode,string varNodeKeyName,                        
                        string varColName1, string varColValue1, int varPKSign,
                        string varColName2, string varColValue2,
                        int varLikeSign,
                        int varXmlFileReLoadSign, ref string varErrStr)
        {
            try
            {
                if (varNodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

                if (varColName1.Trim() == String.Empty)
                {
                    varErrStr = "字段名为空！";
                    return false;
                }

                LoadXmlFile(varFilePath, varRootNode, varXmlFileReLoadSign, ref XElementAlls);

                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (XElementAlls.HasElements == true)
                {
                    //         IEnumerable<XElement> empSelDataRecords;

                    //if (varPKSign == 0)
                    //{
                    //    empSelDataRecords =
                    //        from emp in XElementAlls.Elements(varNodeKeyName)
                    //        where (string)emp.Attribute(varSColConditionName).Value == varSColConditionValue
                    //        select emp;
                    //}
                    //else
                    //{
                    //    empSelDataRecords =
                    //        from emp in XElementAlls.Elements(varNodeKeyName)
                    //        where (string)emp.Element(varSColConditionName).Value == varSColConditionValue
                    //        select emp;
                    //}

                    //if (empSelDataRecords != null)
                    //{
                    //    if (empSelDataRecords.Count() > 0)
                    //    {
                    IEnumerable<XElement> lempDelRecord;

                    if (varPKSign == 0)
                    {
                        if (varLikeSign == 1)
                        {
                            lempDelRecord = from emp in XElementAlls.Elements(varNodeKeyName)
                                            where (string)emp.Attribute(varColName1).Value == varColValue1
                                            && (string)emp.Element(varColName2).Value == varColValue2
                                            select emp;
                        }
                        else
                        {
                            lempDelRecord = from emp in XElementAlls.Elements(varNodeKeyName)
                                            where ((string)emp.Attribute(varColName1).Value).StartsWith(varColValue1)
                                            && ((string)emp.Attribute(varColName2).Value).StartsWith(varColValue2)
                                            select emp;
                        }
                    }
                    else
                    {
                        if (varLikeSign == 1)
                        {
                            lempDelRecord = from emp in XElementAlls.Elements(varNodeKeyName)
                                            where (string)emp.Element(varColName1).Value == varColValue1
                                            && (string)emp.Element(varColName2).Value == varColValue2
                                            select emp;
                        }
                        else
                        {
                            lempDelRecord = from emp in XElementAlls.Elements(varNodeKeyName)
                                            where ((string)emp.Element(varColName1).Value).StartsWith(varColValue1)
                                            && ((string)emp.Attribute(varColName2).Value).StartsWith(varColValue2)
                                            select emp;
                        }
                    }

                    if (lempDelRecord != null)
                    {
                        if (lempDelRecord.Count() > 0)
                        {
                            int itDelRecordCount = 0;
                            itDelRecordCount = lempDelRecord.Count();

                            for (int iDel = itDelRecordCount - 1; iDel > -1; iDel--)
                            {
                                XElement tXe = lempDelRecord.ElementAt(iDel);
                                tXe.Remove();
                            }

                            //foreach (XElement tXe in lempDelRecord)
                            //{
                            //    tXe.Remove();
                            //}

                            XElementAlls.Save(varFilePath);

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
            catch (Exception ee)
            {
                throw ee;
            }
        }

        /// <summary>
        /// 删除全部子节点
        /// </summary>
        /// <param name="varFilePath">完整路径名+XML文件名</param>
        /// <param name="varRootNode">根节点名称</param>
        /// <param name="varNodeKeyName">一级子节点名</param>
        /// <param name="varReLoadSign">文件重载标志</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>  
        public bool deleteAllSonNodeElement(string varFilePath, string varRootNode,
                            int varXmlFileReLoadSign, ref string varErrStr)
        {
            try
            {
                LoadXmlFile(varFilePath, varRootNode, varXmlFileReLoadSign, ref XElementAlls);

                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (XElementAlls.HasElements == true)
                {
                    XElementAlls.RemoveAll();

                    XElementAlls.Save(varFilePath);

                    return true;
                }
                else
                {
                    return true;
                }               
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        /// <summary>
        /// 按照单一列值条件读取节点信息
        /// </summary>
        /// <param name="varFilePath">完整的路径+XML文件名</param>
        /// <param name="varRootNode">根节点名</param>
        /// <param name="varNodeKeyName">一级子节点名</param>
        /// <param name="varSColConditionName">选择列名</param>
        /// <param name="varSColConditionValue">选择列值</param>
        /// <param name="varPKSign">选择的列是否主键标志 0 主键（一级节点属性） 1 非主键（二级节点名）</param>
        /// <param name="varSLSelectColName">返回数据的列名集合</param>
        /// <param name="varPKIndex">主键索引</param>
        /// <param name="varFindNodeValueInfo">返回数据值</param>
        /// <param name="varReLoadSign">文件重载标志</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>
        public bool readNodeInfoBySingleColCondition(string varFilePath, string varRootNode,
                        string varNodeKeyName,
                        string varSColConditionName, string varSColConditionValue, int varPKSign,
                        string[] varSLSelectColName, int varPKIndex, ref string[,] varFindNodeValueInfo,int varXmlFileReLoadSign, ref string varErrStr)
        {
            int itColCount = 0;
            int itRowCount = 0;
            int itRowNum = 0;

            try
            {
                if (varNodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

                if (varSColConditionName.Trim() == String.Empty)
                {
                    varErrStr = "筛选条件列的列名为空！";
                    return false;
                }


                if (varSLSelectColName == null)
                {
                    varErrStr = "输入的返回列名称数组为空！";
                    return false;
                }
                else
                {
                    if (varSLSelectColName.GetLength(0) == 0)
                    {
                        varErrStr = "输入的返回列名称数组中元素个数为零！";
                        return false;
                    }
                }

                itColCount = varSLSelectColName.GetLength(0);

                LoadXmlFile(varFilePath, varRootNode,varXmlFileReLoadSign, ref XElementAlls);

                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (varSLSelectColName.GetLength(0) < (varPKIndex + 1))
                {
                    varErrStr = "主键索引设置错误！";
                    return false;
                }


                if (XElementAlls.HasElements == true)
                {
                    IEnumerable<XElement> empSelDataRecords;

                    if (varPKSign == 0)
                    {
                        empSelDataRecords =
                            from emp in XElementAlls.Elements(varNodeKeyName)
                            where (string)emp.Attribute(varSColConditionName).Value == varSColConditionValue
                            select emp;
                    }
                    else
                    {
                        empSelDataRecords =
                            from emp in XElementAlls.Elements(varNodeKeyName)
                            where (string)emp.Element(varSColConditionName).Value == varSColConditionValue
                            select emp;
                    }

                    if (empSelDataRecords != null)
                    {
                        if (empSelDataRecords.Count() > 0)
                        {
                            itRowCount = empSelDataRecords.Count();

                            varFindNodeValueInfo = new string[itRowCount, itColCount];

                            itRowNum = 0;

                            foreach (XElement tXle in empSelDataRecords)
                            {
                                for (int itCIndex = 0; itCIndex < varSLSelectColName.GetLength(0); itCIndex++)
                                {
                                    if (itCIndex == varPKIndex)
                                    {
                                        varFindNodeValueInfo[itRowNum, itCIndex] = tXle.Attribute(varSLSelectColName[itCIndex]).Value.ToString();
                                    }
                                    else
                                    {
                                        varFindNodeValueInfo[itRowNum, itCIndex] = tXle.Element(varSLSelectColName[itCIndex]).Value.ToString();
                                    }
                                }

                                itRowNum = itRowNum + 1;
                            }

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
            catch (Exception ee)
            {
                throw ee;
            }
        }

        /// <summary>
        /// 按照单一列值条件读取记录集合中最后一个节点信息，根据条件排序
        /// </summary>
        /// <param name="varFilePath">完整的路径+XML文件名</param>
        /// <param name="varRootNode">根节点名</param>
        /// <param name="varNodeKeyName">一级子节点名</param>
        /// <param name="varSColConditionName">选择列名</param>
        /// <param name="varSColConditionValue">选择列值</param>
        /// <param name="varPKSign">选择的列是否主键标志 0 主键（一级节点属性） 1 非主键（二级节点名）</param>
        /// <param name="varOrderIsNotAttributeColOrElementCol">是按照一级子节点属性排序还是按照二级子节点名排序</param>
        /// <param name="varOrderAttributeColIndex">一级子节点属性排序(列)索引</param>
        /// <param name="varOrderAttributeColOrientation">一级子节点属性排序方向</param>
        /// <param name="varOrderElementColIndex">二级子节点名排序(列)索引</param>
        /// <param name="varOrderElementColOrientation">二级子节点名排序方向</param>
        /// <param name="varSLSelectColName">返回数据的列名集合</param>
        /// <param name="varPKIndex">主键索引</param>
        /// <param name="varFindNodeValueInfo">返回数据值</param>
        /// <param name="varReLoadSign">文件重载标志</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>
        public bool readNodeInfoLastNodeBySingleColCondition(string varFilePath, string varRootNode,
                        string varNodeKeyName,
                        string varSColConditionName, string varSColConditionValue, int varPKSign,
                        int varOrderIsNotAttributeColOrElementCol,
                        int varOrderAttributeColIndex, int varOrderAttributeColOrientation,
                        int varOrderElementColIndex, int varOrderElementColOrientation,
                        string[] varSLSelectColName, int varPKIndex, ref string[,] varFindNodeValueInfo, int varXmlFileReLoadSign, ref string varErrStr)
        {
            int itColCount = 0;
            //int itRowCount = 0;
            //int itRowNum = 0;

            try
            {
                if (varNodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

                if (varSColConditionName.Trim() == String.Empty)
                {
                    varErrStr = "筛选条件列的列名为空！";
                    return false;
                }


                if (varSLSelectColName == null)
                {
                    varErrStr = "输入的返回列名称数组为空！";
                    return false;
                }
                else
                {
                    if (varSLSelectColName.GetLength(0) == 0)
                    {
                        varErrStr = "输入的返回列名称数组中元素个数为零！";
                        return false;
                    }
                }

                itColCount = varSLSelectColName.GetLength(0);

                LoadXmlFile(varFilePath, varRootNode, varXmlFileReLoadSign, ref XElementAlls);

                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (varSLSelectColName.GetLength(0) < (varPKIndex + 1))
                {
                    varErrStr = "主键索引设置错误！";
                    return false;
                }


                if (XElementAlls.HasElements == true)
                {
                    IEnumerable<XElement> empSelDataRecords;

                    if (varPKSign == 0)
                    {
                        empSelDataRecords =
                            from emp in XElementAlls.Elements(varNodeKeyName)
                            where (string)emp.Attribute(varSColConditionName).Value == varSColConditionValue
                            select emp;
                    }
                    else
                    {
                        empSelDataRecords =
                            from emp in XElementAlls.Elements(varNodeKeyName)
                            where (string)emp.Element(varSColConditionName).Value == varSColConditionValue
                            select emp;
                    }

                    if (empSelDataRecords != null)
                    {
                        if (empSelDataRecords.Count() > 0)
                        {
                            IEnumerable<XElement> empSelAllDataRecord2;

                            if (varOrderIsNotAttributeColOrElementCol == 0) //按属性排
                            {
                                if (varOrderAttributeColOrientation == 0) //按属性正排
                                {
                                    empSelAllDataRecord2 = empSelDataRecords.OrderBy(X => X.Attribute(varSLSelectColName[varOrderAttributeColIndex]).Value.ToString());
                                }
                                else
                                {   //按属性倒排
                                    empSelAllDataRecord2 = empSelDataRecords.OrderByDescending(X => X.Attribute(varSLSelectColName[varOrderAttributeColIndex]).Value.ToString());
                                }
                            }
                            else
                            {
                                if (varOrderElementColOrientation == 0) //按二级节点名正排
                                {
                                    empSelAllDataRecord2 = empSelDataRecords.OrderBy(X => X.Element(varSLSelectColName[varOrderElementColIndex]).Value.ToString());
                                }
                                else
                                {   //按二级节点名倒排
                                    empSelAllDataRecord2 = empSelDataRecords.OrderByDescending(X => X.Element(varSLSelectColName[varOrderElementColIndex]).Value.ToString());
                                }
                            }

                            if (empSelAllDataRecord2 != null)
                            {
                                if (empSelAllDataRecord2.Count() > 0)
                                {
                                    varFindNodeValueInfo = new string[1, itColCount];

                                    XElement tXle = empSelAllDataRecord2.Last();

                                    for (int itCIndex = 0; itCIndex < varSLSelectColName.GetLength(0); itCIndex++)
                                    {
                                        if (itCIndex == varPKIndex)
                                        {
                                            varFindNodeValueInfo[0, itCIndex] = tXle.Attribute(varSLSelectColName[itCIndex]).Value.ToString();
                                        }
                                        else
                                        {
                                            varFindNodeValueInfo[0, itCIndex] = tXle.Element(varSLSelectColName[itCIndex]).Value.ToString();
                                        }
                                    }

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
            catch (Exception ee)
            {
                throw ee;
            }
        }
        

        /// <summary>
        /// 按照单一列值条件读取节点信息 包括该列中含有相同信息的记录  
        /// </summary>
        /// <param name="varFilePath">完整的路径+XML文件名</param>
        /// <param name="varRootNode">根节点名</param>
        /// <param name="varNodeKeyName">一级子节点名</param>
        /// <param name="varSColConditionName">选择列名</param>
        /// <param name="varSColConditionValue">选择列值</param>
        /// <param name="varPKSign">选择的列是否主键标志 0 主键（一级节点属性） 1 非主键（二级节点名）</param>
        /// <param name="IsOrNotIncludeCurrentRecord">是否包含当前记录 0 包含 1 不包含</param>
        /// <param name="varSLSelectColName">返回数据的列名集合</param>
        /// <param name="varPKIndex">主键索引</param>
        /// <param name="varFindNodeValueInfo">返回数据值</param>
        /// <param name="varReLoadSign">文件重载标志</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>
        public bool readNodeInfoBySingleColCondition2(string varFilePath, string varRootNode,
                        string varNodeKeyName,
                        string varSColConditionName, string varSColConditionValue, int varPKSign,int IsOrNotIncludeCurrentRecord,
                        string[] varSLSelectColName, int varPKIndex, ref string[,] varFindNodeValueInfo, int varXmlFileReLoadSign, ref string varErrStr)
        {
            int itColCount = 0;
            int itRowCount = 0;
            int itRowNum = 0;
            int itSColValueLength=0;

            try
            {
                if (varNodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

                if (varSColConditionName.Trim() == String.Empty)
                {
                    varErrStr = "筛选条件列的列名为空！";
                    return false;
                }


                if (varSLSelectColName == null)
                {
                    varErrStr = "输入的返回列名称数组为空！";
                    return false;
                }
                else
                {
                    if (varSLSelectColName.GetLength(0) == 0)
                    {
                        varErrStr = "输入的返回列名称数组中元素个数为零！";
                        return false;
                    }
                }

                itColCount = varSLSelectColName.GetLength(0);

                LoadXmlFile(varFilePath, varRootNode, varXmlFileReLoadSign, ref XElementAlls);

                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (varSLSelectColName.GetLength(0) < (varPKIndex + 1))
                {
                    varErrStr = "主键索引设置错误！";
                    return false;
                }


                if (XElementAlls.HasElements == true)
                {
                    IEnumerable<XElement> empSelDataRecords;

                    itSColValueLength = 0;
                    itSColValueLength = varSColConditionValue.Trim().Length;

                    if (varPKSign == 0)
                    {
                        if (IsOrNotIncludeCurrentRecord ==0)
                        {
                            empSelDataRecords =
                                from emp in XElementAlls.Elements(varNodeKeyName)
                                where ((string)emp.Attribute(varSColConditionName).Value).Substring(0, itSColValueLength) == varSColConditionValue.Trim()
                                       && ((string)emp.Attribute(varSColConditionName).Value).Length >= varSColConditionValue.Trim().Length
                                select emp;
                        }
                        else 
                        {
                            empSelDataRecords =
                                from emp in XElementAlls.Elements(varNodeKeyName)
                                where ((string)emp.Attribute(varSColConditionName).Value).Substring(0, itSColValueLength) == varSColConditionValue.Trim()
                                    && ((string)emp.Attribute(varSColConditionName).Value).Length > varSColConditionValue.Trim().Length
                                select emp;
                        }
                    }
                    else
                    {
                        if (IsOrNotIncludeCurrentRecord == 0)
                        {
                            empSelDataRecords =
                                from emp in XElementAlls.Elements(varNodeKeyName)
                                where ((string)emp.Element(varSColConditionName).Value).Substring(0, itSColValueLength) == varSColConditionValue.Trim()
                                        && ((string)emp.Element(varSColConditionName).Value).Length >= varSColConditionValue.Trim().Length
                                select emp;
                        }
                        else
                        {
                            empSelDataRecords =
                                from emp in XElementAlls.Elements(varNodeKeyName)
                                where ((string)emp.Element(varSColConditionName).Value).Length > varSColConditionValue.Trim().Length 
                                        && ((string)emp.Element(varSColConditionName).Value).Substring(0, itSColValueLength) == varSColConditionValue.Trim()
                                select emp;
                        }
                    }

                    if (empSelDataRecords != null)
                    {
                        if (empSelDataRecords.Count() > 0)
                        {
                            itRowCount = empSelDataRecords.Count();

                            varFindNodeValueInfo = new string[itRowCount, itColCount];

                            itRowNum = 0;

                            foreach (XElement tXle in empSelDataRecords)
                            {
                                for (int itCIndex = 0; itCIndex < varSLSelectColName.GetLength(0); itCIndex++)
                                {
                                    if (itCIndex == varPKIndex)
                                    {
                                        varFindNodeValueInfo[itRowNum, itCIndex] = tXle.Attribute(varSLSelectColName[itCIndex]).Value.ToString();
                                    }
                                    else
                                    {
                                        varFindNodeValueInfo[itRowNum, itCIndex] = tXle.Element(varSLSelectColName[itCIndex]).Value.ToString();
                                    }
                                }

                                itRowNum = itRowNum + 1;
                            }

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
            catch (Exception ee)
            {
                throw ee;
            }
        }


        /// <summary>
        /// 按照两个列值条件读取节点信息
        /// </summary>
        /// <param name="varFilePath">完整的路径加XML文件名</param>
        /// <param name="varRootNode">根节点名</param>
        /// <param name="varNodeKeyName">一级子节点名</param>
        /// <param name="varSColConditionName1">选择列名1</param>
        /// <param name="varSColConditionValue1">选择列值2</param>
        /// <param name="varPKSign">选择的列1是否主键标志</param>
        /// <param name="varSColConditionName2">选择列名2</param>
        /// <param name="varSColConditionValue2">选择列值2</param>
        /// <param name="varSLSelectColName">返回数据的列名集合</param>
        /// <param name="varPKIndex">主键索引</param>
        /// <param name="varFindNodeValueInfo">返回数据值</param>
        /// <param name="varReLoadSign">文件重载标志</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>
        public bool readNodeInfoByDualColCondition(string varFilePath, string varRootNode,
                        string varNodeKeyName,
                        string varSColConditionName1, string varSColConditionValue1, int varPKSign,
                        string varSColConditionName2, string varSColConditionValue2,
                        string[] varSLSelectColName, int varPKIndex, ref string[,] varFindNodeValueInfo,int varXmlFileReLoadSign, ref string varErrStr)
        {
            int itColCount = 0;
            int itRowCount = 0;
            int itRowNum = 0;

            try
            {
                if (varNodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

                if (varSColConditionName1.Trim() == String.Empty)
                {
                    varErrStr = "筛选条件列1的列名为空！";
                    return false;
                }

                if (varSColConditionName2.Trim() == String.Empty)
                {
                    varErrStr = "筛选条件列2的列名为空！";
                    return false;
                }

                if (varSLSelectColName == null)
                {
                    varErrStr = "输入的返回列名称数组为空！";
                    return false;
                }
                else
                {
                    if (varSLSelectColName.GetLength(0) == 0)
                    {
                        varErrStr = "输入的返回列名称数组中元素个数为零！";
                        return false;
                    }
                }

                itColCount = varSLSelectColName.GetLength(0);

                LoadXmlFile(varFilePath, varRootNode,varXmlFileReLoadSign, ref XElementAlls);


                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (varSLSelectColName.GetLength(0) < (varPKIndex + 1))
                {
                    varErrStr = "主键索引设置错误！";
                    return false;
                }



                if (XElementAlls.HasElements == true)
                {
                    IEnumerable<XElement> empSelDataRecords;

                    if (varPKSign == 0)
                    {
                        empSelDataRecords =
                            from emp in XElementAlls.Elements(varNodeKeyName)
                            where (string)emp.Attribute(varSColConditionName1).Value == varSColConditionValue1
                               && (string)emp.Element(varSColConditionName2).Value == varSColConditionValue2
                            select emp;
                    }
                    else
                    {
                        empSelDataRecords =
                            from emp in XElementAlls.Elements(varNodeKeyName)
                            where (string)emp.Element(varSColConditionName1).Value == varSColConditionValue1
                               && (string)emp.Element(varSColConditionName2).Value == varSColConditionValue2
                            select emp;
                    }

                    if (empSelDataRecords != null)
                    {
                        if (empSelDataRecords.Count() > 0)
                        {
                            itRowCount = empSelDataRecords.Count();

                            varFindNodeValueInfo = new string[itRowCount, itColCount];

                            itRowNum = 0;

                            foreach (XElement tXle in empSelDataRecords)
                            {
                                for (int itCIndex = 0; itCIndex < varSLSelectColName.GetLength(0); itCIndex++)
                                {
                                    if (itCIndex == varPKIndex)
                                    {
                                        varFindNodeValueInfo[itRowNum, itCIndex] = tXle.Attribute(varSLSelectColName[itCIndex]).Value.ToString();
                                    }
                                    else
                                    {
                                        varFindNodeValueInfo[itRowNum, itCIndex] = tXle.Element(varSLSelectColName[itCIndex]).Value.ToString();
                                    }
                                }

                                itRowNum = itRowNum + 1;
                            }

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
            catch (Exception ee)
            {
                throw ee;
            }
        }

        /// <summary>
        /// 根据一级字节属性(主键值)获取读取二级子节点信息(除主键外其他列的值)
        /// </summary>
        /// <param name="varFilePath">完整的路径加XML文件名</param>
        /// <param name="varRootNode">根节点名</param>
        /// <param name="varNodeKeyName">一级子节点名</param>
        /// <param name="varKeyAttributeName">一级子节点属性名(主键名)</param>
        /// <param name="varKeyAttributeValue">一级子节点属性值(主键值)</param>
        /// <param name="varSLColName">返回数据的列名集合</param>
        /// <param name="varFindNodeValueInfo">返回数据值</param>
        /// <param name="varReLoadSign">文件重载标志</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>
        public bool readSingleNodeAlLInfoByKey(string varFilePath, string varRootNode,
                        string varNodeKeyName, string varKeyAttributeName, string varKeyAttributeValue,
                        string[] varSLColName, ref string[] varFindNodeValueInfo,int varXmlFileReLoadSign, ref string varErrStr)
        {
            try
            {
                if (varNodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

                if (varKeyAttributeName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点属性名为空(主键名为空)！";
                    return false;
                }

                if (varSLColName == null)
                {
                    varErrStr = "输入的返回列名称数组为空！";
                    return false;
                }
                else
                {
                    if (varSLColName.GetLength(0) == 0)
                    {
                        varErrStr = "输入的返回列名称数组中元素个数为零！";
                        return false;
                    }
                }

                for (int i = 0; i < varSLColName.GetLength(0); i++)
                {
                    if (varSLColName[i].Trim() == varKeyAttributeName.Trim())
                    {
                        varErrStr = "返回的列名与主键重名！";
                        return false;
                    }
                }

                varFindNodeValueInfo = new string[varSLColName.GetLength(0)];

                LoadXmlFile(varFilePath, varRootNode, varXmlFileReLoadSign, ref XElementAlls);

                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (XElementAlls.HasElements == true)
                {
                    IEnumerable<XElement> lEmpSelDataRecord =
                       from emp in XElementAlls.Elements(varNodeKeyName)
                       where (string)emp.Attribute(varKeyAttributeName) == varKeyAttributeValue
                       select emp;

                    if (lEmpSelDataRecord == null)
                    {
                        return false;
                    }

                    if (lEmpSelDataRecord.Count() == 0)
                    {
                        return false;
                    }

                    XElement tEmpSelDataRecord = lEmpSelDataRecord.ElementAt(0);

                    if (tEmpSelDataRecord == null)
                    {
                        return false;
                    }

                    if (tEmpSelDataRecord.HasElements == true)
                    {
                        for (int itSonElementIndex = 0; itSonElementIndex < varSLColName.GetLength(0); itSonElementIndex++)
                        {
                            varFindNodeValueInfo[itSonElementIndex] = tEmpSelDataRecord.Element(varSLColName[itSonElementIndex]).Value.ToString();
                        }

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
            catch (Exception ee)
            {
                throw ee;
            }
        }

        /// <summary>
        /// 读取全部节点的值
        /// </summary>
        /// <param name="varFilePath">完整的路径加XML文件名</param>
        /// <param name="varRootNode">根节点名</param>
        /// <param name="varNodeKeyName">一级子节点名</param>
        /// <param name="varSLColName">返回数据的列名集合</param>
        /// <param name="varKeyAttributeColNameIndex">列名中是一级子节点属性名的索引</param>
        /// <param name="varOrderIsNotAttributeColOrElementCol">是按照一级子节点属性排序还是按照二级子节点名排序</param>
        /// <param name="varOrderAttributeColIndex">一级子节点属性排序(列)索引</param>
        /// <param name="varOrderAttributeColOrientation">一级子节点属性排序方向</param>
        /// <param name="varOrderElementColIndex">二级子节点名排序(列)索引</param>
        /// <param name="varOrderElementColOrientation">二级子节点名排序方向</param>
        /// <param name="varFindNodeValueInfo">返回数据值</param>
        /// <param name="varReLoadSign">XML文件重载标志</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>
        public bool readAllNodeInfo(string varFilePath, string varRootNode,
                        string varNodeKeyName,
                        string[] varSLColName, int[] varKeyAttributeColNameIndex, 
                        int varOrderIsNotAttributeColOrElementCol,
                        int varOrderAttributeColIndex, int varOrderAttributeColOrientation,
                        int varOrderElementColIndex, int varOrderElementColOrientation,
                        ref string[,] varFindNodeValueInfo,int varXmlFileReLoadSign, ref string varErrStr)
        {
            int itRowCount = 0;
            int itColCount = 0;
            int itRowNum = 0;
            int itAttributeColNameSign = 0;

            try
            {
                if (varNodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

                if (varSLColName == null)
                {
                    varErrStr = "输入的返回列名称数组为空！";
                    return false;
                }
                else
                {
                    if (varSLColName.GetLength(0) == 0)
                    {
                        varErrStr = "输入的返回列名称数组中元素个数为零！";
                        return false;
                    }
                }

                itColCount = varSLColName.GetLength(0);

                LoadXmlFile(varFilePath, varRootNode,varXmlFileReLoadSign, ref XElementAlls);

                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (XElementAlls.HasElements == true)
                {
                    IEnumerable<XElement> empSelAllDataRecord =
                          from emp in XElementAlls.Elements(varNodeKeyName)
                          orderby (string)emp.Attribute(varSLColName[varKeyAttributeColNameIndex[0]]).Value ascending
                          select emp;

                    if (empSelAllDataRecord != null)
                    {
                        if (empSelAllDataRecord.Count() > 0)
                        {
                            IEnumerable<XElement> empSelAllDataRecord2;

                            if (varOrderIsNotAttributeColOrElementCol == 0) //按属性排
                            {
                                if (varOrderAttributeColOrientation == 0) //按属性正排
                                {
                                    empSelAllDataRecord2 = empSelAllDataRecord.OrderBy(X => X.Attribute(varSLColName[varOrderAttributeColIndex]).Value.ToString());
                                }
                                else
                                {   //按属性倒排
                                    empSelAllDataRecord2 = empSelAllDataRecord.OrderByDescending(X => X.Attribute(varSLColName[varOrderAttributeColIndex]).Value.ToString());
                                }
                            }
                            else
                            {
                                if (varOrderElementColOrientation == 0) //按属性正排
                                {
                                    empSelAllDataRecord2 = empSelAllDataRecord.OrderBy(X => X.Element(varSLColName[varOrderElementColIndex]).Value.ToString());
                                }
                                else
                                {   //按属性倒排
                                    empSelAllDataRecord2 = empSelAllDataRecord.OrderByDescending(X => X.Element(varSLColName[varOrderElementColIndex]).Value.ToString());
                                }
                            }

                            itRowCount = empSelAllDataRecord2.Count();

                            varFindNodeValueInfo = new string[itRowCount, itColCount];

                            itRowNum = 0;
                            
                            if (empSelAllDataRecord2.Count() > 0)
                            {
                                foreach (XElement tXe in empSelAllDataRecord2)
                                {
                                    for (int itKACI = 0; itKACI < varKeyAttributeColNameIndex.GetLength(0); itKACI++)
                                    {
                                        varFindNodeValueInfo[itRowNum, itKACI] = tXe.Attribute(varSLColName[varKeyAttributeColNameIndex[itKACI]]).Value;
                                    }

                                    for (int itCol = 0; itCol < itColCount; itCol++)
                                    {
                                        itAttributeColNameSign = 0;

                                        for (int itKACI = 0; itKACI < varKeyAttributeColNameIndex.GetLength(0); itKACI++)
                                        {
                                            if (itCol == varKeyAttributeColNameIndex[itKACI])
                                            {
                                                itAttributeColNameSign = 1;
                                            }
                                        }

                                        if (itAttributeColNameSign == 0)
                                        {
                                            varFindNodeValueInfo[itRowNum, itCol] = tXe.Element(varSLColName[itCol]).Value;
                                        }
                                    }

                                    itRowNum = itRowNum + 1;
                                }
                            }

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
            catch (Exception ee)
            {
                throw ee;
            }
        }

        /// <summary>
        /// 获取单列的最大值
        /// </summary>
        /// <param name="varFilePath">完整的路径加XML文件名</param>
        /// <param name="varRootNode">根节点名</param>
        /// <param name="varNodeKeyName">一级子节点名</param>
        /// <param name="varGetMaxValueColName">求取最大值的列名</param>
        /// <param name="varPKSign">是否主键标志</param>
        /// <param name="varColValueLength">列长度</param>
        /// <param name="varStepValue">步长</param>
        /// <param name="varDefaultValue">默认值</param>
        /// <param name="varFindMaxValue">获取的最大值</param>
        /// <param name="varXmlFileReLoadSign">XML文件重载标志</param>
        /// <param name="varErrStr">捕获错误信息</param>
        /// <returns></returns>
        public bool GetSingleFieldNewMaxValue(string varFilePath, string varRootNode,
                        string varNodeKeyName, 
                        string varGetMaxValueColName,int varPKSign, 
                        string varColValueLength,int varStepValue,string varDefaultValue, ref string varFindMaxValue,
                        int varXmlFileReLoadSign, ref string varErrStr)
        {
            Int64 itFindNewMaxValue = -1;

            try
            {
                if (varNodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }

       
                LoadXmlFile(varFilePath, varRootNode, varXmlFileReLoadSign, ref XElementAlls);

                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (XElementAlls.HasElements == true)
                {
                    Int64 itFindMaxValue = 0;

                    if (varPKSign == 0)
                    {
                        itFindMaxValue = XElementAlls.Elements(varNodeKeyName).Max(x => (Int64)x.Attribute(varGetMaxValueColName));
                    }
                    else
                    {
                        itFindMaxValue = XElementAlls.Elements(varNodeKeyName).Max(x => (Int64)x.Element(varGetMaxValueColName));
                    }

                    if (itFindMaxValue > 0)
                    {
                       itFindNewMaxValue= itFindMaxValue + varStepValue;

                       varFindMaxValue = itFindNewMaxValue.ToString("D" + varColValueLength);
                       
                        return true;
                    }
                    else
                    {
                        if (itFindMaxValue == 0)
                        {
                            varFindMaxValue = varDefaultValue;
                            return true;
                        }
                        else
                        {
                            varErrStr = "未能构造新的最大编码！";
                            return false;
                        }
                    }
                }
                else
                {
                    varFindMaxValue= varDefaultValue;
                    return true;
                }
            }
            catch(Exception ee)
            {
                throw ee;
            }
        }

        /// <summary>
        /// 根据筛选条件(一般是两部分编码的第一部分)，获取单列(两部分构成编码)的最大值
        /// </summary>
        /// <param name="varFilePath">完整的路径加XML文件名</param>
        /// <param name="varRootNode">根节点名</param>
        /// <param name="varNodeKeyName">一级子节点名</param>
        /// <param name="varGetMaxValueColName">求取最大值的列名</param>
        /// <param name="varPKSign">是否主键标志</param>
        /// <param name="varCondationColName">筛选条件列名</param>
        /// <param name="varCondationColValue">筛选条件列值</param>
        /// <param name="varColSecondPartValueLength">编码第二部分列值长度</param>
        /// <param name="varStepValue">步长</param>
        /// <param name="varDefaultFirstPartValue">编码第一部分列值默认值</param>
        /// <param name="varDefaultSecondPartValue">编码第二部分列值默认值</param>
        /// <param name="varFindMaxValue">获取的最大值</param>
        /// <param name="varXmlFileReLoadSign">XML文件重载标志</param>
        /// <param name="varErrStr">捕获错误信息</param>
        /// <returns></returns>
        public bool GetSingleFieldNewTwoPartMaxValueByCondation(string varFilePath, string varRootNode, 
                       string varNodeKeyName,
                       string varGetMaxValueColName, int varPKSign,
                       string varCondationColName, string varCondationColValue,
                       string varColSecondPartValueLength, int varStepValue,
                       string varDefaultFirstPartValue, string varDefaultSecondPartValue, 
                       ref string varFindMaxValue,
                       int varXmlFileReLoadSign, ref string varErrStr)
        {
            int itFindNewMaxValue = -1;

            try
            {
                if (varNodeKeyName.Trim() == String.Empty)
                {
                    varErrStr = "一级子节点名为空(记录标记名为空)！";
                    return false;
                }


                LoadXmlFile(varFilePath, varRootNode, varXmlFileReLoadSign, ref XElementAlls);

                if (XElementAlls == null)
                {
                    varErrStr = "未能装载XML文件！";
                    return false;
                }

                if (XElementAlls.HasElements == true)
                {
                    int itFindMaxValue = 0;

                    IEnumerable<XElement> findXElementRecordByCondation =
                                   from emp in XElementAlls.Elements(varNodeKeyName)
                                   where (string)emp.Element(varCondationColName).Value == varCondationColValue
                                   select emp;

                    if (findXElementRecordByCondation == null)
                    {
                        varFindMaxValue = varDefaultFirstPartValue + varDefaultSecondPartValue;
                        return true;
                    }

                    if (findXElementRecordByCondation.Count() == 0)
                    {
                        varFindMaxValue = varDefaultFirstPartValue + varDefaultSecondPartValue;
                        return true;
                    }

                    string stColFirstValue = findXElementRecordByCondation.First().Attribute(varGetMaxValueColName).Value.ToString();

                    int itColValueLength = stColFirstValue.Length;

                    int itColPartValueLength = int.Parse(varColSecondPartValueLength);

                    if (itColValueLength < itColPartValueLength)
                    {
                        varErrStr = "未能构造新的最大编码！";
                        return false;
                    }

                    if (varPKSign == 0)
                    {
                        itFindMaxValue = findXElementRecordByCondation.Max(x => int.Parse(((string)x.Attribute(varGetMaxValueColName).Value).Substring(itColValueLength - itColPartValueLength, itColPartValueLength)));
                    }
                    else
                    {
                        itFindMaxValue = findXElementRecordByCondation.Max(x => int.Parse(((string)x.Element(varGetMaxValueColName).Value).Substring(itColValueLength - itColPartValueLength, itColPartValueLength)));
                    }

                    if (itFindMaxValue > 0)
                    {
                        itFindNewMaxValue = itFindMaxValue + varStepValue;

                        varFindMaxValue = stColFirstValue.Substring(0, itColValueLength - itColPartValueLength) + itFindNewMaxValue.ToString("D" + varColSecondPartValueLength);
                        return true;
                    }
                    else
                    {
                        if (itFindMaxValue == 0)
                        {
                            varFindMaxValue = stColFirstValue.Substring(0, itColValueLength - itColPartValueLength) + varDefaultSecondPartValue;
                            return true;
                        }
                        else
                        {
                            varErrStr = "未能构造新的最大编码！";
                            return false;
                        }
                    }
                }
                else
                {
                    varFindMaxValue = varDefaultFirstPartValue + varDefaultSecondPartValue;
                    return true;
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        /// <summary>
        /// 将数组转化成为DataTable
        /// </summary>
        /// <param name="varSLColName">输入列名数组</param>
        /// <param name="varSLColTypeName">输入列类型数组</param>
        /// <param name="varSLFindALLNodeValueInfo">要转化的数组</param>
        /// <param name="varDT">转化后的DataTable</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>
        public bool convertArrayToDataTable(ref string[] varSLColName, ref string[] varSLColTypeName, ref string[,] varSLFindALLNodeValueInfo, ref DataTable varDT,ref string varErrStr)
        {
            try
            {
                if (checkTwoArrayDataIntegrity(ref varSLColName, ref varSLColTypeName, ref varErrStr) == false)
                {
                    return false;
                }

                DataTable dt = new DataTable();

                System.Data.DataRow dr;

                for (int iCName = 0; iCName < varSLColName.GetLength(0); iCName++)
                {
                    switch (varSLColTypeName[iCName])
                    {
                        case "string":
                            dt.Columns.Add(varSLColName[iCName], typeof(string));
                            break;
                        case "int":
                            dt.Columns.Add(varSLColName[iCName], typeof(int));
                            break;
                        case "double":
                            dt.Columns.Add(varSLColName[iCName], typeof(double));
                            break;
                        case "bool":
                            dt.Columns.Add(varSLColName[iCName], typeof(bool));
                            break;
                        case "DateTime":
                            dt.Columns.Add(varSLColName[iCName], typeof(DateTime));
                            break;
                        case "image":
                            dt.Columns.Add(varSLColName[iCName], typeof(byte[]));
                            break;
                    }
                }

                for (int itRow = 0; itRow < varSLFindALLNodeValueInfo.GetLength(0); itRow++)
                {
                    dr = dt.NewRow();

                    for (int jtCol = 0; jtCol < varSLFindALLNodeValueInfo.GetLength(1); jtCol++)
                    {
                        switch (varSLColTypeName[jtCol])
                        {
                            case "string":
                                dr[varSLColName[jtCol]] = varSLFindALLNodeValueInfo[itRow, jtCol].ToString();
                                break;
                            case "int":
                                dr[varSLColName[jtCol]] = int.Parse(varSLFindALLNodeValueInfo[itRow, jtCol].ToString());
                                break;
                            case "double":
                                dr[varSLColName[jtCol]] = double.Parse(varSLFindALLNodeValueInfo[itRow, jtCol].ToString());
                                break;
                            case "bool"://在测试中有可能修改调整
                                dr[varSLColName[jtCol]] = bool.Parse(varSLFindALLNodeValueInfo[itRow, jtCol].ToString());
                                break;
                            case "DateTime"://在测试中有可能修改调整
                                dr[varSLColName[jtCol]] = DateTime.Parse(varSLFindALLNodeValueInfo[itRow, jtCol].ToString());
                                break;
                            case "image"://在测试中有可能修改调整
                                if (varSLFindALLNodeValueInfo[itRow, jtCol].ToString().Trim() != String.Empty)
                                {
                                    //byte[] imageData = System.Text.Encoding.Default.GetBytes(varSLFindALLNodeValueInfo[itRow, jtCol].ToString());

                                    byte[] imageData = System.Convert.FromBase64String(varSLFindALLNodeValueInfo[itRow, jtCol]);

                                    if (imageData.GetLength(0) > 0)
                                    {
                                        dr[varSLColName[jtCol]] = imageData;
                                    }
                                }
                                break;
                        }
                    }

                    dt.Rows.Add(dr);
                }

                if (dt != null)
                {
                    if (dt.Rows != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            varDT = dt;

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
                    varErrStr = "二维数组转化DataTable错误!";
                    return false;
                }

            }
            catch (Exception ee)
            {
                throw new Exception("二维数组转化DataTable错误!" + ee.Message);
            }
        }

        /// <summary>
        /// 两个数组中元素是否符合逻辑
        /// </summary>
        /// <param name="varfristArray">第一个数组</param>
        /// <param name="varSecondArray">第二个数组</param>
        /// <param name="varErrStr">捕获错误</param>
        /// <returns></returns>
        private bool checkTwoArrayDataIntegrity(ref string[] varfristArray, ref string[] varSecondArray,ref string varErrStr)
        {
            if (varfristArray == null || varSecondArray == null)
            {
                varErrStr = "输入数组为空！";
                return false;
            }
            else
            {
                if (varSecondArray.GetLength(0) == 0 || varSecondArray.GetLength(0) == 0)
                {
                    varErrStr = "输入数组中元素个数为零！";
                    return false;
                }
                else
                {
                    if (varSecondArray.GetLength(0) != varSecondArray.GetLength(0))
                    {
                        varErrStr = "输入两个数组中元素个数不一致！";
                        return false;
                    }
                }
            }

            return true;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varFirstArray"></param>
        /// <param name="varSecondArray"></param>
        /// <param name="varCombiningArray"></param>
        /// <param name="varErrStr"></param>
        /// <returns></returns>
        private bool JoinArrayToOtherArray(ref string[] varFirstArray, ref string[] varSecondArray, ref string[] varCombiningArray, ref string varErrStr)
        {
            if (varFirstArray == null || varSecondArray == null) 
            {
                varErrStr = "输入数组为空！";
                return false;
            }

            if (varFirstArray.GetLength(0) == 0 || varSecondArray.GetLength(0) == 0)
            {
                varErrStr = "输入数组中元素个数为零！";
                return false;
            }

            string[] CombiningArray = new string[varFirstArray.GetLength(0) + varSecondArray.GetLength(0)];
           
            varFirstArray.CopyTo(CombiningArray, 0);
            
            varSecondArray.CopyTo(CombiningArray, varFirstArray.GetLength(0));

            varCombiningArray = CombiningArray;

            return true;
        }


        ~CXDocumentControl()
        {
            XElementAlls = null;
        }
    }
}

