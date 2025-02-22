﻿using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            comboBoxAdress.Width=buttonBuscar.Left - comboBoxAdress.Left;
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
            webView.CoreWebView2.PostWebMessageAsString(uri);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            string adress1 = comboBoxAdress.Text;

            
            if (!adress1.StartsWith("https:/"))
            {
                comboBoxAdress.Text = "https://" + adress1;
            } else if (adress1.StartsWith("https://"))
            {
                comboBoxAdress.Text = adress1;
            }

            if (!adress1.EndsWith(".com"))
            {
                comboBoxAdress.Text = "https://www.google.com/search?q=" + adress1;

            }
            

            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate(comboBoxAdress.Text);
            }


            //textBoxAdress.Text = ""; //para que aparezca vacio
            string ruta = @"../../historial.txt";

            FileStream stream = new FileStream(ruta, FileMode.Append, FileAccess.Write);
            
            StreamWriter writer = new StreamWriter(stream);



            //Write escribe todo en la misma linea. En este ejemplo se hará un dato por cada línea
            writer.WriteLine(comboBoxAdress.Text);
            //Cerrar el archivo
            writer.Close();


                if (File.Exists(ruta))
                {
                    // Leer todo el contenido del archivo
                    string[] lineas = File.ReadAllLines(ruta);

                    // Limpiar el ComboBox para evitar duplicados
                    comboBoxAdress.Items.Clear();

                    // Agregar cada línea del archivo al ComboBox
                    /*foreach (var linea in lineas)
                    {
                        comboBoxAdress.Items.Add(linea);
                    }*/

                    foreach (var linea in lineas)
                    {
                        comboBoxAdress.Items.Add(linea);
                    }
                    for (int j = 0; j < 10 && j < lineas.Length; j++)
                    {
                        comboBoxAdress.Items.Add(lineas[j]);

                    }

                }

            

            


            //int largoHistorial = 10;

            





        }

        private void textBoxAdress_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Definir la ruta del archivo
            //string rutaArchivo = "C:\\ruta\\a\\tu\\archivo.txt";
            string ruta2 = @"../../historial.txt";



            // Comprobar si el archivo existe
            if (File.Exists(ruta2))
            {
                // Leer todo el contenido del archivo
                string[] lineas = File.ReadAllLines(ruta2);

                // Limpiar el ComboBox para evitar duplicados
                comboBoxAdress.Items.Clear();

                // Agregar cada línea del archivo al ComboBox
                for (int i = 0; i < 10 && i < lineas.Length; i++)
                {
                    comboBoxAdress.Items.Add(lineas[i]);

                }
            }
            else
            {
                MessageBox.Show("El archivo no existe.");
            }
            }
        }
    }

