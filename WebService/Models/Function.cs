using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Web.Mvc;
using OfficeOpenXml;
using System.IO;
using System.Data.SqlTypes;

namespace WebService.Models
{
    public class Function
    {
        Auto_Testing_Service.Service Auto_Testing_Service_ASMX = new Auto_Testing_Service.Service();
        FIMPWS_MS_EXT.SFIS_WS FIMP_MS_EXT_ASMX = new FIMPWS_MS_EXT.SFIS_WS();
        FIMPWS.SFIS_WS FIMPWS_ASMX = new FIMPWS.SFIS_WS();

        public ResponseInfo QueryDataByXML(string IP, string QueryStr)
        {
            ResponseInfo responseInfo = new ResponseInfo();

            if (!(IP.Equals("http://172.22.246.201/Auto_Testing_Service") || IP.Equals("http://172.22.246.201/FIMPWS_MS_EXT/SFIS_WS.asmx") || IP.Equals("http://172.22.246.200/FIMPWS/SFIS_WS.asmx")))
            {
                responseInfo.ResponseMsg = "IP或XML字串錯誤";
                responseInfo.ResponseData = null;
            }

            try
            {
                DataSet ds = new DataSet();

                if (IP.Equals("http://172.22.246.201/Auto_Testing_Service"))
                {
                    responseInfo.ResponseMsg = "Success";
                    responseInfo.ResponseData = Auto_Testing_Service_ASMX.Rv(QueryStr);
                }

                else if (IP.Equals("http://172.22.246.201/FIMPWS_MS_EXT/SFIS_WS.asmx"))
                {
                    responseInfo.ResponseMsg = "Success";
                    responseInfo.ResponseData = FIMP_MS_EXT_ASMX.Rv(QueryStr);
                }


                else if(IP.Equals("http://172.22.246.200/FIMPWS/SFIS_WS.asmx"))
                {
                    responseInfo.ResponseMsg = "Success";
                    responseInfo.ResponseData = FIMPWS_ASMX.Rv(QueryStr);
                }

                return responseInfo;
            }
            catch (Exception ex)
            {
                responseInfo.ResponseMsg = ex.Message;
                responseInfo.ResponseData = null;
                return responseInfo;
            }
        }

        public string[] GetxmlNodeValue(string xmlString)
        {
            //string to XML
            XDocument xmlDoc = XDocument.Parse(xmlString);

            //Get all XML NodeName except root
            string[] xmlNodeName = xmlDoc.Descendants()
            .Where(x => !x.HasElements && x.NodeType == XmlNodeType.Element && !x.Name.LocalName.Contains("METHOD"))
            .Select(x => x.Name.LocalName)
            .ToArray();

            return xmlNodeName;
        }

        public string XmlValueEmpty(string xmlString)
        {
            //string to XML
            XDocument xmlDoc = XDocument.Parse(xmlString);

            //Get all XML NodeName except root
            string[] xmlNodeName = GetxmlNodeValue(xmlString);

            //Set all XML NodeValue => null
            foreach (var item in xmlNodeName)
            {
                XElement nodeToChange = xmlDoc.Descendants(item).FirstOrDefault();
                nodeToChange.Value = "";
            }

            return xmlDoc.ToString();
        }

        public List<string> ExcelValueToXmlValue(HttpPostedFileBase excelFile, string xmlString)
        {
            try
            {
                List<string> sort_value = new List<string>();

                //Set all XML NodeValue => null
                string SortXmlStr = XmlValueEmpty(xmlString);

                //string to XML
                XDocument xmlDoc = XDocument.Parse(SortXmlStr);

                //Use user excel file sort XML value
                using (var package = new ExcelPackage(excelFile.InputStream))
                {
                    //Create worksheets
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    //Get row & col count
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    //Count input data contain with xml format times
                    int sameParaCount = 0;
                    string[] xmlNodeName = GetxmlNodeValue(xmlString);

                    for (int k = 1; k <= colCount; k++)
                    {
                        string ExcelHeadName = worksheet.Cells[1, k].Value.ToString();
                        if (xmlNodeName.Contains(ExcelHeadName))
                        {
                            sameParaCount++;
                        }
                    }

                    //Check input data contain with xml format
                    if (sameParaCount.Equals(colCount))
                    {
                        //Change XML value
                        for (int i = 2; i <= rowCount; i++)
                        {
                            for (int j = 1; j <= colCount; j++)
                            {
                                string colname = worksheet.Cells[1, j].Value.ToString();
                                XElement nodeToChange = xmlDoc.Descendants(colname).FirstOrDefault();

                                if (nodeToChange != null)
                                {
                                    string colvalue = worksheet.Cells[i, j].Value.ToString();
                                    nodeToChange.Value = colvalue;
                                }
                            }

                            sort_value.Add(xmlDoc.ToString());
                        }

                        return sort_value;
                    }
                    else
                    {
                        //MessageBox.Show("Excel headRow value not same with XML format !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public ResponseInfo QueryDataByExcel(HttpPostedFileBase excelFile , string IP, string QueryStr)
        {
            ResponseInfo responseInfo = new ResponseInfo();

            if (!(IP.Equals("http://172.22.246.201/Auto_Testing_Service") || IP.Equals("http://172.22.246.201/FIMPWS_MS_EXT/SFIS_WS.asmx") || IP.Equals("http://172.22.246.200/FIMPWS/SFIS_WS.asmx")))
            {
                responseInfo.ResponseMsg = "IP或XML字串錯誤";
                responseInfo.ResponseData = null;
                return responseInfo;
            }
            else
            {
                try
                {
                    List<string> sort_value = new List<string>();

                    //Set all XML NodeValue => null
                    string SortXmlStr = XmlValueEmpty(QueryStr);

                    //string to XML
                    XDocument xmlDoc = XDocument.Parse(SortXmlStr);

                    //Use user excel file sort XML value
                    using (var package = new ExcelPackage(excelFile.InputStream))
                    {
                        //Create worksheets
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                        //Get row & col count
                        int rowCount = worksheet.Dimension.Rows;
                        int colCount = worksheet.Dimension.Columns;

                        //Count input data contain with xml format times
                        int sameParaCount = 0;
                        string[] xmlNodeName = GetxmlNodeValue(QueryStr);

                        for (int k = 1; k <= colCount; k++)
                        {
                            string ExcelHeadName = worksheet.Cells[1, k].Value.ToString();
                            if (xmlNodeName.Contains(ExcelHeadName))
                            {
                                sameParaCount++;
                            }
                        }

                        //Check input data contain with xml format
                        if (!sameParaCount.Equals(colCount))
                        {
                            responseInfo.ResponseMsg = "Excel欄位內容與XML參數不符合";
                            responseInfo.ResponseData = null;
                            return responseInfo;
                        }
                        else
                        {
                            //Change XML value
                            for (int i = 2; i <= rowCount; i++)
                            {
                                for (int j = 1; j <= colCount; j++)
                                {
                                    string colname = worksheet.Cells[1, j].Value.ToString();
                                    XElement nodeToChange = xmlDoc.Descendants(colname).FirstOrDefault();

                                    if (nodeToChange != null)
                                    {
                                        string colvalue = worksheet.Cells[i, j].Value.ToString();
                                        nodeToChange.Value = colvalue;
                                    }
                                }

                                sort_value.Add(xmlDoc.ToString());
                            }

                            DataSet ds_Finish = new DataSet();

                            foreach (var item in sort_value)
                            {
                                DataSet ds_Process = null;

                                if (IP.Equals("http://172.22.246.201/Auto_Testing_Service"))
                                {
                                    ds_Process = Auto_Testing_Service_ASMX.Rv(item);
                                }

                                else if (IP.Equals("http://172.22.246.201/FIMPWS_MS_EXT/SFIS_WS.asmx"))
                                {
                                    ds_Process = FIMP_MS_EXT_ASMX.Rv(item);
                                }


                                else if (IP.Equals("http://172.22.246.200/FIMPWS/SFIS_WS.asmx"))
                                {
                                    ds_Process = FIMPWS_ASMX.Rv(item);
                                }

                                ds_Finish.Merge(ds_Process);
                            }

                            responseInfo.ResponseMsg = "Success";
                            responseInfo.ResponseData = ds_Finish;
                            return responseInfo;
                        }
                    }
                }
                catch (Exception ex)
                {
                    responseInfo.ResponseMsg = ex.Message;
                    responseInfo.ResponseData = null;
                    return responseInfo;
                }
            }
        }
    }
}