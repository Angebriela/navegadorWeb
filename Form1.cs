using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace navegadorWeb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
            webView.NavigationStarting += EnsureHttps;
            InitializeAsync();

        }

        private void Form_Resize(object sender, EventArgs e)
        {
            webView.Size = this.ClientSize - new System.Drawing.Size(webView.Location);
            buttonBuscar.Left = this.ClientSize.Width - buttonBuscar.Width;
            textBoxAdress.Width = buttonBuscar.Left - textBoxAdress.Left;
            labelbarraSuperior.Size = this.ClientSize = new System.Drawing.Size(labelbarraSuperior.Location);
            labelNavegador.Left= this.ClientSize.Width;
        }

        void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                webView.CoreWebView2.ExecuteScriptAsync($"alert('{uri} is not safe, try an https link')");
                args.Cancel = true;
            }
        }

        async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.WebMessageReceived += UpdateAddressBar;
            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");
            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => alert(event.data));");

        }

        void UpdateAddressBar(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            String uri = args.TryGetWebMessageAsString();
            textBoxAdress.Text = uri;
            webView.CoreWebView2.PostWebMessageAsString(uri);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            string adress = textBoxAdress.Text;

            if (!adress.StartsWith("https:/"))
            {
                textBoxAdress.Text = "https://" + adress;
            }
            
            if (!adress.EndsWith(".com"))
            {
                textBoxAdress.Text = "https://www.google.com/search?q=" + adress;

            }

            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate(textBoxAdress.Text);
            }

            

            

        }

        private void textBoxAdress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
