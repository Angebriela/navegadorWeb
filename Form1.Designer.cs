namespace navegadorWeb
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelNavegador = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelbarraSuperior = new System.Windows.Forms.Label();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.comboBoxAdress = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNavegador
            // 
            this.labelNavegador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNavegador.AutoSize = true;
            this.labelNavegador.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelNavegador.Location = new System.Drawing.Point(12, 41);
            this.labelNavegador.Name = "labelNavegador";
            this.labelNavegador.Size = new System.Drawing.Size(207, 38);
            this.labelNavegador.TabIndex = 0;
            this.labelNavegador.Text = "NAVEGADOR";
            this.labelNavegador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelNavegador.UseMnemonic = false;
            // 
            // label1
            // 
            this.label1.AccessibleName = "";
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(219, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 69);
            this.label1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AccessibleName = "";
            this.label2.BackColor = System.Drawing.Color.SkyBlue;
            this.label2.Location = new System.Drawing.Point(0, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(898, 33);
            this.label2.TabIndex = 3;
            this.label2.Visible = false;
            // 
            // labelbarraSuperior
            // 
            this.labelbarraSuperior.AccessibleName = "";
            this.labelbarraSuperior.BackColor = System.Drawing.Color.SkyBlue;
            this.labelbarraSuperior.Location = new System.Drawing.Point(0, -5);
            this.labelbarraSuperior.Name = "labelbarraSuperior";
            this.labelbarraSuperior.Size = new System.Drawing.Size(898, 33);
            this.labelbarraSuperior.TabIndex = 4;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(669, 88);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(106, 23);
            this.buttonBuscar.TabIndex = 5;
            this.buttonBuscar.Text = "Buscar 🔍";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(-7, 132);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(826, 302);
            this.webView.Source = new System.Uri("https://www.google.com/", System.UriKind.Absolute);
            this.webView.TabIndex = 6;
            this.webView.ZoomFactor = 1D;
            // 
            // comboBoxAdress
            // 
            this.comboBoxAdress.FormattingEnabled = true;
            this.comboBoxAdress.Location = new System.Drawing.Point(12, 90);
            this.comboBoxAdress.Name = "comboBoxAdress";
            this.comboBoxAdress.Size = new System.Drawing.Size(651, 21);
            this.comboBoxAdress.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 428);
            this.Controls.Add(this.comboBoxAdress);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.labelbarraSuperior);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNavegador);
            this.Controls.Add(this.webView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.Label labelNavegador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelbarraSuperior;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.ComboBox comboBoxAdress;
    }
}

