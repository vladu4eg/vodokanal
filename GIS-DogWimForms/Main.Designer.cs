namespace GIS_DogWimForms
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProjectDogovor = new System.Windows.Forms.Button();
            this.btnNewDogovor = new System.Windows.Forms.Button();
            this.btnNewLS = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnPY = new System.Windows.Forms.Button();
            this.btnPokaz = new System.Windows.Forms.Button();
            this.btnKvit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnUpdAdressOnly = new System.Windows.Forms.Button();
            this.btnUpdatePD = new System.Windows.Forms.Button();
            this.chkBoxOnlyMKD = new System.Windows.Forms.CheckBox();
            this.btnClearGis = new System.Windows.Forms.Button();
            this.btnImportLS = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnImportAdress = new System.Windows.Forms.Button();
            this.btnImportDogovor = new System.Windows.Forms.Button();
            this.btnImportPY = new System.Windows.Forms.Button();
            this.groupBoxCreateShablon = new System.Windows.Forms.GroupBox();
            this.btnODPY = new System.Windows.Forms.Button();
            this.groupBoxImportWithBD = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxImportCSV = new System.Windows.Forms.GroupBox();
            this.buttonImportPD = new System.Windows.Forms.Button();
            this.buttonImportLS = new System.Windows.Forms.Button();
            this.buttonImportWith = new System.Windows.Forms.Button();
            this.buttonImportPY = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxCreateShablon.SuspendLayout();
            this.groupBoxImportWithBD.SuspendLayout();
            this.groupBoxImportCSV.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProjectDogovor
            // 
            this.btnProjectDogovor.Location = new System.Drawing.Point(6, 21);
            this.btnProjectDogovor.Name = "btnProjectDogovor";
            this.btnProjectDogovor.Size = new System.Drawing.Size(95, 47);
            this.btnProjectDogovor.TabIndex = 19;
            this.btnProjectDogovor.Text = "Проекты договоров";
            this.btnProjectDogovor.UseVisualStyleBackColor = true;
            this.btnProjectDogovor.Click += new System.EventHandler(this.btnProjectDogovor_Click);
            // 
            // btnNewDogovor
            // 
            this.btnNewDogovor.Location = new System.Drawing.Point(107, 21);
            this.btnNewDogovor.Name = "btnNewDogovor";
            this.btnNewDogovor.Size = new System.Drawing.Size(95, 47);
            this.btnNewDogovor.TabIndex = 20;
            this.btnNewDogovor.Text = "Новый договор";
            this.btnNewDogovor.UseVisualStyleBackColor = true;
            this.btnNewDogovor.Click += new System.EventHandler(this.btnNewDogovor_Click);
            // 
            // btnNewLS
            // 
            this.btnNewLS.Location = new System.Drawing.Point(6, 144);
            this.btnNewLS.Name = "btnNewLS";
            this.btnNewLS.Size = new System.Drawing.Size(95, 47);
            this.btnNewLS.TabIndex = 24;
            this.btnNewLS.Text = "Добавить ЛС";
            this.btnNewLS.Click += new System.EventHandler(this.btnNewLS_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(6, 74);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(95, 64);
            this.btnHome.TabIndex = 22;
            this.btnHome.Text = "Обьекты жил фонда МКД жил";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnPY
            // 
            this.btnPY.Location = new System.Drawing.Point(6, 197);
            this.btnPY.Name = "btnPY";
            this.btnPY.Size = new System.Drawing.Size(95, 47);
            this.btnPY.TabIndex = 23;
            this.btnPY.Text = "ИПУ";
            this.btnPY.UseVisualStyleBackColor = true;
            this.btnPY.Click += new System.EventHandler(this.btnIPY_Click);
            // 
            // btnPokaz
            // 
            this.btnPokaz.Location = new System.Drawing.Point(6, 250);
            this.btnPokaz.Name = "btnPokaz";
            this.btnPokaz.Size = new System.Drawing.Size(95, 47);
            this.btnPokaz.TabIndex = 25;
            this.btnPokaz.Text = "Показания";
            this.btnPokaz.UseVisualStyleBackColor = true;
            this.btnPokaz.Click += new System.EventHandler(this.btnPokaz_Click);
            // 
            // btnKvit
            // 
            this.btnKvit.Location = new System.Drawing.Point(6, 303);
            this.btnKvit.Name = "btnKvit";
            this.btnKvit.Size = new System.Drawing.Size(95, 47);
            this.btnKvit.TabIndex = 26;
            this.btnKvit.Text = "Квитанции";
            this.btnKvit.UseVisualStyleBackColor = true;
            this.btnKvit.Click += new System.EventHandler(this.btnKvit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(7, 71);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 47);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Обновление БД";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnUpdAdressOnly
            // 
            this.btnUpdAdressOnly.Enabled = false;
            this.btnUpdAdressOnly.Location = new System.Drawing.Point(7, 124);
            this.btnUpdAdressOnly.Name = "btnUpdAdressOnly";
            this.btnUpdAdressOnly.Size = new System.Drawing.Size(101, 64);
            this.btnUpdAdressOnly.TabIndex = 29;
            this.btnUpdAdressOnly.Text = "Обновление только адресов";
            this.btnUpdAdressOnly.UseVisualStyleBackColor = true;
            this.btnUpdAdressOnly.Click += new System.EventHandler(this.btnUpdAdressOnly_Click);
            // 
            // btnUpdatePD
            // 
            this.btnUpdatePD.Enabled = false;
            this.btnUpdatePD.Location = new System.Drawing.Point(7, 194);
            this.btnUpdatePD.Name = "btnUpdatePD";
            this.btnUpdatePD.Size = new System.Drawing.Size(101, 64);
            this.btnUpdatePD.TabIndex = 30;
            this.btnUpdatePD.Text = "Обновление ПД";
            this.btnUpdatePD.UseVisualStyleBackColor = true;
            this.btnUpdatePD.Click += new System.EventHandler(this.btnUpdatePD_Click);
            // 
            // chkBoxOnlyMKD
            // 
            this.chkBoxOnlyMKD.AutoSize = true;
            this.chkBoxOnlyMKD.Location = new System.Drawing.Point(107, 144);
            this.chkBoxOnlyMKD.Name = "chkBoxOnlyMKD";
            this.chkBoxOnlyMKD.Size = new System.Drawing.Size(112, 21);
            this.chkBoxOnlyMKD.TabIndex = 31;
            this.chkBoxOnlyMKD.Text = "Только МКД";
            this.chkBoxOnlyMKD.UseVisualStyleBackColor = true;
            this.chkBoxOnlyMKD.CheckedChanged += new System.EventHandler(this.ChkBoxOnlyMKD_CheckedChanged);
            // 
            // btnClearGis
            // 
            this.btnClearGis.Location = new System.Drawing.Point(6, 69);
            this.btnClearGis.Name = "btnClearGis";
            this.btnClearGis.Size = new System.Drawing.Size(101, 47);
            this.btnClearGis.TabIndex = 35;
            this.btnClearGis.Text = "Очистка БД";
            this.btnClearGis.UseVisualStyleBackColor = true;
            this.btnClearGis.Click += new System.EventHandler(this.btnClearGis_Click);
            // 
            // btnImportLS
            // 
            this.btnImportLS.Location = new System.Drawing.Point(6, 230);
            this.btnImportLS.Name = "btnImportLS";
            this.btnImportLS.Size = new System.Drawing.Size(101, 47);
            this.btnImportLS.TabIndex = 36;
            this.btnImportLS.Text = "Import LS";
            this.btnImportLS.UseVisualStyleBackColor = true;
            this.btnImportLS.Click += new System.EventHandler(this.btnImportLS_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnImportAdress
            // 
            this.btnImportAdress.Location = new System.Drawing.Point(6, 177);
            this.btnImportAdress.Name = "btnImportAdress";
            this.btnImportAdress.Size = new System.Drawing.Size(101, 47);
            this.btnImportAdress.TabIndex = 37;
            this.btnImportAdress.Text = "Import Adress";
            this.btnImportAdress.UseVisualStyleBackColor = true;
            this.btnImportAdress.Click += new System.EventHandler(this.btnImportAdress_Click);
            // 
            // btnImportDogovor
            // 
            this.btnImportDogovor.Location = new System.Drawing.Point(6, 124);
            this.btnImportDogovor.Name = "btnImportDogovor";
            this.btnImportDogovor.Size = new System.Drawing.Size(101, 47);
            this.btnImportDogovor.TabIndex = 38;
            this.btnImportDogovor.Text = "Import Dogovor";
            this.btnImportDogovor.UseVisualStyleBackColor = true;
            this.btnImportDogovor.Click += new System.EventHandler(this.btnImportDogovor_Click);
            // 
            // btnImportPY
            // 
            this.btnImportPY.Location = new System.Drawing.Point(6, 283);
            this.btnImportPY.Name = "btnImportPY";
            this.btnImportPY.Size = new System.Drawing.Size(101, 47);
            this.btnImportPY.TabIndex = 39;
            this.btnImportPY.Text = "Import PY";
            this.btnImportPY.UseVisualStyleBackColor = true;
            this.btnImportPY.Click += new System.EventHandler(this.btnImportPY_Click);
            // 
            // groupBoxCreateShablon
            // 
            this.groupBoxCreateShablon.Controls.Add(this.button1);
            this.groupBoxCreateShablon.Controls.Add(this.btnODPY);
            this.groupBoxCreateShablon.Controls.Add(this.btnProjectDogovor);
            this.groupBoxCreateShablon.Controls.Add(this.btnNewDogovor);
            this.groupBoxCreateShablon.Controls.Add(this.btnNewLS);
            this.groupBoxCreateShablon.Controls.Add(this.btnHome);
            this.groupBoxCreateShablon.Controls.Add(this.btnPY);
            this.groupBoxCreateShablon.Controls.Add(this.btnPokaz);
            this.groupBoxCreateShablon.Controls.Add(this.btnKvit);
            this.groupBoxCreateShablon.Controls.Add(this.chkBoxOnlyMKD);
            this.groupBoxCreateShablon.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCreateShablon.Name = "groupBoxCreateShablon";
            this.groupBoxCreateShablon.Size = new System.Drawing.Size(306, 352);
            this.groupBoxCreateShablon.TabIndex = 40;
            this.groupBoxCreateShablon.TabStop = false;
            this.groupBoxCreateShablon.Text = "Формирования шаблонов";
            // 
            // btnODPY
            // 
            this.btnODPY.Location = new System.Drawing.Point(107, 197);
            this.btnODPY.Name = "btnODPY";
            this.btnODPY.Size = new System.Drawing.Size(95, 47);
            this.btnODPY.TabIndex = 32;
            this.btnODPY.Text = "ОДПУ";
            this.btnODPY.UseVisualStyleBackColor = true;
            this.btnODPY.Click += new System.EventHandler(this.btnODPY_Click);
            // 
            // groupBoxImportWithBD
            // 
            this.groupBoxImportWithBD.Controls.Add(this.label1);
            this.groupBoxImportWithBD.Controls.Add(this.btnUpdate);
            this.groupBoxImportWithBD.Controls.Add(this.btnUpdAdressOnly);
            this.groupBoxImportWithBD.Controls.Add(this.btnUpdatePD);
            this.groupBoxImportWithBD.Location = new System.Drawing.Point(583, 15);
            this.groupBoxImportWithBD.Name = "groupBoxImportWithBD";
            this.groupBoxImportWithBD.Size = new System.Drawing.Size(114, 349);
            this.groupBoxImportWithBD.TabIndex = 41;
            this.groupBoxImportWithBD.TabStop = false;
            this.groupBoxImportWithBD.Text = "Обновление MySQL из Oracle ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 34);
            this.label1.TabIndex = 31;
            this.label1.Text = "Временно \r\nнеактуально";
            // 
            // groupBoxImportCSV
            // 
            this.groupBoxImportCSV.Controls.Add(this.buttonImportPD);
            this.groupBoxImportCSV.Controls.Add(this.buttonImportLS);
            this.groupBoxImportCSV.Controls.Add(this.buttonImportWith);
            this.groupBoxImportCSV.Controls.Add(this.buttonImportPY);
            this.groupBoxImportCSV.Location = new System.Drawing.Point(341, 15);
            this.groupBoxImportCSV.Name = "groupBoxImportCSV";
            this.groupBoxImportCSV.Size = new System.Drawing.Size(115, 349);
            this.groupBoxImportCSV.TabIndex = 42;
            this.groupBoxImportCSV.TabStop = false;
            this.groupBoxImportCSV.Text = "Импорт выгрузки из БД";
            // 
            // buttonImportPD
            // 
            this.buttonImportPD.Location = new System.Drawing.Point(6, 230);
            this.buttonImportPD.Name = "buttonImportPD";
            this.buttonImportPD.Size = new System.Drawing.Size(101, 47);
            this.buttonImportPD.TabIndex = 34;
            this.buttonImportPD.Text = "PD";
            this.buttonImportPD.UseVisualStyleBackColor = true;
            this.buttonImportPD.Click += new System.EventHandler(this.buttonImportPD_Click);
            // 
            // buttonImportLS
            // 
            this.buttonImportLS.Location = new System.Drawing.Point(6, 71);
            this.buttonImportLS.Name = "buttonImportLS";
            this.buttonImportLS.Size = new System.Drawing.Size(101, 47);
            this.buttonImportLS.TabIndex = 31;
            this.buttonImportLS.Text = "import_lischt";
            this.buttonImportLS.UseVisualStyleBackColor = true;
            this.buttonImportLS.Click += new System.EventHandler(this.buttonImportLS_Click);
            // 
            // buttonImportWith
            // 
            this.buttonImportWith.Location = new System.Drawing.Point(6, 124);
            this.buttonImportWith.Name = "buttonImportWith";
            this.buttonImportWith.Size = new System.Drawing.Size(101, 47);
            this.buttonImportWith.TabIndex = 32;
            this.buttonImportWith.Text = "import_with";
            this.buttonImportWith.UseVisualStyleBackColor = true;
            this.buttonImportWith.Click += new System.EventHandler(this.buttonImportWith_Click);
            // 
            // buttonImportPY
            // 
            this.buttonImportPY.Location = new System.Drawing.Point(6, 177);
            this.buttonImportPY.Name = "buttonImportPY";
            this.buttonImportPY.Size = new System.Drawing.Size(101, 47);
            this.buttonImportPY.TabIndex = 33;
            this.buttonImportPY.Text = "PY";
            this.buttonImportPY.UseVisualStyleBackColor = true;
            this.buttonImportPY.Click += new System.EventHandler(this.buttonImportPY_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearGis);
            this.groupBox1.Controls.Add(this.btnImportLS);
            this.groupBox1.Controls.Add(this.btnImportAdress);
            this.groupBox1.Controls.Add(this.btnImportPY);
            this.groupBox1.Controls.Add(this.btnImportDogovor);
            this.groupBox1.Location = new System.Drawing.Point(462, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 349);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Импорт из ГИС ЖКХ";
            // 
            // btnDelIPY
            // 
            this.button1.Location = new System.Drawing.Point(211, 197);
            this.button1.Name = "btnDelIPY";
            this.button1.Size = new System.Drawing.Size(95, 47);
            this.button1.TabIndex = 33;
            this.button1.Text = "Удаление ИПУ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnDelIPY_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(827, 372);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxImportCSV);
            this.Controls.Add(this.groupBoxImportWithBD);
            this.Controls.Add(this.groupBoxCreateShablon);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxCreateShablon.ResumeLayout(false);
            this.groupBoxCreateShablon.PerformLayout();
            this.groupBoxImportWithBD.ResumeLayout(false);
            this.groupBoxImportWithBD.PerformLayout();
            this.groupBoxImportCSV.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnProjectDogovor;
        private System.Windows.Forms.Button btnNewDogovor;
        private System.Windows.Forms.Button btnNewLS;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnPY;
        private System.Windows.Forms.Button btnPokaz;
        private System.Windows.Forms.Button btnKvit;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnUpdAdressOnly;
        private System.Windows.Forms.Button btnUpdatePD;
        private System.Windows.Forms.CheckBox chkBoxOnlyMKD;
        private System.Windows.Forms.Button btnClearGis;
        private System.Windows.Forms.Button btnImportLS;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnImportAdress;
        private System.Windows.Forms.Button btnImportDogovor;
        private System.Windows.Forms.Button btnImportPY;
        private System.Windows.Forms.GroupBox groupBoxCreateShablon;
        private System.Windows.Forms.GroupBox groupBoxImportWithBD;
        private System.Windows.Forms.GroupBox groupBoxImportCSV;
        private System.Windows.Forms.Button buttonImportPD;
        private System.Windows.Forms.Button buttonImportLS;
        private System.Windows.Forms.Button buttonImportWith;
        private System.Windows.Forms.Button buttonImportPY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnODPY;
        private System.Windows.Forms.Button button1;
    }
}

