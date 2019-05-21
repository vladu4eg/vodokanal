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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnImportMB = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFIAS = new System.Windows.Forms.Button();
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
            this.btnUpdate.Location = new System.Drawing.Point(6, 59);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 44);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Обновление БД";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnUpdAdressOnly
            // 
            this.btnUpdAdressOnly.Enabled = false;
            this.btnUpdAdressOnly.Location = new System.Drawing.Point(6, 109);
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
            this.btnUpdatePD.Location = new System.Drawing.Point(6, 179);
            this.btnUpdatePD.Name = "btnUpdatePD";
            this.btnUpdatePD.Size = new System.Drawing.Size(101, 47);
            this.btnUpdatePD.TabIndex = 30;
            this.btnUpdatePD.Text = "Обновление ПД";
            this.btnUpdatePD.UseVisualStyleBackColor = true;
            this.btnUpdatePD.Click += new System.EventHandler(this.btnUpdatePD_Click);
            // 
            // btnImportLS
            // 
            this.btnImportLS.Location = new System.Drawing.Point(9, 108);
            this.btnImportLS.Name = "btnImportLS";
            this.btnImportLS.Size = new System.Drawing.Size(100, 30);
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
            this.btnImportAdress.Location = new System.Drawing.Point(9, 72);
            this.btnImportAdress.Name = "btnImportAdress";
            this.btnImportAdress.Size = new System.Drawing.Size(100, 30);
            this.btnImportAdress.TabIndex = 37;
            this.btnImportAdress.Text = "Жилфонд";
            this.btnImportAdress.UseVisualStyleBackColor = true;
            this.btnImportAdress.Click += new System.EventHandler(this.btnImportAdress_Click);
            // 
            // btnImportDogovor
            // 
            this.btnImportDogovor.Location = new System.Drawing.Point(9, 36);
            this.btnImportDogovor.Name = "btnImportDogovor";
            this.btnImportDogovor.Size = new System.Drawing.Size(100, 30);
            this.btnImportDogovor.TabIndex = 38;
            this.btnImportDogovor.Text = "Договора";
            this.btnImportDogovor.UseVisualStyleBackColor = true;
            this.btnImportDogovor.Click += new System.EventHandler(this.btnImportDogovor_Click);
            // 
            // btnImportPY
            // 
            this.btnImportPY.Location = new System.Drawing.Point(9, 144);
            this.btnImportPY.Name = "btnImportPY";
            this.btnImportPY.Size = new System.Drawing.Size(100, 30);
            this.btnImportPY.TabIndex = 39;
            this.btnImportPY.Text = "ПУ";
            this.btnImportPY.UseVisualStyleBackColor = true;
            this.btnImportPY.Click += new System.EventHandler(this.btnImportPY_Click);
            // 
            // groupBoxCreateShablon
            // 
            this.groupBoxCreateShablon.Controls.Add(this.chdListBoxCreate);
            this.groupBoxCreateShablon.Controls.Add(this.btnStart);
            this.groupBoxCreateShablon.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCreateShablon.Name = "groupBoxCreateShablon";
            this.groupBoxCreateShablon.Size = new System.Drawing.Size(230, 279);
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
            "Оплаты"});
            this.chdListBoxCreate.Location = new System.Drawing.Point(6, 21);
            this.chdListBoxCreate.Name = "chdListBoxCreate";
            this.chdListBoxCreate.Size = new System.Drawing.Size(218, 208);
            this.chdListBoxCreate.TabIndex = 44;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 232);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(218, 31);
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
            this.groupBoxImportWithBD.Location = new System.Drawing.Point(490, 13);
            this.groupBoxImportWithBD.Name = "groupBoxImportWithBD";
            this.groupBoxImportWithBD.Size = new System.Drawing.Size(114, 278);
            this.groupBoxImportWithBD.TabIndex = 41;
            this.groupBoxImportWithBD.TabStop = false;
            this.groupBoxImportWithBD.Text = "Обновление MySQL из Oracle ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 34);
            this.label1.TabIndex = 31;
            this.label1.Text = "Временно \r\nнеактуально";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImportLS);
            this.groupBox1.Controls.Add(this.btnImportAdress);
            this.groupBox1.Controls.Add(this.btnImportPY);
            this.groupBox1.Controls.Add(this.btnImportDogovor);
            this.groupBox1.Location = new System.Drawing.Point(248, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 185);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Импорт из ГИС ЖКХ";
            // 
            // btnImportMB
            // 
            this.btnImportMB.Location = new System.Drawing.Point(6, 36);
            this.btnImportMB.Name = "btnImportMB";
            this.btnImportMB.Size = new System.Drawing.Size(100, 30);
            this.btnImportMB.TabIndex = 44;
            this.btnImportMB.Text = "Старт";
            this.btnImportMB.UseVisualStyleBackColor = true;
            this.btnImportMB.Click += new System.EventHandler(this.btnImportMB_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnImportMB);
            this.groupBox2.Location = new System.Drawing.Point(369, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(115, 85);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Авто импорт МегаБиллинг";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFIAS);
            this.groupBox3.Location = new System.Drawing.Point(369, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(115, 94);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Создание кодов ФИАС";
            // 
            // btnFIAS
            // 
            this.btnFIAS.Location = new System.Drawing.Point(6, 53);
            this.btnFIAS.Name = "btnFIAS";
            this.btnFIAS.Size = new System.Drawing.Size(100, 30);
            this.btnFIAS.TabIndex = 44;
            this.btnFIAS.Text = "Старт";
            this.btnFIAS.UseVisualStyleBackColor = true;
            this.btnFIAS.Click += new System.EventHandler(this.btnFIAS_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(611, 297);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxImportWithBD);
            this.Controls.Add(this.groupBoxCreateShablon);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
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
    }
}

