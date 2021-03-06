using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.IO;

namespace VOA
{
    class ClassConfig
    {
        public static string configSavePath;

        public static Boolean configIsHtmlDownload;

        public static Boolean configIsTXTDownload;

        public static Boolean configIsMP3Download;

        public static ArrayList configVOATypeList;

        string[] typeName = { 
            "VOA Standard English", 

            "Development Report", 
            "This is America", 
            "Agriculture Report", 
            "Science in the News", 
            "Health Report", 
            "Explorations", 
            "Education Report", 
            "The Making of a Nation", 
            "Economics Report", 
            "American Mosaic", 
            "In the News", 
            "American Stories", 
            "Words And Their Stories", 
            "People in America", 
            
            "Go English", 
            "Wordmaster", 
            "Learn A Word", 
            "Bilingual News", 
            "American Cafe", 
            "Popular American", 
            "Business Etiquette", 
            "Sports English", 
            "Words And Idioms", 
            "Intermediate American Enlish" 
        };

        string[] typeURL = { 
            "http://www.51voa.com/VOA_Standard_1.html", 
            
            "http://www.51voa.com/Development_Report_1.html", 
            "http://www.51voa.com/This_is_America_1.html", 
            "http://www.51voa.com/Agriculture_Report_1.html", 
            "http://www.51voa.com/Science_in_the_News_1.html", 
            "http://www.51voa.com/Health_Report_1.html", 
            "http://www.51voa.com/Explorations_1.html", 
            "http://www.51voa.com/Education_Report_1.html", 
            "http://www.51voa.com/The_Making_of_a_Nation_1.html", 
            "http://www.51voa.com/Economics_Report_1.html", 
            "http://www.51voa.com/American_Mosaic_1.html", 
            "http://www.51voa.com/In_the_News_1.html", 
            "http://www.51voa.com/American_Stories_1.html", 
            "http://www.51voa.com/Words_And_Their_Stories_1.html", 
            "http://www.51voa.com/People_in_America_1.html", 

            "http://www.51voa.com/Go_English_1.html", 
            "http://www.51voa.com/Word_Master_1.html", 
            "http://www.51voa.com/Learn_A_Word_1.html", 
            "http://www.51voa.com/Bilingual_News_1.html", 
            "http://www.51voa.com/American_Cafe_1.html", 
            "http://www.51voa.com/Popular_American_1.html", 
            "http://www.51voa.com/Business_Etiquette_1.html", 
            "http://www.51voa.com/Sports_English_1.html", 
            "http://www.51voa.com/Words_And_Idioms_1.html", 
            "http://www.51voa.com/Intermediate_American_English_1.html" 
        };

        public ClassConfig()
        {
            configSavePath = "C:\\";
            configIsMP3Download = true;
            configIsTXTDownload = false;
            configIsHtmlDownload = false;
            configVOATypeList = new ArrayList();
            
            for (int i = 0; i < typeName.Length; i++)
            {
                VOA.ClassConfigVOAType voaType = new ClassConfigVOAType();
                voaType.TypeName = typeName[i];
                voaType.TypeURL = typeURL[i];
                if (i == 0)
                {
                    voaType.TypeCategory = "VOA Standard English";
                    voaType.TpyeIsDownload = true;
                }
                else if (i > 0 && i <= 14)
                {
                    voaType.TypeCategory = "VOA Special English";
                    voaType.TpyeIsDownload = false;
                }
                else
                {
                    voaType.TypeCategory = "VOA English Learning";
                    voaType.TpyeIsDownload = false;
                }
                configVOATypeList.Add(voaType);
            }
        }

        public static Boolean ReadConfigFile()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load("VOA.inf");
                XmlNodeList nodeList = document.GetElementsByTagName("ConfigItem");
                for (int i = 0; i < nodeList.Count; i++)
                {
                    XmlNode node = nodeList.Item(i);
                    string test = node.Attributes["Name"].Value + " Value:" + node.Attributes["Value"].Value;
                    if (node.Attributes["Name"].Value == "configSavePath")
                    {
                        VOA.ClassConfig.configSavePath = node.Attributes["Value"].Value;
                    }
                    else if (node.Attributes["Name"].Value == "configIsHtmlDownload")
                    {
                        VOA.ClassConfig.configIsHtmlDownload = node.Attributes["Value"].Value == "False" ? false : true;
                    }
                    else if (node.Attributes["Name"].Value == "configIsMP3Download")
                    {
                        VOA.ClassConfig.configIsMP3Download = node.Attributes["Value"].Value == "False" ? false : true;
                    }
                    else if (node.Attributes["Name"].Value == "configIsTXTDownload")
                    {
                        VOA.ClassConfig.configIsTXTDownload = node.Attributes["Value"].Value == "False" ? false : true;
                    }
                    else
                    {
                        for (int j = 0; j < VOA.ClassConfig.configVOATypeList.Count; j++)
                        {
                            ClassConfigVOAType config = (ClassConfigVOAType)VOA.ClassConfig.configVOATypeList[j];
                            if (node.Attributes["Name"].Value == config.TypeName)
                            {
                                config.TpyeIsDownload = node.Attributes["Value"].Value == "False" ? false : true;
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }           
        }

        public static Boolean SaveConfigFile()
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter("VOA.inf", null);

                writer.Formatting = Formatting.Indented;  //缩进格式
                writer.Indentation = 4;
                writer.WriteStartDocument();

                writer.WriteStartElement("Config");
                writer.WriteStartAttribute("Name", null);
                writer.WriteString("VOADownloader");
                writer.WriteEndAttribute();
                //写入configSavePath
                writer.WriteStartElement("ConfigItem");
                writer.WriteStartAttribute("Name", null);
                writer.WriteString("configSavePath");
                writer.WriteEndAttribute();
                writer.WriteStartAttribute("Value", null);
                writer.WriteString(configSavePath);
                writer.WriteEndAttribute();
                writer.WriteEndElement();

                //写入configIsHtmlDownload
                writer.WriteStartElement("ConfigItem");
                writer.WriteStartAttribute("Name", null);
                writer.WriteString("configIsHtmlDownload");
                writer.WriteEndAttribute();
                writer.WriteStartAttribute("Value", null);
                writer.WriteString(configIsHtmlDownload.ToString());
                writer.WriteEndAttribute();
                writer.WriteEndElement();

                //写入configIsTXTDownload
                writer.WriteStartElement("ConfigItem");
                writer.WriteStartAttribute("Name", null);
                writer.WriteString("configIsTXTDownload");
                writer.WriteEndAttribute();
                writer.WriteStartAttribute("Value", null);
                writer.WriteString(configIsTXTDownload.ToString());
                writer.WriteEndAttribute();
                writer.WriteEndElement();

                //写入configIsMP3Download
                writer.WriteStartElement("ConfigItem");
                writer.WriteStartAttribute("Name", null);
                writer.WriteString("configIsMP3Download");
                writer.WriteEndAttribute();
                writer.WriteStartAttribute("Value", null);
                writer.WriteString(configIsMP3Download.ToString());
                writer.WriteEndAttribute();
                writer.WriteEndElement();

                //写入configVOATypeList
                for (int i = 0; i < configVOATypeList.Count; i++)
                {
                    VOA.ClassConfigVOAType voaType = (VOA.ClassConfigVOAType)configVOATypeList[i];
                    writer.WriteStartElement("ConfigItem");
                    writer.WriteStartAttribute("Name", null);
                    writer.WriteString(voaType.TypeName);
                    writer.WriteEndAttribute();
                    writer.WriteStartAttribute("Value", null);
                    writer.WriteString(voaType.TpyeIsDownload.ToString());
                    writer.WriteEndAttribute();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();

                //FileInfo fi = new FileInfo("VOA.inf");
                //fi.Attributes = fi.Attributes | FileAttributes.Hidden;

                return true;              
            }
            catch (Exception ex)
            {
                return false;  
            }
            
        }
    }
}
