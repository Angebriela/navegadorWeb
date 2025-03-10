using Microsoft.Web.WebView2.Core;
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
        List <Url> urls = new List<Url>();
        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
            CenterLabel();
            webView.NavigationStarting += EnsureHttps;
            InitializeAsync();

        }


        private void Form_Resize(object sender, EventArgs e)
        {
            labelbarraSuperior.Width = this.ClientSize.Width + labelbarraSuperior.Width;
            CenterLabel();
            webView.Size = this.ClientSize - new System.Drawing.Size(webView.Location);
            buttonBuscar.Left = this.ClientSize.Width - buttonBuscar.Width;
            comboBoxAdress.Width=buttonBuscar.Left - comboBoxAdress.Left;
        }

        private void CenterLabel()
        {
            // Establecer la posición superior de la Label
            labelbarraSuperior.Top = 0;

            // Calcular la posición izquierda para centrar la Label
            labelbarraSuperior.Left = (this.ClientSize.Width - labelbarraSuperior.Width) / 2;
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
            //Instanciar la clase Url para poder acceder a sus atributos
            Url url = new Url();

            string adress1 = comboBoxAdress.Text;


            //Para agregar la direccion de enlace en la busqueda
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

            //Para el funcionamiento de la navegacion en el webview
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate(comboBoxAdress.Text);
            }


            //textBoxAdress.Text = ""; //para que aparezca vacio
            string ruta = @"../../historial.txt";

            FileStream stream = new FileStream(ruta, FileMode.Append, FileAccess.Write);
            
            StreamWriter writer = new StreamWriter(stream);

            //Instanciar la clase Url objetos
            url.DireccionUrl = comboBoxAdress.Text;
            url.FechaAcceso = DateTime.Now;
            url.ContadorVisitas = 1;



            //Write escribe todo en la misma linea. En este ejemplo se hará un dato por cada línea
            writer.WriteLine(comboBoxAdress.Text);
            urls.Add(url);
            //Cerrar el archivo
            writer.Close();


                if (File.Exists(ruta))
                {
                    // Leer todo el contenido del archivo
                    string[] lineas = File.ReadAllLines(ruta);

                    // Limpiar el ComboBox para evitar duplicados
                    comboBoxAdress.Items.Clear();

                   
                    for (int j = 0; j < 10 && j < lineas.Length; j++)
                    {
                        comboBoxAdress.Items.Add(lineas[j]);

                    }
                
            }



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

