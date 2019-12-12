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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnUpdAdressOnly = new System.Windows.Forms.Button();
            this.btnUpdatePD = new System.Windows.Forms.Button();
            this.btnImportLS = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnImportAdress = new System.Windows.Forms.Button();
            this.btnImportDogovor = new System.Windows.Forms.Button();
            this.btnImportPY = new System.Windows.Forms.Button();
            this.groupBoxCreateShablon = new System.Windows.Forms.GroupBox();
            this.chdListBoxCreate = new System.Windows.Forms.CheckedListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBoxImportWithBD = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImportPD = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnImportMB = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFIAS = new System.Windows.Forms.Button();
            this.btnLSCancel = new System.Windows.Forms.Button();
            this.groupBoxCreateShablon.SuspendLayout();
            this.groupBoxImportWithBD.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(4, 48);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(97, 36);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Обновление БД";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnUpdAdressOnly
            // 
            this.btnUpdAdressOnly.Enabled = false;
            this.btnUpdAdressOnly.Location = new System.Drawing.Point(4, 89);
            this.btnUpdAdressOnly.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdAdressOnly.Name = "btnUpdAdressOnly";
            this.btnUpdAdressOnly.Size = new System.Drawing.Size(97, 52);
            this.btnUpdAdressOnly.TabIndex = 29;
            this.btnUpdAdressOnly.Text = "Обновление только адресов";
            this.btnUpdAdressOnly.UseVisualStyleBackColor = true;
            this.btnUpdAdressOnly.Click += new System.EventHandler(this.btnUpdAdressOnly_Click);
            // 
            // btnUpdatePD
            // 
            this.btnUpdatePD.Enabled = false;
            this.btnUpdatePD.Location = new System.Drawing.Point(4, 145);
            this.btnUpdatePD.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdatePD.Name = "btnUpdatePD";
            this.btnUpdatePD.Size = new System.Drawing.Size(97, 38);
            this.btnUpdatePD.TabIndex = 30;
            this.btnUpdatePD.Text = "Обновление ПД";
            this.btnUpdatePD.UseVisualStyleBackColor = true;
            this.btnUpdatePD.Click += new System.EventHandler(this.btnUpdatePD_Click);
            // 
            // btnImportLS
            // 
            this.btnImportLS.Location = new System.Drawing.Point(7, 88);
            this.btnImportLS.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportLS.Name = "btnImportLS";
            this.btnImportLS.Size = new System.Drawing.Size(75, 24);
            this.btnImportLS.TabIndex = 36;
            this.btnImportLS.Text = "ЛС";
            this.btnImportLS.UseVisualStyleBackColor = true;
            this.btnImportLS.Click += new System.EventHandler(this.btnImportLS_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnImportAdress
            // 
            this.btnImportAdress.Location = new System.Drawing.Point(7, 58);
            this.btnImportAdress.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportAdress.Name = "btnImportAdress";
            this.btnImportAdress.Size = new System.Drawing.Size(75, 24);
            this.btnImportAdress.TabIndex = 37;
            this.btnImportAdress.Text = "Жилфонд";
            this.btnImportAdress.UseVisualStyleBackColor = true;
            this.btnImportAdress.Click += new System.EventHandler(this.btnImportAdress_Click);
            // 
            // btnImportDogovor
            // 
            this.btnImportDogovor.Location = new System.Drawing.Point(7, 29);
            this.btnImportDogovor.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportDogovor.Name = "btnImportDogovor";
            this.btnImportDogovor.Size = new System.Drawing.Size(75, 24);
            this.btnImportDogovor.TabIndex = 38;
            this.btnImportDogovor.Text = "Договора";
            this.btnImportDogovor.UseVisualStyleBackColor = true;
            this.btnImportDogovor.Click += new System.EventHandler(this.btnImportDogovor_Click);
            // 
            // btnImportPY
            // 
            this.btnImportPY.Location = new System.Drawing.Point(7, 117);
            this.btnImportPY.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportPY.Name = "btnImportPY";
            this.btnImportPY.Size = new System.Drawing.Size(75, 24);
            this.btnImportPY.TabIndex = 39;
            this.btnImportPY.Text = "ПУ";
            this.btnImportPY.UseVisualStyleBackColor = true;
            this.btnImportPY.Click += new System.EventHandler(this.btnImportPY_Click);
            // 
            // groupBoxCreateShablon
            // 
            this.groupBoxCreateShablon.Controls.Add(this.chdListBoxCreate);
            this.groupBoxCreateShablon.Controls.Add(this.btnStart);
            this.groupBoxCreateShablon.Location = new System.Drawing.Point(9, 10);
            this.groupBoxCreateShablon.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxCreateShablon.Name = "groupBoxCreateShablon";
            this.groupBoxCreateShablon.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxCreateShablon.Size = new System.Drawing.Size(172, 227);
            this.groupBoxCreateShablon.TabIndex = 40;
            this.groupBoxCreateShablon.TabStop = false;
            this.groupBoxCreateShablon.Text = "Формирования шаблонов";
            // 
            // chdListBoxCreate
            // 
            this.chdListBoxCreate.FormattingEnabled = true;
            this.chdListBoxCreate.Items.AddRange(new object[] {
            "Проекты договоров",
            "Новый договор",
            "Обьекты жил фонда МКД",
            "Добавить ЛС",
            "ИПУ",
            "Удаление ИПУ",
            "Показания ИПУ",
            "ОДПУ",
            "Квитанции",
            "Оплаты",
            "Аннулированные ЛС"});
            this.chdListBoxCreate.Location = new System.Drawing.Point(4, 17);
            this.chdListBoxCreate.Margin = new System.Windows.Forms.Padding(2);
            this.chdListBoxCreate.Name = "chdListBoxCreate";
            this.chdListBoxCreate.Size = new System.Drawing.Size(164, 169);
            this.chdListBoxCreate.TabIndex = 44;
            this.chdListBoxCreate.SelectedIndexChanged += new System.EventHandler(this.chdListBoxCreate_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(4, 188);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(164, 25);
            this.btnStart.TabIndex = 45;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBoxImportWithBD
            // 
            this.groupBoxImportWithBD.Controls.Add(this.label1);
            this.groupBoxImportWithBD.Controls.Add(this.btnUpdate);
            this.groupBoxImportWithBD.Controls.Add(this.btnUpdAdressOnly);
            this.groupBoxImportWithBD.Controls.Add(this.btnUpdatePD);
            this.groupBoxImportWithBD.Location = new System.Drawing.Point(368, 11);
            this.groupBoxImportWithBD.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxImportWithBD.Name = "groupBoxImportWithBD";
            this.groupBoxImportWithBD.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxImportWithBD.Size = new System.Drawing.Size(105, 226);
            this.groupBoxImportWithBD.TabIndex = 41;
            this.groupBoxImportWithBD.TabStop = false;
            this.groupBoxImportWithBD.Text = "Обновление MySQL из Oracle ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 190);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 26);
            this.label1.TabIndex = 31;
            this.label1.Text = "Временно \r\nнеактуально";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLSCancel);
            this.groupBox1.Controls.Add(this.btnImportPD);
            this.groupBox1.Controls.Add(this.btnImportLS);
            this.groupBox1.Controls.Add(this.btnImportAdress);
            this.groupBox1.Controls.Add(this.btnImportPY);
            this.groupBox1.Controls.Add(this.btnImportDogovor);
            this.groupBox1.Location = new System.Drawing.Point(186, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(86, 212);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Импорт из ГИС ЖКХ";
            // 
            // btnImportPD
            // 
            this.btnImportPD.Location = new System.Drawing.Point(7, 145);
            this.btnImportPD.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportPD.Name = "btnImportPD";
            this.btnImportPD.Size = new System.Drawing.Size(75, 24);
            this.btnImportPD.TabIndex = 40;
            this.btnImportPD.Text = "ПД";
            this.btnImportPD.UseVisualStyleBackColor = true;
            this.btnImportPD.Click += new System.EventHandler(this.btnImportPD_Click);
            // 
            // btnImportMB
            // 
            this.btnImportMB.Location = new System.Drawing.Point(4, 29);
            this.btnImportMB.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportMB.Name = "btnImportMB";
            this.btnImportMB.Size = new System.Drawing.Size(75, 24);
            this.btnImportMB.TabIndex = 44;
            this.btnImportMB.Text = "Старт";
            this.btnImportMB.UseVisualStyleBackColor = true;
            this.btnImportMB.Click += new System.EventHandler(this.btnImportMB_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnImportMB);
            this.groupBox2.Location = new System.Drawing.Point(277, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(86, 69);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Авто импорт МегаБиллинг";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFIAS);
            this.groupBox3.Location = new System.Drawing.Point(277, 84);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(86, 76);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Создание кодов ФИАС";
            // 
            // btnFIAS
            // 
            this.btnFIAS.Location = new System.Drawing.Point(4, 43);
            this.btnFIAS.Margin = new System.Windows.Forms.Padding(2);
            this.btnFIAS.Name = "btnFIAS";
            this.btnFIAS.Size = new System.Drawing.Size(75, 24);
            this.btnFIAS.TabIndex = 44;
            this.btnFIAS.Text = "Старт";
            this.btnFIAS.UseVisualStyleBackColor = true;
            this.btnFIAS.Click += new System.EventHandler(this.btnFIAS_Click);
            // 
            // btnLSCancel
            // 
            this.btnLSCancel.Location = new System.Drawing.Point(7, 173);
            this.btnLSCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnLSCancel.Name = "btnLSCancel";
            this.btnLSCancel.Size = new System.Drawing.Size(75, 24);
            this.btnLSCancel.TabIndex = 41;
            this.btnLSCancel.Text = "ЛС аннул.";
            this.btnLSCancel.UseVisualStyleBackColor = true;
            this.btnLSCancel.Click += new System.EventHandler(this.btnLSCancel_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(484, 241);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxImportWithBD);
            this.Controls.Add(this.groupBoxCreateShablon);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main menu";
            this.groupBoxCreateShablon.ResumeLayout(false);
            this.groupBoxImportWithBD.ResumeLayout(false);
            this.groupBoxImportWithBD.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnUpdAdressOnly;
        private System.Windows.Forms.Button btnUpdatePD;
        private System.Windows.Forms.Button btnImportLS;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnImportAdress;
        private System.Windows.Forms.Button btnImportDogovor;
        private System.Windows.Forms.Button btnImportPY;
        private System.Windows.Forms.GroupBox groupBoxCreateShablon;
        private System.Windows.Forms.GroupBox groupBoxImportWithBD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chdListBoxCreate;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnImportMB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFIAS;
        private System.Windows.Forms.Button btnImportPD;
        private System.Windows.Forms.Button btnLSCancel;
    }
}

