namespace M2MSOAPSample
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProxyServer = new System.Windows.Forms.TextBox();
            this.chbUseProxy = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labCheckDostavka = new System.Windows.Forms.Label();
            this.labSend = new System.Windows.Forms.Label();
            this.labTime = new System.Windows.Forms.Label();
            this.labImport = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnGener = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCheckSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(109, 16);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(4);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(259, 22);
            this.txtLogin.TabIndex = 0;
            this.txtLogin.Text = "79788421425";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(109, 46);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(259, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "237195";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(153, 121);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(119, 49);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 119);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Сервер";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 151);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Порт";
            // 
            // txtProxyPort
            // 
            this.txtProxyPort.Location = new System.Drawing.Point(109, 146);
            this.txtProxyPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtProxyPort.Name = "txtProxyPort";
            this.txtProxyPort.Size = new System.Drawing.Size(77, 22);
            this.txtProxyPort.TabIndex = 18;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtLogin);
            this.groupBox3.Controls.Add(this.txtProxyPort);
            this.groupBox3.Controls.Add(this.txtPassword);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtProxyServer);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.chbUseProxy);
            this.groupBox3.Location = new System.Drawing.Point(16, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(448, 216);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Авторизация";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Баланс: ";
            // 
            // txtProxyServer
            // 
            this.txtProxyServer.Location = new System.Drawing.Point(109, 116);
            this.txtProxyServer.Margin = new System.Windows.Forms.Padding(4);
            this.txtProxyServer.Name = "txtProxyServer";
            this.txtProxyServer.Size = new System.Drawing.Size(259, 22);
            this.txtProxyServer.TabIndex = 16;
            // 
            // chbUseProxy
            // 
            this.chbUseProxy.AutoSize = true;
            this.chbUseProxy.Location = new System.Drawing.Point(7, 87);
            this.chbUseProxy.Margin = new System.Windows.Forms.Padding(4);
            this.chbUseProxy.Name = "chbUseProxy";
            this.chbUseProxy.Size = new System.Drawing.Size(78, 21);
            this.chbUseProxy.TabIndex = 14;
            this.chbUseProxy.Text = "Прокси";
            this.chbUseProxy.UseVisualStyleBackColor = true;
            this.chbUseProxy.CheckedChanged += new System.EventHandler(this.chbUseProxy_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.labCheckDostavka);
            this.groupBox1.Controls.Add(this.labSend);
            this.groupBox1.Controls.Add(this.btnCheckSend);
            this.groupBox1.Controls.Add(this.labTime);
            this.groupBox1.Controls.Add(this.labImport);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btnGener);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Location = new System.Drawing.Point(16, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 217);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Импорт";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // labCheckDostavka
            // 
            this.labCheckDostavka.AutoSize = true;
            this.labCheckDostavka.Location = new System.Drawing.Point(306, 18);
            this.labCheckDostavka.Name = "labCheckDostavka";
            this.labCheckDostavka.Size = new System.Drawing.Size(92, 17);
            this.labCheckDostavka.TabIndex = 21;
            this.labCheckDostavka.Text = "Доставлено:";
            this.labCheckDostavka.Click += new System.EventHandler(this.labCheckDostavka_Click);
            // 
            // labSend
            // 
            this.labSend.AutoSize = true;
            this.labSend.Location = new System.Drawing.Point(3, 190);
            this.labSend.Name = "labSend";
            this.labSend.Size = new System.Drawing.Size(93, 17);
            this.labSend.TabIndex = 18;
            this.labSend.Text = "Отправлено:";
            this.labSend.Click += new System.EventHandler(this.label9_Click);
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(3, 173);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(128, 17);
            this.labTime.TabIndex = 15;
            this.labTime.Text = "Время обработки:";
            this.labTime.Click += new System.EventHandler(this.label3_Click);
            // 
            // labImport
            // 
            this.labImport.AutoSize = true;
            this.labImport.Location = new System.Drawing.Point(150, 18);
            this.labImport.Name = "labImport";
            this.labImport.Size = new System.Drawing.Size(112, 17);
            this.labImport.TabIndex = 14;
            this.labImport.Text = "Cформировано:";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(7, 94);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(102, 21);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "Показания";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(7, 67);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(107, 21);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Госповерка";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(62, 21);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Долг";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnGener
            // 
            this.btnGener.Location = new System.Drawing.Point(6, 121);
            this.btnGener.Name = "btnGener";
            this.btnGener.Size = new System.Drawing.Size(119, 49);
            this.btnGener.TabIndex = 9;
            this.btnGener.Text = "Импорт файла";
            this.btnGener.UseVisualStyleBackColor = true;
            this.btnGener.Click += new System.EventHandler(this.btnGener_Click);
            // 
            // btnCheckSend
            // 
            this.btnCheckSend.Location = new System.Drawing.Point(299, 121);
            this.btnCheckSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckSend.Name = "btnCheckSend";
            this.btnCheckSend.Size = new System.Drawing.Size(119, 49);
            this.btnCheckSend.TabIndex = 2;
            this.btnCheckSend.Text = "Статус доставки";
            this.btnCheckSend.UseVisualStyleBackColor = true;
            this.btnCheckSend.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(453, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(446, 121);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 49);
            this.button1.TabIndex = 22;
            this.button1.Text = "Импорт оплат";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 472);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mainForm";
            this.Text = "Рассылка СМС";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProxyPort;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtProxyServer;
        private System.Windows.Forms.CheckBox chbUseProxy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Label labImport;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnGener;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labSend;
        private System.Windows.Forms.Label labCheckDostavka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCheckSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

