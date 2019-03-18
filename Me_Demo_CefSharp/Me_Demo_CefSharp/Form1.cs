using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using CefSharp;
using CefSharp.WinForms;

using Microsoft.CSharp;

namespace Me_Demo_CefSharp
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser webbrowser;
        public Form1()
        {
            var settings = new CefSettings();
            //设置浏览器语言，默认en-us
            settings.Locale = "zh-cn";
            //设置userAgent
            settings.UserAgent = "Mozilla/5.0(Windows NT 6.1; WOW64) AppleWebKit/537.36(KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            // settings.LegacyJavascriptBindingEnabled = true;
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            CefSharp.Cef.Initialize(settings);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://websocket.yuanmacloud.com/add.html";
            url = "http://www.yuanmacloud.com";

            webbrowser = new ChromiumWebBrowser(url)
            {
                Dock = DockStyle.Fill
            };


            //页面加载开始事件
            webbrowser.FrameLoadStart += Webbrowser_FrameLoadStart;
            //页面加载完成事件
            webbrowser.FrameLoadEnd += Webbrowser_FrameLoadEnd;
            //页面加载状态改变事件
            webbrowser.LoadingStateChanged += Webbrowser_LoadingStateChanged;
            //控制台消息管理
            webbrowser.ConsoleMessage += Webbrowser_ConsoleMessage;



            //绑定后台的属性和方法,类的方法名为小写字符开头
            webbrowser.RegisterJsObject("bod", new BoundObject());



            this.Invoke(new Action(() =>
            {
                this.panel1.Controls.Add(webbrowser);
            }));

        }

        private void Webbrowser_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                this.textBox2.AppendText(e.Message.ToString());
                this.textBox2.AppendText("\r\n");
            }));
        }

        private void Webbrowser_LoadingStateChanged(object sender, CefSharp.LoadingStateChangedEventArgs e)
        {

        }

        private void Webbrowser_FrameLoadStart(object sender, CefSharp.FrameLoadStartEventArgs e)
        {

        }

        private void Webbrowser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private async void button3_ClickAsync(object sender, EventArgs e)
        {
            string js_func = this.textBox1.Text;
            JavascriptResponse x = await webbrowser.EvaluateScriptAsync(js_func);
        }

        private async void button4_ClickAsync(object sender, EventArgs e)
        {
            var websources = await webbrowser.GetSourceAsync();
            this.textBox3.Text = websources;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap iBitmap = new Bitmap(100, 100);
            webbrowser.DrawToBitmap(iBitmap, this.panel1.ClientRectangle);



        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            //NSoup.NSoupClient.Parse()
        }
    }
}
