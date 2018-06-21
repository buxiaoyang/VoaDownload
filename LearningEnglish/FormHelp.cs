﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VOA
{
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();
            StringBuilder str = new StringBuilder();

            str.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
            str.Append("<html>");
            str.Append("	<head>");
            str.Append("		<title></title>");
            str.Append("	</head>");
            str.Append("	<body>");
            str.Append("        <strong><span style=\"font-size: 14pt\">");
            str.Append("        VOA自动下载器 v1.0 </span></strong>");
            str.Append("        <br />");
            str.Append("        ==========================<br />");
            str.Append("        版权所有，违者不究。^_^");
            str.Append("        <br />");
            str.Append("        电子邮件：<span style=\"color: blue\">lotte-yang@hotmail.com </span>");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <a name=\"1\"><strong>一、什么是“VOA自动下载器” </strong></a>");
            str.Append("        <br />");
            str.Append("        <hr></hr>");
            str.Append("        <br />");
            str.Append("        <strong>“VOA自动下载器”</strong>是一个英语学习辅助工具软件，它能根据用户的设置自动下载网络上最新更新的<strong>“VOA”（美国之音）</strong>音频和文本到本地计算机。<br />");
            str.Append("        <br />");
            str.Append("        设计这个软件的最初目的是因为练习听力需要定期的更新MP3里的新闻音频，但是每次都去网页上点击下载比较繁琐<span style=\"color: red\">（参见：<span style=\"color: blue\">“http://www.51voa.com”</span>）</span>。本工具的作用就是省去了点击网页的时间，让您能够一键下载需要的音频和文本到本地文件夹，从而可以直接拷到MP3中使用。");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        * 用户可自定义下载路径。<span style=\"color: darkgray\">参见“三、关于<strong>“配置”</strong>界面-&gt;<strong>下载文件保存路径</strong>”");
            str.Append("        </span>");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        * 用户可自定义下载文件的类别<span style=\"color: red\">（包括</span><strong>“常速英语”</strong>、<strong>“慢速英语”</strong>、<strong>“英语学习”</strong><span");
            str.Append("            style=\"color: red\">）</span>。<span style=\"color: silver\">参见“三、关于<strong>“配置”</strong>界面-&gt;<strong>下载文件的类别</strong>”");
            str.Append("        <br />");
            str.Append("        </span>");
            str.Append("        <br />");
            str.Append("        * 用户可自定义下载文件的类型<span style=\"color: red\">（包括</span><strong>“MP3音频文件”</strong>、<strong>“HTML网页文件”</strong><span");
            str.Append("            style=\"color: red\">）</span>。<span style=\"color: silver\">参见“三、关于<strong>“配置”</strong>界面-&gt;<strong>选择下载的文件类型</strong>”");
            str.Append("        <br />");
            str.Append("        </span>");
            str.Append("        <br />");
            str.Append("        * 软件的主要由<strong>“主界面”</strong>、<strong>“配置”</strong>、<strong>“帮助”</strong>、<strong>“关于”</strong>几个界面组成。");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <a id=\"2\" name=\"2\"><strong>二、关于“主界面” </strong></a>");
            str.Append("        <br />");
            str.Append("        <hr></hr>");
            str.Append("        <br />");
            str.Append("        <strong>“主界面”</strong>是用户刚启动软件时所能见到的界面。");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <strong>“主界面”</strong>由<strong>“菜单栏”</strong>、<strong>“复选框列表”</strong>、<strong>“按钮面板”</strong>和<strong>“状态栏”</strong>组成。");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <strong>“菜单栏”</strong>由<strong>“配置”</strong>、<strong>“帮助”</strong>、<strong>“关于”</strong>菜单组成。点击相应的菜单可打开对应的界面。");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <strong>“复选框列表”</strong>显示的是软件根据用户配置获取的最新跟新的音频文件列表，包括文件类别、文件名、以及文件跟新的日期。用户可以点击选中一个或多个文件已供下载。<br />");
            str.Append("        <span style=\"color: red\">");
            str.Append("        （注：只有在这个列表中选中的文件才会被下载） </span>");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <strong>“按钮面板”</strong>包括<strong>“刷新列表”</strong>、<strong>“全选”</strong>、<strong>“选中前20个”</strong>、<strong>“全不选”</strong>和<strong>“开始下载”</strong>五个按钮。其中前四个按钮是对“<strong>复选框列表”</strong>的相应操作，点击<strong>“开始下载”</strong>按钮则下载选中的文件。<br />");
            str.Append("        <span style=\"color: red\">（注：下载的文件会保存在<strong>“配置”</strong>界面中配置的<strong>“下载文件保存路径”</strong>路径下面，软件会自动在该目录下新建一个以下载当天日期命名的文件夹中，MP3文件和HTML文件会放在同一文件夹下。）</span>");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <strong>“状态栏”</strong>由<strong>“状态”</strong>和<strong>“进度”</strong>两个部分组成。当有操作时，状态栏会显示相应状态和进度。");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        每次刚打开软件时，软件会根据配置项自动加载<strong>“复选框列表”</strong>中的最新更新，点击<strong>“刷新列表”</strong>按钮则重复这一过程。需要说明的是，如果用户在<strong>“配置”</strong>界面修改了配置后，需要点击<strong>“刷新列表”</strong>或者重启软件以根据最新配置跟新列表。<br />");
            str.Append("        <span style=\"color: red\">（注：当跟新<strong>“复选框列表”</strong>时<strong>“配置”</strong>菜单、<strong>“刷新列表”</strong>按钮、<strong>“开始下载”</strong>按钮将不可用，列表跟新完毕后恢复可用）</span>");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <a name=\"3\"><strong>三、关于“配置”界面</strong></a>");
            str.Append("        <br />");
            str.Append("        <hr></hr>");
            str.Append("        <br />");
            str.Append("        点击<strong>“主界面”</strong>菜单栏中的<strong>“配置”</strong>菜单可打开<strong>“配置”</strong>界面。");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <strong>“配置”</strong>界面由<strong>“下载文件保存路径”</strong>、<strong>“下载文件的类别”</strong>、<strong>“选择下载的文件类型”</strong>和<strong>“保存、取消”</strong>按钮几个部分组成。");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <strong>“下载文件保存路径”</strong>中用户可设置下载的音频文本文件的保存路径。");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <strong>“下载文件的类别”</strong>中用户可设置显示的文件跟新的类别。类别包括<strong>“常速英语”</strong>、<strong>“慢速英语”</strong>、<strong>“英语学习”</strong>以及它们的子项。用户如果需要深入了解各种类别的区别可访问<span");
            str.Append("            style=\"color: blue\">“<span>http://www.51voa.com</span>”</span>。<br />");
            str.Append("        <span style=\"color: red\">（注：<strong>“下载文件的类别”</strong>一项中，选择的类别越多，<strong>“主界面”</strong>中获取文件最新列表的时间将相应的会越长，这也将取决于您的网络连接速度。）");
            str.Append("            <br />");
            str.Append("        </span>");
            str.Append("        <br />");
            str.Append("        <strong>“选择下载的文件类型”</strong>中用户可选则下载<strong>“MP3音频文件”</strong>、还是<strong>“HTML网页文件”</strong>、还是两种文件都下载。");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        点击<strong>“保存”</strong>按钮保存所做的配置，<strong>“取消”</strong>则不保存。配置保存后，需要在主界面中点击<strong>“刷新列表”</strong>按钮来根据新的配置获取文件列表。<br />");
            str.Append("        <span style=\"color: red\">（注：配置保存后会在<strong>“软件可执行exe文件”</strong>同目录下生成一个配置文件<strong>“VOA.inf”</strong>保存用户的配置信息，下次打开软件时则自动读取上次所配项，如果此文件不存在则恢复默认配置。）");
            str.Append("        </span>");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <a name=\"4\"><strong>四、关于“帮助”和“关于”界面 </strong></a>");
            str.Append("        <br />");
            str.Append("        <hr></hr>");
            str.Append("        <br />");
            str.Append("        点击<strong>“主界面”</strong>菜单中相应的菜单可以打开对应的界面。<strong>“帮助”</strong>界面可以看到此文档，<strong>“关于”</strong>界面则是软件的相关信息。");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <a name=\"5\"><strong>五、关于“VOA自动下载器” </strong></a>");
            str.Append("        <br />");
            str.Append("        <hr></hr>");
            str.Append("        <br />");
            str.Append("        <strong>“VOA自动下载器”</strong>是一个免费的软件，您可以在不违反国家法律的情况下自由的分发和使用该软件。");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        <a name=\"6\"><strong>六、软件运行的系统要求 </strong></a>");
            str.Append("        <br />");
            str.Append("        <hr></hr>");
            str.Append("        <br />");
            str.Append("        Windows 2000/XP/2003/Vista/7 ");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        Windows 2000/XP 需要安装微软的类库<strong>“Microsoft");
            str.Append("        .NET Framework 2.0 (x86)”</strong>。具体下载地址：<span style=\"color: blue\">“http://www.microsoft.com/downloads/details.aspx?FamilyID=0856EACB-4362-4B0D-8EDD-AAB15C5E04F5&amp;displaylang=zh-cn”");
            str.Append("        </span><span style=\"color: red\">");
            str.Append("        （注：微软的官网地址，可能会变动） ");
            str.Append("            <br />");
            str.Append("            <br />");
            str.Append("        </span>");
            str.Append("        <br />");
            str.Append("        <a name=\"7\"><strong>七、技术支持  </strong></a>");
            str.Append("        <br />");
            str.Append("        <hr></hr>");
            str.Append("        <br />");
            str.Append("        如需任何技术支持，或者有任何建议和意见可以发邮件给我 <span style=\"color: blue\">“</span><span style=\"color: blue\">lotte-yang@hotmail.com”</span>");
            str.Append("        ，或者访问我校内主页<span style=\"color: blue\">“http://www.renren.com/buxiaoyang”</span> 。 ");
            str.Append("        <br />");
            str.Append("        <br />");
            str.Append("        欢迎大家使用。如有软件或者工具需求也可联系我，在时间允许并且感兴趣的情况下我会帮你免费制作该工具。^_^");
            str.Append("        <br />");
            str.Append("	");
            str.Append("	</body>");
            str.Append("</html>");



            this.webBrowserHelp.ScriptErrorsSuppressed = true;
            this.webBrowserHelp.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserHelp.WebBrowserShortcutsEnabled = false;
            //this.webBrowserHelp.AllowNavigation = false;
            this.webBrowserHelp.AllowWebBrowserDrop = false;

            this.webBrowserHelp.DocumentText = str.ToString();
        }
    }
}